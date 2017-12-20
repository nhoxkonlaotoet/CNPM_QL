using CNPM.DA_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    class BLEmployee
    {
        DBMain db;
        public BLEmployee()
        {
            db = new DBMain();
        }
        public DataTable Employees()
        {
            string sqlString = @"select MaNV, HoTen, Tuoi, Nam, CMND, DiaChi, SoDienThoai, TrangThai from nhanvien";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
 
        public bool Insert(string name, int age, int isMale, string address,string ID, string phoneNumber, byte[] img, string status, ref string err)
        {
            string sqlString = "Insert into NhanVien values(N'" + name 
                + "', " + age + "," + isMale + ",N'" + address + "','"+ID+"', '" + phoneNumber + "', @Hinh,N'"+status+"')";
            return db.MyExecuteNonQuery1(sqlString,"@Hinh", img, CommandType.Text, ref err);
        }
        public bool Update(int empId, string name, int age, int isMale, string address,string ID, string phoneNumber, byte[] img, string status, ref string err)
        {
            string sqlString = "Update NhanVien set HoTen=N'" + name
                        + "',Tuoi= " + age + ",Nam=" + isMale + ",DiaChi=N'" + address 
                        + "',CMND='" + ID + "',SoDienThoai= '" + phoneNumber + "',Hinh= @Hinh, TrangThai= N'" + status + "' where MaNV="+empId;
            return db.MyExecuteNonQuery1(sqlString, "@Hinh", img, CommandType.Text, ref err);
        }
        public bool Delete(int empId, ref string err)
        {
            string sqlString = @"delete from NhanVien where MaNV=" + empId;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataTable PhoneNumbers()
        {
            string sqlString = @"select SDT from TaiKhoan where QuyenHan=N'Nhân viên' 
                                except 
                                select SoDienThoai from TaiKhoan, NhanVien 
                                where TaiKhoan.SDT = NhanVien.SoDienThoai";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public byte[] Avatar(int empId)
        {
            string sqlString = @"select Hinh from NhanVien where MaNV=" + empId;
            return (byte[])db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0].Rows[0]["Hinh"];
        }
    }
}
