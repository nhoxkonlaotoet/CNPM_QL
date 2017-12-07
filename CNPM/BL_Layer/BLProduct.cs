using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM.DB_Layer;
using System.Data;

namespace CNPM.BL_Layer
{
    public class BLProduct
    {
        DBMain db;
        public BLProduct()
        {
            db = new DBMain();
        }
        public DataTable Products()
        {
            string sqlString = @"select MaSP, LoaiSanPham.MaLoai, TenLoai as TenSanPham, DungTich, Gia, TrangThai, NgaySanXuat, HanSuDung
                                from sanpham, loaisanpham 
                                where sanpham.maloai=loaisanpham.maloai";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable TypeSource()
        {
            string sqlString = @"select MaLoai, TenLoai from LoaiSanPham";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable getType(int typeId)
        {
            string sqlString = @"select TenLoai, DungTich, Gia, Hinh from LoaiSanPham where MaLoai="+ typeId;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public bool InsertProduct(string status, int typeId, string manufactureDate, string expireDate, ref string err)
        {
            string sqlString = @"insert into SanPham values(N'"+status+"', "+typeId+", '"+manufactureDate+"', '"+expireDate+"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool UpdateProduct(int id, string status, int typeId, string manufactureDate, string expireDate, ref string err)
        {
            string sqlString = @"update SanPham set TrangThai =N'" + status + "', MaLoai= " + typeId + ", NgaySanXuat='" 
                            + manufactureDate + "', HanSuDung= '" + expireDate + "' where MaSP="+id;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool DeleteProduct(int id, ref string err)
        {
            string sqlString = @"delete from SanPham where MaSP=" + id;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool InsertProductType(string typeName, float capacity, int price, byte[] image, ref string err)
        {
            string sqlString = @"Insert into LoaiSanPham values(N'" + typeName + "', " + capacity + ", " + price + ", @Hinh)";
            return db.MyExecuteNonQuery1(sqlString, "@Hinh", image, CommandType.Text, ref err);
        }
        public bool UpdateProductType(int id, string typeName, float capacity, int price, byte[] image, ref string err)
        {
            string sqlString = @"Update LoaiSanPham set TenLoai= N'" + typeName + "', DungTich=" 
                        + capacity + ", Gia=" + price + ", Hinh=@Hinh where MaLoai="+id;
            return db.MyExecuteNonQuery1(sqlString, "@Hinh", image, CommandType.Text, ref err);
        }
        public bool DeleteProductType(int typeId, ref string err)
        {
            string sqlString = @"Delete from LoaiSanPham where MaLoai=" + typeId ;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool UpdateImage(int  typeId, byte[] image, ref string err)
        {
            string sqlString = @"Update LoaiSanPham set Hinh=@Hinh where MaLoai=" + typeId;
            return db.MyExecuteNonQuery1(sqlString, "@Hinh", image, CommandType.Text, ref err);
        }
    }
}
