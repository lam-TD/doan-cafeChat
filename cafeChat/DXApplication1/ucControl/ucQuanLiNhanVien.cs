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
    public partial class ucQuanLiNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiNhanVien()
        {
            InitializeComponent();
        }
        void NhanVien_Load()
        {
            gridNhanVien.DataSource = NhanVienBUS.NhanVien_Load();
        }

        private void ucQuanLiNhanVien_Load(object sender, EventArgs e)
        {
            NhanVien_Load();
        }

        void resetText()
        {
            txtdiachi.ResetText();
            txthoten.ResetText();
            txtmanv.ResetText();
            txtsdt.ResetText();
            cbtrangthai.ResetText();
        }


        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtdiachi.Text == "" || txthoten.Text == "" || txtsdt.Text == "" || cbtrangthai.Text == "")
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.Nv_id = NhanVienBUS.TimIDKeTiep();
                nv.Nv_sdt = txtsdt.Text;
                nv.Nv_taikhoan = 0;
                nv.Nv_ten = txthoten.Text;
                nv.Nv_trangthai = cbtrangthai.Text;
                nv.Nv_diachi = txtdiachi.Text;
                if (NhanVienBUS.NhanVien_ThemSuaXoa(nv,1))
                {
                    XtraMessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    NhanVien_Load();
                    resetText();
                }
                else { XtraMessageBox.Show("Lỗi không thêm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn sửa thông tin nhân viên vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                nv.Nv_id = txtmanv.Text;
                nv.Nv_ten = txthoten.Text;
                nv.Nv_diachi = txtdiachi.Text;
                nv.Nv_sdt = txtsdt.Text;
                nv.Nv_trangthai = cbtrangthai.Text;

                if (NhanVienBUS.NhanVien_ThemSuaXoa(nv, 2))
                {
                    XtraMessageBox.Show("Sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhanVien_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Lỗi không sửa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridNhanVien_Click(object sender, EventArgs e)
        {
            txtmanv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txthoten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtsdt.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            txtdiachi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            cbtrangthai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn XÓA thông tin nhân viên vừa chọn", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                nv.Nv_id = txtmanv.Text;
                if (NhanVienBUS.NhanVien_ThemSuaXoa(nv, 3))
                {
                    XtraMessageBox.Show("Đã xóa nhân viên " + txtmanv.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhanVien_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Lỗi không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) { e.Handled = true; }
        }
    }
}
