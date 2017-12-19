using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CNPM.BL_Layer;
namespace CNPM
{
    public partial class FormEmployee : Form
    {
        const string FREE = "Rảnh", DELIVERY = "Giao hàng";
        bool block, blockAcc, add;
        public FormEmployee()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            btnEditAcc.Image = Image.FromFile("edit.png");
            btnSearch.Image = Image.FromFile("search.png");
        }
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            BLEmployee db = new BLEmployee();
            cboPhoneNumber.DataSource = db.PhoneNumbers();
            cboPhoneNumber.DisplayMember = "SDT";
            dgvEmployee.DataSource = db.Employees();

            Block = false;
            BlockAcc = false;
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
            int r = dgvEmployee.CurrentCell.RowIndex;
            int empId = int.Parse(dgvEmployee.Rows[r].Cells["MaNV"].Value.ToString());
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn xoá?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string err = null;
            if (traloi == DialogResult.Yes)
            {
                BLEmployee db = new BLEmployee();
                if (!db.Delete(empId, ref err))
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
            BLEmployee db = new BLEmployee();
            string name = txtName.Text;
            int age;
            try { age = int.Parse(txtAge.Text); }
            catch { MessageBox.Show("Tuổi phải là số"); return; }
            string phoneNumber = cboPhoneNumber.Text.Trim();
            foreach (char c in phoneNumber)
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("SDT không hợp lệ");
                    return;
                }
            int isMale = rbtnMale.Checked ? 1 : 0;
            Image img = picAvatar.Image;
            string address = txtAddress.Text;
            string status = cboStatus.Text;
            string ID = txtID.Text.Trim();
            string err = "";
            if (add)
            {
                if (db.Insert(name, age, isMale, address,ID, phoneNumber,MyConvert.ImageToByteArray(img),status, ref err))
                    MessageBox.Show("Đã thêm");
                else
                    MessageBox.Show("Thêm thất bại: " + err);
            }

            else
            {
                int id = int.Parse(txtEmpId.Text);
                if (db.Update(id, name, age, isMale, address,ID,phoneNumber, MyConvert.ImageToByteArray(img),status, ref err))
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

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Block)
                return;
            int r = dgvEmployee.CurrentCell.RowIndex;
            txtEmpId.Text = dgvEmployee.Rows[r].Cells["MaNV"].Value.ToString();
            txtName.Text = dgvEmployee.Rows[r].Cells["HoTen"].Value.ToString();
            txtAge.Text = dgvEmployee.Rows[r].Cells["Tuoi"].Value.ToString();
            txtAddress.Text = dgvEmployee.Rows[r].Cells["DiaChi"].Value.ToString();
            txtID.Text = dgvEmployee.Rows[r].Cells["CMND"].Value.ToString();
            cboPhoneNumber.SelectedIndex = cboPhoneNumber.FindString(dgvEmployee.Rows[r].Cells["SoDienThoai"].Value.ToString());
            cboStatus.SelectedIndex = cboStatus.FindString(dgvEmployee.Rows[r].Cells["TrangThai"].Value.ToString());
            if (cboPhoneNumber.SelectedIndex == -1)
                cboPhoneNumber.Text = dgvEmployee.Rows[r].Cells["SoDienThoai"].Value.ToString();
            rbtnMale.Checked = (bool)dgvEmployee.Rows[r].Cells["Nam"].Value;

            if (!rbtnMale.Checked)
                rbtnFemale.Checked = true;
            try { picAvatar.Image = MyConvert.ByteArrayToImage(new BLEmployee().Avatar(int.Parse(txtEmpId.Text))); }
            catch { picAvatar.Image = null; }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try { picAvatar.Image = Image.FromFile(openFileDialog1.FileName); }
            catch { }
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

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
                    if (add)
                    {
                        cboStatus.Enabled = false;
                        cboStatus.SelectedIndex = cboStatus.FindString(FREE);
                    }
                    else if (cboStatus.Text == DELIVERY)
                        cboStatus.Enabled = true;
                    picAvatar.Enabled = true;
                    pnlInfor.Enabled = true;
                    txtEmpId.Enabled = false;
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
                    dgvEmployee_CellClick(null, null);
                }
            }
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
                    cboAccStatus.Enabled = true;
                    btnSaveAcc.Enabled = true;
                    btnCancelAcc.Enabled = true;

                }
                else
                {

                    btnEditAcc.Enabled = true;
                    txtAcc.Enabled = false;
                    txtPassword.Enabled = false;
                    txtRole.Enabled = false;
                    cboAccStatus.Enabled = false;
                    btnSaveAcc.Enabled = false;
                    btnCancelAcc.Enabled = false;
                }
            }
        }
        void resetcontrols()
        {
            txtEmpId.ResetText();
            txtName.ResetText();
            txtID.ResetText();
            txtAge.ResetText();
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            txtAddress.ResetText();
            cboPhoneNumber.ResetText();
            picAvatar.Image = null;
            
        }

    }


}
