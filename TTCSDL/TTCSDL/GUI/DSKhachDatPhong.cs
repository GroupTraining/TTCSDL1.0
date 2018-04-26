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

namespace TTCSDL.GUI
{
    public partial class DSKhachDatPhong : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        public DSKhachDatPhong()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CenterToParent();
        }

        private void DSKhachDatPhong_Load(object sender, EventArgs e)
        {
            dataGridViewDSKH.DataSource = csdl.getDataKHDP();
            dataGridViewDSKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewDSKH.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewDSKH.DataSource = csdl.getDataKHDP1(Convert.ToString(dateTimeNgayDen.Value), Convert.ToString(dateTimeNgayTra.Value));
            dataGridViewDSKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewDSKH.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
