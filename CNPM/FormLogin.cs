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
    public partial class FormLogin : Form
    {
        bool loged = false;
        public FormLogin()
        {
            InitializeComponent();
            txtID.Text = "chu";
            txtPassword.Text = "123456";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string password = txtPassword.Text;
            BLLogin db = new BLLogin();
            if (db.Login(id, password))
            {
                loged = true;
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
