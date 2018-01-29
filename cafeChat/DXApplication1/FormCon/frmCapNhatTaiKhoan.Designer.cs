namespace DXApplication1.FormCon
{
    partial class frmCapNhatTaiKhoan
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnthoat = new DevExpress.XtraEditors.SimpleButton();
            this.btncapnhat = new DevExpress.XtraEditors.SimpleButton();
            this.txtmatkhau = new DevExpress.XtraEditors.TextEdit();
            this.cbquyen = new System.Windows.Forms.ComboBox();
            this.cbmanv = new System.Windows.Forms.ComboBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtmatkhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnthoat);
            this.layoutControl1.Controls.Add(this.btncapnhat);
            this.layoutControl1.Controls.Add(this.txtmatkhau);
            this.layoutControl1.Controls.Add(this.cbquyen);
            this.layoutControl1.Controls.Add(this.cbmanv);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(284, 123);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(144, 86);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(128, 22);
            this.btnthoat.StyleController = this.layoutControl1;
            this.btnthoat.TabIndex = 9;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btncapnhat
            // 
            this.btncapnhat.Location = new System.Drawing.Point(12, 86);
            this.btncapnhat.Name = "btncapnhat";
            this.btncapnhat.Size = new System.Drawing.Size(128, 22);
            this.btncapnhat.StyleController = this.layoutControl1;
            this.btncapnhat.TabIndex = 8;
            this.btncapnhat.Text = "Cập nhật";
            this.btncapnhat.Click += new System.EventHandler(this.btncapnhat_Click);
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(79, 62);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(193, 20);
            this.txtmatkhau.StyleController = this.layoutControl1;
            this.txtmatkhau.TabIndex = 6;
            // 
            // cbquyen
            // 
            this.cbquyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbquyen.FormattingEnabled = true;
            this.cbquyen.Items.AddRange(new object[] {
            "Nhân viên",
            "Quản lý"});
            this.cbquyen.Location = new System.Drawing.Point(79, 37);
            this.cbquyen.Name = "cbquyen";
            this.cbquyen.Size = new System.Drawing.Size(193, 21);
            this.cbquyen.TabIndex = 5;
            // 
            // cbmanv
            // 
            this.cbmanv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmanv.FormattingEnabled = true;
            this.cbmanv.Location = new System.Drawing.Point(79, 12);
            this.cbmanv.Name = "cbmanv";
            this.cbmanv.Size = new System.Drawing.Size(193, 21);
            this.cbmanv.TabIndex = 4;
            this.cbmanv.SelectedIndexChanged += new System.EventHandler(this.cbmanv_SelectedIndexChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(284, 123);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cbmanv;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(264, 25);
            this.layoutControlItem1.Text = "Mã nhân viên";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbquyen;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(264, 25);
            this.layoutControlItem2.Text = "Quyền";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtmatkhau;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(264, 24);
            this.layoutControlItem3.Text = "Mật khẩu";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btncapnhat;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(132, 29);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnthoat;
            this.layoutControlItem6.Location = new System.Drawing.Point(132, 74);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(132, 29);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmCapNhatTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmCapNhatTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật tài khoản";
            this.Load += new System.EventHandler(this.frmCapNhatTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtmatkhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.ComboBox cbmanv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.ComboBox cbquyen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnthoat;
        private DevExpress.XtraEditors.SimpleButton btncapnhat;
        private DevExpress.XtraEditors.TextEdit txtmatkhau;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}