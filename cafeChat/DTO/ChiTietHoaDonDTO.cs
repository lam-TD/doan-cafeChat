using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        private string hd_ma;
        private int cthd_soluong;
        private int tu_id;
        private int tu_dongia;
        private int cthd_thanhtien;
        private string tu_ten;
        public string Hd_ma
        {
            get
            {
                return hd_ma;
            }

            set
            {
                hd_ma = value;
            }
        }

        public int Cthd_soluong
        {
            get
            {
                return cthd_soluong;
            }

            set
            {
                cthd_soluong = value;
            }
        }

        public int Tu_id
        {
            get
            {
                return tu_id;
            }

            set
            {
                tu_id = value;
            }
        }

        public int Tu_dongia
        {
            get
            {
                return tu_dongia;
            }

            set
            {
                tu_dongia = value;
            }
        }

        public int Cthd_thanhtien
        {
            get
            {
                return cthd_thanhtien;
            }

            set
            {
                cthd_thanhtien = value;
            }
        }

        public string Tu_ten
        {
            get
            {
                return tu_ten;
            }

            set
            {
                tu_ten = value;
            }
        }
    }
}
