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
    public partial class frmDoiBan : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiBan(string tenban, string maban)
        {
            InitializeComponent();
            cbchonBan_Load();
            cbChonBan.Text = tenban;
            doiBan_Load(maban);
        }

        private void frmDoiBan_Load(object sender, EventArgs e)
        {
            
        }

        void cbchonBan_Load()
        {
            cbChonBan.DataSource = BanBUS.Ban_Load_BanTrangThaiCoKhach();
            cbChonBan.DisplayMember = "ban_ten";
            cbChonBan.ValueMember = "ban_id";
        }
        void doiBan_Load(string maban)
        {
            cbDoiBan.DataSource = BanBUS.Ban_Load_LoaiTru1BanTrung_TrangThaiCoKhach(maban);
            cbDoiBan.DisplayMember = "ban_ten";
            cbDoiBan.ValueMember = "ban_id";
            cbDoiBan.SelectedIndex = -1;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btndoiban_Click(object sender, EventArgs e)
        {
            // cập nhật lại trạng thái bàn chọn và bàn được đổi
            // cập nhật lại Bàn trong hóa đơn của bàn đổi
            string mabanChon = cbChonBan.SelectedValue.ToString();
            string mabanDoi = cbDoiBan.SelectedValue.ToString();
            try
            {
                if (HoaDonBUS.HoaDon_DoiBan(mabanChon, mabanDoi))
                {
                    if (BanBUS.Ban_CapNhatTrangThaiBan(mabanChon, "Trống") && BanBUS.Ban_CapNhatTrangThaiBan(mabanDoi, "Có khách"))
                    {
                        XtraMessageBox.Show("Đã đổi BÀN!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }   
                    else XtraMessageBox.Show("Lỗi không cập nhật được trạng thái BÀN!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else XtraMessageBox.Show("Lỗi không đổi BÀN được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception) { XtraMessageBox.Show("Lỗi không đổi được BÀN BÀN!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            }
    }
}