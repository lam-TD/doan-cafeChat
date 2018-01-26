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
    public partial class frmDoiMatkhau : DevExpress.XtraEditors.XtraForm
    {
        private static string manhanvien = "";
        public frmDoiMatkhau(string manv)
        {
            InitializeComponent();
            manhanvien = manv;
        }

        void loadmk(string manv)
        {
            DataTable dt = TaiKhoanBus.TaiKhoan_LayQuyenTruyCap(manv);
            string mkcu = dt.Rows[0]["tk_matkhau"].ToString();
            if (mkcu == txtmatkhaucu.Text)
            {
                if (txtmkmoi.Text != txtmatkhaucu.Text)
                {
                    if (txtmkmoi.Text == txtnhaplaimk.Text)
                    {
                        DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            TaiKhoanDTO tk = new TaiKhoanDTO();
                            tk.Nv_id = manv;
                            tk.Tm_mk = txtmkmoi.Text;
                            tk.Tk_trangthai = 1;
                            tk.Tk_quyen = int.Parse(dt.Rows[0]["tk_quyen"].ToString());
                            if (TaiKhoanBus.TaiKhoan_Them(tk, 2))
                                XtraMessageBox.Show("Đã cập nhật mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                XtraMessageBox.Show("Lỗi không cập nhật được mật khẩu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }
                    else { XtraMessageBox.Show("Xác nhận mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { XtraMessageBox.Show("Mật khẩu cũ và mật khẩu mới phải khác nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { XtraMessageBox.Show("Mật khẩu cũ cũ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            loadmk(manhanvien);
        }

        private void frmDoiMatkhau_Load(object sender, EventArgs e)
        {
            AcceptButton = btndoimk;
        }
    }
}