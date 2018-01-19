using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhMucDTO
    {
        private int dm_id;
        private string dm_ten;
        private int dm_trangthai;
        private string dm_ghichu;

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

        public string Dm_ten
        {
            get
            {
                return dm_ten;
            }

            set
            {
                dm_ten = value;
            }
        }

        public int Dm_trangthai
        {
            get
            {
                return dm_trangthai;
            }

            set
            {
                dm_trangthai = value;
            }
        }

        public string Dm_ghichu
        {
            get
            {
                return dm_ghichu;
            }

            set
            {
                dm_ghichu = value;
            }
        }
    }
}
