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
    public partial class ThanhToanPhong : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        public ThanhToanPhong()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CenterToParent();
        }
        string name = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = csdl.getDataHDTT1(textTenKH.Text);
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewX1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            name = dataGridViewX1.CurrentRow.Cells["MaHD"].Value.ToString();

            GUI.PrintRpt print_report = new GUI.PrintRpt(name);
            print_report.Show();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textTenKH.Text = dataGridViewX1.CurrentRow.Cells["TenKH"].Value.ToString();
        }

        private void linkLichSu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GUI.LichSuThanhToan lichsu = new GUI.LichSuThanhToan(textTenKH.Text);
            lichsu.Show();
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn trả phòng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var hoadon = data.HDThanhToans.Single(a => a.MaHDTT.Trim() == dataGridViewX1.CurrentRow.Cells["MaHD"].Value.ToString());
                var kh = data.KhachHangs.Single(a => a.MaKH == hoadon.MaKHTT);
                var hoadonphong = data.ChiTietThuePhongs.Single(a => a.MaPhong == hoadon.MaPhong);
                var phong = data.Phongs.Single(a => a.SoPhong == hoadonphong.SoPhong); 

                kh.TrangThai = "checkout";
                phong.TinhTrangPhong = false;
                hoadon.NgayThanhToan = DateTime.Now;
                data.SubmitChanges();
                MessageBox.Show("Trả phòng thành công!!");
                textTenKH.Text = "";
                dataGridViewX1.DataSource = null;
            }
        }
    }
}
