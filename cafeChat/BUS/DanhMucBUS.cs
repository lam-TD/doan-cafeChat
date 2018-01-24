using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class DanhMucBUS
    {
        private static Connect conn = new Connect();

        public static DataTable DanhMuc_Load()
        {
            DataTable dt = conn.getTable("EXEC DanhMuc_Load");
            return dt;
        }

        public static bool DanhMuc_ThemSuaXoa(DanhMucDTO dm, int type)
        {
            string query = "";
            switch (type)
            {
                case 1:
                    query = "EXEC DanhMuc_Them N'" + dm.Dm_ten + "'," + dm.Dm_trangthai + ",N'" + dm.Dm_ghichu + "'";
                    break;
                case 2:
                    query = "EXEC DanhMuc_Sua " + dm.Dm_id + ",N'" + dm.Dm_ten + "'," + dm.Dm_trangthai + ",'" + dm.Dm_ghichu + "'";
                    break;
                case 3:
                    query = "EXEC DanhMuc_Xoa " + dm.Dm_id + "";
                    break;
            }
            if (conn.ExcuteQuery(query))
                return true;
            else
                return false;
        }

        public static List<DanhMucDTO> DanhMuc_List()
        {
            DataTable dt = DanhMuc_Load();
            List<DanhMucDTO> listDanhMuc = new List<DanhMucDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DanhMucDTO dm = new DanhMucDTO();
                dm.Dm_id = int.Parse(dt.Rows[i]["dm_id"].ToString());
                dm.Dm_ten = dt.Rows[i]["dm_ten"].ToString();
                dm.Dm_trangthai = int.Parse(dt.Rows[i]["dm_trangthai"].ToString());
                dm.Dm_ghichu = dt.Rows[i]["dm_ghichu"].ToString();
                listDanhMuc.Add(dm);
            }
            return listDanhMuc;
        }
    }
}
