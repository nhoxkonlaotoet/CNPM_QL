using System.Data;
using CNPM.DA_Layer;
namespace CNPM.BL_Layer
{
    public class BLSalary
    {
        DBMain db;
        public BLSalary()
        {
            db = new DBMain();
        }
        public DataTable Salaries(int year)
        {
            string sqlString = @"select TienCong.MaNV, HoTen, MaHD, SoTien, Ngay 
                                from tiencong, nhanvien 
                                where TienCong.MaNV=NhanVien.MaNV
                                and YEAR(Ngay)="+year;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable Salaries(int year, int month)
        {
            string sqlString = @"select TienCong.MaNV, HoTen, MaHD, SoTien, Ngay 
                                from tiencong, nhanvien 
                                where TienCong.MaNV=NhanVien.MaNV
                                and YEAR(Ngay)="+year+" and MONTH(Ngay)="+month;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool Clear(ref string err)
        {
            string sqlString = @"delete from TienCong";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
