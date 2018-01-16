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

        public static DataTable Load_TaiKhoan()
        {
            string query = "EXEC TaiKhoan_Load";
            DataTable dt = conn.getTable(query);
            return dt;
        }
    }
}
