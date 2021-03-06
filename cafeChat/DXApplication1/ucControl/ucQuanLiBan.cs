﻿using System;
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
    public partial class ucQuanLiBan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiBan()
        {
            InitializeComponent();
        }

        static bool flag = false;
        void Ban_Load()
        {
            gridBan.DataSource = BanBUS.Ban_Load();
        }

        void Ban_Load_TrangThai_Xoa()
        {
            gridBanDaXoa.DataSource = BanBUS.Ban_Load_TrangThai_Xoa();
        }

        void cbkhu_vuc_Load()
        {
            cbkhu_vuc.DataSource = KhuVucBUS.KhuVuc_Load();
            cbkhu_vuc.DisplayMember = "kv_ten";
            cbkhu_vuc.ValueMember = "kv_id";
            cbkhu_vuc.SelectedItem = -1;
        }

        void resetText()
        {
            txtma.ResetText();
            txtten.ResetText();
            cbkhu_vuc.ResetText();
            cbtrang_thai.ResetText();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            if (txtten.Text != "" && cbkhu_vuc.ToString() != "" && cbtrang_thai.ToString() != "")
            {
                if (BanBUS.Ban_KiemTraBanTrungTen(txtten.Text))
                {
                    XtraMessageBox.Show("Tên bàn đã tồn tại vui lòng nhập tên khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    BanDTO b = new BanDTO();
                    b.Ban_id = BanBUS.Ban_TimMaBanKeTiep();
                    b.Ban_ten = txtten.Text;
                    b.Ban_trangthai = "Trống";
                    b.Kv_id = int.Parse(cbkhu_vuc.SelectedValue.ToString());
                    b.Ban_xoa = 0;
                    if (BanBUS.Ban_ThemSuaXoa(b, 1))
                    {
                        XtraMessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Ban_Load();
                        resetText();
                    }
                    else
                        XtraMessageBox.Show("Lỗi không thêm được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnCapNhatBan_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                BanDTO b = new BanDTO();
                string Ban_id = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "ban_id").ToString();
                if (BanBUS.Ban_CapNhatTrangThaiBan(Ban_id, "Trống"))
                {
                    XtraMessageBox.Show("Đã cập nhật lại trạng thái Bàn vừa chọn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Ban_Load();
                    Ban_Load_TrangThai_Xoa();
                }
                else
                    XtraMessageBox.Show("Lỗi không cập nhật được trạng thái bàn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BanDTO b = new BanDTO();
                if (BanBUS.Ban_KiemTraBanTrungTen(txtten.Text))
                {
                    XtraMessageBox.Show("Tên bàn đã tồn tại vui lòng nhập tên khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn SỬA thông tin BÀN vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        b.Ban_id = txtma.Text;
                        b.Ban_ten = txtten.Text;
                        b.Ban_trangthai = cbtrang_thai.Text;
                        b.Kv_id = int.Parse(cbkhu_vuc.SelectedValue.ToString());
                        b.Ban_xoa = 0;
                        if (BanBUS.Ban_ThemSuaXoa(b, 2))
                        {
                            XtraMessageBox.Show("Sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Ban_Load();
                            resetText();
                        }
                        else
                            XtraMessageBox.Show("Lỗi không sửa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void ucQuanLiBan_Load(object sender, EventArgs e)
        {
            Ban_Load();
            Ban_Load_TrangThai_Xoa();
            cbkhu_vuc_Load();
        }

        private void gridBan_Click_1(object sender, EventArgs e)
        {
            txtma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            cbkhu_vuc.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            cbtrang_thai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            btnThemBan.Enabled = true;
            flag = false;
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            BanDTO b = new BanDTO();
            string Ban_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ban_id").ToString();
            if (BanBUS.Ban_KiemTra_TrangThai_TheoIDBan(Ban_id) != "Trống")
                XtraMessageBox.Show("Bàn phải có trạng thái trống mới xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn XÓA thông tin BÀN vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    b.Ban_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ban_id").ToString();
                    b.Ban_xoa = 0;
                    if (BanBUS.Ban_ThemSuaXoa(b, 3))
                    {
                        XtraMessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Ban_Load();
                        txtma.ResetText();
                        txtten.ResetText();
                        cbkhu_vuc.ResetText();
                        cbtrang_thai.ResetText();
                    }
                    else
                        XtraMessageBox.Show("Lỗi không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            Ban_Load_TrangThai_Xoa();
        }

        private void gridBanDaXoa_Click(object sender, EventArgs e)
        {
            txtma.Text = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtten.Text = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            cbkhu_vuc.Text = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            cbtrang_thai.Text = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            btnThemBan.Enabled = false;
            flag = true;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Ban_Load_TrangThai_Xoa();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Lỗi không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
