using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class DanhMucBUS
    {
        private static Connect conn = new Connect();

        public static DataTable DanhMuc_Load()
        {
            DataTable dt = conn.getTable("EXEC DanhMuc_Load");
            return dt;
        }

        public static List<DanhMucDTO> DanhMuc_List()
        {
            DataTable dt = DanhMuc_Load();
            List<DanhMucDTO> listDanhMuc = new List<DanhMucDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DanhMucDTO dm = new DanhMucDTO();
                dm.Dm_id = int.Parse(dt.Rows[i]["dm_id"].ToString());
                dm.Dm_ten = dt.Rows[i]["dm_ten"].ToString();
                dm.Dm_trangthai = int.Parse(dt.Rows[i]["dm_trangthai"].ToString());
                dm.Dm_ghichu = dt.Rows[i]["dm_ghichu"].ToString();
                listDanhMuc.Add(dm);
            }
            return listDanhMuc;
        }
    }
}
