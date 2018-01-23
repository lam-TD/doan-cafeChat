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
        public frmGopBan(string tenban, string maban)
        {
            InitializeComponent();
            Load_cbchonban1();
            cbchonban1.Text = tenban;
            gridHoaDon1.DataSource = Load_HoaDon(maban);
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

        DataTable Load_HoaDon(string maban)
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
                gridHoaDon2.DataSource = Load_HoaDon(cbchonban2.SelectedValue.ToString());
            }
            catch (Exception) { gridHoaDon2.DataSource = null; return; }
            
        }

        private void btnban1sangban2_Click(object sender, EventArgs e)
        {

        }

        bool GopBan(string mahd1, string maban1, string hd2, string maban2)
        {
            // lấy dánh sách chi tiết hóa đơn của hd1
            // thực hiệp cập nhật cthd của hd1 sang hd2
            // nếu thức uống đã có trong cthd cua hd2 thì update lại sô lượng
            // nếu thức uống chưa có thì thêm mới cthd của hd2

            List<ChiTietHoaDonDTO> list = ChiTietHoaDonBUS.CTHD_List(maban1);
            return true;
        }
    }
}