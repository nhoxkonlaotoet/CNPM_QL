using System;
using System.Data;
using System.Windows.Forms;
using CNPM.BL_Layer;
using System.Drawing;

namespace CNPM
{
    public partial class FormFeedback : Form
    {
        const int DEFAULT_YEAR = 2016;
        const string ALLYEAR = "Cả năm", NONE = "";
        int year, month;
        public FormFeedback()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            btnSearch.Image = Image.FromFile(Values.URL_SEARCH);
            btnRefresh.Image = Image.FromFile(Values.URL_REFRESH);
            int y = DateTime.Now.Year;
            for (int i = DEFAULT_YEAR; i <= y; i++)
                cboYear.Items.Add(i);
            for (int i = 1; i <= 12; i++)
                cboMonth.Items.Add(i);
            cboMonth.Items.Add(ALLYEAR);
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


        private void FormFeedback_Load(object sender, EventArgs e)
        {
            cboYear.SelectedIndex = cboYear.FindString(DateTime.Now.Year.ToString());
            LoadData();
        }
        void LoadData()
        {
            BLFeedback db = new BLFeedback();
            if (month == -1)
                dgvFeedback.DataSource = db.Feedbacks(year);
            else
                dgvFeedback.DataSource = db.Feedbacks(year, month);
        }
    }
}
