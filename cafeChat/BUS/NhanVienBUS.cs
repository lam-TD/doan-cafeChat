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
            return conn.getTable("EXEC NhanVien_Load");
        }

        public static DataTable NhanVien_LoadNhanVienTheoMa(string manv)
        {
            return conn.getTable("EXEC NhanVien_LoadNhanVienTheoMa '" + manv + "'");
        }

        public static bool NhanVien_ThemSuaXoa(NhanVienDTO nv, int type)
        {
            string query = "";
            switch (type)
            {
                case 1:
                    query = "EXEC NhanVien_Them '" + nv.Nv_id + "',N'" + nv.Nv_ten + "',N'" + nv.Nv_diachi + "'," + nv.Nv_sdt + "," + nv.Nv_taikhoan + ",N'" + nv.Nv_trangthai + "'";
                    break;
                case 2:
                    query = "EXEC NhanVien_Sua '" + nv.Nv_id + "',N'" + nv.Nv_ten + "',N'" + nv.Nv_diachi + "'," + nv.Nv_sdt + "," + nv.Nv_taikhoan + ",N'" + nv.Nv_trangthai + "'";
                    break;
                case 3:
                    query = "EXEC NhanVien_Xoa '" + nv.Nv_id + "'";
                    break;
            }
            if (conn.ExcuteQuery(query))
                return true;
            else
                return false;
        }

        public static string NhanVien_LayMaNhanVienKeTiep()
        {
            return conn.TimIDKeTiep("nv");
        }
        public static string TimIDKeTiep()
        {
            //-- b tim id ke tiep cua table Ban
            //-- hd tim id ke tiep cua table HoaDon
            //-- nv tim id ke tiep cua table NhanVien
            if (conn.ExcuteQuery("EXEC NhanVien_TimIDKeTiep"))
            {
                DataTable dt = conn.getTable("EXEC LayIDKeTiep");
                return dt.Rows[0]["nv_id"].ToString();
            }
            else
                return "null";
        }

        public static bool NhanVien_CapNhatNhanVienCoTaiKhoan(string nv_id, int nv_taikhoan)
        {
            return conn.ExcuteQuery("EXEC NhanVien_CapNhatNhanVienCoTaiKhoan '"+ nv_id +"',"+ nv_taikhoan +"");
        }

    }
}
