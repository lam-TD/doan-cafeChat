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

        public static DataTable CTHD_LoadTheoMaHD(string mahd)
        {
            DataTable dt = conn.getTable("EXEC CTHD_Load_IDHoaDon @hd_ma = '"+ mahd +"'");
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

        public static DataTable CTHD_KiemTraThucUongCoTrongCTHD(int mathucuong, string mahd)
        {
            return conn.getTable("EXEC CTHD_KiemTraThucUongCoTrongCTHD " + mathucuong + ",'" + mahd + "'");
        }

        public static List<ChiTietHoaDonDTO> CTHD_List(string mahd)
        {
            DataTable dt = CTHD_LoadTheoMaHD(mahd);
            List<ChiTietHoaDonDTO> list = new List<ChiTietHoaDonDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                cthd.Tu_id = int.Parse(dt.Rows[i]["tu_id"].ToString());
                cthd.Hd_ma = dt.Rows[i]["hd_id"].ToString();
                cthd.Cthd_soluong = int.Parse(dt.Rows[i]["cthd_soluong"].ToString());
                list.Add(cthd);
            }
            return list;
        }

    }
}
