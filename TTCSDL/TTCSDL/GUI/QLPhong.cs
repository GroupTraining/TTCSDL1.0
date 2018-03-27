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
    public partial class QLPhong : Form
    {
        TTCSDLDataContext data = new TTCSDLDataContext();
        CSDLConnected bus = new CSDLConnected();
        public QLPhong()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            dataGridViewX1.DataSource = bus.getDataPhong();
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewX1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        
        private void QLPhong_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            comboBoxTT.Items.Add("[Tình Trạng]");
            comboBoxTT.Items.Add("Đang sử dụng");
            comboBoxTT.Items.Add("Đang trống");
            comboBoxTT.SelectedItem = "[Tình Trạng]";

            comboBoxLP.Items.Add("[Loại Phòng]");
            comboBoxLP.Items.Add("Phòng đơn");
            comboBoxLP.Items.Add("Phòng đôi");
            comboBoxLP.Items.Add("Phòng Vip");
            comboBoxLP.SelectedItem = "[Loại Phòng]";
            
        }

        private void comboBoxLP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLP.SelectedItem.ToString() == "Phòng đơn")
            {
                labelGP.Text = "300000";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng đôi")
            {
                labelGP.Text = "500000";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng Vip")
            {
                labelGP.Text = "1000000";
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            bool tt = true;
            if (comboBoxTT.SelectedItem.ToString() == "Đang sử dụng")
            {
                tt = true;
            }
            else if (comboBoxTT.SelectedItem.ToString() == "Đang trống")
            {
                tt = false;
            }
            string lp = "";
            if (comboBoxLP.SelectedItem.ToString() == "Phòng đơn")
            {
                lp = "phong don";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng đôi")
            {
                lp = "phong doi";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng Vip")
            {
                lp = "phong vip";
            }
            if (MessageBox.Show("Bạn có muốn thêm phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.addPhong(txtSP.Text, lp, Convert.ToInt32(labelGP.Text), tt, time);
                MessageBox.Show("Thêm thành công !!");
            }
            else
            {
                MessageBox.Show("Thêm không thành công !!");
            }

            dataGridViewX1.DataSource = bus.getDataPhong();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            bool tt = true;
            if (comboBoxTT.SelectedItem.ToString() == "Đang sử dụng")
            {
                tt = true;
            }
            else if (comboBoxTT.SelectedItem.ToString() == "Đang trống")
            {
                tt = false;
            }
            string lp = "";
            if (comboBoxLP.SelectedItem.ToString() == "Phòng đơn")
            {
                lp = "phong don";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng đôi")
            {
                lp = "phong doi";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng Vip")
            {
                lp = "phong vip";
            }
            if (MessageBox.Show("Bạn có muốn sửa thông tin phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.editPhong(txtSP.Text, lp, Convert.ToInt32(labelGP.Text), tt, time);
                MessageBox.Show("Cập nhật thành công !!");
            }else
            {
                MessageBox.Show("Cập nhật không thành công !!");
            }

            txtSP.Text = "";
            comboBoxLP.SelectedItem = "[Loại Phòng]";
            labelGP.Text = "";
            comboBoxTT.SelectedItem = "[Tình trạng]";
            txtSP.Enabled = true;
            btn_add.Show();
            dataGridViewX1.DataSource = bus.getDataPhong();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.removePhong(txtSP.Text.Trim());
                MessageBox.Show("Xóa thành công !!");
            }
            else
            {
                MessageBox.Show("Xóa không thành công !!");
            }
            txtSP.Text = "";
            comboBoxLP.SelectedItem = "[Loại Phòng]";
            labelGP.Text = "";
            comboBoxTT.SelectedItem = "[Tình trạng]";
            txtSP.Enabled = true;
            btn_add.Show();
            dataGridViewX1.DataSource = bus.getDataPhong();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_add.Hide();
            int rowindex = dataGridViewX1.CurrentCell.RowIndex;
            int columnindex = dataGridViewX1.CurrentCell.ColumnIndex;
            txtSP.Enabled = false;
            txtSP.Text = dataGridViewX1.Rows[rowindex].Cells[0].Value.ToString();
            string LP = dataGridViewX1.Rows[rowindex].Cells[1].Value.ToString().Trim();
            if ( LP == "phong don")
            {
                comboBoxLP.SelectedItem = "Phòng đơn";
            }else if (LP == "phong doi")
            {
                comboBoxLP.SelectedItem = "Phòng đôi";
            }else if (LP == "phong vip")
            {
                comboBoxLP.SelectedItem = "Phòng Vip";
            }
            labelGP.Text = dataGridViewX1.Rows[rowindex].Cells[2].Value.ToString();
            string TT = dataGridViewX1.Rows[rowindex].Cells[3].Value.ToString();
            if (TT == "True")
            {
                comboBoxTT.SelectedItem = "Đang sử dụng";
            }
            else if ( TT == "False")
            {
                comboBoxTT.SelectedItem = "Đang trống";
            }
        }
    }
}
