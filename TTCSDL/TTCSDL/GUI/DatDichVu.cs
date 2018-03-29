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


            var dvs = from dv in data.DichVus
                      select dv;
            foreach (var dv in dvs)
            {
                comboBox_namedv.Items.Add(dv.TenDV.Trim());
            }
        }

        private void DatDichVu_Load(object sender, EventArgs e)
        {
            
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
            comboBox_sophong.SelectedIndex = 0;



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
            tongtien += Convert.ToInt32(dv.GiaDV * Convert.ToInt32(comboBox_count.SelectedItem.ToString().Trim()));
            lbl_sumamount.Text = string.Format("{0,-10:N0}đ", tongtien) ;
            

        }

         string makh = "";
        private void comboBox_sophong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChiTietThuePhong phong = data.ChiTietThuePhongs.Single(p => p.SoPhong == comboBox_sophong.SelectedItem.ToString().Trim());
            HDThuePhong tp = data.HDThuePhongs.Single(p => p.MaPhong == phong.MaPhong);
            makh = tp.MaKHThue;
        }
        
        private void btn_submit_Click(object sender, EventArgs e)
        {
            int sum = tongtien;
            int sl = Convert.ToInt32(comboBox_count.SelectedItem.ToString().Trim());
            string maDV = madv;
            string mahd = "HDDV"+ makh.Trim();
            comboBox_namedv.SelectedIndex = 0;
            comboBox_count.SelectedIndex = 0;
            lbl_amount.Text = "";
            lbl_sumamount.Text = "";
            
            DateTime time = DateTime.Now;
            
            if (MessageBox.Show("Bạn chắc chắn gọi dịch vụ này này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.HDDV(mahd, makh, maDV,sl, time, sum);
                data.CTHDDV(mahd, maDV, sl, sum);
                MessageBox.Show("Gọi thành công !! Vui lòng đợi nhân viên phục vụ...");
            }
           

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
