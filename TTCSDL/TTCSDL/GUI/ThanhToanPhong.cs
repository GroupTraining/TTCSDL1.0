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
        }
        string name = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = csdl.getDataHDTT1(textTenKH.Text);
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
    }
}
