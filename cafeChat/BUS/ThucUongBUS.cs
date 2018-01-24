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
    public class ThucUongBUS
    {
        private static Connect conn = new Connect();

        public static DataTable ThucUong_Load()
        {
            return conn.getTable("EXEC ThucUong_Load"); ;
        }

        public static DataTable ThucUong_Load_IDDanhMuc(int iddanhmuc)
        {
            return conn.getTable("EXEC ThucUong_Load_IDDanhMuc " + iddanhmuc + "");
        }

        public static bool ThucUong_ThemSuaXoa(ThucUongDTO tu, int type)
        {
            string query = "";
            switch (type)
            {
                case 1:
                    query = "EXEC ThucUong_Them " + tu.Tu_id + ",N'" + tu.Tu_ten + "'," + tu.Tu_gia + "," + tu.Tu_trangthai + "," + tu.Dm_id + "";
                    break;
                case 2:
                    query = "EXEC ThucUong_Sua " + tu.Tu_id + ",N'" + tu.Tu_ten + "'," + tu.Tu_gia + "," + tu.Tu_trangthai + "," + tu.Dm_id + "";
                    break;
                case 3:
                    query = "EXEC ThucUong_Xoa " + tu.Tu_id + "";
                    break;
            }
            if (conn.ExcuteQuery(query))
                return true;
            else
                return false;
        }

        public static List<ThucUongDTO> ThucUong_List()
        {
            DataTable dt = ThucUong_Load();
            List<ThucUongDTO> listThucUong = new List<ThucUongDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThucUongDTO Tu = new ThucUongDTO();
                Tu.Tu_id = int.Parse(dt.Rows[i]["tu_id"].ToString());
                Tu.Tu_ten = dt.Rows[i]["tu_ten"].ToString();
                Tu.Tu_gia = double.Parse(dt.Rows[i]["tu_gia"].ToString());
                Tu.Tu_trangthai = int.Parse(dt.Rows[i]["tu_trangthai"].ToString());
                Tu.Dm_id = int.Parse(dt.Rows[i]["dm_id"].ToString());
                listThucUong.Add(Tu);
            }
            return listThucUong;
        }

    }
}
