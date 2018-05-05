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
            
        }
        string mahd = "";
        string makh = "";
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            var thongtins = from tt in data.KhachHangs
                            select tt;
            foreach (var thongtin in thongtins)
            {
                if (txtSDT.Text == thongtin.SoDT.Trim())
                {
                    makh = thongtin.MaKH;
                    labelHoTen.Text = thongtin.TenKH;
                    var hoadons = from a in data.HDThuePhongs
                                  where a.MaKHThue == thongtin.MaKH
                                  where DateTime.Compare(Convert.ToDateTime(a.NgayThue), DateTime.Now) >= 0
                                  select a;
                    foreach (var hoadon in hoadons)
                    {
                        ChiTietThuePhong phong = data.ChiTietThuePhongs.Single(a => a.MaPhong == hoadon.MaPhong);
                        comboBoxSP.Items.Add(phong.SoPhong);
                    }
                }
            }
            
        }
     
        private void comboBoxSP_SelectedIndexChanged(object sender, EventArgs e)
        {
                    var hoadons = from a in data.ChiTietThuePhongs
                                  where a.SoPhong == comboBoxSP.Text
                                  select a;
                    foreach (var hoadon in hoadons)
                    {
                        HDThuePhong thue = data.HDThuePhongs.Single(a => a.MaPhong == hoadon.MaPhong);
                        if (thue.MaKHThue ==makh&& DateTime.Compare(Convert.ToDateTime(thue.NgayThue), DateTime.Now) >= 0)
                        {
                            mahd = thue.MaPhong;
                            labelNgayDen.Text = Convert.ToDateTime(thue.NgayThue).ToShortDateString();
                            labelNgayTra.Text = Convert.ToDateTime(thue.NgayTra).ToShortDateString();
                        }
                    }
                
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (labelHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại khách hàng");
                return;
            }
            else if (labelNgayDen.Text == "")
            {
                MessageBox.Show("Vui lòng chọn số phòng cần hủy");
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn hủy phòng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhachHang kh = data.KhachHangs.Single(a => a.TenKH == labelHoTen.Text);
                    Phong p = data.Phongs.Single(a => a.SoPhong == comboBoxSP.Text);
                    HDThuePhong hdphong = data.HDThuePhongs.Single(a => a.MaPhong == mahd);
                    HDThanhToan hdtt = data.HDThanhToans.Single(a => a.MaPhong == hdphong.MaPhong);
                    HDDichVu hddv = data.HDDichVus.Single(a => a.MaHD == hdtt.MaHDDV);
                    p.TinhTrangPhong = false;
                    kh.TrangThai = "checkout";
                    data.HDThuePhongs.DeleteOnSubmit(hdphong);
                    data.HDDichVus.DeleteOnSubmit(hddv);
                    data.HDThanhToans.DeleteOnSubmit(hdtt);
                    data.SubmitChanges();

                    MessageBox.Show("Hủy thành công");
                    
                    labelHoTen.Text = "";
                    txtSDT.Text = "";
                    labelNgayDen.Text = "";
                    labelNgayTra.Text = "";
                }
            }
        }

        
    }
}
