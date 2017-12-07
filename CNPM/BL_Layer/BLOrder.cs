using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.DB_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLOrder
    {
        DBMain db;
        public BLOrder()
        {
            db = new DBMain();
        }
        public DataTable Orders()
        {
            string sqlString = @"Select * from DonHang";
            return db.ExecuteQueryDataSet(sqlString, System.Data.CommandType.Text).Tables[0];
        }
        public DataTable Detail(string orderId)
        {
            string sqlString = @"Select * from ChiTietDonHang where MaDH='" + orderId + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool Insert(string id, string date, int cost, string empId, string status, ref string err)
        {
            string sqlString = "Insert into DonHang values('" + id + "', '" + date + "', " + cost + ", '" + empId + "', N'" + status + "');";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text,ref err);
        }
        public bool Update(string id, string date, int cost, string empId, string status, ref string err)
        {
            string sqlString = "Update DonHang set ThoiDiemDatHang='" + date + "',TongSoTien= " + cost + ",MaKH= '" + empId + "',TrangThai= N'" + status + "' where MaDH='"+id+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool Delete(string id, ref string err)
        {
            string sqlString = "Delete from DonHang where MaDH='" + id + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool InsertDetail(string orderId, string productId, int price, ref string err)
        {
            string sqlString= "Insert into ChiTietDonHang values('"+orderId+"', '"+productId+"', "+price+");";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool DeleteDetail(string orderId, string productId, ref string err)
        {
            string sqlString = "delete from ChiTietDonHang where MaDH='"+orderId+"' and MaSP='"+productId+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataTable Customers()
        {
            string sqlString = @"Select MaKH, HoTen from Khachhang";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable FreeEmployees()
        {
            string sqlString = @"Select MaNV, HoTen from NhanVien where TrangThai=N'Rảnh'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        
    }
}
