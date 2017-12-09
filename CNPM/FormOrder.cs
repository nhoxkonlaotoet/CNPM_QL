using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNPM.BL_Layer;
namespace CNPM
{
    public partial class FormOrder : Form
    {
        bool block, blockDetail, add, addDetail;
        int quantity;
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvOrder.CurrentCell.RowIndex;
            string state = dgvOrder.Rows[r].Cells["TrangThai"].Value.ToString();
            txtId.Text = dgvOrder.Rows[r].Cells["MaDH"].Value.ToString();
            txtDate.Text = dgvOrder.Rows[r].Cells["ThoiDiemDatHang"].Value.ToString();
            cboStatus.SelectedIndex = cboStatus.FindString(state);
            cboCusID.SelectedIndex = cboCusID.FindString(dgvOrder.Rows[r].Cells["MaKH"].Value.ToString());
            if (!state.Contains("Đã gửi"))
            {
                cbIsTransported.Enabled = false;
                cboEmpID.SelectedIndex = cboEmpID.FindString(new BLOrder().TransportedId(int.Parse(txtId.Text)).ToString());
                cbIsTransported.Checked = true;
                if (state.Contains("Đã nhận"))
                    cboEmpID.Enabled = false;
            }
            else
            {
                cbIsTransported.Enabled = true;
                cbIsTransported.Checked = false;
                cboEmpID.Enabled = true;
            }
            LoadDetail();
        }

        void LoadDetail()
        {
            BlockDetail = false;
            int orderId = int.Parse(txtId.Text);
            BLOrder db = new BLOrder();
            dgvDetail.DataSource = db.Detail(orderId);
            dgvDetail_CellClick(null, null);
        }

        private void cboCusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboCusID.SelectedItem;
            txtCusName.Text = (string)drv.Row.ItemArray[1];
        }

        private void cboEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboEmpID.SelectedItem;
            txtEmpName.Text = (string)drv.Row.ItemArray[1];
        }

        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = true;
            Block = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            add = false;
            Block = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvOrder.CurrentCell.RowIndex;
            int id = int.Parse(dgvOrder.Rows[r].Cells["MaDH"].Value.ToString());
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn xoá?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string err = null;
            if (traloi == DialogResult.Yes)
            {
                BLOrder db = new BLOrder();
                if (!db.Delete(id, ref err))
                {
                    MessageBox.Show(err);
                    return;
                }
                LoadData();
                MessageBox.Show("Đã xóa xong!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BLOrder db = new BLOrder();
            int cusId = int.Parse(cboCusID.Text);
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            string err = "";
            if (add)
            {
                bool f;
                if (cbIsTransported.Checked)
                {
                    int empId = int.Parse(cboEmpID.Text);
                    f = db.Insert(date, 0, cusId, empId, "Đã gửi", ref err);
                }
                else
                    f = db.Insert(date, 0, cusId, "Đã gửi", ref err);
                if (f)
                    MessageBox.Show("Đã thêm");
                else
                    MessageBox.Show("Thêm thất bại: " + err);
            }

            else
            {
                int id = int.Parse(txtId.Text);
                date = txtDate.Text;
                int cost = int.Parse(txtCost.Text);
                string status = cboStatus.Text;
                if (db.Update(id,date,cost, cost,status, ref err))
                    MessageBox.Show("Đã cập nhật");
                else
                    MessageBox.Show("Cập nhật thất bại: " + err);
            }
            Block = false;
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Block = false;
            dgvOrder_CellClick(null, null);
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            BlockDetail = true;
            nudQuantity_ValueChanged(null, null);
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDetail.CurrentCell.RowIndex;

            nudQuantity.Value = int.Parse(dgvDetail.Rows[r].Cells["SoLuong"].Value.ToString());
             
            txtCost.Text = dgvDetail.Rows[r].Cells["ThanhTien"].Value.ToString();
            txtPrice.Text = dgvDetail.Rows[r].Cells["DonGia"].Value.ToString();
            cboTypeName.SelectedValue = dgvDetail.Rows[r].Cells["MaLoai"].Value.ToString();
      

        }

        private void cboTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLOrder db = new BLOrder();
            DataRowView drv = (DataRowView)cboTypeName.SelectedItem;
            int typeId = int.Parse(drv.Row.ItemArray[1].ToString());
            int available = db.Available(typeId);
            txtPrice.Text = db.Price(typeId).ToString();
            txtAvailable.Text = available.ToString();
            if (available == 0)
                nudQuantity.Value = 0;
            else
                nudQuantity.Value = 1;
        }
      
        private void cbIsTransported_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsTransported.Checked)
            {
                lblEmpID.Show();
                cboEmpID.Show();
                lblEmpName.Show();
                txtEmpName.Show();
            }
            else
            {
                lblEmpID.Hide();
                cboEmpID.Hide();
                lblEmpName.Hide();
                txtEmpName.Hide();
            }
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (addDetail)
            {
                if (int.Parse(txtAvailable.Text) < nudQuantity.Value)
                {
                    nudQuantity.Value = int.Parse(txtAvailable.Text);
                    return;
                }
                txtCost.Text = (int.Parse(txtPrice.Text) * nudQuantity.Value).ToString();
            }
        }

        void LoadData()
        {
            BLOrder db = new BLOrder();
            dgvOrder.DataSource = db.Orders();
            cboCusID.DataSource = db.Customers();
            cboCusID.DisplayMember = "MaKH";
            cboCusID.ValueMember = "HoTen";
            cboEmpID.DataSource = db.FreeEmployees();
            cboEmpID.DisplayMember = "MaNV";
            cboEmpID.ValueMember = "HoTen";
            cboTypeName.DataSource = db.ProductType();
            cboTypeName.DisplayMember = "TenLoai";
            cboTypeName.ValueMember = "MaLoai";
            cbIsTransported.Checked = false;
            Block = false;
        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            BLOrder db = new BLOrder();
            string err = "";
            int orderId = int.Parse(txtId.Text);
            int quantity = (int)nudQuantity.Value;
            if(quantity==0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0");
                return;
            }
            DataRowView drv = (DataRowView)cboTypeName.SelectedItem;
            int typeId = int.Parse(drv.Row.ItemArray[1].ToString());
            for (int i=0;i<quantity;i++)
            {
                int productId = new BLOrder().AvailProductId(typeId);
                MessageBox.Show(productId + "");
                if (productId != -1)
                {
                    if (!db.InsertDetail(orderId, productId, int.Parse(txtPrice.Text), ref err))
                    {
                        MessageBox.Show(err);
                    }
                }
                else
                {
                    MessageBox.Show("Thêm được " + i + "/" + quantity + " sản phẩm");
                    return;
                }
            }
            BlockDetail = false;
            MessageBox.Show("Thêm thành công");
        }

        private void btnCancelDetail_Click(object sender, EventArgs e)
        {
            dgvDetail_CellClick(null, null);
            BlockDetail = false;
        }

        public bool Block
        {
            get
            {
                return block;
            }

            set
            {
                block = value;
                if (block)
                {
                    pnlInfor.Enabled = true;
                    if (add)
                    {
                        txtId.ResetText();
                        txtDate.Text = DateTime.Now.ToString();
                        cboStatus.SelectedIndex = cboStatus.FindString("Đã gửi");
                        cbIsTransported.Checked = false;
                        cbIsTransported.Enabled = true;
                        cboEmpID.Enabled = true;
                    }
                    txtId.Enabled = false;
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {

                    pnlInfor.Enabled = false;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    dgvOrder_CellClick(null, null);
                }
            }
        }

        public bool BlockDetail
        {
            get
            {
                return blockDetail;
            }

            set
            {
                blockDetail = value;
                if (blockDetail)
                {
                    addDetail = true;
                    btnAddDetail.Enabled = false;
                    btnRemoveDetail.Enabled = false;
                    pic.Enabled = true;
                    cboTypeName.Enabled = true;
                    txtAvailable.Enabled = true;
                    nudQuantity.Enabled = true;
                    txtPrice.Enabled = true;
                    txtCost.Enabled = true;
                    btnSaveDetail.Enabled = true;
                    btnCancelDetail.Enabled = true;

                }
                else
                {
                    addDetail = false;
                    btnAddDetail.Enabled = true;
                    btnRemoveDetail.Enabled = true;
                    pic.Enabled = false;
                    cboTypeName.Enabled = false;
                    txtAvailable.Enabled = false;
                    nudQuantity.Enabled = false;
                    txtPrice.Enabled = false;
                    txtCost.Enabled = false;
                    btnSaveDetail.Enabled = false;
                    btnCancelDetail.Enabled = false;
                }
            }
        }

   

       
    }
}
