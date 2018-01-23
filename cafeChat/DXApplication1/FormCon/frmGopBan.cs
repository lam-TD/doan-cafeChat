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
using BUS;
using DTO;

namespace DXApplication1.FormCon
{
    public partial class frmGopBan : DevExpress.XtraEditors.XtraForm
    {
        static List<ChiTietHoaDonDTO> listCTHD1;
        static List<ChiTietHoaDonDTO> listCTHD2;
        public frmGopBan(string tenban, string maban)
        {
            InitializeComponent();
            Load_cbchonban1();
            cbchonban1.Text = tenban;
            gridHoaDon1.DataSource = Load_HoaDonTheoMaBan(maban);
        }

        void Load_cbchonban1()
        {
            cbchonban1.DataSource = BanBUS.Ban_LoadBanTheoTrangThai("Có khách");
            cbchonban1.DisplayMember = "ban_ten";
            cbchonban1.ValueMember = "ban_id";
        }

        void Load_cbchonban2(string maban)
        {
            cbchonban2.DataSource = BanBUS.Ban_Load_LoaiTru1BanTrung_TrangThaiCoKhach(maban);
            cbchonban2.DisplayMember = "ban_ten";
            cbchonban2.ValueMember = "ban_id";
        }

        private void cbchonban1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_cbchonban2(cbchonban1.SelectedValue.ToString());
            cbchonban2.SelectedIndex = -1;
        }

        DataTable Load_HoaDonTheoMaBan(string maban)
        {
            try
            {
                DataTable dt = HoaDonBUS.HoaDon_LayHoaDonTheoMaBan(maban);
                string mahd = dt.Rows[0]["hd_id"].ToString();
                return ChiTietHoaDonBUS.CTHD_Load_DonGia_TinhThanhTien(mahd);
            }
            catch (Exception)
            {
                DataTable dt = null;
                return dt;
            }
        }

        private void cbchonban2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoaDon2.DataSource = Load_HoaDonTheoMaBan(cbchonban2.SelectedValue.ToString());
            }
            catch (Exception) { gridHoaDon2.DataSource = null; return; }
            
        }

        private void btnban1sangban2_Click(object sender, EventArgs e)
        {
            string maban1 = cbchonban1.SelectedValue.ToString();
            DataTable dt = HoaDonBUS.HoaDon_LayHoaDonTheoMaBan(maban1);
            string mahd1 = dt.Rows[0]["hd_id"].ToString();

            string maban2 = cbchonban2.SelectedValue.ToString();
            DataTable dt2 = HoaDonBUS.HoaDon_LayHoaDonTheoMaBan(maban2);
            string mahd2 = dt2.Rows[0]["hd_id"].ToString();

            listCTHD1 = ChiTietHoaDonBUS.CTHD_List(mahd1);
            listCTHD2 = ChiTietHoaDonBUS.CTHD_List(mahd2);

            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn GỘP '" + cbchonban1.Text + "'" + " sang " + "'" + cbchonban2.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (GopBan(mahd1, maban1, mahd2, maban2))
                {
                    ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                    cthd.Hd_ma = mahd1;
                    if (ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 4))
                    {
                        HoaDonDTO hd = new HoaDonDTO();
                        hd.Hd_id = mahd1;
                        if (HoaDonBUS.HoaDon_ThemXoaSuaHuyBan(hd, 4))
                        {
                            if (!BanBUS.Ban_CapNhatTrangThaiBan(maban1, "Trống"))
                                XtraMessageBox.Show("Lỗi không cập nhật được trạng thái Bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else 
                            {
                                XtraMessageBox.Show("Đã GỘP " + cbchonban1.Text + "sang" + cbchonban2.Text + "!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                gridHoaDon1.DataSource = null;
                                gridHoaDon2.DataSource = Load_HoaDonTheoMaBan(maban2);
                            } 
                        }
                        else
                            XtraMessageBox.Show("Lỗi không xóa Hóa Đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        XtraMessageBox.Show("Lỗi không xóa được Chi Tiết Hóa Đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        bool GopBan(string mahd1, string maban1, string mahd2, string maban2)
        {
            // lấy dánh sách chi tiết hóa đơn của hd1
            // thực hiện cập nhật cthd của hd1 sang hd2
            // nếu thức uống đã có trong cthd cua hd2 thì update lại sô lượng
            // nếu thức uống chưa có thì thêm mới cthd của hd2
            try
            {
                List<ChiTietHoaDonDTO> list = ChiTietHoaDonBUS.CTHD_List(mahd1);

                foreach (ChiTietHoaDonDTO item in list)
                {
                    DataTable dt = ChiTietHoaDonBUS.CTHD_KiemTraThucUongCoTrongCTHD(item.Tu_id, mahd2);
                    if (dt.Rows.Count > 0)
                    {
                        ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                        cthd.Tu_id = item.Tu_id;
                        cthd.Hd_ma = mahd2;
                        cthd.Cthd_soluong = item.Cthd_soluong + int.Parse(dt.Rows[0]["cthd_soluong"].ToString());
                        ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 2);
                    }
                    else
                    {
                        ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                        cthd.Tu_id = item.Tu_id;
                        cthd.Hd_ma = mahd2;
                        cthd.Cthd_soluong = item.Cthd_soluong;
                        ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 1);
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnban2sangban1_Click(object sender, EventArgs e)
        {
            string maban1 = cbchonban2.SelectedValue.ToString();
            DataTable dt = HoaDonBUS.HoaDon_LayHoaDonTheoMaBan(maban1);
            string mahd1 = dt.Rows[0]["hd_id"].ToString();

            string maban2 = cbchonban1.SelectedValue.ToString();
            DataTable dt2 = HoaDonBUS.HoaDon_LayHoaDonTheoMaBan(maban2);
            string mahd2 = dt2.Rows[0]["hd_id"].ToString();

            listCTHD1 = ChiTietHoaDonBUS.CTHD_List(mahd1);
            listCTHD2 = ChiTietHoaDonBUS.CTHD_List(mahd2);

            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn GỘP '" + cbchonban1.Text + "'" + " sang " + "'" + cbchonban2.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (GopBan(mahd1, maban1, mahd2, maban2))
                {
                    ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                    cthd.Hd_ma = mahd1;
                    if (ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 4))
                    {
                        HoaDonDTO hd = new HoaDonDTO();
                        hd.Hd_id = mahd1;
                        if (HoaDonBUS.HoaDon_ThemXoaSuaHuyBan(hd, 4))
                        {
                            if (!BanBUS.Ban_CapNhatTrangThaiBan(maban1, "Trống"))
                                XtraMessageBox.Show("Lỗi không cập nhật được trạng thái Bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                XtraMessageBox.Show("Đã GỘP " + cbchonban1.Text + "sang" + cbchonban2.Text + "!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                gridHoaDon2.DataSource = null;
                                gridHoaDon1.DataSource = Load_HoaDonTheoMaBan(maban2);
                            }
                        }
                        else
                            XtraMessageBox.Show("Lỗi không xóa Hóa Đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        XtraMessageBox.Show("Lỗi không xóa được Chi Tiết Hóa Đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}