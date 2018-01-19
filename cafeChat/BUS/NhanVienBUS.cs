using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class NhanVienBUS
    {
        private static Connect conn = new Connect();

        public static DataTable NhanVien_Load()
        {
            string query = "EXEC NhanVien_Load";
            DataTable dt = conn.getTable(query);
            return dt;
        }
    }
}
