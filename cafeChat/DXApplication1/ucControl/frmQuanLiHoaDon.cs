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
using DAL;
using DTO;
using DevExpress.XtraReports.UI;

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

        private void frmQuanLiHoaDon_Load(object sender, EventArgs e)
        {
            HoaDon_Load();
            cbloaithongke.SelectedIndex = -1;
            cauhinhButton(false);
        }

        void cauhinhButton(bool t)
        {
            cbhienthi.Enabled = t;
            dateTuNgay.Enabled = t;
            dateDenNgay.Enabled = t;
            btnlammoi.Enabled = t;
            simpleButton2.Enabled = t;
            btnIn.Enabled = t;
        }

        void CTHD_LoadTheoIDHoaDon(string mahd)
        {
            gridCTHD.DataSource = ChiTietHoaDonBUS.CTHD_Load_DonGia_TinhThanhTien(mahd);
        }

        void Load_cbNhanVienLapHD()
        {
            cbhienthi.DataSource = TaiKhoanBus.Load_TaiKhoan();
            cbhienthi.DisplayMember = "nv_id";
            cbhienthi.ValueMember = "nv_id";
            cbhienthi.SelectedIndex = -1;
        }

        void ThongKe_LietKe()
        {
            switch (cbloaithongke.Text)
            {
                case "Nhân viên":
                    gridHoaDon.DataSource = HoaDonBUS.HoaDonThongKeTheoNhanVienTheoNgay(cbhienthi.SelectedValue.ToString(), dateTuNgay.Value.ToString(), dateDenNgay.Value.ToString());
                    break;
                case "Ngày lập hóa đơn":
                    gridHoaDon.DataSource = HoaDonBUS.HoaDonThongKeTheoKhoangCachNgay(dateTuNgay.Value.ToString(), dateDenNgay.Value.ToString());
                    break;
                default:
                    break;
            }
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
            catch (Exception) { return; }
        }

        private void cbloaithongke_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cbloaithongke.Text)
                {
                    case "Nhân viên":
                        Load_cbNhanVienLapHD();
                        cauhinhButton(true);
                        break;
                    case "Ngày lập hóa đơn":
                        cbhienthi.Enabled = false;
                        cauhinhButton(true);
                        break;
                    default:
                        cauhinhButton(false);
                        break;
                }
            }
            catch (Exception) { return; }    
        }

        private void cbhienthi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoaDon.DataSource = HoaDonBUS.HoaDonThongKeTheoNhanVien(cbhienthi.SelectedValue.ToString());
                txtsoluongketqua.Text = gridView1.RowCount.ToString();
                txttongdoanhthu.Text = HoaDonBUS.DinhDangTienTienTe(double.Parse(gridView1.Columns["hd_tongtien"].SummaryItem.SummaryValue.ToString())).ToString();
            }
            catch (Exception) { return; }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime d1 = dateTuNgay.Value;
            DateTime d2 = dateDenNgay.Value;
            if (DateTime.Compare(d1,d2) > 0){ XtraMessageBox.Show("Ngày không được bé hơn ngày đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ThongKe_LietKe();
                txtsoluongketqua.Text = gridView1.RowCount.ToString();
                txttongdoanhthu.Text = txttongdoanhthu.Text = HoaDonBUS.DinhDangTienTienTe(double.Parse(gridView1.Columns["hd_tongtien"].SummaryItem.SummaryValue.ToString())).ToString();
            }
            catch (Exception) { return; }
            
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            HoaDon_Load();
        }

        private void btncapnhattrangthaiHD_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult di = XtraMessageBox.Show("Bạn có muốn cập nhật lại trạng thái Hóa Đơn: " + txtmahd.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (di == DialogResult.OK)
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.Ban_id = txtban.Text;
                    hd.Hd_id = txtmahd.Text;
                    hd.Hd_ngaylap = txtngaylap.Text;
                    hd.Hd_tongtien = double.Parse(txttongtien.Text);
                    hd.Hd_giamgia = double.Parse(txtgiamgia.Text);
                    hd.Hd_phuthu = double.Parse(txtphuthu.Text);
                    hd.Nv_id = txtmanv.Text;
                    if (cbtrangthaihd.Text == "Đã thanh toán") { hd.Hd_trangthai = 1; }
                    else { hd.Hd_trangthai = 0; }
                    hd.Hd_trangthai = 0;
                    if (HoaDonBUS.HoaDon_ThemXoaSuaHuyBan(hd, 2))
                    {
                        if (BanBUS.Ban_CapNhatTrangThaiBan(txtban.Text, "Trống")) { XtraMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); HoaDon_Load(); }
                        else { XtraMessageBox.Show("Lỗi không cập nhật được trạng thái bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }     
                    }         
                    else XtraMessageBox.Show("Lỗi không cập nhật được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception) { XtraMessageBox.Show("Lỗi không cập nhật được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            DateTime tungay = dateTuNgay.Value;
            DateTime denngay = dateDenNgay.Value;
            InBaoCao bc = new InBaoCao();
            bc.DataSource = conn.getTable("EXEC HoaDon_InBaoCaoTheoTuyChon '"+ tungay +"','"+ denngay +"'");
            bc.ShowPreviewDialog();
        }
    }
}
