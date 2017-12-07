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
                if (db.Update(id, name, age, isMale, address, Lat, Lng, phoneNumber, MyConvert.ImageToByteArray(img), ref err))
                    MessageBox.Show("Đã cập nhật");
                else
                    MessageBox.Show("Cập nhật thất bại: " + err);
            }
            Block = false;
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDetail.CurrentCell.RowIndex;
            BLOrder db = new BLOrder();
            nudQuantity.Value = int.Parse(dgvDetail.Rows[r].Cells["SoLuong"].Value.ToString());
            txtCost.Text = dgvDetail.Rows[r].Cells["ThanhTien"].Value.ToString();
            txtPrice.Text = dgvDetail.Rows[r].Cells["DonGia"].Value.ToString();
            cboTypeName.SelectedValue = dgvDetail.Rows[r].Cells["MaLoai"].Value.ToString();

            DataRowView drv = (DataRowView)cboTypeName.SelectedItem;
            int typeId = int.Parse(drv.Row.ItemArray[1].ToString());
            txtAvailable.Text = db.Available(typeId).ToString();
        }

        private void cboTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                        txtId.ResetText();
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
