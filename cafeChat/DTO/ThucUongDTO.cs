using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThucUongDTO
    {
        private int tu_id;
        private string tu_ten;
        private double tu_gia;
        private int tu_trangthai;
        private int dm_id;

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

        public double Tu_gia
        {
            get
            {
                return tu_gia;
            }

            set
            {
                tu_gia = value;
            }
        }

        public int Tu_trangthai
        {
            get
            {
                return tu_trangthai;
            }

            set
            {
                tu_trangthai = value;
            }
        }

        public int Dm_id
        {
            get
            {
                return dm_id;
            }

            set
            {
                dm_id = value;
            }
        }
    }
}
