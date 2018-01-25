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
using DAL;
namespace DXApplication1
{
    public partial class FrmThuNgan : DevExpress.XtraEditors.XtraForm
    {
        public FrmThuNgan()
        {
            InitializeComponent();
        }



        #region XU LY
        public static string MaNhanVien = "NV0001";
        public static int MaThucUong;
        public static string tenban;
        void Tao_Ban()
        {
            flowLayoutBan.Controls.Clear();
            DataTable dt = KhuVucBUS.KhuVuc_LoadTheoTrangThai("Đang sử dụng");
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
                    gridCTHD_Load(dt.Rows[0]["hd_id"].ToString()); // load danh sach thức uống trong chi tiết HD
                    txttiennhan.ReadOnly = false;
                    btnthemthucuong.Enabled = true;
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

        void gridCTHD_Load(string mahd)
        {
            gridCTHD.DataSource = ChiTietHoaDonBUS.CTHD_Load_DonGia_TinhThanhTien(mahd);
        }

        void txtThanhTien_txtTongCong_Load() // tính tổng tiền gán vào txttongcong
        {
            try
            {
                txtthanhtien.Text = HoaDonBUS.DinhDangTienTienTe(double.Parse(gridViewCTHD.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()));
                txttongcong.Text = HoaDonBUS.DinhDangTienTienTe(HoaDonBUS.HoaDon_TinhTongTien(txtthanhtien.Text, txtphuthu.Text, txtgiamgia.Text));
            }
            catch (Exception)
            {
                txtthanhtien.Text = "0";
                txttongcong.Text = "0";
            }
            
        }

        void txtPhuThu_txtGiamGia_txtTienNhan_Xet_Watermark()
        {
            txtphuthu.Text = "0";
            this.txtphuthu.Leave += new System.EventHandler(this.txtphuthu_Leave);
            this.txtphuthu.Enter += new System.EventHandler(this.txtphuthu_Enter);

            txtgiamgia.Text = "0";
            this.txtgiamgia.Leave += new System.EventHandler(this.txtgiamgia_Leave);
            this.txtgiamgia.Enter += new System.EventHandler(this.txtgiamgia_Enter);

            txttiennhan.Text = "0";
            this.txttiennhan.Leave += new System.EventHandler(this.txttiennhan_Leave);
            this.txttiennhan.Enter += new System.EventHandler(this.txttiennhan_Enter);
            this.txttiennhan.TextChanged += new System.EventHandler(this.txttiennhan_TextChanged);
        }

        public void TachSo(TextBox phuthu) //hàm nhập số thêm vào dấu phẩy
        {
            string txt, txt1;
            txt1 = txttiennhan.Text.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            txttiennhan.Text = txt;
            txttiennhan.SelectionStart = txttiennhan.Text.Length;
        }

        public void TachSo_txtphucthu(TextEdit phuthu) //hàm nhập số thêm vào dấu phẩy
        {
            string txt, txt1;
            txt1 = txtphuthu.Text.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            txtphuthu.Text = txt;
            txtphuthu.SelectionStart = txtphuthu.Text.Length;
        }

        public void TachSo_txtgiamgia(TextEdit phuthu) //hàm nhập số thêm vào dấu phẩy
        {
            string txt, txt1;
            txt1 = txtgiamgia.Text.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            txtgiamgia.Text = txt;
            txtgiamgia.SelectionStart = txtgiamgia.Text.Length;
        }

        void XetThuocTinhChoCacButton(bool dong_mo, bool themthucuong, bool huyban_thanhtoan)
        {
            btnthemthucuong.Enabled = themthucuong;
            btnhuyban.Enabled = dong_mo;
            numgiamgia.Enabled = dong_mo;
            numphuthu.Enabled = dong_mo;
            txttiennhan.Enabled = dong_mo;
            txtgiamgia.Enabled = dong_mo;
            txtphuthu.Enabled = dong_mo;
            txttongcong.Enabled = dong_mo;
            txtghichu.Enabled = dong_mo;
            txtthanhtien.Enabled = dong_mo;
            txttenkh.Enabled = dong_mo;
            btnthanhtoan.Enabled = dong_mo;
            txttienthua.Enabled = dong_mo;
            btnhuyban.Enabled = huyban_thanhtoan;
            btnthanhtoan.Enabled = huyban_thanhtoan;
            btndoiban.Enabled = huyban_thanhtoan;
            btngopban.Enabled = huyban_thanhtoan;
            txttongcong.ForeColor = Color.Red;
            gridCTHD.Enabled = huyban_thanhtoan;
        }


        #endregion END XU LY
        

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void FrmThuNgan_Load(object sender, EventArgs e)
        {
            Tao_Ban();
            treelist_ThemDanhMuc();
            listview_ThucUong_Load(1,0);
            cbBan_Load();
            dateTimePickerNgayLap.Value = DateTime.Now;
            dateTimeGioLapHD.Value = DateTime.Now;
            XetThuocTinhChoCacButton(false,false,false);
            txtPhuThu_txtGiamGia_txtTienNhan_Xet_Watermark();
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
                string trangthaiBan = BanBUS.Ban_KiemTra_TrangThai_TheoIDBan(maban);
                DataTable dt = HoaDonBUS.HoaDon_XacDinh_BanCoHDHayChua(trangthaiBan, maban);
                txtmahd.Text = dt.Rows[0]["hd_id"].ToString(); // gán mã hóa đơn
                gridCTHD_Load(dt.Rows[0]["hd_id"].ToString()); // load danh sach thức uống trong chi tiết HD
                if (trangthaiBan == "Có khách")
                {
                    dateTimePickerNgayLap.Value = DateTime.Parse(dt.Rows[0]["hd_ngaylap"].ToString());
                    XetThuocTinhChoCacButton(true,true,true);
                }
                else{ XetThuocTinhChoCacButton(false, true,false); }
                    
                txttrangthaiban.Text = trangthaiBan;                                         
                txtThanhTien_txtTongCong_Load();
            }
            catch (Exception)
            { return; }   
        }

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            txtThanhTien_txtTongCong_Load();
        }

        private void listViewThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewThucUong.SelectedItems.Count == 0)
                return;
            numsoluong.Value = 1;
            ListViewItem item = listViewThucUong.SelectedItems[0];
            txtTenThucChon.Text = item.Text;
            MaThucUong = int.Parse(item.SubItems[2].Text); // lấy lã thức uống để thêm vào CTHD

        }

        private void btnthemthucuong_Click(object sender, EventArgs e)
        {
            if (txtTenThucChon.Text == "")
            {
                XtraMessageBox.Show("Chưa chọn thức uống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                cthd.Tu_id = MaThucUong;   // lấy mã thức uống lưu vào CTHD
                cthd.Hd_ma = txtmahd.Text; // lấy mã hóa đơn lưu vào CTHD
                cthd.Cthd_soluong = int.Parse(numsoluong.Value.ToString()); // lấy số lượng thức uống lưu vào CTHD
                // kiểm tra trạng thái của Bàn và mã Hóa Đơn
                // nếu Bàn trống thì thêm Hoa Don trước -> thêm CTHD
                // Bàn có khách thì chỉ thêm mới cthd -> kiểm tra thức uống thêm vào đã có trong CTHD hay chưa
                //-> nếu có thì cập nhật lại số lượng theo mã HD và mã Thức uống
                //-> nếu chưa thì thêm mới CTHD 
                switch (txttrangthaiban.Text)
                {
                    case "Trống":
                        HoaDonDTO hd = new HoaDonDTO();
                        hd.Hd_id = txtmahd.Text;
                        hd.Ban_id = cbBan.SelectedValue.ToString();
                        hd.Hd_trangthai = 0;
                        hd.Hd_ngaylap = dateTimePickerNgayLap.Value.ToString("MM/dd/yyyy");
                        hd.Hd_phuthu = 0;
                        hd.Hd_giamgia = 0;
                        hd.Hd_tongtien = 0;
                        hd.Nv_id = MaNhanVien;
                        if (HoaDonBUS.HoaDon_ThemXoaSuaHuyBan(hd,1))
                        {
                            if (ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 1))
                            {
                                if (BanBUS.Ban_CapNhatTrangThaiBan(cbBan.SelectedValue.ToString(), "Có khách"))
                                { Tao_Ban(); txttrangthaiban.Text = "Có khách"; XetThuocTinhChoCacButton(true, true, true); }
                                else
                                    XtraMessageBox.Show("Lỗi nhật được trạng thái bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                                XtraMessageBox.Show("Lỗi không thêm được Chi Tiết Hóa Đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            XtraMessageBox.Show("Lỗi không thêm Hóa Đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "Có khách":
                        DataTable dt = ChiTietHoaDonBUS.CTHD_KiemTraThucUongCoTrongCTHD(int.Parse(MaThucUong.ToString()), txtmahd.Text);
                        if (dt.Rows.Count > 0)
                        {
                            cthd.Cthd_soluong = int.Parse(dt.Rows[0]["cthd_soluong"].ToString()) + int.Parse(numsoluong.Value.ToString());
                            if (!ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd,2))
                                XtraMessageBox.Show("Lỗi không cập nhật được sô lượng Thức uống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (!ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd,1))
                                XtraMessageBox.Show("Lỗi không thêm mới được Chi Tiết Hóa Đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    default:
                        break;
                }
                gridCTHD_Load(txtmahd.Text);
                txtthanhtien.Text = HoaDonBUS.DinhDangTienTienTe(double.Parse(gridViewCTHD.Columns["ThanhTien"].SummaryItem.SummaryValue.ToString()));
                txtThanhTien_txtTongCong_Load();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi");
            }
        }

        #region txtgiamgia, txtphuthu
        private void txtgiamgia_Enter(object sender, EventArgs e)
        {
            if (txtgiamgia.Text == "0")txtgiamgia.Text = "";
        }

        private void txtgiamgia_Leave(object sender, EventArgs e)
        {
            if (txtgiamgia.Text == "")txtgiamgia.Text = "0";
        }

        private void txtphuthu_Leave(object sender, EventArgs e)
        {
            if (txtphuthu.Text == "")txtphuthu.Text = "0";
        }

        private void txtphuthu_Enter(object sender, EventArgs e)
        {
            if (txtphuthu.Text == "0")txtphuthu.Text = "";
        }

        private void txtphuthu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))e.Handled = true;
        }

        private void txtgiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))e.Handled = true;
        }
        #endregion
        private void btn_XoaChiTietHD_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
            cthd.Tu_id = int.Parse(gridViewCTHD.GetRowCellValue(gridViewCTHD.FocusedRowHandle, "tu_id").ToString());
            cthd.Hd_ma = txtmahd.Text;
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa thức uống vừa chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (!ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 3))
                {
                    XtraMessageBox.Show("Lỗi","Thông báo");
                }
                gridCTHD_Load(txtmahd.Text);
                txtThanhTien_txtTongCong_Load();
            }   
        }

        private void gridViewCTHD_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                cthd.Tu_id = int.Parse(gridViewCTHD.GetRowCellValue(e.RowHandle, "tu_id").ToString());
                cthd.Hd_ma = txtmahd.Text;
                cthd.Cthd_soluong = int.Parse(gridViewCTHD.GetRowCellValue(e.RowHandle, "cthd_soluong").ToString());
                DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn sửa lại số lượng thức uống vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 2))
                        XtraMessageBox.Show("Lỗi không cập nhật được số lượng mới!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                gridCTHD_Load(txtmahd.Text);
                txtThanhTien_txtTongCong_Load();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi", "Thông báo");
            }
        }

        private void gridCTHD_ProcessGridKey(object sender, KeyEventArgs e)
        {
            
        }

        private void gridViewCTHD_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            // Sự kiện này để người ta không chuyển qua dòng khác được khi có lỗi xảy ra nè
            // Nó nhận giá trị e.Valid của gridView1_ValidateRow để ứng xử
            // neu e,Valid =True thì nó cho chuyển qua dòng khác hoặc làm tác vụ khác
            // và ngược lại
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void txtphuthu_TextChanged_1(object sender, EventArgs e)
        {
            txtThanhTien_txtTongCong_Load();
            TachSo_txtphucthu(txtphuthu);
        }

        private void txttiennhan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double tongtien = double.Parse(txttongcong.Text);
                if (double.Parse(txttiennhan.Text) >= tongtien)
                    txttienthua.Text = HoaDonBUS.DinhDangTienTienTe(HoaDonBUS.HoaDon_TinhTienThua(txttiennhan.Text, txttongcong.Text));
                else
                    txttienthua.Text = "0";
                TachSo(txttiennhan);
            }
            catch (Exception)
            { return; }
        }

        private void txttiennhan_Enter(object sender, EventArgs e)
        {
            if (txttiennhan.Text == "0")txttiennhan.Text = "";
        }

        private void txttiennhan_Leave(object sender, EventArgs e)
        {
            if (txttiennhan.Text == "")txttiennhan.Text = "0";
        }

        private void btnhuyban_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn hủy "+ cbBan.SelectedText +"?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                cthd.Hd_ma = txtmahd.Text;
                if (ChiTietHoaDonBUS.CTHD_ThemXoaSuaHuyBan(cthd, 4))
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.Hd_id = txtmahd.Text;
                    if (HoaDonBUS.HoaDon_ThemXoaSuaHuyBan(hd,4))
                    {
                        if (!BanBUS.Ban_CapNhatTrangThaiBan(cbBan.SelectedValue.ToString(), "Trống"))
                            XtraMessageBox.Show("Lỗi không cập nhật được trạng thái Bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            XtraMessageBox.Show("Đã hủy "+ cbBan.SelectedText.ToString() +"!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Tao_Ban();
                        }
                    }
                    else
                        XtraMessageBox.Show("Lỗi không xóa Hóa Đơn!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                    XtraMessageBox.Show("Lỗi không xóa được Chi Tiết Hóa Đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridCTHD_Load(txtmahd.Text);
                txtThanhTien_txtTongCong_Load();
            }
        }

        private void txttiennhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void numphuthu_ValueChanged(object sender, EventArgs e)
        {
            txtphuthu.Text = HoaDonBUS.DinhDangTienTienTe(HoaDonBUS.TinhTienTheoPhanTram(numphuthu.Value.ToString(), txtthanhtien.Text));
        }

        private void numgiamgia_ValueChanged(object sender, EventArgs e)
        {
            txtgiamgia.Text = HoaDonBUS.DinhDangTienTienTe(HoaDonBUS.TinhTienTheoPhanTram(numgiamgia.Value.ToString(), txtthanhtien.Text));
        }

        private void btndoiban_Click(object sender, EventArgs e)
        {
            FormCon.frmDoiBan doiban = new FormCon.frmDoiBan(cbBan.Text, cbBan.SelectedValue.ToString());
            if (doiban.ShowDialog() == DialogResult.OK)
            {
                Tao_Ban();
                XetThuocTinhChoCacButton(false,false,false);
            }
        }

        private void btngopban_Click(object sender, EventArgs e)
        {
            FormCon.frmGopBan gb = new FormCon.frmGopBan(cbBan.Text, cbBan.SelectedValue.ToString());
            //FormCon.frmGopTachBan gb = new FormCon.frmGopTachBan(cbBan.Text, cbBan.SelectedValue.ToString());
            if (gb.ShowDialog() == DialogResult.OK)
            {
                Tao_Ban();
                XetThuocTinhChoCacButton(false, false, false);
            }
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            
            try
            {
                HoaDonDTO hd = new HoaDonDTO();
                hd.Hd_id = txtmahd.Text;
                hd.Hd_phuthu = int.Parse(txtphuthu.Text);
                hd.Hd_giamgia = int.Parse(txtgiamgia.Text);
                double tongtien = double.Parse(txttongcong.Text.ToString());
                hd.Hd_tongtien = tongtien;
                hd.Hd_ngaylap = dateTimePickerNgayLap.Value.ToString("MM/dd/yyyy");
                hd.Ban_id = cbBan.SelectedValue.ToString();
                hd.Nv_id = MaNhanVien;
                hd.Hd_trangthai = 1;
                if (HoaDonBUS.HoaDon_ThemXoaSuaHuyBan(hd,2))
                {
                    if (BanBUS.Ban_CapNhatTrangThaiBan(hd.Ban_id,"Trống"))
                    {
                        Tao_Ban();
                        XetThuocTinhChoCacButton(false, false, false);
                    }else XtraMessageBox.Show("Không cập nhật được trạng thái Bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else XtraMessageBox.Show("Lỗi không cập nhật được Hóa Đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi không Thanh Toán được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}