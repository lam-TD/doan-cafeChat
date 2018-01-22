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
        public frmDoiBan(string tenban)
        {
            InitializeComponent();
            Ban_Load();
            cbBan.Text = tenban;
        }

        private void frmDoiBan_Load(object sender, EventArgs e)
        {
            
        }

        void Ban_Load()
        {
            cbBan.DataSource = BanBUS.Ban_Load();
            cbBan.DisplayMember = "ban_ten";
            cbBan.ValueMember = "ban_id";
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btndoiban_Click(object sender, EventArgs e)
        {

        }
    }
}