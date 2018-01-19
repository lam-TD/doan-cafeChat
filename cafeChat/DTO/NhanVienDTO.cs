using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string nv_id;
        private string nv_ten;
        private string nv_diachi;
        private string nv_sdt;
        private string nv_trangthai;
        private int nv_taikhoan;

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

        public string Nv_ten
        {
            get
            {
                return nv_ten;
            }

            set
            {
                nv_ten = value;
            }
        }

        public string Nv_diachi
        {
            get
            {
                return nv_diachi;
            }

            set
            {
                nv_diachi = value;
            }
        }

        public string Nv_sdt
        {
            get
            {
                return nv_sdt;
            }

            set
            {
                nv_sdt = value;
            }
        }

        public string Nv_trangthai
        {
            get
            {
                return nv_trangthai;
            }

            set
            {
                nv_trangthai = value;
            }
        }

        public int Nv_taikhoan
        {
            get
            {
                return nv_taikhoan;
            }

            set
            {
                nv_taikhoan = value;
            }
        }
    }
}
