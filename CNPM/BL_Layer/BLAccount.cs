using CNPM.DA_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLAccount
    {
        DBMain db = new DBMain();
        public BLAccount()
        {
            db = new DBMain();
        }

        public DataTable Accounts()
        {
            string sqlString = @"select SDT,HoTen as ChuSoHuu, QuyenHan, TinhTrang, NgayKichHoat 
from TaiKhoan left outer join (select SoDienThoai, HoTen 
                                from NhanVien 
                                union 
                                select SoDienThoai, HoTen  
                                from KhachHang)as A on TaiKhoan.SDT=A.SoDienThoai order by QuyenHan";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }

        public DataTable GetAccount(string phoneNumber)
        {
            string sqlString = "select * from TaiKhoan where SDT='" + phoneNumber + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool Insert(string id, string password, string role, string status, string date, ref string err)
        {
            string sqlString = "insert into TaiKhoan values('"+id+"', '"+password+"', N'"+role+"', N'"+status+"','"+date+"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text,ref err);
        }
        public bool Update(string id, string password, string role, string status, string date, ref string err)
        {
            string sqlString;
            if (date!=null)
                sqlString = "update TaiKhoan set MatKhau='" + password + "', QuyenHan=N'" + role + "', TinhTrang=N'" + status + "', NgayKichHoat='" + date + "' where SDT='" + id + "'";
            else
                sqlString = "update TaiKhoan set MatKhau='" + password + "', QuyenHan=N'" + role + "', TinhTrang=N'" + status + "' where SDT='" + id + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool Delete(string id, ref string err)
        {
            string sqlString = @"delete from taikhoan where sdt='" + id + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataTable Owners(string role)
        {
            string sqlString = @"if N'"+role+ @"'=N'Khách'
	select MaKH as Ma , KhachHang.SoDienThoai, HoTen from KhachHang left outer join TaiKhoan on KhachHang.SoDienThoai=TaiKhoan.SDT where TaiKhoan.SDT is null
else if N'" + role+ @"' = N'Nhân viên'
	select MaNV as Ma, NhanVien.SoDienThoai, HoTen from NhanVien left outer join TaiKhoan on NhanVien.SoDienThoai=TaiKhoan.SDT where TaiKhoan.SDT is null";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];

        }
        public DataTable AvailableOwners(string role)
        {
            string sqlString = @"if N'" + role + @"'=N'Khách'
	select MaKH as Ma , KhachHang.SoDienThoai, HoTen from KhachHang left outer join TaiKhoan on KhachHang.SoDienThoai=TaiKhoan.SDT where TaiKhoan.SDT is not null
else if N'" + role + @"' = N'Nhân viên'
	select MaNV as Ma, NhanVien.SoDienThoai, HoTen from NhanVien left outer join TaiKhoan on NhanVien.SoDienThoai=TaiKhoan.SDT where TaiKhoan.SDT is not null";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];

        }
        public string Password(string id)
        {
            string sqlString =@"select matkhau from taikhoan where SDT='"+id+"'";
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            else
                return null;
        }
    }
}
