using System;
using System.Windows.Forms;
using CNPM.BL_Layer;
namespace CNPM
{
    public partial class FormInvoice : Form
    {
        public FormInvoice()
        {
            InitializeComponent();
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            BLInvoice db = new BLInvoice();
            dgvInvoice.DataSource = db.Invoices();
            dgvInvoice_CellClick(null, null);
        }
        void LoadDetail()
        {
            BLInvoice db = new BLInvoice();
            int invoiceId = int.Parse(txtInvoiceId.Text.Trim()) ;
            dgvDetail.DataSource = db.Detail_Invoice(invoiceId);
            dgvDetail_CellClick(null, null);
        }
        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvInvoice.CurrentCell.RowIndex;
            if (r < 0)
                r = 0;
            dgvInvoice.Rows[r].Selected = true;

            txtDate.Text = dgvInvoice.Rows[r].Cells["NgayIn"].Value.ToString();
            txtInvoiceId.Text = dgvInvoice.Rows[r].Cells["MaHD"].Value.ToString();
            txtOrderID.Text = dgvInvoice.Rows[r].Cells["MaDH"].Value.ToString();
            txtEmpID.Text = dgvInvoice.Rows[r].Cells["MaNV"].Value.ToString();
            txtCusID.Text = dgvInvoice.Rows[r].Cells["MaKH"].Value.ToString();
            txtTotal.Text = dgvInvoice.Rows[r].Cells["TongSoTien"].Value.ToString();
            BLInvoice db = new BLInvoice();
            txtEmpName.Text = db.EmpName((int)dgvInvoice.Rows[r].Cells["MaNV"].Value);
            txtCusName.Text = db.CusName((int)dgvInvoice.Rows[r].Cells["MaKH"].Value);
            LoadDetail();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddInvoice f = new AddInvoice();
            f.ShowDialog();
            if (f.changed)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvInvoice.CurrentCell.RowIndex;
            int id = int.Parse(dgvInvoice.Rows[r].Cells["MaHD"].Value.ToString());
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn xoá?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string err = null;
            if (traloi == DialogResult.Yes)
            {
                BLInvoice db = new BLInvoice();
                if (!db.Delete(id, ref err))
                {
                    MessageBox.Show(err);
                    return;
                }
                LoadData();
                MessageBox.Show("Đã xóa xong!");
            }
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDetail.CurrentCell.RowIndex;
            dgvDetail.Rows[r].Selected = true;

            txtQuantity.Text = dgvDetail.Rows[r].Cells["SoLuong"].Value.ToString();

            txtCost.Text = dgvDetail.Rows[r].Cells["ThanhTien"].Value.ToString();
            txtPrice.Text = dgvDetail.Rows[r].Cells["DonGia"].Value.ToString();
            txtTypeName.Text = dgvDetail.Rows[r].Cells["TenLoai"].Value.ToString();
            int typeId = int.Parse(dgvDetail.Rows[r].Cells["MaLoai"].Value.ToString());
            try { pic.Image = MyConvert.ByteArrayToImage((byte[])new BLOrder().ProductImage(typeId).Rows[0][0]); }
            catch { pic.Image = null; }
        }
    }
}
