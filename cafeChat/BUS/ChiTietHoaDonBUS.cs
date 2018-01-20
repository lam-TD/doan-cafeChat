using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        private static Connect conn = new Connect();

        public static DataTable CTHD_Load()
        {
            DataTable dt = conn.getTable("EXEC Ban_Load");
            return dt;
        }

        public static DataTable CTHD_Load_DonGia_TinhThanhTien(string mahd)
        {
            return conn.getTable("EXEC CTHD_Load_DonGia_TinhThanhTien '" + mahd + "'");
        }

        public static bool CTHD_ThemXoaSuaHuyBan(ChiTietHoaDonDTO cthd, int type)
        {
            string query = "";
            try
            {
                switch (type)
                {
                    case 1:
                        query = "EXEC CTHD_Them "+ cthd.Cthd_soluong +",'"+ cthd.Hd_ma +"',"+ cthd.Tu_id +"";
                        break;
                    case 2:
                        query = "EXEC CTHD_Sua " + cthd.Cthd_soluong + ",'" + cthd.Hd_ma + "'," + cthd.Tu_id + "";
                        break;
                    case 3:
                        query = "EXEC CTHD_Xoa '" + cthd.Hd_ma + "'," + cthd.Tu_id + "";
                        break;
                    case 4:
                        query = "EXEC CTHD_HuyBan '"+ cthd.Hd_ma +"'";
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
