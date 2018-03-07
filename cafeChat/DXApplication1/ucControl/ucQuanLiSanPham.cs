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
    public partial class ucQuanLiSanPham : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiSanPham()
        {
            InitializeComponent();
        }

        void ThucUong_Load()
        {
            gridThucUong.DataSource = ThucUongBUS.ThucUong_Load();
        }
        void resetText()
        {
            txtmatu.ResetText();
            txttentu.ResetText();
            numdongia.ResetText();
            cbdanhmuc.ResetText();
            cbtrangthai.ResetText();
        }

        void cbDanhMuc_Load()
        {
            cbdanhmuc.DataSource = DanhMucBUS.DanhMuc_Load();
            cbdanhmuc.DisplayMember = "dm_ten";
            cbdanhmuc.ValueMember = "dm_id";
            cbdanhmuc.SelectedIndex = 0;

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txttentu.Text != "" && numdongia.Value != 0 && cbtrangthai.ToString() != "" && cbdanhmuc.Text != "")
            {
                ThucUongDTO tu = new ThucUongDTO();
                //tu.Tu_id = int.Parse(txtmatu.Text);
                tu.Tu_ten = txttentu.Text;
                tu.Tu_gia = int.Parse(numdongia.Value.ToString());
                if (cbtrangthai.Text == "Đang sử dụng") { tu.Tu_trangthai = 1; }
                else { tu.Tu_trangthai = 0; }

                tu.Dm_id = int.Parse(cbdanhmuc.SelectedValue.ToString());
                if (ThucUongBUS.ThucUong_ThemSuaXoa(tu, 1))
                {
                    XtraMessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThucUong_Load();
                    resetText();
                }
                else XtraMessageBox.Show("Lỗi không thêm được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void gridThucUong_Load(object sender, EventArgs e)
        {
            LookUpEditTranThai.DisplayMember = "";
            LookUpEditTranThai.ValueMember = "tu_trangthai";
        }

        private void gridThucUong_Click(object sender, EventArgs e)
        {
            txtmatu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txttentu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            numdongia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            string trangthai = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            if (trangthai == "0")
                cbtrangthai.Text = "Không sử dụng";
            else
                cbtrangthai.Text = "Đang sử dụng";
            cbdanhmuc.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            ThucUongDTO tu = new ThucUongDTO();
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn SỬA thông tin thức uống vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                tu.Tu_id = int.Parse(txtmatu.Text);
                tu.Tu_ten = txttentu.Text;
                tu.Tu_gia = int.Parse(numdongia.Value.ToString());
                if (cbtrangthai.Text == "Đang sử dụng")
                {
                    tu.Tu_trangthai = 1;
                }
                else
                {
                    tu.Tu_trangthai = 0;
                }

                tu.Dm_id = int.Parse(cbdanhmuc.SelectedValue.ToString());
                if (ThucUongBUS.ThucUong_ThemSuaXoa(tu, 2))
                {
                    XtraMessageBox.Show("Sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThucUong_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Lỗi không sửa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            ThucUongDTO tu = new ThucUongDTO();
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn XÓA thông tin thức uống vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                tu.Tu_id = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"tu_id").ToString());
                if (ThucUongBUS.ThucUong_ThemSuaXoa(tu, 3))
                {
                    XtraMessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThucUong_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Lỗi không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ucQuanLiSanPham_Load(object sender, EventArgs e)
        {
            ThucUong_Load();
            cbDanhMuc_Load();
            cbtrangthai.SelectedIndex = 0;
        }
    }
}
