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
    public partial class frmCapNhatTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frmCapNhatTaiKhoan(string manv, string quyen, string mk)
        {
            InitializeComponent();
            TaiKhoan_Load();
            cbmanv.Text = manv;
            cbquyen.Text = quyen;
            txtmatkhau.Text = mk;
        }

        void TaiKhoan_Load()
        {
            cbmanv.DataSource = TaiKhoanBus.Load_TaiKhoan();
            cbmanv.DisplayMember = "nv_id";
            cbmanv.ValueMember = "nv_id";
            cbmanv.SelectedIndex = -1;
        }

        private void frmCapNhatTaiKhoan_Load(object sender, EventArgs e)
        {
            //TaiKhoan_Load();
        }

        private void cbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = TaiKhoanBus.TaiKhoan_LayQuyenTruyCap(cbmanv.SelectedValue.ToString());
                if (dt.Rows[0]["tk_quyen"].ToString() == "0")
                    cbquyen.Text = "Nhân viên";
                else
                    cbquyen.Text = "Quản lý";
                txtmatkhau.Text = dt.Rows[0]["tk_matkhau"].ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (cbquyen.SelectedIndex == -1 || cbquyen.SelectedIndex == -1 || txtmatkhau.Text == "")
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT tài khoản vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    TaiKhoanDTO tk = new TaiKhoanDTO();
                    tk.Nv_id = cbmanv.Text;
                    if (cbquyen.Text == "Nhân viên") { tk.Tk_quyen = 0; }else { tk.Tk_quyen = 1; }
                    tk.Tm_mk = txtmatkhau.Text;
                    tk.Tk_trangthai = 1;
                    if (TaiKhoanBus.TaiKhoan_Them(tk,2))
                    {
                        XtraMessageBox.Show("Cập nhật thành công tài khoản: " + cbmanv.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                        XtraMessageBox.Show("Lỗi không xóa được", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}