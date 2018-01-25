using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class KhuVucBUS
    {
        private static Connect conn = new Connect();
        public static DataTable KhuVuc_Load()
        {
            DataTable dt = conn.getTable("EXEC KhucVuc_Load");
            return dt;
        }

        public static DataTable KhuVuc_LoadTheoTrangThai(string trangthai)
        {
            DataTable dt = conn.getTable("EXEC KhuVuc_LoadTheoTrangThai N'"+ trangthai +"'");
            return dt;
        }

        public static bool KhuVuc_ThemSuaXoa(KhuVucDTO kv, int type)
        {
            string query = "";
            switch (type)
            {
                case 1:
                    query = "EXEC KhuVuc_Them N'" + kv.Kv_ten + "',N'" + kv.Kv_trangthai + "',N'" + kv.Kv_ghichu + "'";
                    break;
                case 2:
                    query = "EXEC KhuVuc_Sua " + kv.Kv_id + ",N'" + kv.Kv_ten + "',N'" + kv.Kv_trangthai + "',N'" + kv.Kv_ghichu + "'";
                    break;
                case 3:
                    query = "EXEC KhuVuc_Xoa  " + kv.Kv_id + "";
                    break;
            }
            if (conn.ExcuteQuery(query))
                return true;
            else
                return false;
        }

    }
}
