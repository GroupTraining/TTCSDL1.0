using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTCSDL.GUI
{
    public partial class DoanhThu : Form
    {
        TTCSDLDataContext data = new TTCSDLDataContext();
        CSDLConnected csdl = new CSDLConnected();

        public DoanhThu()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CenterToParent();
            comboBoxDoanhthu.Items.Add("[Tiêu chí]");
            comboBoxDoanhthu.Items.Add("Theo ngày");
            comboBoxDoanhthu.Items.Add("Theo tháng");
            comboBoxDoanhthu.Items.Add("Theo năm");
            comboBoxDoanhthu.SelectedItem = "[Tiêu chí]";
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxDoanhthu.Text == "Theo ngày")
            {
                dataGridViewDT.DataSource = csdl.Doanthutheongay();
                dataGridViewDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridViewDT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                textBoxDT.Text = string.Format("{0,-10:N0}đ", csdl.Dtngay()); ;

              
            }
            else if (comboBoxDoanhthu.Text == "Theo tháng")
            {
                dataGridViewDT.DataSource = csdl.Doanthutheothang();
                dataGridViewDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridViewDT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                textBoxDT.Text = string.Format("{0,-10:N0}đ", csdl.Dtthang());
            }
            else if (comboBoxDoanhthu.Text == "Theo năm")
            {
                dataGridViewDT.DataSource = csdl.Doanthutheonam();
                dataGridViewDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridViewDT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                textBoxDT.Text = string.Format("{0,-10:N0}đ", csdl.Dtnam());
            }

            //var hoadon = data.HDThanhToans.Single(a => a.MaHDTT == dataGridViewDT.CurrentRow.Cells["MaHDTT"].Value.ToString());
            //var kh = data.KhachHangs.Single(a => a.MaKH == hoadon.MaKHTT);
            //int doanhthu = 0;
            //doanhthu = Convert.ToInt32(hoadon.Total);
            //textBoxDT.Text = "";
            //textBoxDT.Text = Convert.ToString(doanhthu);

        }
        

    }
}
