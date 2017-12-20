using System;
using System.Drawing;
using System.Windows.Forms;
using CNPM.BL_Layer;
namespace CNPM
{
    public partial class FormFrame : Form
    {
        string user;
        const string CONTROLLER = "Controller",
                        PRODUCT = "Product",
                        CUSTOMER = "Customer",
                        EMPLOYEE = "Employee",
                        ORDER = "Order",
                        INVOICE = "Invoice",
                        SALARY = "Salary",
                        FEEDBACK = "Feedback",
                        ACCOUNT = "Account";

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnLoad(e);
        }

        public string User
        {
            get
            {
                return user;
            }

            set
            {

                user = value;
                lblUser.Text = user;
                if (new BLLogin().Role(user) == Values.ROLE_ADMIN)
                    btnAccount.Show();
                else
                    btnAccount.Hide();
            }
        }

        public FormFrame()
        {
            InitializeComponent();
            init();
        }

        private void FormFrame_Load(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();

            form.Login += new EventHandler(getUser);

            Hide();
            form.ShowDialog();
            Show();
            btnMenu_Click(btnDelivery, e);
        }
        private void getUser(object sender, EventArgs e)
        {
            User = (string)sender;
        }
        void init()
        {
            btnDelivery.Tag = CONTROLLER;
            btnProduct.Tag = PRODUCT;
            btnCustomer.Tag = CUSTOMER;
            btnOrder.Tag = ORDER;
            btnEmployee.Tag = EMPLOYEE;
            btnInvoice.Tag = INVOICE;
            btnSalary.Tag = SALARY;
            btnFeedback.Tag = FEEDBACK;
            btnAccount.Tag = ACCOUNT;
            Icon = new Icon("water.ico");
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
                f.Close();
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case CONTROLLER:
                    FormDelivery fc = new FormDelivery();
                    fc.MdiParent = this;
                    fc.Dock = DockStyle.Fill;
                    fc.Show();
                    break;
                case PRODUCT:
                    FormProduct fp = new FormProduct();
                    fp.MdiParent = this;
                    fp.Dock = DockStyle.Fill;
                    fp.Show();
                    break;
                case CUSTOMER:
                    FormCustomer fc1 = new FormCustomer();
                    fc1.MdiParent = this;
                    fc1.Dock = DockStyle.Fill;
                    fc1.Show();
                    break;
                case EMPLOYEE:
                    FormEmployee fe = new FormEmployee();
                    fe.MdiParent = this;
                    fe.Dock = DockStyle.Fill;
                    fe.Show();
                    break;
                case ORDER:
                    FormOrder fo = new FormOrder();
                    fo.MdiParent = this;
                    fo.Dock = DockStyle.Fill;
                    fo.Show();
                    break;
                case INVOICE:
                    FormInvoice fi = new FormInvoice();
                    fi.MdiParent = this;
                    fi.Dock = DockStyle.Fill;
                    fi.Show();
                    break;
                case FEEDBACK:
                    FormFeedback fe1 = new FormFeedback();
                    fe1.MdiParent = this;
                    fe1.Dock = DockStyle.Fill;
                    fe1.Show();
                    break;
                case SALARY:
                    FormSalary fs = new FormSalary();
                    fs.MdiParent = this;
                    fs.Dock = DockStyle.Fill;
                    fs.Show();
                    break;
                case ACCOUNT:
                    if (new BLLogin().Role(user) == Values.ROLE_ADMIN)
                    {
                        FormAccount fc2 = new FormAccount();
                        fc2.MdiParent = this;
                        fc2.Dock = DockStyle.Fill;
                        fc2.Show();
                    }
                    break;
                default: break;
            }


        }
        private void CreateInvoid(object sender, EventArgs e)
        {
            string orderId = (string)sender;
            MessageBox.Show(orderId);
        }
    }
}
