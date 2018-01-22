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
using BUS;
using DTO;

namespace DXApplication1.FormCon
{
    public partial class frmDoiBan : DevExpress.XtraEditors.XtraForm
    {
        private string tenban;
        public frmDoiBan()
        {
            InitializeComponent();  
        }

        public frmDoiBan()
        {

        }

        public string Tenban
        {
            get
            {
                return tenban;
            }

            set
            {
                tenban = value;
            }
        }

        private void frmDoiBan_Load(object sender, EventArgs e)
        {
            Ban_Load();
        }

        void Ban_Load()
        {
            cbBan.DataSource = BanBUS.Ban_Load();
            cbBan.DisplayMember = "ban_ten";
            cbBan.ValueMember = "ban_id";
            cbBan.Text = tenban;
        }
    }
}