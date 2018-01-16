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
namespace DXApplication1
{
    public partial class frmTaiKhoan_Them : DevExpress.XtraEditors.XtraForm
    {
        public frmTaiKhoan_Them()
        {
            InitializeComponent();
            
        }
        void Load_cbMaNhanVien()
        {
            cbMaNv.DataSource = TaiKhoanBus.Load_TaiKhoan();
            cbMaNv.DisplayMember = "nv_id";
            cbMaNv.ValueMember = "nv_id";
            cbMaNv.SelectedIndex = -1;
        }

        bool KiemTra_Text()
        {
            return true;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaiKhoan_Them_Load(object sender, EventArgs e)
        {
            Load_cbMaNhanVien();
        }

        private void btnThemTk_Click(object sender, EventArgs e)
        {
            if (txtmatkhau.Text != "" && txtnhaplaimk.Text != "" && cbMaNv.SelectedValue.ToString() != "" && cbQuyen.Text != "")
            {
                if (txtmatkhau.Text.Length > 5 && txtmatkhau.Text.Length <= 20)
                {
                    if (txtmatkhau.Text == txtnhaplaimk.Text)
                    {
                        TaiKhoanDTO tk = new TaiKhoanDTO();
                        tk.Nv_id = cbMaNv.SelectedValue.ToString();
                        if (cbQuyen.Text == "Quản lý")
                            tk.Tk_quyen = 1;
                        else
                            tk.Tk_quyen = 0;
                        tk.Tm_mk = txtmatkhau.Text;
                        if (TaiKhoanBus.TaiKhoan_Them(tk, 1))
                        {
                            XtraMessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            XtraMessageBox.Show("Lỗi không thêm được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        XtraMessageBox.Show("Mật khẩu không trùng khớp!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    XtraMessageBox.Show("Độ dài mật khẩu từ 6-20 ký tự!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}