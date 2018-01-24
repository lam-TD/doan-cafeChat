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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        void Dang_Nhap()
        {
            if (txttaikhoan.Text == "" || txtmatkhau.Text == "") { XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                string taikhoan = txttaikhoan.Text.Trim();
                string matkhau = txtmatkhau.Text.Trim();
                if (TaiKhoanBus.TaiKhoan_Login(taikhoan, matkhau))
                {
                    Form1 frmchinh = new Form1(taikhoan);
                    frmchinh.ShowDialog();
                    this.Hide();
                }
                else { XtraMessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            Dang_Nhap();
        }

        private void btndangnhap_Enter(object sender, EventArgs e)
        {
            //Dang_Nhap();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            AcceptButton = btndangnhap;
            txttaikhoan.Text = "Vui lòng nhập tài khoản...";
            txttaikhoan.ForeColor = Color.Gray;
            this.txttaikhoan.Leave += new System.EventHandler(this.txttaikhoan_Leave);
            this.txttaikhoan.Enter += new System.EventHandler(this.txttaikhoan_Enter);
            
        }

        private void txttaikhoan_Enter(object sender, EventArgs e)
        {
            if (txttaikhoan.Text == "Vui lòng nhập tài khoản...")
            { txttaikhoan.Text = ""; txttaikhoan.ForeColor = Color.Black; }
        }

        private void txttaikhoan_Leave(object sender, EventArgs e)
        {
            if (txttaikhoan.Text == "") { txttaikhoan.Text = "Vui lòng nhập tài khoản..."; txttaikhoan.ForeColor = Color.LightGray; }
        }

        private void txtmatkhau_Enter(object sender, EventArgs e)
        {
            //{ txtmatkhau.Text = "Vui lòng nhập mật khẩu..."; txtmatkhau.ForeColor = Color.Black; }
        }

        private void txtmatkhau_Leave(object sender, EventArgs e)
        {
            //if (txtmatkhau.Text == "Vui lòng nhập mật khẩu...") txtmatkhau.Text = "0";
        }
    }
}