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
using DTO;
using BUS;
namespace DXApplication1
{
    public partial class FrmThuNgan : DevExpress.XtraEditors.XtraForm
    {
        public FrmThuNgan()
        {
            InitializeComponent();
        }

        #region XU LY
        public void create_table(int col, int row)
        {
            Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
            List<BanDTO> tb = new List<BanDTO>();
            tb = BanBUS.Ban_List();
            foreach (BanDTO tb_child in tb)
            {
                Button btn = new Button()
                {
                    Width = 80,
                    Height = 80,
                    Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                    Text = tb_child.Ban_ten,
                    Tag = tb_child.Ban_id
                };
                // gán màu cho bàn theo trạng thái Trống - xanh, Có khách - Đỏ, Đặt trước - Hồng
                if (tb_child.Ban_trangthai == "Trống")
                    btn.BackColor = Color.Blue;
                else if (tb_child.Ban_trangthai == "Có khách")
                    btn.BackColor = Color.Red;
                else
                    btn.BackColor = Color.Pink;

                //btn.MouseDown += new MouseEventHandler(bt_MouseDown); // tạo sự kiện click cho các button
                flowLayoutBan.Controls.Add(btn);
                oldbtn = btn;
            }
        } // end create_table
        #endregion
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void FrmThuNgan_Load(object sender, EventArgs e)
        {
            create_table(3, 3);
        }
    }
}