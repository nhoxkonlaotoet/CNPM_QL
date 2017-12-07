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
            txtId.Text = dgvOrder.Rows[r].Cells["MaDH"].Value.ToString();
            txtDate.Text = dgvOrder.Rows[r].Cells["ThoiDiemDatHang"].Value.ToString();
            cboStatus.SelectedIndex = cboStatus.FindString(dgvOrder.Rows[r].Cells["TrangThai"].Value.ToString());
            LoadDetail();
        }

        void LoadDetail()
        {
            string orderId = txtId.Text.Trim();
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
        }
    }
}
