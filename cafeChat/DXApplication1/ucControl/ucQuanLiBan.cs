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
    public partial class ucQuanLiBan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiBan()
        {
            InitializeComponent();
        }

        void Ban_Load()
        {
            gridBan.DataSource = BanBUS.Ban_Load();
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
                BanDTO b = new BanDTO();
                b.Ban_id = BanBUS.Ban_TimMaBanKeTiep();
                b.Ban_ten = txtten.Text;
                b.Ban_trangthai = cbtrang_thai.SelectedItem.ToString();
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
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnCapNhatBan_Click(object sender, EventArgs e)
        {
            BanDTO b = new BanDTO();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn SỬA thông tin BÀN vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void gridBan_Click(object sender, EventArgs e)
        {
            txtma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            cbkhu_vuc.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            cbtrang_thai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
        }

        private void ucQuanLiBan_Load(object sender, EventArgs e)
        {
            Ban_Load();
            cbkhu_vuc_Load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BanDTO b = new BanDTO();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn XÓA thông tin BÀN vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                b.Ban_id = txtma.Text;
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
}
