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
    public partial class frmGopTachBan : DevExpress.XtraEditors.XtraForm
    {
        public frmGopTachBan(string tenban, string maban)
        {
            InitializeComponent();
            CauHinh_ListViewHoaDon(listViewHD1);
            CauHinh_ListViewHoaDon(listViewHD2);
            Load_cbchonban1();
            cbchonban1.Text = tenban;
            listview_ThucUong_Load(listViewHD1,maban);
        }


        void Load_cbchonban1()
        {
            cbchonban1.DataSource = BanBUS.Ban_LoadBanTheoTrangThai("Có khách");
            cbchonban1.DisplayMember = "ban_ten";
            cbchonban1.ValueMember = "ban_id";
        }

        void Load_cbchonban2(string maban)
        {
            cbchonban2.DataSource = BanBUS.Ban_Load_LoaiTru1BanTrung_TrangThaiCoKhach(maban);
            cbchonban2.DisplayMember = "ban_ten";
            cbchonban2.ValueMember = "ban_id";
        }

        void CauHinh_ListViewHoaDon(ListView lst)
        {
            lst.View = View.Details; // hiểm thị detail cho listview
            lst.FullRowSelect = true;
            lst.GridLines = true;

            ColumnHeader header1 = new ColumnHeader();
            header1.Text = "ID";
            header1.Width = 30;
            header1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader header2 = new ColumnHeader(); // cấu hình cột cho listview
            header2.Text = "Tên thức uống";
            header2.Width = 100;
            header2.TextAlign = HorizontalAlignment.Center;

            ColumnHeader header3 = new ColumnHeader();
            header3.Text = "Đơn giá";
            header3.Width = 80;
            header3.TextAlign = HorizontalAlignment.Center;

            ColumnHeader header4 = new ColumnHeader();
            header4.Text = "SL";
            header4.Width = 50;
            header4.TextAlign = HorizontalAlignment.Center;

            ColumnHeader header5 = new ColumnHeader();
            header5.Text = "Thành tiền";
            header5.Width = 98;
            header5.TextAlign = HorizontalAlignment.Center;


            lst.Columns.Add(header1);
            lst.Columns.Add(header2);
            lst.Columns.Add(header3);
            lst.Columns.Add(header4);
            lst.Columns.Add(header5);
        }

        void listview_ThucUong_Load(ListView lst, string maban) // load tất cả thức uống hoặc theo id danh mục 1-tất cả || 2-id danh mục
        {
            lst.Clear();
            CauHinh_ListViewHoaDon(lst);
            DataTable dt = Load_HoaDonTheoMaBan(maban);
            int i = 0;
            foreach (DataRow itemTU in dt.Rows)
            {
                lst.Items.Add(itemTU["tu_id"].ToString());
                lst.Items[i].SubItems.Add(itemTU["tu_ten"].ToString());
                lst.Items[i].SubItems.Add(itemTU["tu_gia"].ToString());
                lst.Items[i].SubItems.Add(itemTU["cthd_soluong"].ToString());
                lst.Items[i].SubItems.Add(itemTU["ThanhTien"].ToString());
                i++;
            }

        }

        DataTable Load_HoaDonTheoMaBan(string maban)
        {
            try
            {
                DataTable dt = HoaDonBUS.HoaDon_LayHoaDonTheoMaBan(maban);
                string mahd = dt.Rows[0]["hd_id"].ToString();
                return ChiTietHoaDonBUS.CTHD_Load_DonGia_TinhThanhTien(mahd);
            }
            catch (Exception)
            {
                DataTable dt = null;
                return dt;
            }
        }

    }
}