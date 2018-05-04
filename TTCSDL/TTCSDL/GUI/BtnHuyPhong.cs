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

namespace TTCSDL.GUI
{
    public partial class BtnHuyPhong : Form
    {
        TTCSDLDataContext data = new TTCSDLDataContext();
        public BtnHuyPhong()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CenterToParent();
        }

        private void BtnHuyPhong_Load(object sender, EventArgs e)
        {
            comboBoxSP.Items.Add("[Chọn phòng]");
            var khs = from a in data.KhachHangs
                      where a.TrangThai == "reservation"
                      select a;
            foreach (var kh in khs)
            {
                var hoadons = from a in data.HDThuePhongs
                              where a.MaKHThue == kh.MaKH
                              where Convert.ToDateTime(a.NgayThue).Day == DateTime.Now.Day
                              select a;
                foreach (var hoadon in hoadons)
                {
                    ChiTietThuePhong phong = data.ChiTietThuePhongs.Single(a => a.MaPhong == hoadon.MaPhong);
                    comboBoxSP.Items.Add(phong.SoPhong);
                }
            }
            comboBoxSP.SelectedItem = "[Chọn phòng]";
        }

        private void comboBoxSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hoadons = from a in data.ChiTietThuePhongs
                          where a.SoPhong == comboBoxSP.Text
                          select a;
            foreach (var hoadon in hoadons)
            {
                HDThuePhong thue = data.HDThuePhongs.Single(a => a.MaPhong == hoadon.MaPhong);
                if (Convert.ToDateTime(thue.NgayThue).Day == DateTime.Now.Day)
                {
                    KhachHang kh = data.KhachHangs.Single(p => p.MaKH == thue.MaKHThue);
                    labelHoTen.Text = kh.TenKH;
                    labelSDT.Text = kh.SoDT;
                    labelNgayDen.Text = Convert.ToDateTime(thue.NgayThue).ToShortDateString();
                    labelNgayTra.Text = Convert.ToDateTime(thue.NgayTra).ToShortDateString();
                }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (labelHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng chọn số phòng");
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn nhận phòng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhachHang kh = data.KhachHangs.Single(a => a.TenKH == labelHoTen.Text);
                    Phong p = data.Phongs.Single(a => a.SoPhong == comboBoxSP.Text);
                    p.TinhTrangPhong = false;
                    kh.TrangThai = "checkout";
                    data.SubmitChanges();
                    MessageBox.Show("Hủy thành công");

                    labelHoTen.Text = "";
                    labelSDT.Text = "";
                    labelNgayDen.Text = "";
                    labelNgayTra.Text = "";
                    comboBoxSP.SelectedItem = "[Chọn phòng]";
                }
            }
        }
    }
}
