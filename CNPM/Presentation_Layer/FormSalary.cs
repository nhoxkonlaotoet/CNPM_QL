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
    public partial class FormSalary : Form
    {
        const int DEFAULT_YEAR = 2016;
        const string ALLYEAR = "Cả năm", NONE = "";
        int year, month;
        public FormSalary()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            int y = DateTime.Now.Year;
            for (int i = DEFAULT_YEAR; i <= y; i++)
                cboYear.Items.Add(i);
            for (int i = 1; i <= 12; i++)
                cboMonth.Items.Add(i);
            cboMonth.Items.Add(ALLYEAR);
        }

        private void FormSalary_Load(object sender, EventArgs e)
        {
            cboYear.SelectedIndex = cboYear.FindString(DateTime.Now.Year.ToString());
            LoadData();
        }
        void LoadData()
        {
            BLSalary db = new BLSalary();
            if (month == -1)
                dgvSalary.DataSource = db.Salaries(year);
            else
                dgvSalary.DataSource = db.Salaries(year, month);
        }
        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = int.Parse(cboYear.Text);
            if (cboMonth.Text == ALLYEAR || cboMonth.Text == NONE)
                month = -1;
            else
                month = int.Parse(cboMonth.Text);
            LoadData();
        }

    }
}
