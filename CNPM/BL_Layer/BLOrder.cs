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
        // đơn hàng
        public DataTable Orders()
        {
            string sqlString = @"Select * from DonHang";
            return db.ExecuteQueryDataSet(sqlString, System.Data.CommandType.Text).Tables[0];
        }
      
        public bool Insert(string date, int cost, int cusId, string status, ref string err)
        {
            string sqlString = "Insert into DonHang values('" + date + "', " + cost + ", " + cusId + ", N'" + status + "');";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text,ref err);
        }

        public bool Insert(string date, int cost, int cusId, int EmpId, string status, ref string err)
        {
            string sqlString = "Insert into DonHang values('" + date + "', " + cost + ", " + cusId + ", N'" + status + "');";
            if (!db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err))
                return false;
            sqlString = "Insert into GiaoHang values(" + RecentlyOrderId(cusId) + ", " + EmpId + ", '" + date + "');";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        int RecentlyOrderId(int cusId)
        {
            string sqlString = @"select MaDH from DonHang,(select MaKH, max(ThoiDiemDatHang) as ThoiGian 
                                                            from DonHang where MaKH="+cusId+@" group by MaKH)as A
                                where DonHang.MaKH = A.MaKH and DonHang.ThoiDiemDatHang = A.ThoiGian";
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["MaDH"].ToString());
            return -1;
        }
        public bool Update(int id, string date, int cost, int cusId, string status, ref string err)
        {
            string sqlString = "Update DonHang set ThoiDiemDatHang='" + date + "',TongSoTien= " + cost + ",MaKH= " + cusId + ",TrangThai= N'" + status + "' where MaDH="+id;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool Delete(int id, ref string err)
        {
            string sqlString = "Delete from DonHang where MaDH=" + id;
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

        public int TransportedId(int orderId)
        {
            string sqlString = @"select MaNV from GiaoHang where MaDH="+orderId;
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["MaNV"].ToString());
            return -1;
        }





        // chi tiết
        public DataTable Detail(int orderId)
        {
            string sqlString = @"select LoaiSanPham.MaLoai, TenLoai, count(SanPham.MaSP) as SoLuong,Gia as DonGia, sum(Gia) as ThanhTien
                                from ChiTietDonHang,SanPham, LoaiSanPham 
                                where ChiTietDonHang.MaSP=SanPham.MaSP and SanPham.MaLoai=LoaiSanPham.MaLoai and MaDH=" + orderId +
                                "group by LoaiSanPham.MaLoai, TenLoai, Gia";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }

        public bool InsertDetail(int orderId, int productId, int price, ref string err)
        {
            string sqlString= "Insert into ChiTietDonHang values("+orderId+", "+productId+", "+price+");";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool DeleteDetail(int orderId, int productId, ref string err)
        {
            string sqlString = "delete from ChiTietDonHang where MaDH="+orderId+" and MaSP="+productId;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataTable ProductType()
        {
            string sqlString = "select TenLoai, MaLoai  from LoaiSanPham";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public int Available(int TypeId)
        {
            string sqlString = @"select count(*) as ConLai
                                from SanPham, LoaiSanPham 
                                where SanPham.MaLoai=LoaiSanPham.MaLoai 
                                    and TrangThai=N'Còn' 
                                    and LoaiSanPham.MaLoai=" + TypeId;
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
                    return int.Parse(dt.Rows[0]["ConLai"].ToString());
            return -1;
        }
        
    }
}
