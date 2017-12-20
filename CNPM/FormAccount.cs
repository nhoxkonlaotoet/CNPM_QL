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
    public partial class FormAccount : Form
    {
       
        bool block, add;
        public FormAccount()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            cboRole.Items.Add(Values.ROLE_ADMIN);
            cboRole.Items.Add(Values.ROLE_MANAGER);
            cboRole.Items.Add(Values.ROLE_EMPLOYEE);
            cboRole.Items.Add(Values.ROLE_CUSTOMER);
            cboStatus.Items.Add(Values.STATE_ACTIVE);
            cboStatus.Items.Add(Values.STATE_BAN);
        }

        private void FormAccount_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            BLAccount db = new BLAccount();
            dgvAccount.DataSource = db.Accounts();
            Block = false;
            dgvAccount_CellClick(null, null);
        }


        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvAccount.CurrentCell.RowIndex;
            if (r < 0)
                r = 0;
            dgvAccount.Rows[r].Selected = true;
            if (Block)
                return;

            BLAccount db = new BLAccount();
            cboRole.SelectedIndex = cboRole.FindString(dgvAccount.Rows[r].Cells["QuyenHan"].Value.ToString());

            cboStatus.SelectedIndex = cboStatus.FindString(dgvAccount.Rows[r].Cells["TinhTrang"].Value.ToString());
            txtId.Text = dgvAccount.Rows[r].Cells["SDT"].Value.ToString();
            txtPassword.Text = db.Password(txtId.Text);
            txtDate.Text = dgvAccount.Rows[r].Cells["NgayKichHoat"].Value.ToString();
            if (!Block)
            {
                try
                {
                    foreach (DataRowView drv in cboOwner.Items)
                    {
                        if (drv.Row.ItemArray[1].ToString() == txtId.Text)
                        {
                            cboOwner.SelectedIndex = cboOwner.FindString(drv.Row.ItemArray[0].ToString());
                            break;
                        }
                    }
                }
                catch { }
            }
            try { picAvatar.Image = MyConvert.ByteArrayToImage(new BLCustomer().Avatar(int.Parse(txtId.Text))); }
            catch { picAvatar.Image = null; }
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // vì lúc thêm item là string ko phải dùng datasource=
            string role = cboRole.SelectedItem.ToString();
            if (role ==Values.ROLE_ADMIN || role == Values.ROLE_MANAGER)
            {
                cboOwner.DataSource = new List<string> { Values.OWNER_NONE };
                txtId.Enabled = true;
            }
            else
            {
                txtId.Enabled = false;
                BLAccount db = new BLAccount();
                DataTable dt;
                if (add)
                    dt = db.Owners(role);
                else dt = db.AvailableOwners(role);
                if (dt.Rows.Count > 0)
                {
                    cboOwner.DataSource = dt;
                    cboOwner.DisplayMember = "Ma";
                }
                else
                    cboOwner.DataSource = new List<string> { Values.OWNER_NONE };
            }
        }
        private void cboOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOwner.Text.Contains(Values.OWNER_NONE))
            {
                txtId.ResetText();
                txtName.ResetText();
                return;
            }
            DataRowView drv = (DataRowView)cboOwner.SelectedItem;
            if (drv == null)
                txtName.ResetText();
            txtId.Text = drv.Row.ItemArray[1].ToString();
            txtName.Text = drv.Row.ItemArray[2].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = true;
            Block = true;
            cboRole_SelectedIndexChanged(null, e);
            txtId.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            add = false;
            Block = true;
            txtPassword.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn xoá?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string err = null;
            if (traloi == DialogResult.Yes)
            {
                BLAccount db = new BLAccount();
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
            BLAccount db = new BLAccount();
            string id = txtId.Text;
            string password = txtPassword.Text;
            string role = cboRole.Text;
            if (role.Contains(Values.ROLE_CUSTOMER) || role.Contains(Values.ROLE_EMPLOYEE))
                foreach (char c in id)
                    if (!char.IsDigit(c))
                    {
                        MessageBox.Show("SDT không hợp lệ");
                        return;
                    }
            string status = cboStatus.Text;
            string date;
            try
            {
                DateTime d = Convert.ToDateTime(txtDate.Text);
                date = d.ToString("MM/dd/yyyy HH:mm:ss");
                MessageBox.Show(date);
            }
            catch { MessageBox.Show("Ngày không hợp lệ"); date = ""; }



            string err = "";
            if (add)
            {
                if (db.Insert(id, password, role, status, date, ref err))
                    MessageBox.Show("Đã thêm");
                else
                    MessageBox.Show("Thêm thất bại: " + err);
            }

            else
            {
                if (db.Update(id, password, role, status, date, ref err))
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
                        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        txtId.Enabled = true;
                        txtId.ResetText();
                        txtName.ResetText();
                        txtPassword.ResetText();
                        cboRole.Enabled = true;
                        cboOwner.Enabled = true;
                    }
                    else
                    {
                        cboRole.Enabled = false;
                        cboOwner.Enabled = false;
                        txtId.Enabled = false;
                    }
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
                    dgvAccount_CellClick(null, null);
                }
            }
        }

    }
}
