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
    public partial class frmQuanLiHoaDon : DevExpress.XtraEditors.XtraUserControl
    {
        public frmQuanLiHoaDon()
        {
            InitializeComponent();
        }

        void HoaDon_Load()
        {
            gridHoaDon.DataSource = HoaDonBUS.HoaDon_Load();
        }

        void CTHD_LoadTheoIDHoaDon(string mahd)
        {
            gridCTHD.DataSource = ChiTietHoaDonBUS.CTHD_Load_DonGia_TinhThanhTien(mahd);
        }

        private void frmQuanLiHoaDon_Load(object sender, EventArgs e)
        {
            HoaDon_Load();
        }

        private void gridHoaDon_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtmahd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtngaylap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtphuthu.Text = HoaDonBUS.DinhDangTienTienTe(double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString()));
                txtgiamgia.Text = HoaDonBUS.DinhDangTienTienTe(double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString()));
                txttongtien.Text = HoaDonBUS.DinhDangTienTienTe(double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()));
                txtban.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtmanv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
                string trangthai = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString();
                if (trangthai == "1") { cbtrangthaihd.Text = "Đã thanh toán"; cbtrangthaihd.Enabled = false; }
                else { cbtrangthaihd.Text = "Chưa thanh toán"; cbtrangthaihd.Enabled = true; }
                CTHD_LoadTheoIDHoaDon(txtmahd.Text);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
