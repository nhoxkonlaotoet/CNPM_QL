using System;
using CNPM.DA_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLDelivery
    {
        DBMain db;
        public BLDelivery()
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
        public DataTable GetOrder(int orderId)
        {
            string sqlString = @"select MaDH, ThoiDiemDatHang, HoTen,DiaChi,Lat,Lng, SoDienThoai, TongSoTien 
                                    from DonHang, KhachHang 
                                    where DonHang.MaKH=KhachHang.MaKH and MaDH=" + orderId;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        // chi tiết của đơn hàng
        public DataTable GetDetailbyId(int orderId)
        {
            string sqlString = @"select SanPham.MaSP, TenLoai as TenSanPham, DungTich, Gia
                                from ChiTietDonHang,SanPham,LoaiSanPham 
                                where ChiTietDonHang.MaSP=SanPham.MaSP 
		                        and SanPham.MaLoai=LoaiSanPham.MaLoai and MaDH=" + orderId;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable GetDetailbyNumber(int orderId)
        {
            string sqlString = @"select TenLoai as TenSanPham, count(SanPham.MaSP) as SoLuong,Gia as DonGia, sum(Gia) as ThanhTien
                                from ChiTietDonHang,SanPham, LoaiSanPham 
                                where ChiTietDonHang.MaSP=SanPham.MaSP and SanPham.MaLoai=LoaiSanPham.MaLoai and MaDH=" + orderId +
                               "group by LoaiSanPham.MaLoai, TenLoai, Gia";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool InsertDelivery(int empId, int orderId, DateTime time, ref string err)
        {
            string sqlString = "Insert into GiaoHang values(" + orderId + ", " + empId + ", '" + time.ToString("MM/dd/yyyy HH:mm:ss") + "');";
            sqlString += "Update DonHang set TrangThai=N'Đang chuyển' where MaDH=" + orderId + ";";
            sqlString += "Update NhanVien set TrangThai=N'Giao hàng' where MaNV=" + empId ;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
