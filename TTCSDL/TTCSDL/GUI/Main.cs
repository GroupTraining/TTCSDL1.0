using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
namespace TTCSDL.GUI
{
    public partial class Main_admin : DevComponents.DotNetBar.Office2007RibbonForm
    {
        string username = "";
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        public Main_admin()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            var phongs = from p in data.Phongs
                         select p;
            foreach (var p in phongs)
            {
                listView1.SmallImageList = imageList1;
                listView1.LargeImageList = imageList1;

                ListViewItem item = new ListViewItem();
                item.Text = p.SoPhong;
                item.SubItems.Add("hi");
                item.SubItems.Add("download");
                item.ImageIndex = 0;
                listView1.Items.Add(item);
                listView1.View = View.SmallIcon;
            }

        }
        public Main_admin(string txt) : this()
        {
            string text = txt;
            username = text;
        }
        public void admin()
        {
        }
        public void personal()
        {
            ribbonBarQLDV.Hide();
            ribbonBarRoom.Hide();
        }
        

        private void btn_login_Click(object sender, EventArgs e)
        {

        }

        private void Main_admin_Load(object sender, EventArgs e)
        {
            
            this.CenterToScreen();
            if(csdl.getGroup(username) == "1")
            {
                admin();
            }else if(csdl.getGroup(username) == "2")
            {
                personal();
            }
            


            
        }

        private void btn_tk_Click(object sender, EventArgs e)
        {
            GUI.QLTaiKhoan qltk = new GUI.QLTaiKhoan();
            qltk.Show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            GUI.Login lg = new GUI.Login();
            lg.Show();
        }

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            GUI.ChangePassword form = new GUI.ChangePassword(username);
            form.Show();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            GUI.QLKhachHang kh = new GUI.QLKhachHang();
            kh.Show();
        }

        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            GUI.QuanLyDV dv = new GUI.QuanLyDV();
            dv.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            GUI.QLPhong phong = new QLPhong();
            phong.Show();
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            GUI.HoaDonThanhToan hd = new GUI.HoaDonThanhToan();
            hd.Show();
        }

        private void btn_LoaiDV_Click(object sender, EventArgs e)
        {
            GUI.DatDichVu datdv = new DatDichVu();
            datdv.Show();

        }

        private void btn_datphong_Click(object sender, EventArgs e)
        {
            GUI.DatPhong datp = new GUI.DatPhong();
            datp.Show();
        }
    }
}
