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
    }
}
