using GMap.NET;
using GMap.NET.MapProviders;
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
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace CNPM
{
    public partial class FormDelivery : Form
    {
        List<object> lstOrderbyEmp;
        string emp_id;
       
        public FormDelivery()
        {
            InitializeComponent();
        }

        private void FormController_Load(object sender, EventArgs e)
        {
            gMapControl1.ShowCenter = false;
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.SetPositionByKeywords("Vietnam, Ho Chi Minh, Thu Duc, Su pham ky thuat");
            LoadData();



        }
        void LoadData()
        {
            BLDelivery db = new BLDelivery();
            DataTable dtorder = db.Orders();
            lbOrder.Items.Clear();
            lbEmpOrder.Items.Clear();
            lstOrderbyEmp = new List<object>();

            for (int i = 0; i < dtorder.Rows.Count; i++)
                lbOrder.Items.Add(dtorder.Rows[i]["MaDH"].ToString().Trim());
            DataTable dtemp = db.Employees();
            cboFreeEmployee.DataSource = dtemp;
            cboFreeEmployee.DisplayMember = "HoTen";
            cboFreeEmployee.ValueMember = "MaNV";
            // tạo 1 danh sách chứa: mã nv + danh sách đơn hàng tạm thời của nv đó  
            for (int i = 0; i < dtemp.Rows.Count; i++)
            {
                var ob = new
                {
                    emp_id = dtemp.Rows[i]["MaNV"].ToString().Trim(),
                    lstOrders = new List<string>()
                };
                lstOrderbyEmp.Add(ob);
            }
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Clear();
            gMapControl1.Overlays.Clear();
            int n = dtorder.Rows.Count;
            GMapMarker[] mks = new GMapMarker[n];
            for (int i = 0; i < n; i++)
            {
                mks[i] = new GMarkerGoogle(new PointLatLng(double.Parse(dtorder.Rows[i]["Lat"].ToString()),
                                                            double.Parse(dtorder.Rows[i]["Lng"].ToString())),
                                            GMarkerGoogleType.green);
                mks[i].Tag = dtorder.Rows[i]["MaDH"].ToString();
                markers.Markers.Add(mks[i]);
                mks[i].ToolTipText = dtorder.Rows[i]["MaDH"].ToString().Trim();
                mks[i].ToolTipMode = MarkerTooltipMode.Always;
            }
            gMapControl1.Overlays.Add(markers);
        }

        private void cboFreeEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)cboFreeEmployee.SelectedItem;
                emp_id = drv.Row.ItemArray[0].ToString().Trim();
                // lấy đc item chứa mã nv đang đc chọn trong combobox và danh sách mã đơn hàng của nv đó
                dynamic ob = lstOrderbyEmp
                                         .Where(a => a.GetType().GetProperty("emp_id").GetValue(a).ToString() == emp_id)
                                         .First();
                // hiển thị các đơn hàng tạm thời trong listbox danh sách đơn hàng của nv
                lbEmpOrder.Items.Clear();
                for (int i = 0; i < ob.lstOrders.Count; i++)
                    lbEmpOrder.Items.Add(ob.lstOrders[i]);
            }
            catch { }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (lbOrder.SelectedIndex < 0)
                return;
            // lấy đc item chứa mã nv đang đc chọn trong combobox và danh sách mã đơn hàng của nv đó
            dynamic ob = lstOrderbyEmp
                                        .Where(a => a.GetType().GetProperty("emp_id").GetValue(a).ToString() == emp_id)
                                        .First();
            //int indexOfob = lstOrderbyEmp.IndexOf(ob);
            ((List<string>)ob.lstOrders).Add(lbOrder.SelectedItem.ToString());
            //var lob=(lstOrderbyEmp.Select(n => n.GetType().GetProperty("emp_id").GetValue(n))).Where(m => m.ToString() == emp_id).First();
            lbEmpOrder.Items.Add(lbOrder.SelectedItem);
            lbOrder.Items.Remove(lbOrder.SelectedItem);


            var ob1 = lstOrderbyEmp
                                .Select(a => a.GetType().GetProperty("lstOrders").GetValue(a));



        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lbEmpOrder.SelectedIndex < 0)
                return;
            // lấy đc item chứa mã nv đang đc chọn trong combobox và danh sách mã đơn hàng của nv đó
            dynamic ob = lstOrderbyEmp
                                        .Where(a => a.GetType().GetProperty("emp_id").GetValue(a).ToString() == emp_id)
                                        .First();
            ((List<string>)ob.lstOrders).Remove(lbEmpOrder.SelectedItem.ToString());
            lbOrder.Items.Add(lbEmpOrder.SelectedItem);
            lbEmpOrder.Items.Remove(lbEmpOrder.SelectedItem);
        }

        private void lbOrder_Click(object sender, EventArgs e)
        {
            lbEmpOrder.SelectedIndex = -1;
        }

        private void lbEmpOrder_Click(object sender, EventArgs e)
        {
            lbOrder.SelectedIndex = -1;
        }
        void LoadDetail(int orderId)
        {
            BLDelivery db = new BLDelivery();
            DataTable dtorder = db.GetOrder(orderId);
            if (dtorder.Rows.Count == 0) return;
            txtOrderId.Text = dtorder.Rows[0]["MaDH"].ToString().Trim();
            txtDate.Text = dtorder.Rows[0]["ThoiDiemDatHang"].ToString();
            txtCustName.Text = dtorder.Rows[0]["HoTen"].ToString();
            txtAddress.Text = dtorder.Rows[0]["DiaChi"].ToString();
            txtPhoneNumber.Text = dtorder.Rows[0]["SoDienThoai"].ToString();
            txtCost.Text = dtorder.Rows[0]["TongSoTien"].ToString();
            dgvDetail.DataSource = db.GetDetail(orderId);

        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            getAddress(item, false);
            string orderId = item.ToolTipText;
            lbOrder.SelectedIndex = lbOrder.FindString(orderId);
            if (lbOrder.SelectedIndex < 0)
                if (Emp(orderId) != null)
                {
                    cboFreeEmployee.SelectedValue = Emp(orderId);
                    lbEmpOrder.SelectedIndex = lbEmpOrder.FindString(orderId);
                }
        }

        void getAddress(GMapMarker item, bool isNew)
        {
            PointLatLng point = item.Position;
            List<Placemark> plc = null;
            var st = GMapProviders.GoogleMap.GetPlacemarks(point, out plc);

            if (st == GeoCoderStatusCode.G_GEO_SUCCESS && plc != null)
            {
                //MessageBox.Show(item.Tag.ToString());
                //MessageBox.Show(plc.First().Address.ToString());

            }
        }

     
        // lấy mã nv đang giữ đơn hàng
        string Emp(string orderId)
        {
            foreach (var o in lstOrderbyEmp)
            {
                int i = ((List<string>)(o.GetType().GetProperty("lstOrders").GetValue(o))).IndexOf(orderId);
                if (i != -1)
                {
                    return o.GetType().GetProperty("emp_id").GetValue(o).ToString();
                }
            }
            return null;
        }
        private void lbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbOrder.SelectedItem != null)
            {
                lbEmpOrder.SelectedIndex = -1;
                LoadDetail(int.Parse(lbOrder.SelectedItem.ToString()));
            }
        }
        private void lbEmpOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEmpOrder.SelectedItem != null)
            {
                lbOrder.SelectedIndex = -1;
                LoadDetail(int.Parse(lbEmpOrder.SelectedItem.ToString()));
            }
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            dynamic ob = lstOrderbyEmp
                                       .Where(a => a.GetType().GetProperty("emp_id").GetValue(a).ToString() == emp_id)
                                       .First();
            List<string> orders = (List<string>)ob.lstOrders;
            if(orders.Count==0)
            {
                MessageBox.Show("Không có đơn hàng!");
                return;
            }
            BLDelivery db = new BLDelivery();
            string err = "";

            foreach (string order in orders)
                if (!db.InsertTransport(int.Parse(emp_id),int.Parse( order), DateTime.Now, ref err))
                {
                    MessageBox.Show("Giao hàng thất bại: \r\n" + err);
                    return;
                }
            MessageBox.Show("Đã giao");
            OnLoad(e);
        }
    }
}
