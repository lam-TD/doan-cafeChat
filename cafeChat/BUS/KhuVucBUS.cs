using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class KhuVucBUS
    {
        private static Connect conn = new Connect();
        public static DataTable KhuVuc_Load()
        {
            DataTable dt = conn.getTable("EXEC KhucVuc_Load");
            return dt;
        }
    }
}
