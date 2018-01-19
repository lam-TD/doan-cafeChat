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

        void Tao_Ban2()
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
                grkhuvuc.Controls.Add(flowKhuVuc);

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
                }
                flowLayoutBan.Controls.Add(grkhuvuc);
            }
        }


        void Tao_Ban()
        {
            
            DataTable dt = KhuVucBUS.KhuVuc_Load();
            GroupBox grKhuVuc = new GroupBox();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int makv = int.Parse(dt.Rows[i]["kv_id"].ToString());
                string tenkv = dt.Rows[i]["kv_ten"].ToString();
                // Tao Danh sach ban
                List<BanDTO> tb = new List<BanDTO>();
                tb = BanBUS.Ban_List_KhuVuc(makv);
                Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
                GroupBox oldgr = new GroupBox() { Width = 0, Location = new Point(0, 0) };
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
                    grKhuVuc = new GroupBox()
                    {
                        Width = 400,
                        Height = 400,
                        Location = new Point(oldgr.Location.X + oldgr.Width, oldgr.Location.Y),
                        Text = tenkv
                    };
                    grKhuVuc.Controls.Add(btn);
                    oldbtn = btn;
                    oldgr = grKhuVuc;
                }
                flowLayoutBan.Controls.Add(grKhuVuc);
            }//end tao danh sach ban
        }
        public void create_table()
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
            //create_table();
            //Tao_Ban();
            Tao_Ban2();
        }
    }
}