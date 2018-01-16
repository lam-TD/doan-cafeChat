using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        private string nv_id;
        private string tm_mk;
        private int tk_quyen;

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

        public string Tm_mk
        {
            get
            {
                return tm_mk;
            }

            set
            {
                tm_mk = value;
            }
        }

        public int Tk_quyen
        {
            get
            {
                return tk_quyen;
            }

            set
            {
                tk_quyen = value;
            }
        }
    }
}
