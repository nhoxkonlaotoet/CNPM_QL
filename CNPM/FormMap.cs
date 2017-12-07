using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
    public partial class FormMap : Form
    {
        public bool isOK;
        public double Lat, Lng;
        GMapOverlay markers = new GMapOverlay("markers");
  
        public FormMap()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            gMapControl1.ShowCenter = false;
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.SetPositionByKeywords("Vietnam, Ho Chi Minh, Thu Duc, Su pham ky thuat");
            markers.Markers.Clear();
            gMapControl1.Overlays.Clear();

            gMapControl1.Overlays.Add(markers);
        }

        private void gMapControl1_Click(object sender, EventArgs e)
        {
           

        }

        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {          
            if (e.Button != MouseButtons.Left)
                return;
            markers.Markers.Clear();
            PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

            GMapMarker mk = new GMarkerGoogle(point,
                        GMarkerGoogleType.red);
            markers.Markers.Add(mk);
            Lat = point.Lat;
            Lng = point.Lng;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isOK = true;
            Close();
        }

        private void FormMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isOK)
            {
                Lat = 0;
                Lng = 0;
            }
        }

        private void FormMap_Load(object sender, EventArgs e)
        {
           
        }
       
    }
}
