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

namespace DXApplication1.ucControl
{
    public partial class ucQuanLiTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiTaiKhoan()
        {
            InitializeComponent();
            load_TaiKhoan();
        }

        void load_TaiKhoan()
        {
            gridTk.DataSource =  TaiKhoanBus.Load_TaiKhoan();
        }

        private void btnThemTk_Click(object sender, EventArgs e)
        {
            frmTaiKhoan_Them tk = new frmTaiKhoan_Them();
            tk.ShowDialog();
        }
    }
}
