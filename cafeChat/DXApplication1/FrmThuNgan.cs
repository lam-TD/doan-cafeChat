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
                cbBan.Text = bt.Text;
                try
                {
                    string trangthaiBan = BanBUS.Ban_KiemTra_TrangThai_TheoIDBan(bt.Tag.ToString());
                    DataTable dt = HoaDonBUS.HoaDon_XacDinh_BanCoHDHayChua(trangthaiBan, bt.Tag.ToString());
                    txtmahd.Text = dt.Rows[0]["hd_id"].ToString();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Lỗi rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    //contextMenuStrip_Table.Show(bt, e.Location);
                }
        }

        void treelist_ThemDanhMuc()
        {
            List<DanhMucDTO> dm = DanhMucBUS.DanhMuc_List();
            foreach (DanhMucDTO item in dm)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Dm_ten;
                node.Tag = item.Dm_id.ToString();
                treedanhmuc.Nodes.Add(node);
            }
        }

        void CauHinh_ListViewThucUong()
        {
            listViewThucUong.View = View.Details; // hiểm thị detail cho listview
            listViewThucUong.FullRowSelect = true;
            listViewThucUong.GridLines = true;

            ColumnHeader header1 = new ColumnHeader(); // cấu hình cột cho listview
            header1.Text = "Tên thức uống";
            header1.Width = 100;
            header1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader header2 = new ColumnHeader();
            header2.Text = "Đơn giá";
            header2.Width = 98;
            header2.TextAlign = HorizontalAlignment.Center;

            ColumnHeader header3 = new ColumnHeader();
            header3.Text = "ID";
            header3.Width = 30;
            header3.TextAlign = HorizontalAlignment.Center;

            listViewThucUong.Columns.Add(header1);
            listViewThucUong.Columns.Add(header2);
            listViewThucUong.Columns.Add(header3);
        }
        void listview_ThucUong_Load(int type, int iddanhmuc) // load tất cả thức uống hoặc theo id danh mục 1-tất cả || 2-id danh mục
        {
            listViewThucUong.Clear();
            CauHinh_ListViewThucUong();
            DataTable dt = new DataTable();
            if (type == 1)
                dt = ThucUongBUS.ThucUong_Load();
            else
                dt = ThucUongBUS.ThucUong_Load_IDDanhMuc(iddanhmuc);
            int i = 0;
            foreach (DataRow itemTU in dt.Rows)
            {
                listViewThucUong.Items.Add(itemTU["tu_ten"].ToString());
                listViewThucUong.Items[i].SubItems.Add(itemTU["tu_gia"].ToString());
                listViewThucUong.Items[i].SubItems.Add(itemTU["tu_id"].ToString());
                i++;
            }

        }

        void cbBan_Load()
        {
            cbBan.DataSource = BanBUS.Ban_Load();
            cbBan.DisplayMember = "ban_ten";
            cbBan.ValueMember = "ban_id";
            cbBan.SelectedIndex = -1;
        }

        #endregion END XU LY
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void FrmThuNgan_Load(object sender, EventArgs e)
        {
            Tao_Ban();
            treelist_ThemDanhMuc();
            listview_ThucUong_Load(1,0);
            cbBan_Load();
        }

        private void treedanhmuc_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listview_ThucUong_Load(2, int.Parse(e.Node.Tag.ToString()));
        }

        private void cbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string maban = cbBan.SelectedValue.ToString();
                try
                {
                    string trangthaiBan = BanBUS.Ban_KiemTra_TrangThai_TheoIDBan(maban);
                    DataTable dt = HoaDonBUS.HoaDon_XacDinh_BanCoHDHayChua(trangthaiBan, maban);
                    txtmahd.Text = dt.Rows[0]["hd_id"].ToString();
                    //txtthanhtien.Text = dt.Rows[0]["hd_id"].ToString();
                    //txttongcong.Text = dt.Rows[0]["hd_tongtien"].ToString();
                }
                catch (Exception)
                {
                    //XtraMessageBox.Show("Lỗi rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}