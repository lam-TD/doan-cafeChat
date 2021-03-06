﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class TaiKhoanBus
    {
        private static Connect conn = new Connect();

        public static DataTable Load_TaiKhoan()
        {
            string query = "EXEC TaiKhoan_Load";
            DataTable dt = conn.getTable(query);
            return dt;
        }
        public static DataTable TaiKhoan_Login(string tk, string mk)
        {
            return conn.getTable("EXEC TaiKhoan_Load_nv_id '" + tk + "', '" + mk + "'");
        }

        public static bool TaiKhoan_Them(TaiKhoanDTO tk, int type)
        {
            string query = "";
            try
            {
                switch (type)
                {
                    case 1:
                        query = "EXEC TaiKhoan_Them '" + tk.Nv_id + "','" + tk.Tm_mk + "'," + tk.Tk_quyen + ", "+ tk.Tk_trangthai +"";
                        break;
                    case 2:
                        query = "EXEC TaiKhoan_Sua '" + tk.Nv_id + "','" + tk.Tm_mk + "'," + tk.Tk_quyen + ", "+ tk.Tk_trangthai +"";
                        break;
                    case 3:
                        query = "EXEC TaiKhoan_Xoa '" + tk.Nv_id + "'";
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

        public static DataTable TaiKhoan_LoadNVChuCoTaiKhoan()
        {
            return conn.getTable("EXEC NhanVien_LoadNVChuaCoTaiKhoan");
        }

        public static DataTable TaiKhoan_LayQuyenTruyCap(string tk_id)
        {
            return conn.getTable("EXEC TaiKhoan_LayQuyenTruyCap '" + tk_id + "'");
        }
    }
}
