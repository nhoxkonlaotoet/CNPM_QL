﻿using System;
using System.Windows.Forms;

namespace CNPM
{
    public partial class FormFrame : Form
    {

        const string CONTROLLER = "Controller",
                        PRODUCT = "Product",
                        CUSTOMER = "Customer",
                        EMPLOYEE = "Employee",
                        ORDER = "Order",
                        INVOICE = "Invoice",
                        SALARY = "Salary",
                        FEEDBACK = "Feedback",
                        ACCOUNT = "Account";
        public FormFrame()
        {
            InitializeComponent();
            init();
        }

        private void FormFrame_Load(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            Hide();
            form.ShowDialog();
            Show();
        }

        void init()
        {
            btnController.Tag = CONTROLLER;
            btnProduct.Tag = PRODUCT;
            btnCustomer.Tag = CUSTOMER;
            btnOrder.Tag = ORDER;
            btnEmployee.Tag = EMPLOYEE;
            btnInvoice.Tag = INVOICE;
            btnSalary.Tag = SALARY;
            btnFeedback.Tag = FEEDBACK;
            btnAccount.Tag = ACCOUNT;

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
                    break;
                case SALARY:
                    FormSalary fs = new FormSalary();
                    fs.MdiParent = this;
                    fs.Dock = DockStyle.Fill;
                    fs.Show();
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
