using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.DA_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLFeedback
    {
        DBMain db;
        public BLFeedback()
        {
            db = new DBMain();
        }
        public DataTable Feedbacks(int year)
        {
            string sqlString = @"select MaGY, GopY.MaKH, HoTen,NoiDung , Ngay 
                                from GopY, KhachHang 
                                where GopY.MaKH=KhachHang.MaKH and YEAR(Ngay)=" + year;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable Feedbacks(int year,int month)
        {
            string sqlString = @"select MaGY, GopY.MaKH, HoTen,NoiDung , Ngay 
                                from GopY, KhachHang 
                                where GopY.MaKH=KhachHang.MaKH and YEAR(Ngay)=" + year+" and MONTH(Ngay)="+month;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool Clear(ref string err)
        {
            string sqlString = @"delete from GopY";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
