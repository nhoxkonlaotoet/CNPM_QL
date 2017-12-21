using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CNPM
{
    public partial class FormMap : Form
    {
        public bool isOK;
        public string address;
        public double Lat, Lng;
        GMapOverlay markers = new GMapOverlay("markers");
  
        public FormMap()
        {
            InitializeComponent();
            init();
            
        }
        public FormMap(double Lat, double Lng)
        {
            InitializeComponent();
            init();
            this.Lat = Lat;
            this.Lng = Lng;

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
            PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
            getAddressFromPoint(point);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isOK = true;
            Close();
        }
        void getAddressFromPoint(PointLatLng point)
        {
            markers.Markers.Clear();
           

            GMapMarker mk = new GMarkerGoogle(point,
                        GMarkerGoogleType.red);
            markers.Markers.Add(mk);
            Lat = point.Lat;
            Lng = point.Lng;
            List<Placemark> plc = null;
            var st = GMapProviders.GoogleMap.GetPlacemarks(point, out plc);
            if (st == GeoCoderStatusCode.G_GEO_SUCCESS && plc != null)
            {
                txtAddress.Text = plc[0].Address;
            }
            else
                txtAddress.ResetText();
        }


        private void FormMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isOK)
            {
                Lat = 0;
                Lng = 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text != "")
                gMapControl1.SetPositionByKeywords(txtAddress.Text.Trim());
            PointLatLng point = gMapControl1.Position;
            gMapControl1_MouseDown(gMapControl1, new MouseEventArgs(MouseButtons.Left, 1, gMapControl1.Size.Width / 2, gMapControl1.Size.Height / 2, 0));
        }

        private void FormMap_Load(object sender, EventArgs e)
        {
            if (Lat != 0 && Lng != 0)
            {
                MessageBox.Show(Lat + "   " + Lng);
                getAddressFromPoint(new PointLatLng(Lat, Lng));
            }
        }

    }
}
