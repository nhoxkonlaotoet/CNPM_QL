using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.DB_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLController
    {
        DBMain db;
        public BLController()
        {
            db = new DBMain();
        }
        // danh sách đơn hàng chưa giao
        public DataTable Orders()
        {
            string sqlString = "select MaDH, Lat,Lng from DonHang, KhachHang where DonHang.MaKH=KhachHang.MaKH and TrangThai=N'Đã gửi'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        // danh sách nhân viên rảnh
        public DataTable Employees()
        {
            string sqlString = "select MaNV, HoTen from NhanVien where TrangThai =N'Rảnh'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        // thông tin của đơn hàng
        public DataTable GetOrder(string orderId)
        {
            string sqlString = @"select MaDH, ThoiDiemDatHang, HoTen,DiaChi,Lat,Lng, SoDienThoai, TongSoTien 
                                    from DonHang, KhachHang 
                                    where DonHang.MaKH=KhachHang.MaKH and MaDH='" + orderId+"'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        // chi tiết của đơn hàng
        public DataTable GetDetail(string orderId)
        {
            string sqlString = @"select SanPham.MaSP, TenLoai as TenSanPham, DungTich, Gia
                                from ChiTietDonHang,SanPham,LoaiSanPham 
                                where ChiTietDonHang.MaSP=SanPham.MaSP 
		                        and SanPham.MaLoai=LoaiSanPham.MaLoai and MaDH='" + orderId + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool InsertTransport(string empId, string orderId, DateTime time, ref string err)
        {
            string sqlString = "Insert into GiaoHang values('" + orderId + "', '" + empId + "', '" + time.ToString("MM/dd/yyyy HH:mm:ss") + "');";
            sqlString += "Update DonHang set TrangThai=N'Đã giao' where MaDH='" + orderId + "';";
            sqlString += "Update NhanVien set TrangThai=N'Đang giao hàng' where MaNV='" + empId + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
