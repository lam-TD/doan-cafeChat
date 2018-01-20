using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace BUS
{
    public class HoaDonBUS
    {
        private static Connect conn = new Connect();

        public static DataTable HoaDon_XacDinh_BanCoHDHayChua(string trangthaiBan, string maban)
        {
            if (trangthaiBan == "Có khách")
                return conn.getTable("EXEC HoaDon_Load_IDBan_TrangThaiHD '" + maban + "'");
            else // trường hợp này là bàn đặt trước và bàn trống
            {
                conn.ExcuteQuery("EXEC TimIDKeTiep 'hd'");
                return conn.getTable("EXEC LayIDKeTiep");
            }
        }

        public static bool HoaDon_ThemXoaSuaHuyBan(HoaDonDTO hd, int type)
        {
            string query = "";
            try
            {
                switch (type)
                {
                    case 1:
                        query = "EXEC HoaDon_Them '" + hd.Hd_id + "','" + hd.Hd_ngaylap + "'," + hd.Hd_trangthai + "," + hd.Hd_phuthu + "," + hd.Hd_giamgia + "," + hd.Hd_tongtien + ",'" + hd.Ban_id + "','" + hd.Nv_id + "'";
                        break;
                    case 2:
                        query = "EXEC HoaDon_Sua '" + hd.Hd_id + "','" + hd.Hd_ngaylap + "'," + hd.Hd_trangthai + "," + hd.Hd_phuthu + "," + hd.Hd_giamgia + "," + hd.Hd_tongtien + ",'" + hd.Ban_id + "','" + hd.Nv_id + "'";
                        break;
                    case 3:
                        query = "EXEC HoaDon_Xoa '" + hd.Hd_id + "'";
                        break;
                    case 4:
                        query = "EXEC HoaDon_HuyBan '" + hd.Hd_id + "'";
                        break;
                }
                if (conn.ExcuteQuery(query))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
