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
    public partial class ucQuanLiDanhMuc : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiDanhMuc()
        {
            InitializeComponent();
        }

        void resetText()
        {
            txtmadanhmuc.ResetText();
            txttendanhmuc.ResetText();
            txtghichu.ResetText();
            cbtrangthai.ResetText();
        }
        void DanhMuc_Load()
        {
            gridDanhMuc.DataSource = DanhMucBUS.DanhMuc_Load();
        }

        private void ucQuanLiDanhMuc_Load(object sender, EventArgs e)
        {
            DanhMuc_Load();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            if (txttendanhmuc.Text != "" && txtghichu.Text != "" && cbtrangthai.Text != "")
            {
                DanhMucDTO dm = new DanhMucDTO();
                //dm.Dm_id = int.Parse(txtmadanhmuc.Text);
                dm.Dm_ten = txttendanhmuc.Text;
                dm.Dm_ghichu = txtghichu.Text;
                if (cbtrangthai.Text == "Đang sử dụng")
                {
                    dm.Dm_trangthai = 1;
                }
                else
                {
                    dm.Dm_trangthai = 0;
                }
                if (DanhMucBUS.DanhMuc_ThemSuaXoa(dm, 1))
                {
                    XtraMessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DanhMuc_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Lỗi không thêm được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhatBan_Click(object sender, EventArgs e)
        {
            DanhMucDTO dm = new DanhMucDTO();
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn SỬA thông tin Danh Mục vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                dm.Dm_id = int.Parse(txtmadanhmuc.Text);
                dm.Dm_ten = txttendanhmuc.Text;
                dm.Dm_ghichu = txtghichu.Text;
                if (cbtrangthai.Text == "Đang sử dụng")
                {
                    dm.Dm_trangthai = 1;
                }
                else
                {
                    dm.Dm_trangthai = 0;
                }
                if (DanhMucBUS.DanhMuc_ThemSuaXoa(dm, 2))
                {
                    XtraMessageBox.Show("Sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DanhMuc_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Lỗi không sửa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DanhMucDTO dm = new DanhMucDTO();
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn XÓA thông tin Danh Mục vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                dm.Dm_id = int.Parse(txtmadanhmuc.Text);
                dm.Dm_ten = txttendanhmuc.Text;
                dm.Dm_ghichu = txtghichu.Text;
                if (cbtrangthai.Text == "Đang sử dụng")
                {
                    dm.Dm_trangthai = 1;
                }
                else
                {
                    dm.Dm_trangthai = 0;
                }
                if (DanhMucBUS.DanhMuc_ThemSuaXoa(dm, 3))
                {
                    XtraMessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DanhMuc_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Lỗi không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridDanhMuc_Click(object sender, EventArgs e)
        {
            txtmadanhmuc.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txttendanhmuc.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtghichu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            string trangthai = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            if (trangthai == "0")
                cbtrangthai.Text = "Không sử dụng";
            else
                cbtrangthai.Text = "Đang sử dụng";
        }
    }
}
