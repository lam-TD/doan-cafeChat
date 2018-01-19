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

        void load_ucControl(UserControl uc, string caption, int col, int row)
        {
            uc.Dock = DockStyle.Fill;
            lbcaption.Text = caption;
            tableLayoutMain.Controls.Clear();
            tableLayoutMain.Controls.Add(lbcaption, 1, 0);
            tableLayoutMain.Controls.Add(uc, col, row);
        }
        private void btnQLTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucControl.ucQuanLiTaiKhoan ucTK = new ucControl.ucQuanLiTaiKhoan();
            load_ucControl(ucTK, "Quản lý tài khoản", 1, 1);
        }

        private void btnQLSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucControl.ucQuanLiSanPham ucSP = new ucControl.ucQuanLiSanPham();
            load_ucControl(ucSP, "Quản lý sản phẩm", 1, 1);
        }

        private void btnQLNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucControl.ucQuanLiNhanVien ucNV = new ucControl.ucQuanLiNhanVien();
            load_ucControl(ucNV, "Quản lý nhân viên", 1, 1);
        }

        private void btnThuNgan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThuNgan frmTn = new FrmThuNgan();
            frmTn.ShowDialog();
        }

        private void btnQLBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucControl.ucQuanLiBan ucBan = new ucControl.ucQuanLiBan();
            load_ucControl(ucBan, "Quản lý bàn", 1, 1);
        }

        private void btnQLKhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucControl.ucQuanLiKhuVuc ucKV = new ucControl.ucQuanLiKhuVuc();
            load_ucControl(ucKV, "Quản lý khu vực", 1, 1);
        }

        private void btnQLDanhMuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucControl.ucQuanLiDanhMuc ucDM = new ucControl.ucQuanLiDanhMuc();
            load_ucControl(ucDM, "Quản lý danh mục", 1, 1);
        }
    }
}
