using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuVucDTO
    {
        private int kv_id;
        private string kv_ten;
        private string kv_trangthai;
        private string kv_ghichu;

        public int Kv_id
        {
            get
            {
                return kv_id;
            }

            set
            {
                kv_id = value;
            }
        }

        public string Kv_ten
        {
            get
            {
                return kv_ten;
            }

            set
            {
                kv_ten = value;
            }
        }

        public string Kv_trangthai
        {
            get
            {
                return kv_trangthai;
            }

            set
            {
                kv_trangthai = value;
            }
        }

        public string Kv_ghichu
        {
            get
            {
                return kv_ghichu;
            }

            set
            {
                kv_ghichu = value;
            }
        }
    }
}
