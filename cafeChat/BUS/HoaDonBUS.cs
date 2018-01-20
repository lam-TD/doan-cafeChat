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
    }
}
