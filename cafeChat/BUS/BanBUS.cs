using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BanBUS
    {
        private static Connect conn = new Connect();

        public static DataTable Ban_Load()
        {
            DataTable dt = conn.getTable("EXEC Ban_Load");
            return dt;
        }

        public static List<BanDTO> Ban_List()
        {
            DataTable dt = Ban_Load();
            List<BanDTO> listBan = new List<BanDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BanDTO ban = new BanDTO();
                ban.Ban_id = dt.Rows[i]["ban_id"].ToString();
                ban.Ban_ten = dt.Rows[i]["ban_ten"].ToString();
                ban.Ban_trangthai = dt.Rows[i]["ban_trangthai"].ToString();
                ban.Kv_id = int.Parse(dt.Rows[i]["kv_id"].ToString());
                listBan.Add(ban);
            }
            return listBan;
        }

        public static List<BanDTO> Ban_List_KhuVuc(int maKhuVuc)
        {
            DataTable dt = conn.getTable("EXEC Ban_Load_KhuVuc "+ maKhuVuc +"");
            List<BanDTO> listBan = new List<BanDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BanDTO ban = new BanDTO();
                ban.Ban_id = dt.Rows[i]["ban_id"].ToString();
                ban.Ban_ten = dt.Rows[i]["ban_ten"].ToString();
                ban.Ban_trangthai = dt.Rows[i]["ban_trangthai"].ToString();
                ban.Kv_id = int.Parse(dt.Rows[i]["kv_id"].ToString());
                listBan.Add(ban);
            }
            return listBan;
        }
    }
}
