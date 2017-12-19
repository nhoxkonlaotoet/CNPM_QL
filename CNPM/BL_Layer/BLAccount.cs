using CNPM.DB_Layer;
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
    }
}
