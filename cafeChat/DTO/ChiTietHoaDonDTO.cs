using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        private int cthd_id;
        private string hd_ma;
        private int cthd_soluong;
        private int tu_id;

        public int Cthd_id
        {
            get
            {
                return cthd_id;
            }

            set
            {
                cthd_id = value;
            }
        }

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
    }
}
