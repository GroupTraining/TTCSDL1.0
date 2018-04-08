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
    public partial class DatDichVu : Form
    {
        TTCSDLDataContext data = new TTCSDLDataContext();
        public DatDichVu()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CenterToParent();

        }

        private void DatDichVu_Load(object sender, EventArgs e)
        {
            comboBox_namedv.Items.Add("[Chọn dịch vụ]");
            comboBox_sophong.Items.Add("[Chọn Phòng]");
            var phongs = from p in data.Phongs
                           select p;
            
            foreach(var p in phongs)
            {
                if(p.TinhTrangPhong == true)
                {
                    comboBox_sophong.Items.Add(p.SoPhong);
                }
            }
            comboBox_sophong.SelectedItem = "[Chọn Phòng]";
            
            var dvs = from dv in data.DichVus
                      select dv;
            foreach (var dv in dvs)
            {
                comboBox_namedv.Items.Add(dv.TenDV.Trim());
            }
            comboBox_namedv.SelectedItem = "[Chọn dịch vụ]";

        }
        string madv = "";
        private void comboBox_namedv_SelectedIndexChanged(object sender, EventArgs e)
        {
            DichVu dv = data.DichVus.Single(p => p.TenDV == comboBox_namedv.SelectedItem.ToString());
            lbl_amount.Text = string.Format("{0,-10:N0}đ", dv.GiaDV);
            madv = dv.MaDV;
        }
        int tongtien = 0;
        private void comboBox_count_SelectedIndexChanged(object sender, EventArgs e)
        {

            DichVu dv = data.DichVus.Single(p => p.TenDV == comboBox_namedv.SelectedItem.ToString());
            tongtien = Convert.ToInt32(dv.GiaDV * Convert.ToInt32(comboBox_count.SelectedItem.ToString().Trim()));
            lbl_sumamount.Text = string.Format("{0,-10:N0}đ", tongtien) ;
            

        }

         string makh = "";
        
        private void btn_submit_Click(object sender, EventArgs e)
        {
            int sum = tongtien;
            int sl = Convert.ToInt32(comboBox_count.Text.Trim());
            string maDV = madv;
            //Lấy mã kh
            DateTime time1 = DateTime.Now;
            var chitiettps = from a in data.ChiTietThuePhongs
                             where a.SoPhong.Trim() == comboBox_sophong.Text
                             select a;
            DateTime gannhat = DateTime.Now;
            double min = 1000000;
            foreach (var chitiet in chitiettps)
            {
                TimeSpan maxdays = time1 - Convert.ToDateTime(chitiet.TimeEdited);
                if (maxdays.TotalMinutes < min)
                {
                    gannhat = Convert.ToDateTime(chitiet.TimeEdited);
                    min = maxdays.TotalMinutes;
                }
            }
            ChiTietThuePhong ct = data.ChiTietThuePhongs.Single(b => b.SoPhong.Trim() == comboBox_sophong.Text && DateTime.Compare(gannhat, Convert.ToDateTime(b.TimeEdited)) == 0);
            HDThuePhong tp = data.HDThuePhongs.Single(p => p.MaPhong == ct.MaPhong);
            makh = tp.MaKHThue;
            //Lấy mã hd
            DateTime time = DateTime.Now;
            var chitietdvs = from a in data.HDDichVus
                           where a.MaKH == makh
                           select a;
            DateTime gannhat1 = DateTime.Now;
            double min1 = 1000000;
            foreach (var chitiet in chitietdvs)
            {
                TimeSpan maxdays = time - Convert.ToDateTime(chitiet.NgayLapHD);
                if (maxdays.TotalMinutes < min1)
                {
                    gannhat1 = Convert.ToDateTime(chitiet.NgayLapHD);
                    min1 = maxdays.TotalMinutes;
                }
            }
            HDDichVu hd = data.HDDichVus.Single(p => p.MaKH == makh && DateTime.Compare(gannhat1,Convert.ToDateTime(p.NgayLapHD))==0);
            string mahd = hd.MaHD;

            comboBox_count.SelectedIndex = 0;

            
            if (MessageBox.Show("Bạn chắc chắn gọi dịch vụ này này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(comboBox_sophong.Text == "[Chọn Phòng]")
                {
                    MessageBox.Show("Vui lòng chọn đúng  số phòng !");
                    return;
                }else if(comboBox_namedv.Text == "[Chọn dịch vụ]")
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ  !");
                    return;
                }else if (comboBox_sophong.Text == "[Chọn Phòng]" && comboBox_namedv.Text == "[Chọn dịch vụ]")
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ và số phòng !");
                    return;
                }
                else
                {
                    data.HDDV(mahd, makh, maDV, sl, time, sum);
                    data.CTHDDV(mahd, maDV, sl, sum);
                    MessageBox.Show("Gọi thành công !! Vui lòng đợi nhân viên phục vụ...");
                    lbl_amount.Text = "";
                    lbl_sumamount.Text = "";
                    comboBox_sophong.SelectedIndex = 0;
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.HoaDonThanhToan hd = new GUI.HoaDonThanhToan();
            hd.Show();
        }

    }
}
