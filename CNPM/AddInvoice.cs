using System;
using System.Data;
using System.Windows.Forms;
using CNPM.BL_Layer;
namespace CNPM
{
    public partial class AddInvoice : Form
    {
        int orderId = -1, total;
        public bool changed;

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
                txtTotal.Text = total + " đồng";
            }
        }

        public AddInvoice()
        {
            InitializeComponent();
        }
        public AddInvoice(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
        }
        private void AddInvoice_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            BLInvoice db = new BLInvoice();
            txtDate.Text = DateTime.Now.ToString();
            cboOrderId.DataSource = null;
            cboOrderId.DataSource = db.NotPaidEnoughOrders();
            cboOrderId.DisplayMember = "MaDH";
            if (orderId != -1)
            {
                cboOrderId.SelectedIndex = cboOrderId.FindString(orderId.ToString());
                cboOrderId.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BLInvoice db = new BLInvoice();
            string err = "";
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            int orderId = int.Parse(cboOrderId.Text);
            DataTable dt = db.OrderInfor(orderId);
            if (dt.Rows.Count < 0) return;
            int empId = int.Parse(dt.Rows[0]["MaNV"].ToString());
            if (db.Insert(date, 0, orderId, empId, ref err))
            {
                int invoiceId = db.RecentlyInvoiceId(orderId);
                foreach (DataGridViewRow rowType in dgvDetail.Rows)
                {
                    if ((bool)rowType.Cells[0].Value)
                    {
                        int n = (int)rowType.Cells["SoLuong"].Value;
                        int price = (int)rowType.Cells["DonGia"].Value;
                        for (int i = 0; i < n; i++)
                        {
                            if (!db.InsertDetail(invoiceId,
                                db.UnpaidProductId(orderId, (int)rowType.Cells["MaLoai"].Value),
                                price, ref err))
                            {
                                MessageBox.Show("Thêm thất bại " + err);
                                db.Delete(invoiceId, ref err);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Thêm thất bại " + err);
            }
            changed = true;
              Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            changed = false;
            Close();
        }

        private void cboOrderId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!char.IsDigit(cboOrderId.Text[0]))
                return;
            BLInvoice db = new BLInvoice();
            int oderId =int.Parse(cboOrderId.Text);
            
            DataTable dt= db.OrderInfor(oderId);
          

            if (dt.Rows.Count > 0)
            {
                txtCusName.Text = dt.Rows[0]["TenKhach"].ToString();
                txtEmpName.Text = dt.Rows[0]["TenNhanVien"].ToString();
            }
            dgvDetail.DataSource = db.Detail(oderId);
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dgvDetail.Rows[row.Index].Cells["Check"].Value = true;
                Total += (int)dgvDetail.Rows[row.Index].Cells["DonGia"].Value * (int)dgvDetail.Rows[row.Index].Cells["SoLuong"].Value;
            }

        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDetail.CurrentCell.RowIndex;
            if (r < 0)
                r = 0;
            try
            {
                if (e.ColumnIndex == dgvDetail.Columns.IndexOf(dgvDetail.Columns["Check"]))
                {
                    if ((bool)dgvDetail.Rows[r].Cells[0].Value)
                    {
                        dgvDetail.Rows[r].Cells["Check"].Value = false;
                    }
                    else
                    {
                        dgvDetail.Rows[r].Cells["Check"].Value = true;
                    }
                    updateTotal();
                }

            }
            catch { return; }

        }

        private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                    dgvDetail.Rows[e.RowIndex].Cells[5].Value = (int)dgvDetail.Rows[e.RowIndex].Cells[3].Value * (int)dgvDetail.Rows[e.RowIndex].Cells[4].Value;
                if (e.ColumnIndex == 5)
                {
                    updateTotal();
                }
            }
            catch { }
        }

        void updateTotal()
        {
            Total = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
                if ((bool)row.Cells[0].Value)
                {
                    Total += (int)row.Cells["DonGia"].Value * (int)row.Cells["SoLuong"].Value;
                }
        }
    }
}
