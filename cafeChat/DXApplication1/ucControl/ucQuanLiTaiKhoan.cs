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
    public partial class ucQuanLiTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public static string tennv = "";
        public static string quyen = "";
        public static string mk = "";
        public ucQuanLiTaiKhoan()
        {
            InitializeComponent();
            TaiKhoan_Load();
        }

        void TaiKhoan_Load()
        {
            gridTk.DataSource =  TaiKhoanBus.Load_TaiKhoan();
        }

        private void btnThemTk_Click(object sender, EventArgs e)
        {
            frmTaiKhoan_Them tk = new frmTaiKhoan_Them();
            if (tk.ShowDialog() == DialogResult.OK) { TaiKhoan_Load(); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FormCon.frmCapNhatTaiKhoan c = new FormCon.frmCapNhatTaiKhoan(tennv, quyen,mk);
            if (c.ShowDialog() == DialogResult.OK) { TaiKhoan_Load(); }
        }

        private void gridTk_Click(object sender, EventArgs e)
        {
            try
            {
                tennv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                quyen = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                mk = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.Nv_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn XÓA tài khoản vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (TaiKhoanBus.TaiKhoan_Them(tk, 3))
                {
                    XtraMessageBox.Show("Đã xóa tài khoản của nhân viên có mã: " + tk.Nv_id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiKhoan_Load();
                }
                else
                    XtraMessageBox.Show("Lỗi không xóa được" + tk.Nv_id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
        }
    }
}
