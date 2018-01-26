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

        public static DataTable HoaDon_Load()
        {
            return conn.getTable("EXEC HoaDon_Load");
        }

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

        public static bool HoaDon_ThemXoaSuaHuyBan(HoaDonDTO hd, int type)
        {
            string query = "";
            try
            {
                switch (type)
                {
                    case 1:
                        query = "EXEC HoaDon_Them '" + hd.Hd_id + "','" + hd.Hd_ngaylap + "'," + hd.Hd_trangthai + "," + hd.Hd_phuthu + "," + hd.Hd_giamgia + "," + hd.Hd_tongtien + ",'" + hd.Ban_id + "','" + hd.Nv_id + "'";
                        break;
                    case 2:
                        query = "EXEC HoaDon_Sua '" + hd.Hd_id + "','" + hd.Hd_ngaylap + "'," + hd.Hd_trangthai + "," + hd.Hd_phuthu + "," + hd.Hd_giamgia + "," + hd.Hd_tongtien + ",'" + hd.Ban_id + "','" + hd.Nv_id + "'";
                        break;
                    case 3:
                        query = "EXEC HoaDon_Xoa '" + hd.Hd_id + "'";
                        break;
                    case 4:
                        query = "EXEC HoaDon_HuyBan '" + hd.Hd_id + "'";
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

        public static bool HoaDon_DoiBan(string mabanChon, string mabanDoi)
        {
            try
            {
                if (conn.ExcuteQuery("EXEC HoaDon_DoiBan '" + mabanChon + "','" + mabanDoi + "'"))
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }

        public static DataTable HoaDon_LayHoaDonTheoMaBan(string maban)
        {
            return conn.getTable("EXEC HoaDon_LayHoaDonTheoMaBan @maban = '"+ maban +"'");
        }

        public static DataTable HoaDonThongKeTheoNhanVien(string manv)
        {
            return conn.getTable("EXEC HoaDon_ThongKeTheoNhanVien '" + manv + "'");
        }

        public static DataTable HoaDonThongKeTheoNhanVienTheoNgay(string manv, string tungay, string denngay)
        {
            return conn.getTable("EXEC HoaDon_ThongKeTheoNhanVienTheoNgayLap 'NV0001','"+ tungay +"','"+ denngay +"'");
        }

        public static DataTable HoaDonThongKeTheoKhoangCachNgay(string tungay, string denngay)
        {
            return conn.getTable("EXEC HoaDon_ThongKeTheoNgayLap '"+ tungay +"','"+ denngay +"'");
        }

        #region ĐỊNH DẠNG TIỀN TỆ - TÍNH TIỀN
        public static string DinhDangTienTienTe(double giatri)
        {
            return String.Format("{0:0,0}", giatri);
        }

        public static double HoaDon_TinhTongTien(string thanhtien, string phuthu, string giamgia)
        {
            try
            {
                double thanh_tien = double.Parse(thanhtien);
                double phu_thu = 0;
                double giam_gia = 0;
                if (phuthu != "")
                    phu_thu = double.Parse(phuthu);
                if (giamgia != "")
                    giam_gia = double.Parse(giamgia);
                double tong_tien = (thanh_tien + phu_thu) - giam_gia;
                return tong_tien;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        public static double HoaDon_TinhTienThua(string tiennhan, string tongtien)
        {
            double tien_nhan = 0;
            if (tiennhan != "")
                tien_nhan = double.Parse(tiennhan);
            double tong_tien = double.Parse(tongtien);
            return tien_nhan - tong_tien;
        }

        public static double TinhTienTheoPhanTram(string phantram, string tien)
        {
            double phan_tram = double.Parse(phantram);
            double tien_tien = double.Parse(tien);
            return (tien_tien * phan_tram / 100);
        }
        #endregion
    }
}
