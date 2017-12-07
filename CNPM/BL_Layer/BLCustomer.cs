using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.DB_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLCustomer
    {
        DBMain db;
        public BLCustomer()
        {
            db = new DBMain();
        }
        public DataTable Customers()
        {
            string sqlString = @"Select MaKH, HoTen, Tuoi, Nam, DiaChi, SoDienThoai, Lat,Lng from KhachHang";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        } 
        public DataTable PhoneNumbers()
        {
            string sqlString = @"select SDT from TaiKhoan except select SDT from TaiKhoan where QuyenHan=N'Admin' or QuyenHan=N'Nhân viên' or QuyenHan=N'Quản lí'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public byte[] Avatar(int customerId)
        {
            string sqlString = @"select Hinh from KhachHang where MaKH='"+ customerId+"'";
            return (byte[])db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0].Rows[0]["Hinh"];
        }
        public bool Insert(string name, int age, int isMale, string address, double lat, double lng, string phoneNumber, byte[] image, ref string err)
        {

            string sqlString = "Insert into KhachHang values(N'" + name + "', " + age + "," + isMale + ",N'" + address + "', " 
                                + lat + ", " + lng + ", '" + phoneNumber + "', @Hinh)";
            return db.MyExecuteNonQuery1(sqlString, "@Hinh", image, CommandType.Text, ref err);
        }
        public bool Update(int id, string name, int age, int isMale, string address, double lat, double lng, string phoneNumber, byte[] image, ref string err)
        {

            string sqlString = "Update KhachHang set HoTen=N'" + name + "',Tuoi= " + age + ",Nam=" + isMale + ",DiaChi= N'" + address + "', Lat= "
                                + lat + ", Lng=" + lng + ", SoDienThoai='" + phoneNumber + "',Hinh= @Hinh" + id +" where MaKH='"+id+"'" ;
            return db.MyExecuteNonQuery1(sqlString, "@Hinh" + id, image, CommandType.Text, ref err);
        }
        public bool Delete(int id, ref string err)
        {
            string sqlString = "Delete from KhachHang where MaKH='" + id + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
       
        
    }
}
