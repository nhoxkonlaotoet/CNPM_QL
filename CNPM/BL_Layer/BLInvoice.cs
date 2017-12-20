using CNPM.DA_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLInvoice
    {
        DBMain db;
        public BLInvoice()
        {
            db = new DBMain();
        }
        public DataTable Invoices()
        {
            string sqlString = @"select MaHD,HoaDon.MaDH,MaKH,MaNV, NgayIn,HoaDon.TongSoTien from HoaDon, DonHang where HoaDon.MaDH=DonHang.MaDH";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool Insert(string date, int cost, int orderId, int empId, ref string err)
        {
            string sqlString = @"insert into HoaDon values('" + date + "', " + cost + ", " + orderId + ", " + empId + ");";
            if (db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err))
            {
                if (RecentlyInvoiceId(empId, orderId, date) != -1)
                {
                    sqlString = "insert into TienCong values(" + empId + ", " + RecentlyInvoiceId(empId, orderId, date) + "," + (float)((float)cost * 0.2) + ", '" + date + "');";
                    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

                }
            }

            return false;
        }
        public int RecentlyInvoiceId(int empId, int orderId, string date)
        {
            string sqlString = @"select MaHD from hoadon where NgayIn ='" + date + "' and MaDH =" + orderId + " and MaNV =" + empId;
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0][0].ToString());
            else return -1;
        }
        public bool Delete(int invoiceId, ref string err)
        {
            string sqlString = @"delete from HoaDon where MaHD=" + invoiceId+";";
            sqlString += @"delete from TienCong where MaHD=" + invoiceId;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public int RecentlyInvoiceId(int orderId)
        {
            string sqlString = "select Max(MaHD)as MaHD from hoadon where MaDH= " + orderId + " and TongSoTien=0";
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0][0].ToString());
            return -1;
        }
        public DataTable NotPaidEnoughOrders()
        {
            string sqlString = @"select MaDH
from (select DonHang.MaDH,DonHang.TongSoTien,  CAST(CASE 
													WHEN HoaDon.TongSoTien is null
								                        THEN 0 
                                                    ELSE HoaDon.TongSoTien
                                                        END AS int ) as DaThanhToan
	from DonHang left outer join HoaDon on DonHang.MaDH=HoaDon.MaDH
	where DonHang.TrangThai=N'Đã nhận')as A
group by MaDH, TongSoTien
having  sum(DaThanhToan) <TongSoTien";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable OrderInfor(int orderId)
        {
            string sqlString = @"select MaKH,TenKhach,MaNV,TenNhanVien
from 	(select DonHang.MaDH, KhachHang.MaKH, KhachHang.HoTen as TenKhach
    from DonHang left outer join KhachHang
    on DonHang.MaKH=KhachHang.MaKH 
    where DonHang.MaDH=" + orderId + @")as DH left outer join
(select MaDH, NhanVien.MaNV, HoTen as TenNhanVien 
from NhanVien,GiaoHang
where NhanVien.MaNV=GiaoHang.MaNV
and MaDH=" + orderId + @")as GH on DH.MaDH=GH.MaDH";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable Detail(int orderId)
        {
            string sqlString = @"select LoaiSanPham.MaLoai, TenLoai, Gia as DonGia, count(A.MaSP) as SoLuong, sum(LoaiSanPham.Gia)as ThanhTien
from SanPham,LoaiSanPham, (select MaDH, MaSP from ChiTietDonHang 
except select MaDH, MaSP from ChiTietHoaDon,HoaDon 
where ChiTietHoaDon.MaHD=HoaDon.MaHD) as A
where A.MaSP=SanPham.MaSP and SanPham.MaLoai=LoaiSanPham.MaLoai and MaDH=" + orderId + @"
group by LoaiSanPham.MaLoai, TenLoai, Gia";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }



        public bool InsertDetail(int invoiceId, int empId, int productId, int price, ref string err)
        {
            string sqlString = @"insert into ChiTietHoaDon values(" + invoiceId + ", " + productId + ", " + price + ");";
            sqlString += @"update HoaDon set TongSoTien = TongSoTien + " + price + " where MaHD=" + invoiceId + ";";
            sqlString += @"Update TienCong set SoTien=SoTien+" + (float)((float)price * 0.2) + "where MaHD=" + invoiceId + " and MaNV=" + empId;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public int UnpaidProductId(int orderId, int typeId)
        {
            string sqlString = @"select top 1 MaSP
from (select ChiTietDonHang.MaSP 
		from ChiTietDonHang,SanPham 
		where  ChiTietDonHang.MaSP=SanPham.MaSP and MaLoai=" + typeId + @" and MaDH=" + orderId + @" 
except select ChiTietHoaDon.MaSP 
		from ChiTietHoaDon, HoaDon, SanPham
		where ChiTietHoaDon.MaHD=HoaDon.MaHD and ChiTietHoaDon.MaSP=SanPham.MaSP and MaLoai=" + typeId + @" and MaDH=" + orderId + @")as A";
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0][0].ToString());
            return -1;
        }
        public string EmpName(int empId)
        {
            string sqlString = @"select HoTen from NhanVien where MaNV=" + empId;
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            else
                return null;
        }
        public string CusName(int cusId)
        {
            string sqlString = @"select HoTen from KhachHang where MaKH=" + cusId;
            DataTable dt = db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            else
                return null;
        }
        public DataTable Detail_Invoice(int invoiceId)
        {
            string sqlString = @"select LoaiSanPham.MaLoai, TenLoai, count(SanPham.MaSP) as SoLuong,Gia as DonGia, sum(Gia) as ThanhTien
from ChiTietHoaDon,SanPham, LoaiSanPham 
where ChiTietHoaDon.MaSP=SanPham.MaSP and SanPham.MaLoai=LoaiSanPham.MaLoai and MaHD=" + invoiceId + @"
group by LoaiSanPham.MaLoai, TenLoai, Gia";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }

    }
}
