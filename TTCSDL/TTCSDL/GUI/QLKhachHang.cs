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
    public partial class QLKhachHang : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        public QLKhachHang()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            dataGridView1.DataSource = csdl.getDataKH();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            textMakh.Enabled = false;
            textMakh.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            textTenkh.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            dateNS.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[rowindex].Cells[3].Value.ToString() == "True")
                radioNu.Checked = true;
            else
                radioNam.Checked = true;
            textSocmt.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            textPhone.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
            textDiachi.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            comboBoxLevel.Text = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TTCSDLDataContext data = new TTCSDLDataContext();
            bool gt=true;
            if (radioNam.Checked == true)
            {
                gt = false;
            }
            if (radioNu.Checked == true)
            {
                gt = true;
            }
            int grp = Convert.ToInt32(comboBoxLevel.SelectedItem.ToString());
            DateTime time = DateTime.Now;
            data.addkhachhang(textMakh.Text,textTenkh.Text,Convert.ToDateTime(dateNS.Text), gt,textSocmt.Text,textPhone.Text,textDiachi.Text,grp,time);
            MessageBox.Show("Thêm thành công !!");
            dataGridView1.Refresh();
            dataGridView1.DataSource = csdl.getDataKH();
        }


        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            comboBoxLevel.Items.Add("[Level]");
            comboBoxLevel.Items.Add("1");
            comboBoxLevel.Items.Add("2");
            comboBoxLevel.Items.Add("3");
            comboBoxLevel.SelectedItem = "[Level]";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn có muốn sửa thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                int grp = Convert.ToInt32(comboBoxLevel.SelectedItem.ToString());
                DateTime time = DateTime.Now;
                data.editkhachhang(textMakh.Text, textTenkh.Text, Convert.ToDateTime(dateNS.Text), gt, textSocmt.Text, textPhone.Text, textDiachi.Text, grp, time);
                MessageBox.Show("Chỉnh sửa thành công !!");
            }
            textMakh.Text = "";
            textTenkh.Text = "";
            dateNS.Text = "";
            radioNam.Checked= false;
            radioNu.Checked = false;
            textSocmt.Text = "";
            textPhone.Text = "";
            textDiachi.Text = "";
            comboBoxLevel.Text = "";
            textMakh.Enabled = true;
            dataGridView1.Refresh();
            dataGridView1.DataSource = csdl.getDataKH();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa  thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.RemoveKhachHang(textMakh.Text);
                MessageBox.Show("Xóa thành công !!");
            }
            
            dataGridView1.DataSource = csdl.getDataKH();
        }

        
    }
}
