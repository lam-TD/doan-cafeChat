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

        public static DataTable Ban_Load_TrangThai_Xoa()
        {
            return conn.getTable("EXEC Ban_Load_TrangThai_DaXoa");
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

        public static string Ban_KiemTra_TrangThai_TheoIDBan(string maban)
        {
            DataTable dt = conn.getTable("EXEC Ban_KiemTraTrangThai_TheoIdBan '" + maban + "'");
            return dt.Rows[0]["ban_trangthai"].ToString();
        }

        public static bool Ban_CapNhatTrangThaiBan(string maban, string trangthai)
        {
            try
            {
                if (conn.ExcuteQuery("EXEC Ban_CapNhatTrangThaiBan " + maban + ",N'" + trangthai + "'"))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static DataTable Ban_Load_LoaiTru1BanTrung_TrangThaiCoKhach(string maban)
        {
            return conn.getTable("Ban_Load_LoaiTru1BanTrung_TrangThaiCoKhach '" + maban + "'");
        }

        public static DataTable Ban_LoadBanTheoTrangThai(string trangthai)
        {
            return conn.getTable("EXEC Ban_Load_TrangThai N'"+ trangthai +"'");
        }

        public static bool Ban_ThemSuaXoa(BanDTO b, int type)
        {
            string query = "";
            switch (type)
            {
                case 1:
                    query = "EXEC Ban_Them '" + b.Ban_id + "',N'" + b.Ban_ten + "',N'" + b.Ban_trangthai + "'," + b.Kv_id + "," + b.Ban_xoa + "";
                    break;
                case 2:
                    query = "EXEC Ban_Sua '" + b.Ban_id + "',N'" + b.Ban_ten + "',N'" + b.Ban_trangthai + "'," + b.Kv_id + "";
                    break;
                case 3:
                    query = "EXEC Ban_Xoa '" + b.Ban_id + "'";
                    break;
            }
            if (conn.ExcuteQuery(query))
                return true;
            else
                return false;
        }

        public static bool Ban_KiemTraBanTrungTen(string tenban)
        {
            DataTable dt = conn.getTable("EXEC Ban_KiemTraTenBanTrung N'"+tenban+"'");
            if (dt.Rows.Count > 0)
                return true;
            else return false;
        }

        public static string Ban_TimMaBanKeTiep()
        {
            return conn.TimIDKeTiep("b");
        }
    }
}
