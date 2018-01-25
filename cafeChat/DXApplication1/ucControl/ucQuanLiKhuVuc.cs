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
using DTO;
using BUS;

namespace DXApplication1.ucControl
{
    public partial class ucQuanLiKhuVuc : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLiKhuVuc()
        {
            InitializeComponent();
        }

        void resetText()
        {
            txtma.ResetText();
            txtten.ResetText();
            txtghichuddd.Control.ResetText();
            cbtrangthai.ResetText();
        }
        void KhuVuc_Load()
        {
            gridKhuVuc.DataSource = KhuVucBUS.KhuVuc_Load();
        }

        private void btnThemKV_Click(object sender, EventArgs e)
        {
            if (txtten.Text != "" && cbtrangthai.ToString() != "")
            {
                KhuVucDTO kv = new KhuVucDTO();
                kv.Kv_ten = txtten.Text;
                kv.Kv_trangthai = cbtrangthai.SelectedItem.ToString();
                kv.Kv_ghichu = txtghichu.Text;

                if (KhuVucBUS.KhuVuc_ThemSuaXoa(kv, 1))
                {
                    XtraMessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhuVuc_Load();
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

        private void btnCapNhatKV_Click(object sender, EventArgs e)
        {
            KhuVucDTO kv = new KhuVucDTO();
            DialogResult dialogResult = MessageBox.Show("Chắc chắn", "Bạn chắc muốn sửa chứ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (txtma.Text != "" & txtten.Text != "" && cbtrangthai.ToString() != "")
                {
                    kv.Kv_id = int.Parse(txtma.Text);
                    kv.Kv_ten = txtten.Text;
                    kv.Kv_trangthai = cbtrangthai.SelectedItem.ToString();
                    kv.Kv_ghichu = txtghichu.Text;

                    if (KhuVucBUS.KhuVuc_ThemSuaXoa(kv, 2))
                    {
                        XtraMessageBox.Show("Sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KhuVuc_Load();
                        resetText();
                    }
                    else
                        XtraMessageBox.Show("Lỗi không sửa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KhuVucDTO kv = new KhuVucDTO();
            DialogResult dialogResult = MessageBox.Show("Chắc chắn", "Bạn chắc muốn xóa chứ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                kv.Kv_id = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"kv_id").ToString());
                if (KhuVucBUS.KhuVuc_ThemSuaXoa(kv, 3))
                {
                    XtraMessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhuVuc_Load();
                    resetText();
                }
                else
                    XtraMessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridKhuVuc_Click(object sender, EventArgs e)
        {
            txtma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtghichu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            cbtrangthai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
        }

        private void ucQuanLiKhuVuc_Load(object sender, EventArgs e)
        {
            KhuVuc_Load();
        }
    }
}
