using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BUS
{
    public class HoaDonBUS
    {
        private static Connect conn = new Connect();

        public static string HoaDon_XacDinh_BanCoHDHayChua(string trangthaiBan)
        {
            string mahd = "";
            if (trangthaiBan == "Trống")
                mahd = conn.TimIDKeTiep("hd");
            else

        }
    }
}
