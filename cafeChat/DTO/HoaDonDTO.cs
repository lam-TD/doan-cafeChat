using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        private string hd_id;
        private string ban_id;
        private string hd_ngaylap;
        private double hd_phuthu;
        private double hd_giamgia;
        private int hd_trangthai;
        private double hd_tongtien;
        private string nv_id;

        public string Hd_id
        {
            get
            {
                return hd_id;
            }

            set
            {
                hd_id = value;
            }
        }

        public string Ban_id
        {
            get
            {
                return ban_id;
            }

            set
            {
                ban_id = value;
            }
        }

        public string Hd_ngaylap
        {
            get
            {
                return hd_ngaylap;
            }

            set
            {
                hd_ngaylap = value;
            }
        }

        public double Hd_phuthu
        {
            get
            {
                return hd_phuthu;
            }

            set
            {
                hd_phuthu = value;
            }
        }

        public double Hd_giamgia
        {
            get
            {
                return hd_giamgia;
            }

            set
            {
                hd_giamgia = value;
            }
        }

        public int Hd_trangthai
        {
            get
            {
                return hd_trangthai;
            }

            set
            {
                hd_trangthai = value;
            }
        }

        public double Hd_tongtien
        {
            get
            {
                return hd_tongtien;
            }

            set
            {
                hd_tongtien = value;
            }
        }

        public string Nv_id
        {
            get
            {
                return nv_id;
            }

            set
            {
                nv_id = value;
            }
        }
    }
}
