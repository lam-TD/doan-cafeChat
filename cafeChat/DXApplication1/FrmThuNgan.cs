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

        void Tao_Ban()
        {
            DataTable dt = KhuVucBUS.KhuVuc_Load();
            GroupBox grkhuvucCu = new GroupBox() { Width = 0, Location = new Point(0, 0) }; // lưu vị trí của groupbox cũ
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int makv = int.Parse(dt.Rows[i]["kv_id"].ToString());
                string tenkv = dt.Rows[i]["kv_ten"].ToString();
                GroupBox grkhuvuc = new GroupBox() // tạo groupbox(khu vực) chứa các button(bàn)
                {
                    Width = 450,
                    Height = 300,
                    Location = new Point(grkhuvucCu.Location.X + grkhuvucCu.Width, grkhuvucCu.Location.Y),
                    Text = tenkv,
                    Tag = makv,
                };

                FlowLayoutPanel flowKhuVuc = new FlowLayoutPanel(); // tạo FlowLayoutPanel add vào grKhuVuc
                flowKhuVuc.Dock = DockStyle.Fill;
                flowKhuVuc.AutoScroll = true;
                grkhuvuc.Controls.Add(flowKhuVuc); // add button vao flow

                // tao danh sach ban theo khu vuc
                List<BanDTO> ban = new List<BanDTO>();
                ban = BanBUS.Ban_List_KhuVuc(makv);
                Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
                foreach (BanDTO item in ban)
                {
                    Button btn = new Button()
                    {
                        Width = 80,
                        Height = 80,
                        Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                        Text = item.Ban_ten,
                        Tag = item.Ban_id
                    };
                    // gán màu cho bàn theo trạng thái Trống - xanh, Có khách - Đỏ, Đặt trước - Hồng
                    if (item.Ban_trangthai == "Trống")
                        btn.BackColor = Color.Blue;
                    else if (item.Ban_trangthai == "Có khách")
                        btn.BackColor = Color.Red;
                    else
                        btn.BackColor = Color.Pink;
                    flowKhuVuc.Controls.Add(btn);
                    btn.MouseDown += new MouseEventHandler(bt_MouseDown); // tạo sự kiện click cho các button
                }
                flowLayoutBan.Controls.Add(grkhuvuc);
            }
        }

        private void bt_MouseDown(object sender, MouseEventArgs e)// sự kiện click button khi tạo bảng table
        {
            Button bt = (Button)sender; //lấy button đang được click
            //tagtext = ((Button)sender).Text;

            if (e.Button == MouseButtons.Left)
            {
                //gridControl_bill_tbid.DataSource = BUS_Bill.loadBill_tbid(int.Parse(bt.Tag.ToString()));
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    //contextMenuStrip_Table.Show(bt, e.Location);
                }
        }

        #endregion
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void FrmThuNgan_Load(object sender, EventArgs e)
        {
            Tao_Ban();
        }
    }
}