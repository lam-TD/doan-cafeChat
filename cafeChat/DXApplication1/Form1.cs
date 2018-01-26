using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DXApplication1.FormCon;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public static string manv;
        public static string tennv;
        public Form1(string manv1,int quyen)
        {
            InitializeComponent();
            NhanVien_LoadThongTin(manv1);
            manv = manv1;
            lbcaption.Text = "";
            if (quyen == 1) { PhanQuyen(true); }
            else { PhanQuyen(false); }
        }

        void PhanQuyen(bool quyen)
        {
            ribbonPageQuanLi.Visible = quyen;
            ribbonPageThongKe.Visible = quyen;
            ribbonPageGroupQLTaiKhoan.Visible = quyen;
        }
        void NhanVien_LoadThongTin(string manv)
        {
            DataTable dt = NhanVienBUS.NhanVien_LoadNhanVienTheoMa(manv);
            manv = dt.Rows[0]["nv_id"].ToString();
            tennv = dt.Rows[0]["nv_ten"].ToString();
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
            load_ucControl(ucSP, "Quản lý thức uống", 1, 1);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            txttenhanvien.Caption = "Nhân viên: " + tennv;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn đăng xuất?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmDangNhap dn = new frmDangNhap();
                dn.ShowDialog();
            }
        }

        private void btndoimk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCon.frmDoiMatkhau doimk = new frmDoiMatkhau(manv);
            doimk.ShowDialog();
        }

        private void btnQLHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tableLayoutMain.Controls.Clear();
            ucControl.frmQuanLiHoaDon uchd = new ucControl.frmQuanLiHoaDon();
            //uchd.Dock = DockStyle.Fill;
            //tableLayoutMain.Controls.Add(uchd);
            load_ucControl(uchd, "Quản lý Hóa Đơn", 1, 1);
        }
    }
}
