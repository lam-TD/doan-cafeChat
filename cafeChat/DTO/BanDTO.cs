using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BanDTO
    {
        private string ban_id;
        private string ban_ten;
        private string ban_trangthai;
        private int kv_id;

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

        public string Ban_ten
        {
            get
            {
                return ban_ten;
            }

            set
            {
                ban_ten = value;
            }
        }

        public string Ban_trangthai
        {
            get
            {
                return ban_trangthai;
            }

            set
            {
                ban_trangthai = value;
            }
        }

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
    }
}
