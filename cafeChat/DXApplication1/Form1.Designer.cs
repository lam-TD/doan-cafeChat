namespace DXApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnQLTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnThuNgan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLHoaDon = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLThongKe = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLCaTruc = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLSanPham = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLDanhMuc = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLBan = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLKhuVuc = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbcaption = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.tableLayoutMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnQLTaiKhoan,
            this.barButtonItem2,
            this.barButtonItem3,
            this.btnThuNgan,
            this.barButtonItem5,
            this.btnQLHoaDon,
            this.btnQLThongKe,
            this.btnQLNhanVien,
            this.btnQLCaTruc,
            this.btnQLSanPham,
            this.btnQLDanhMuc,
            this.btnQLBan,
            this.btnQLKhuVuc});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2,
            this.ribbonPage1,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(891, 141);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.Caption = "Quản lý tài khoản";
            this.btnQLTaiKhoan.Id = 1;
            this.btnQLTaiKhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLTaiKhoan.ImageOptions.Image")));
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQLTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLTaiKhoan_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Đổi mật khẩu";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Đăng xuất";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnThuNgan
            // 
            this.btnThuNgan.Caption = "Thu ngân";
            this.btnThuNgan.Id = 4;
            this.btnThuNgan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThuNgan.ImageOptions.Image")));
            this.btnThuNgan.Name = "btnThuNgan";
            this.btnThuNgan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnThuNgan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThuNgan_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // btnQLHoaDon
            // 
            this.btnQLHoaDon.Caption = "Danh sách hóa đơn";
            this.btnQLHoaDon.Id = 6;
            this.btnQLHoaDon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLHoaDon.ImageOptions.Image")));
            this.btnQLHoaDon.Name = "btnQLHoaDon";
            this.btnQLHoaDon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnQLThongKe
            // 
            this.btnQLThongKe.Caption = "Thống kê ";
            this.btnQLThongKe.Id = 7;
            this.btnQLThongKe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLThongKe.ImageOptions.Image")));
            this.btnQLThongKe.Name = "btnQLThongKe";
            this.btnQLThongKe.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnQLNhanVien
            // 
            this.btnQLNhanVien.Caption = "Danh sách nhân viên";
            this.btnQLNhanVien.Id = 8;
            this.btnQLNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLNhanVien.ImageOptions.Image")));
            this.btnQLNhanVien.Name = "btnQLNhanVien";
            this.btnQLNhanVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQLNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLNhanVien_ItemClick);
            // 
            // btnQLCaTruc
            // 
            this.btnQLCaTruc.Caption = "Ca trực";
            this.btnQLCaTruc.Id = 9;
            this.btnQLCaTruc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLCaTruc.ImageOptions.Image")));
            this.btnQLCaTruc.Name = "btnQLCaTruc";
            this.btnQLCaTruc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnQLSanPham
            // 
            this.btnQLSanPham.Caption = "Danh sách sản phẩm";
            this.btnQLSanPham.Id = 10;
            this.btnQLSanPham.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLSanPham.ImageOptions.Image")));
            this.btnQLSanPham.Name = "btnQLSanPham";
            this.btnQLSanPham.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQLSanPham.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLSanPham_ItemClick);
            // 
            // btnQLDanhMuc
            // 
            this.btnQLDanhMuc.Caption = "Danh mục sản phẩm";
            this.btnQLDanhMuc.Id = 11;
            this.btnQLDanhMuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLDanhMuc.ImageOptions.Image")));
            this.btnQLDanhMuc.Name = "btnQLDanhMuc";
            this.btnQLDanhMuc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQLDanhMuc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLDanhMuc_ItemClick);
            // 
            // btnQLBan
            // 
            this.btnQLBan.Caption = "Danh sách bàn";
            this.btnQLBan.Id = 12;
            this.btnQLBan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLBan.ImageOptions.Image")));
            this.btnQLBan.Name = "btnQLBan";
            this.btnQLBan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQLBan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLBan_ItemClick);
            // 
            // btnQLKhuVuc
            // 
            this.btnQLKhuVuc.Caption = "Khu vực";
            this.btnQLKhuVuc.Id = 13;
            this.btnQLKhuVuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLKhuVuc.ImageOptions.Image")));
            this.btnQLKhuVuc.Name = "btnQLKhuVuc";
            this.btnQLKhuVuc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQLKhuVuc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLKhuVuc_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Tài khoản";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnQLTaiKhoan);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Thu ngân";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnThuNgan);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Quản lý";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnQLHoaDon);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnQLThongKe);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Quản lý hóa đơn";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnQLNhanVien);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnQLCaTruc);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Quản lí nhân viên";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnQLSanPham);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnQLDanhMuc);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Quản lý sản phẩm";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnQLBan);
            this.ribbonPageGroup8.ItemLinks.Add(this.btnQLKhuVuc);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Quản lý khu vực";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 513);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(891, 27);
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 3;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutMain.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 141);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutMain.Size = new System.Drawing.Size(891, 372);
            this.tableLayoutMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbcaption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(92, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 31);
            this.panel1.TabIndex = 0;
            // 
            // lbcaption
            // 
            this.lbcaption.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbcaption.Appearance.Options.UseFont = true;
            this.lbcaption.Appearance.Options.UseTextOptions = true;
            this.lbcaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbcaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbcaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbcaption.Location = new System.Drawing.Point(0, 0);
            this.lbcaption.Name = "lbcaption";
            this.lbcaption.Size = new System.Drawing.Size(706, 31);
            this.lbcaption.TabIndex = 0;
            this.lbcaption.Text = "Quản lý tài khoản";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 540);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coffe Chất";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.tableLayoutMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnQLTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnThuNgan;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem btnQLHoaDon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnQLThongKe;
        private DevExpress.XtraBars.BarButtonItem btnQLNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnQLCaTruc;
        private DevExpress.XtraBars.BarButtonItem btnQLSanPham;
        private DevExpress.XtraBars.BarButtonItem btnQLDanhMuc;
        private DevExpress.XtraBars.BarButtonItem btnQLBan;
        private DevExpress.XtraBars.BarButtonItem btnQLKhuVuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lbcaption;
    }
}

