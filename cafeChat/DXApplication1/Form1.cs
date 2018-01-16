using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQLTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucControl.ucQuanLiTaiKhoan ucTK = new ucControl.ucQuanLiTaiKhoan();
            ucTK.Dock = DockStyle.Fill;
            tableLayoutMain.Controls.Clear();
            tableLayoutMain.Controls.Add(ucTK,1,0);
        }
    }
}
