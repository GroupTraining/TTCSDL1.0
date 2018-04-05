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
using System.Globalization;

namespace TTCSDL.GUI
{
    public partial class DatPhong : Form
    {
        TTCSDLDataContext data = new TTCSDLDataContext();
        CSDLConnected bus = new CSDLConnected();
        public DatPhong()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CenterToParent();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            var thongtins = from tt in data.KhachHangs
                           select tt;
            foreach (var thongtin in thongtins)
            {
                if (txtSDT.Text == thongtin.SoDT.Trim())
                {
                    labelHoTen.Text = thongtin.TenKH;
                    if (thongtin.CapBac == 1)
                    {
                        labelQLKH.Text = "Khách Thường";
                    }else if (thongtin.CapBac == 2)
                    {
                        labelQLKH.Text = "Khách Quen";
                    }else if (thongtin.CapBac == 3)
                    {
                        labelQLKH.Text = "Khách VIP";
                    }
                }
            }

        }

        private void DatPhong_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            comboBoxSP.Items.Add("[Danh sách phòng]");
            var phongs = from a in data.Phongs
                        select a;
            foreach (var phong in phongs)
            {
                comboBoxSP.Items.Add(phong.SoPhong);
            }
            comboBoxSP.SelectedItem = "[Danh sách phòng]";
        }
        private void comboBoxSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var phongs = from a in data.Phongs
                        where a.SoPhong.Trim() == comboBoxSP.Text
                        select a;
            foreach(var phong in phongs)
            {
                labelLP.Text = phong.LoaiPhong;
            }
             
        }

        int thanhtien = 0;
        DateTime ngayden;
        DateTime ngaytra;
        TimeSpan thoigianthue;
        private void dateTimeNgayTra_ValueChanged(object sender, EventArgs e)
        {
            Phong p = data.Phongs.Single(d => d.SoPhong.Trim() == comboBoxSP.Text);

             ngayden = DateTime.ParseExact(dateTimeNgayDen.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
             ngaytra = DateTime.ParseExact(dateTimeNgayTra.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
             thoigianthue = ngaytra - ngayden;

            //Kiểm tra giá trị ngày trả đúng yêu cầu chưa
            if (thoigianthue.TotalHours < 0)
            {
                labelThanhTien.Text = "0 đ";
                MessageBox.Show("Nhập lại giá trị ngày trả phòng");
                return;
            }else if (thoigianthue.TotalHours == 0)
            {
                thanhtien = Convert.ToInt32(p.GiaPhong);
            }
            else
            {
                thanhtien = Convert.ToInt32(p.GiaPhong * thoigianthue.TotalDays);
            }
            labelThanhTien.Text = string.Format("{0,-10:N0}đ", thanhtien);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            KhachHang kh   = data.KhachHangs.Single(a => a.SoDT.Trim() == txtSDT.Text);
            Phong p        = data.Phongs.Single(d => d.SoPhong.Trim() == comboBoxSP.Text);
            string makh = kh.MaKH;
            string mahd = "";
            
            
            //Kiểm tra trường hợp khách hàng đặt phòng lần đầu hay ko
            var khachs = from a in data.HDThuePhongs
                         where a.MaKHThue == makh
                         select a;
            int count = 0;
            if ( khachs == null)
            {
                 mahd = "HDTP" + makh.Trim();
            }else
            {
                foreach (var khach in khachs)
                {
                    count = count + 1;
                }
                mahd = "HDTP" + makh.Trim() + count.ToString();
            }
            
           
            
            DateTime time = DateTime.Now;
            string sophong =  comboBoxSP.Text;

            if (MessageBox.Show("Bạn chắc chắn đặt phòng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kiểm tra trường hợp 1 phòng có thể đặt nhiều lần ko
                var phongs = from a in data.ChiTietThuePhongs
                            select a;
                int check = 0;
                foreach (var phong in phongs)
                {
                    if(sophong == phong.SoPhong)
                    {
                        check = 1;//Đã tồn tại phòng ở trong chi tiết thuê phòng
                        break;
                    }
                }
                if (check == 1)
                {
                    
                    var chitiets = from a in data.ChiTietThuePhongs
                                   where a.SoPhong.Trim() == comboBoxSP.Text
                                   select a;
                    DateTime gannhat = DateTime.Now ;
                    double min =1000000;
                    foreach (var chitiet in chitiets)
                    {
                        TimeSpan maxdays = time - Convert.ToDateTime(chitiet.TimeEdited);
                        if (maxdays.TotalMinutes < min)
                        {
                            gannhat = Convert.ToDateTime(chitiet.TimeEdited);
                            min = maxdays.TotalMinutes;
                        }
                    }
                    ChiTietThuePhong ct = data.ChiTietThuePhongs.Single(b => b.SoPhong.Trim() == comboBoxSP.Text && DateTime.Compare(gannhat,Convert.ToDateTime(b.TimeEdited)) == 0);
                    HDThuePhong hd = data.HDThuePhongs.Single(c => c.MaPhong == ct.MaPhong);
                    
                    if (DateTime.Compare(ngayden,Convert.ToDateTime(hd.NgayTra)) < 0)
                    {
                        MessageBox.Show("Phòng " + sophong.Trim() + " đang được sử dụng");
                    }
                    else
                    {
                        data.HDTP(mahd, makh, ngayden, ngaytra, Convert.ToInt32(thoigianthue.TotalDays), thanhtien, time, sophong);
                        MessageBox.Show("Đặt phòng thành công!!");
                        p.TinhTrangPhong = true;
                        data.SubmitChanges();

                        txtSDT.Text = "";
                        labelHoTen.Text = "";
                        labelQLKH.Text = "";
                        labelLP.Text = "";
                        labelThanhTien.Text = "0 đ";
                        comboBoxSP.SelectedItem = "[Danh sách phòng]";
                        dateTimeNgayDen.Value = DateTime.Now;
                    }
                }
                else
                {
                    data.HDTP(mahd, makh, ngayden, ngaytra, Convert.ToInt32(thoigianthue.TotalDays), thanhtien, time, sophong);
                    MessageBox.Show("Đặt phòng thành công!!");
                    p.TinhTrangPhong = true;
                    data.SubmitChanges();

                    txtSDT.Text = "";
                    labelHoTen.Text = "";
                    labelQLKH.Text = "";
                    labelLP.Text = "";
                    labelThanhTien.Text = "0 đ";
                    comboBoxSP.SelectedItem = "[Danh sách phòng]";
                    dateTimeNgayDen.Value = DateTime.Now;
                }


            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy đặt phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

       
    }
}
