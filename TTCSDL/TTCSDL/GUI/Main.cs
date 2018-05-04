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
            Load_ListView();

        }
        public void Load_ListView()
        {
            var phongs = from p in data.Phongs
                         select p;
            foreach (var p in phongs)
            {
                listView1.SmallImageList = imageList1;
                listView1.LargeImageList = imageList1;


                if (p.TinhTrangPhong == true)
                {
                    ListViewItem item = new ListViewItem("Phòng số " + p.SoPhong + "Đang sử dụng");
                    item.ForeColor = Color.Red;
                    item.ImageIndex = 0;
                    listView1.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem("Phòng số " + p.SoPhong + "Đang trống");
                    item.ForeColor = Color.Green;
                    item.ImageIndex = 0;
                    listView1.Items.Add(item);
                }


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
            ribbonTabItemTK.Enabled = false;
            ribbonBarQLNV.Hide();
            ribbonBarTK.Hide();
        }
        
        private void Main_admin_Load(object sender, EventArgs e)
        {
            string username1 = username;
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            listView1.Width = widthScreen - 10;
            listView1.Height = heightScreen - 10;
            if (csdl.getGroup(username1) == "1")
            {
                admin();
            }else if(csdl.getGroup(username1) == "2")
            {
                personal();
            }
            else
            {

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
            if(datp.isLoad)
            {
                Load_ListView();
            }
        }


        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            string used = "sử dụng";
                if(item.Text.Contains(used))
                {
                    MessageBox.Show("Đang sử dụng!!");
                }
        }

        private void btn_LoaiPhong_Click(object sender, EventArgs e)
        {
            GUI.ThanhToanPhong tt = new GUI.ThanhToanPhong();
            tt.Show();
            if(tt.isLoad)
            {
                Load_ListView();
            }
        }

        private void btn_qlnv_Click_1(object sender, EventArgs e)
        {
            GUI.QLNhanVien nv = new QLNhanVien();
            nv.Show();
        }

        private void btn_nhanphong_Click(object sender, EventArgs e)
        {
            GUI.BtnNhanPhong nhanphong = new BtnNhanPhong();
            nhanphong.Show();
        }

        private void btn_KHDatPhong_Click(object sender, EventArgs e)
        {
            GUI.DSKhachDatPhong kh = new DSKhachDatPhong();
            kh.Show();
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            GUI.DoanhThu thu = new DoanhThu();
            thu.Show();
        }

        private void btn_huyphong_Click(object sender, EventArgs e)
        {
            GUI.BtnHuyPhong huy = new BtnHuyPhong();
            huy.Show();
        }
    }
}
