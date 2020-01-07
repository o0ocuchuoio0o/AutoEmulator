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

    }
}
