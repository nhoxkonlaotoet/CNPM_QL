using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM
{
    public partial class MyMessageBox : Form
    {
        public int total;
        public int quantity;
        bool isOK;

        public int QuantityLength
        {
            get
            {
                int n = 0;
                int i = quantity;
                while (i > 0)
                {
                    i /= 10;
                    n++;
                }
                return n;
            }

        }

        public MyMessageBox(int total)
        {
            InitializeComponent();
            this.total =total;
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) 
                || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                quantity *= 10;
                quantity += e.KeyValue % 48;
            }
            if(e.KeyCode==Keys.Back)
            {
                quantity /= 10;
            }
            if(quantity>total)
            {
                quantity = total;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(QuantityLength + "\t"+quantity);
            txtQuantity.SelectionLength = 0;
            txtQuantity.SelectionStart = QuantityLength;
            txtQuantity.Text = quantity + "/" + total;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isOK = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isOK = false;
            Close();
        }

        private void MyMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isOK)
                quantity = 0;
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            txtQuantity_TextChanged(null, null);
            txtQuantity.SelectionLength = 0;
        }
    }
}
