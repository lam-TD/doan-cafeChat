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
            //Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
            Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
            List<BanDTO> tb = new List<BanDTO>();
            tb = BUS_Table.List_Table();
            foreach (DTO_Table tb_child in tb)
            {
                string status_tb;
                if (tb_child.Tb_status == 0)
                    status_tb = "Trống";
                else
                    status_tb = "Có khách";
                Button btn = new Button()
                {
                    Width = 120,
                    Height = 120,
                    Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                    //Text = tb_child.Tb_name,
                    Tag = tb_child.Tb_id
                    //BackgroundImage = Properties.Resources.coffee
                };
                if (tb_child.Tb_status == 0)
                    btn.BackgroundImage = Properties.Resources.cokhach;
                else
                    btn.BackgroundImage = Properties.Resources.cokhach2;
                Label name = new Label()
                {
                    Top = 2,
                    Left = 2,
                    Text = tb_child.Tb_name,
                    BackColor = Color.AliceBlue,
                    ForeColor = Color.Red,
                    Width = 60,
                };
                name.TextAlign = ContentAlignment.MiddleCenter;
                name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                btn.MouseDown += new MouseEventHandler(bt_MouseDown); // tạo sự kiện click cho các button
                btn.Controls.Add(name);
                flowLayout_table.Controls.Add(btn);
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
    }
}