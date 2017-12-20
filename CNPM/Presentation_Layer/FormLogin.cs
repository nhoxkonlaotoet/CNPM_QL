using System;
using System.Windows.Forms;
using CNPM.BL_Layer;
using System.Drawing;

namespace CNPM
{
    public partial class FormLogin : Form
    {
        public event EventHandler Login;
        bool loged = false;
        public FormLogin()
        {
            InitializeComponent();
            init();
          
        }

        void init()
        {
            txtID.Text = "chu";
            txtPassword.Text = "123456";
            Icon = new Icon("water.ico");
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string password = txtPassword.Text;
            BLLogin db = new BLLogin();
            if (db.Login(id, password))
            {
                loged = true;
                Login?.Invoke(txtID.Text.Trim(), e);
                Close();
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loged)
                Application.Exit();
        }
    }
}
