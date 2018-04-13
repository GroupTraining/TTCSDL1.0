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
    public partial class QLNhanVien : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        public QLNhanVien()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            dataGridViewNV.DataSource = csdl.getDataNV();
            dataGridViewNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
           // dataGridViewNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridViewNV.CurrentCell.RowIndex;
            int columnindex = dataGridViewNV.CurrentCell.ColumnIndex;
            textManv.Enabled = false;
            textManv.Text = dataGridViewNV.Rows[rowindex].Cells[0].Value.ToString();
            textTennv.Text = dataGridViewNV.Rows[rowindex].Cells[1].Value.ToString();
            dateNS.Text = dataGridViewNV.Rows[rowindex].Cells[2].Value.ToString();
            if (dataGridViewNV.Rows[rowindex].Cells[3].Value.ToString() == "True")
                radioNu.Checked = true;
            else
                radioNam.Checked = true;
            textSocmt.Text = dataGridViewNV.Rows[rowindex].Cells[4].Value.ToString();
            textPhone.Text = dataGridViewNV.Rows[rowindex].Cells[5].Value.ToString();
            textQuequan.Text = dataGridViewNV.Rows[rowindex].Cells[6].Value.ToString();
            textLuong.Text = dataGridViewNV.Rows[rowindex].Cells[7].Value.ToString();
            textBoxChucvu.Text = dataGridViewNV.Rows[rowindex].Cells[8].Value.ToString();

        }
    }
}
