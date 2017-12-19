using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CNPM.BL_Layer;

namespace CNPM
{
    public partial class FormOrder : Form
    {
        const string SENT = "Đã gửi", DELIVERED = "Đang chuyển", RECEIVED = "Đã nhận";
        bool block, blockDetail, add, addDetail;
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Block)
                return;
            if(!cboStatus.Items.Contains(DELIVERED))
                cboStatus.Items.Add(DELIVERED);
            int r = dgvOrder.CurrentCell.RowIndex;
            if (r < 0)
                r = 0;
            dgvOrder.Rows[r].Selected = true;
            try
            {
                if (e.ColumnIndex == dgvOrder.Columns.IndexOf(dgvOrder.Columns["btn"])
                    && (bool)dgvOrder.Rows[r].Cells["ThemHD"].Value)
                {
                    int orderId = int.Parse(dgvOrder.Rows[r].Cells["MaDH"].Value.ToString().Trim());
                    AddInvoice f = new AddInvoice(orderId);
                    f.ShowDialog();
                    if(f.changed)
                        LoadData();
                  
                }
            }
            catch {  }

            string state = dgvOrder.Rows[r].Cells["TrangThai"].Value.ToString();
            txtId.Text = dgvOrder.Rows[r].Cells["MaDH"].Value.ToString();
            txtDate.Text = dgvOrder.Rows[r].Cells["ThoiDiemDatHang"].Value.ToString();
            cboCusID.SelectedIndex = cboCusID.FindString(dgvOrder.Rows[r].Cells["MaKH"].Value.ToString());
            if (!state.Contains(SENT))
            {
                cbIsDelivered.Enabled = false;
                int empId = new BLOrder().ShipperId(int.Parse(txtId.Text));
                cboEmpID.SelectedIndex = cboEmpID.FindString(empId.ToString());
                if (empId != -1)
                {
                    cbIsDelivered.Checked = true;
                }
                else
                    cbIsDelivered.Checked = false;
                if (state.Contains(DELIVERED))
                {
                    if(cboStatus.Items.Contains(SENT))
                        cboStatus.Items.Remove(SENT);
                    cboEmpID.Enabled = true;
                }
                else
                {
                    cboEmpID.Enabled = false;
                }
            }
            else
            {
                if (!cboStatus.Items.Contains(SENT))
                    cboStatus.Items.Add(SENT);
                cbIsDelivered.Enabled = true;
                cbIsDelivered.Checked = false;
                cboEmpID.Enabled = true;
            }
            cboStatus.SelectedIndex = cboStatus.FindString(state);

            LoadDetail();
        }

        void LoadDetail()
        {
            int orderId = int.Parse(txtId.Text);
            BLOrder db = new BLOrder();
            dgvDetail.DataSource = db.Detail(orderId);
            dgvDetail_CellClick(null, null);
            BlockDetail = false;

        }

        private void cboCusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboCusID.SelectedItem;
            txtCusName.Text = (string)drv.Row.ItemArray[1];
        }

        private void cboEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboEmpID.SelectedItem;
            if (drv != null)
                txtEmpName.Text = (string)drv.Row.ItemArray[1];
        }

        public FormOrder()
        {
            InitializeComponent();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvOrder.Columns.Add(btn);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Width = 40;
            btn.HeaderText = "";
            btn.Name = "btn";
            btn.DefaultCellStyle.BackColor = Color.White;
            btn.UseColumnTextForButtonValue = true;

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
                if (cbIsDelivered.Checked)
                {
                    int empId = int.Parse(cboEmpID.Text);
                    f = db.Insert(date, 0, cusId, empId, SENT, ref err);
                }
                else
                    f = db.Insert(date, 0, cusId, SENT, ref err);
                if (f)
                    MessageBox.Show("Đã thêm");
                else
                    MessageBox.Show("Thêm thất bại: " + err);
            }

            else
            {
                int id = int.Parse(txtId.Text);
                date = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy HH:mm:ss");
                int cost = int.Parse(txtCost.Text);
                string status = cboStatus.Text;
                bool f;
                if (cbIsDelivered.Checked)
                {
                    int empId = int.Parse(cboEmpID.Text);
                    f = db.Update(id, date, cost, cusId, empId, status, ref err);

                }
                else f = db.Update(id, date, cost, cusId, status, ref err);

                if (f)
                    MessageBox.Show("Đã cập nhật");
                else
                    MessageBox.Show("Cập nhật thất bại: " + err);
            }
            LoadData();

            Block = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Block = false;
            cboEmpID.DataSource = new BLOrder().Employees();
            cboEmpID.DisplayMember = "MaNV";
            cboEmpID.ValueMember = "HoTen";
            dgvOrder_CellClick(null, null);
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            BlockDetail = true;
            nudQuantity_ValueChanged(null, null);
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count == 0)
                return;
            int r = dgvDetail.CurrentCell.RowIndex;
            int typeId = int.Parse(dgvDetail.Rows[r].Cells["MaLoai"].Value.ToString());
            MyMessageBox mess = new MyMessageBox(int.Parse(dgvDetail.Rows[r].Cells["SoLuong"].Value.ToString()));
            mess.ShowDialog();
            if (mess.quantity == 0)
                return;
            string err = null;
            BLOrder db = new BLOrder();
            for (int i = 0; i < mess.quantity; i++)
            {

                if (!db.DeleteDetail(int.Parse(txtId.Text), db.ProductIdOfOrder(int.Parse(txtId.Text), typeId), ref err))
                {
                    MessageBox.Show("Đã xóa " + i + "/" + mess.quantity + " sản phẩm");
                    return;
                }
            }
            MessageBox.Show("Đã xóa");
            LoadData();
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count == 0)
            {
                btnRemoveDetail.Enabled = false;
                return;
            }
            int r = dgvDetail.CurrentCell.RowIndex;
            dgvDetail.Rows[r].Selected = true;

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
         
            try { pic.Image = MyConvert.ByteArrayToImage((byte[])new BLOrder().ProductImage(typeId).Rows[0][0]); }
            catch { pic.Image = null; }
            if (available == 0)
                nudQuantity.Value = 0;
            else
                nudQuantity.Value = 1;
        }

        private void cbIsTransported_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsDelivered.Checked)
            {
                lblEmpID.Show();
                cboEmpID.Show();
                lblEmpName.Show();
                txtEmpName.Show();
                if (cboEmpID.Items.Count == 0)
                    txtEmpName.ResetText();
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
            cboEmpID.DataSource = db.Employees();
            cboEmpID.DisplayMember = "MaNV";
            cboEmpID.ValueMember = "HoTen";
            cboTypeName.DataSource = db.ProductType();
            cboTypeName.DisplayMember = "TenLoai";
            cboTypeName.ValueMember = "MaLoai";
            cbIsDelivered.Checked = false;
            Block = false;
            dgvOrder_CellClick(null, null);

        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            BLOrder db = new BLOrder();
            string err = "";
            int orderId = int.Parse(txtId.Text);
            int quantity = (int)nudQuantity.Value;
            if (quantity == 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0");
                return;
            }
            DataRowView drv = (DataRowView)cboTypeName.SelectedItem;
            int typeId = int.Parse(drv.Row.ItemArray[1].ToString());
            for (int i = 0; i < quantity; i++)
            {
                int productId = new BLOrder().AvailProductId(typeId);
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
            LoadData();
            BlockDetail = false;
            MessageBox.Show("Thêm thành công");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            OnLoad(e);
        }

        private void dgvOrder_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                int w = 24;
                int h = 24;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                Image img = Image.FromFile("coin.png");
                if ((bool)dgvOrder.Rows[e.RowIndex].Cells["ThemHD"].Value)
                {
                    e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                    e.Graphics.DrawRectangle(new Pen(Color.White), e.CellBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);
                }
                e.Handled = true;
            }
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
                        if (!cboStatus.Items.Contains(SENT))
                            cboStatus.Items.Add(SENT);
                        txtId.ResetText();
                        txtDate.Text = DateTime.Now.ToString();
                        cboStatus.SelectedIndex = cboStatus.FindString(SENT);
                        cbIsDelivered.Checked = false;
                        cbIsDelivered.Enabled = true;
                        cboEmpID.DataSource = new BLOrder().FreeEmployees(-1);
                        cboEmpID.DisplayMember = "MaNV";
                        cboEmpID.ValueMember = "HoTen";
                        cboEmpID.Enabled = true;
                    }
                    else
                    {
                        if (cboStatus.Text != DELIVERED)
                            try
                            {
                                cboStatus.Items.Remove(DELIVERED);
                            }
                            catch { }
                        if (cboStatus.Text == RECEIVED)
                            cboStatus.Enabled = false;
                        else
                            cboStatus.Enabled = true;
                        cboEmpID.DataSource = new BLOrder().FreeEmployees(int.Parse(txtId.Text));
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
                    nudQuantity.Value = 1;
                    txtPrice.Enabled = true;
                    txtCost.Enabled = true;
                    btnSaveDetail.Enabled = true;
                    btnCancelDetail.Enabled = true;

                }
                else
                {
                    DateTime deliveryTime = new BLOrder().DeliveryTime(int.Parse(txtId.Text));
                    addDetail = false;
                    if (!cboStatus.Text.Contains(RECEIVED)
                        && (deliveryTime == DateTime.MinValue || DateTime.Now - deliveryTime <= new TimeSpan(0,10,0))) // chỉ đc thêm/ xóa sp khi đơn hàng chưa quá 10p
                    {
                        btnAddDetail.Enabled = true;
                        if (dgvDetail.Rows.Count == 0)
                            btnRemoveDetail.Enabled = false;
                        else
                            btnRemoveDetail.Enabled = true;
                    }
                    else
                    {

                        btnAddDetail.Enabled = false;
                        btnRemoveDetail.Enabled = false;
                    }
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
