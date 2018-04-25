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
            this.CenterToParent();
            dataGridViewNV.DataSource = csdl.getDataNV();
            dataGridViewNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
           // dataGridViewNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnThem.Enabled = true;
        }

        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnThem.Enabled = false;
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
            textLuong.Text = dataGridViewNV.Rows[rowindex].Cells[8].Value.ToString();
            textBoxChucvu.Text = dataGridViewNV.Rows[rowindex].Cells[7].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TTCSDLDataContext data = new TTCSDLDataContext();
            bool gt = true;
            if (radioNam.Checked == true)
            {
                gt = false;
            }
            if (radioNu.Checked == true)
            {
                gt = true;
            }
            
            DateTime time = DateTime.Now;
            data.addnv(textManv.Text, textTennv.Text, Convert.ToDateTime(dateNS.Text), gt, textSocmt.Text, textPhone.Text, textQuequan.Text, Convert.ToInt32(textLuong.Text), textBoxChucvu.Text, time);
            MessageBox.Show("Thêm thành công !!");
            dataGridViewNV.Refresh();
            dataGridViewNV.DataSource = csdl.getDataNV();
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool gt = true;
                if (radioNam.Checked == true)
                {
                    gt = false;
                }
                if (radioNu.Checked == true)
                {
                    gt = true;
                }

                DateTime time = DateTime.Now;
                data.editnv(textManv.Text, textTennv.Text, Convert.ToDateTime(dateNS.Text), gt, textSocmt.Text, textPhone.Text, textQuequan.Text, Convert.ToInt32(textLuong.Text), textBoxChucvu.Text, time);
                MessageBox.Show("Chỉnh sửa thành công !!");
                textManv.Text = "";
                textTennv.Text = "";
                dateNS.Text = "";
                radioNam.Checked = false;
                radioNu.Checked = false;
                textSocmt.Text = "";
                textPhone.Text = "";
                textQuequan.Text = "";
                textLuong.Text = "";
                textBoxChucvu.Text = "";
                textManv.Enabled = true;
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
                btnThem.Enabled = true;
                dataGridViewNV.DataSource = csdl.getDataNV();
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa  thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.Removenv(textManv.Text);
                MessageBox.Show("Xóa thành công !!");
            }
            textManv.Text = "";
            textTennv.Text = "";
            dateNS.Text = "";
            radioNam.Checked = false;
            radioNu.Checked = false;
            textSocmt.Text = "";
            textPhone.Text = "";
            textQuequan.Text = "";
            textLuong.Text = "";
            textBoxChucvu.Text = "";
            textManv.Enabled = true;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnThem.Enabled = true;
            dataGridViewNV.DataSource = csdl.getDataNV();
        }
    }
}
