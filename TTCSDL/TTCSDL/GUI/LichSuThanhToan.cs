using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;

namespace TTCSDL.GUI
{
    public partial class LichSuThanhToan : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        public LichSuThanhToan()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CenterToParent();
        }
        string tenkh = "";
        public LichSuThanhToan(string name) : this()
        {
            string text = name;
            tenkh = text;
        }

        private void LichSuThanhToan_Load(object sender, EventArgs e)
        {
            dataGridViewLichSu.DataSource = csdl.getDataHDTT2(tenkh);
            dataGridViewLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewLichSu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewLichSu.DataSource =csdl.getDataHDTT3(tenkh,Convert.ToString(dateTimeNgayDen.Value),Convert.ToString(dateTimeNgayTra.Value)) ;
            dataGridViewLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewLichSu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
