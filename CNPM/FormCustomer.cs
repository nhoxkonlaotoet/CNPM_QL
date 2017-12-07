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
    public partial class FormCustomer : Form
    {
        bool block, blockAcc, add;
        public FormCustomer()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            btnEditAcc.Image = Image.FromFile("edit.png");
            btnSearch.Image = Image.FromFile("search.png");
            btnLocate.Image = Image.FromFile("locate.png");
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvCustomer.CurrentCell.RowIndex;
            txtId.Text = dgvCustomer.Rows[r].Cells["MaKH"].Value.ToString();
            txtName.Text = dgvCustomer.Rows[r].Cells["HoTen"].Value.ToString();
            txtAge.Text = dgvCustomer.Rows[r].Cells["Tuoi"].Value.ToString();
            txtAddress.Text = dgvCustomer.Rows[r].Cells["DiaChi"].Value.ToString();
            cboPhoneNumber.SelectedIndex = cboPhoneNumber.FindString(dgvCustomer.Rows[r].Cells["SoDienThoai"].Value.ToString());
            if(cboPhoneNumber.SelectedIndex==-1)
                cboPhoneNumber.Text= dgvCustomer.Rows[r].Cells["SoDienThoai"].Value.ToString();
            rbtnMale.Checked = (bool)dgvCustomer.Rows[r].Cells["Nam"].Value;
            txtLat.Text =  dgvCustomer.Rows[r].Cells["Lat"].Value.ToString();
            txtLng.Text = dgvCustomer.Rows[r].Cells["Lng"].Value.ToString();

            LoadAccount(txtAcc.Text);

            if (!rbtnMale.Checked)
                rbtnFemale.Checked = true;
            try { picAvatar.Image = MyConvert.ByteArrayToImage(new BLCustomer().Avatar(txtId.Text)); }
            catch { picAvatar.Image = null; }

        }
        void LoadAccount(string phoneNumber)
        {
            BLAccount db = new BLAccount();
            DataTable dt = db.GetAccount(phoneNumber);
            if (dt.Rows.Count > 0)
            {
                txtPassword.Text = dt.Rows[0]["MatKhau"].ToString();
                txtRole.Text = dt.Rows[0]["QuyenHan"].ToString();
                cboStatus.SelectedIndex = cboStatus.FindString(dt.Rows[0]["TinhTrang"].ToString());
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = true;
            Block = true;
            resetcontrols();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            add = false;
            Block = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvCustomer.CurrentCell.RowIndex;
            string id = dgvCustomer.Rows[r].Cells["MaKH"].Value.ToString();
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn xoá?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string err = null;
            if (traloi == DialogResult.Yes)
            {
                BLCustomer db = new BLCustomer();
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
            BLCustomer db = new BLCustomer();
            string id = txtId.Text;
            string name = txtName.Text;
            int age;
            try { age = int.Parse(txtAge.Text); }
            catch { MessageBox.Show("Tuổi phải là số"); return; }
            string phoneNumber = cboPhoneNumber.Text;
            foreach (char c in phoneNumber)
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("SDT không hợp lệ");
                    return;
                }
            int isMale = rbtnMale.Checked ? 1 : 0;
            Image img = picAvatar.Image;
            string address = txtAddress.Text;
            double Lat = double.Parse(txtLat.Text);
            double Lng = double.Parse(txtLng.Text);

            string err = "";
            if (add)
            {
                if (db.Insert(id, name, age, isMale, address, Lat, Lng, phoneNumber, MyConvert.ImageToByteArray(img), ref err))
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
            Block = false;
            
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            BLCustomer db = new BLCustomer();
            cboPhoneNumber.DataSource = db.PhoneNumbers();
            cboPhoneNumber.DisplayMember = "SDT";
            dgvCustomer.DataSource = db.Customers();
            
            Block = false;
            BlockAcc = false;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try { picAvatar.Image = Image.FromFile(openFileDialog1.FileName); }
            catch { }
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            BlockAcc = true;
        }

        private void cboPhoneNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAcc.Text = cboPhoneNumber.Text;
        }

        private void cboPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            txtAcc.Text = cboPhoneNumber.Text;
            LoadAccount(txtAcc.Text);
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
                    picAvatar.Enabled = true;
                    pnlInfor.Enabled = true;
                    if (add)
                    {
                        txtId.Enabled = true;
                    }
                    else
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
                    dgvCustomer_CellClick(null, null);
                }
            }
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            FormMap f = new FormMap();
            f.ShowDialog();
            if(f.isOK)
            {
                txtLat.Text = f.Lat.ToString();
                txtLng.Text = f.Lng.ToString();
            }

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if ((string)txtPassword.Tag=="1")
            {
                txtPassword.PasswordChar = new char();
                txtPassword.Tag = "0";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPassword.Tag = "1";
            }
        }

        private void btnSaveAcc_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtAcc.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            string status = cboStatus.Text;
            string err = "";
            BLAccount db = new BLAccount();
            if (db.Update(phoneNumber, password, role, status, null, ref err))
                MessageBox.Show("Đã cập nhật");
            else
                MessageBox.Show("Cập nhật thất bại: " + err);
        }

        private void btnCancelAcc_Click(object sender, EventArgs e)
        {

        }

        public bool BlockAcc
        {
            get
            {
                return blockAcc;
            }

            set
            {
                blockAcc = value;
                if (blockAcc)
                {
                    // txtAcc.Enabled = true;
                    btnEditAcc.Enabled = false;
                    txtPassword.Enabled = true;
                    // txtRole.Enabled = true;
                    cboStatus.Enabled = true;
                    btnSaveAcc.Enabled = true;
                    btnCancelAcc.Enabled = true;

                }
                else
                {

                    btnEditAcc.Enabled = true;
                    txtAcc.Enabled = false;
                    txtPassword.Enabled = false;
                    txtRole.Enabled = false;
                    cboStatus.Enabled = false;
                    btnSaveAcc.Enabled = false;
                    btnCancelAcc.Enabled = false;
                }
            }
        }
        void resetcontrols()
        {
            txtId.ResetText();
            txtName.ResetText();
            txtAge.ResetText();
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            txtAddress.ResetText();
            cboPhoneNumber.ResetText();
            picAvatar.Image = null;
            txtLng.ResetText();
            txtLat.ResetText();
        }
    }
}
