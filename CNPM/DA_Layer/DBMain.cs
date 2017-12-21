using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.DA_Layer
{
    public class DBMain
    {
        public static string server;
        string strConnectionString = @"Server= "+server+@"; 
                                        Database=QuanLyBanNuoc; 
                                        User=abcdef; Password=123456";

        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DBMain()
        {
       
            conn = new SqlConnection(strConnectionString);
            comm = conn.CreateCommand();
        }
        public void Connect(ref string state)
        {//kiểm tra kết nối, nếu kết nối thành công thì trạng thái là "Open"
         // ngược lại là "Closed"
            if (conn.State == ConnectionState.Open)
                conn.Close();
            try { conn.Open(); }
            catch { }
            state = conn.State.ToString();
        }


        public DataSet ExecuteQueryDataSet(string strSQl, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQl;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public bool MyExecuteNonQuery1(string strSQL, string column, byte[] bytearr, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            comm.Parameters.Add(column, SqlDbType.VarBinary, bytearr.Length).Value = bytearr;
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }

            finally
            {
                conn.Close();
            }
            return f;
        }
    }
}
