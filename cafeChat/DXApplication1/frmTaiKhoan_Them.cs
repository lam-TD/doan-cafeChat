using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication1
{
    public partial class frmTaiKhoan_Them : DevExpress.XtraEditors.XtraForm
    {
        public frmTaiKhoan_Them()
        {
            InitializeComponent();
        }
        void Load_cbMaNhanVien()
        {
            //cbMaNv.DataSource = 
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaiKhoan_Them_Load(object sender, EventArgs e)
        {

        }
    }
}