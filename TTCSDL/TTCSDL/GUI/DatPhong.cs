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
            comboBoxLP.Items.Add("[Loại phòng]");
            comboBoxLP.Items.Add("Phòng đơn");
            comboBoxLP.Items.Add("Phòng đôi");
            comboBoxLP.Items.Add("Phòng VIP");
            comboBoxLP.SelectedItem = "[Loại phòng]";
        }
       

        int thanhtien = 0;
        DateTime ngayden;
        DateTime ngaytra;
        TimeSpan thoigianthue;
        string loai = "";

        private void comboBoxLP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ngayden = DateTime.ParseExact(dateTimeNgayDen.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ngaytra = DateTime.ParseExact(dateTimeNgayTra.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            thoigianthue = ngaytra - ngayden;
            if (thoigianthue.TotalHours < 0)
            {
                MessageBox.Show("Nhập lại giá trị ngày trả phòng");
                return;
            }

            
            if (comboBoxLP.Text == "Phòng đơn")
            {
                loai = "phong don";
            }else if (comboBoxLP.Text == "Phòng đôi")
            {
                loai = "phong doi";
            }else if (comboBoxLP.Text == "Phòng VIP")
            {
                loai = "phong vip";
            }
            var phongs = from a in data.Phongs
                         from b in data.ChiTietThuePhongs
                         from c in data.HDThuePhongs
                         where  (a.SoPhong == b.SoPhong && b.MaPhong ==c.MaPhong)  
                         where a.LoaiPhong.Trim() == loai
                         where DateTime.Compare(ngayden, Convert.ToDateTime(c.NgayTra)) >= 0 
                         select new
                         {
                             SoPhong = a.SoPhong,
                             LoaiPhong = a.LoaiPhong,
                             TinhTrang = a.TinhTrangPhong,
                             GiaPhong = a.GiaPhong
                         };
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewX1.DataSource = phongs;
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Phong p = data.Phongs.Single(d => d.SoPhong.Trim() == dataGridViewX1.CurrentRow.Cells["SoPhong"].Value.ToString());

            labelSP.Text = dataGridViewX1.CurrentRow.Cells["SoPhong"].Value.ToString();
            labelNgayO.Text = Convert.ToString(thoigianthue.Days) + " ngày";

            //Kiểm tra giá trị ngày trả đúng yêu cầu chưa
           
            if (thoigianthue.TotalHours == 0)
            {
                thanhtien = Convert.ToInt32(p.GiaPhong) / 2;
            }
            else
            {
                thanhtien = Convert.ToInt32(p.GiaPhong * thoigianthue.TotalDays) / 2;
            }
            labelThanhTien.Text = string.Format("{0,-10:N0}đ", thanhtien);

        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(labelHoTen.Text != "")
            {
                KhachHang kh   = data.KhachHangs.Single(a => a.SoDT.Trim() == txtSDT.Text);
                Phong p = data.Phongs.Single(d => d.SoPhong.Trim() == dataGridViewX1.CurrentRow.Cells["SoPhong"].Value.ToString());
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
                string sophong =  labelSP.Text;

                if (MessageBox.Show("Bạn chắc chắn đặt phòng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                        data.HDTP(mahd, makh, ngayden, ngaytra, Convert.ToInt32(thoigianthue.TotalDays), thanhtien, thanhtien * 2, time, sophong);
                        MessageBox.Show("Đặt phòng thành công!!");
                        p.TinhTrangPhong = true;
                        data.SubmitChanges();

                        txtSDT.Text = "";
                        labelHoTen.Text = "";
                        labelQLKH.Text = "";
                        labelSP.Text = "";
                        labelNgayO.Text = "";
                        labelThanhTien.Text = "0 đ";
                        comboBoxLP.SelectedItem = "[Danh sách phòng]";
                        dateTimeNgayDen.Value = DateTime.Now;
                
                  }
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền thông tin khách hàng!!");
                return;
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
