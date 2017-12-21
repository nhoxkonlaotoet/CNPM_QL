using System;
using System.Windows.Forms;
using CNPM.BL_Layer;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Linq;
using System.Net;
using System.Net.Sockets;

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
            
            if (db.Connect(cboIP.Text.Trim()))
            {
                if (db.Login(id, password))
                {
                    loged = true;
                    Login?.Invoke(txtID.Text.Trim(), e);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Không đúng máy chủ");
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loged)
                Application.Exit();
        }

        private void btnShowMore_Click(object sender, EventArgs e)
        {
            if (cboIP.Visible)
                cboIP.Hide();
            else
                cboIP.Show();
        }
        void LoadIPs()
        {
            var gateway_address = NetworkInterface.GetAllNetworkInterfaces()
            .Where(e => e.OperationalStatus == OperationalStatus.Up)
            .SelectMany(e => e.GetIPProperties().GatewayAddresses);

            string[] s = new string[gateway_address.Count() + 1];

            s [0]= Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(a => a.AddressFamily == AddressFamily.InterNetwork).First().ToString();
            int i = 1;
            foreach (var ip in gateway_address)
            {
                s[i++] = ip.Address.ToString();
            }
           
            BindingSource theBindingSource = new BindingSource();
            theBindingSource.DataSource = s;
            cboIP.DataSource = theBindingSource.DataSource;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            LoadIPs();
        }
    }
}
