using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connect
    {
        private SqlConnection conn;
        public Connect()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-V6OACE7;Initial Catalog=CafeDataBase;Integrated Security=True");
            conn.Open();
        }

        public DataTable getTable(string sql) //load du lieu tra ve la mot table
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ExcuteQuery(string sql) // kiem tra truy van
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string TimIDKeTiep(string type)
        {
            //-- b tim id ke tiep cua table Ban
            //-- hd tim id ke tiep cua table HoaDon
            //-- nv tim id ke tiep cua table NhanVien
            if (ExcuteQuery("EXEC TimIDKeTiep '" + type + "'"))
            {
                string id = "";
                DataTable dt = getTable("EXEC LayIDKeTiep");
                switch (type)
                {
                    case "b":
                        id = dt.Rows[0]["ban_id"].ToString();
                        break;
                    case "hd":
                        id = dt.Rows[0]["hd_id"].ToString();
                        break;
                    case "nv":
                        id = dt.Rows[0]["nv_id"].ToString();
                        break;
                }
                return id;
            }
            else
                return "null";
        }
    }
}
