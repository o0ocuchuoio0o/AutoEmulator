using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;


namespace DaoAuto
{
    public class da_SQLlite
    {
        public static SQLiteConnection hamketnoisql()
        {
            return new SQLiteConnection("Data Source=AutoF.sqlite;Version=3;");
        }


        public DataTable DanhSachTK(SQLiteConnection conn)
        {
            DataSet ds = new DataSet();
            conn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from tbl_taikhoan", conn);          
            try
            {
              
                da.Fill(ds, "DanhSach");
                return ds.Tables["DanhSach"];
            }
            catch
            {
                throw;
            }
            finally
            {               
                conn.Close();
                conn.Dispose();
            }           
        }
        public void ThemTK(SQLiteConnection conn, string Email, string Pass, string EmailKhoiPhuc,string DienThoai, string Proxy)
        {
            conn.Open();
            string caulenh = "";
            SQLiteCommand cmd = new SQLiteCommand(caulenh, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 72000;
            try
            {
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Pass", Pass);
                cmd.Parameters.AddWithValue("@EmailKhoiPhuc", EmailKhoiPhuc);
                cmd.Parameters.AddWithValue("@DienThoai", DienThoai);
                cmd.Parameters.AddWithValue("@Proxy", Proxy);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

        }
        public void SuaTK(SQLiteConnection conn, string Email, string Pass, string EmailKhoiPhuc, string DienThoai, string Proxy)
        {
            conn.Open();
            string caulenh = "";
            SQLiteCommand cmd = new SQLiteCommand(caulenh, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 72000;
            try
            {
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Pass", Pass);
                cmd.Parameters.AddWithValue("@EmailKhoiPhuc", EmailKhoiPhuc);
                cmd.Parameters.AddWithValue("@DienThoai", DienThoai);
                cmd.Parameters.AddWithValue("@Proxy", Proxy);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

        }
    }
}
