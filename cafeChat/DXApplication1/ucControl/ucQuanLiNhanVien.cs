using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DTO;
namespace DXApplication1.ucControl
{
    public partial class ucQuanLiNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiNhanVien()
        {
            InitializeComponent();
        }
        void NhanVien_Load()
        {
            gridNhanVien.DataSource = NhanVienBUS.NhanVien_Load();
        }

        private void ucQuanLiNhanVien_Load(object sender, EventArgs e)
        {
            NhanVien_Load();
        }
    }
}
