using CNPM.DB_Layer;
namespace CNPM.BL_Layer
{
    public class BLLogin
    {
        DBMain db;
        public BLLogin()
        {
            db = new DBMain();
        }
        public bool Login(string id, string password)
        {
            string sqlstring = @"select count(*) from TaiKhoan where (QuyenHan=N'Admin' or QuyenHan=N'Quản lí') and SDT='" + id + "' and MatKhau='" + password + "'";
            int f = int.Parse(db.ExecuteQueryDataSet(sqlstring, System.Data.CommandType.Text).Tables[0].Rows[0][0].ToString());
            if (f == 1)
                return true;
            return false;
        }
    }
}
