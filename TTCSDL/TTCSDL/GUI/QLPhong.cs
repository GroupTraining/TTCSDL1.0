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
            btn_del.Hide();
            btn_edit.Hide();
        }

        
        private void QLPhong_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
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
                labelGP.Text = "300.000  đ";
                labelTT.Text = "Đang trống";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng đôi")
            {
                labelGP.Text = "500.000  đ";
                labelTT.Text = "Đang trống";
            }
            else if (comboBoxLP.SelectedItem.ToString() == "Phòng Vip")
            {
                labelGP.Text = "1.000.000 đ";
                labelTT.Text = "Đang trống";
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            
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

            int giaphong = 0;
            if (labelGP.Text == "300.000  đ")
            {
                giaphong = 300000;
            }
            else if(labelGP.Text == "500.000  đ")
            {
                giaphong = 500000;
            }
            else if (labelGP.Text == "1.000.000 đ")
            {
                giaphong = 1000000;
            }
            if (MessageBox.Show("Bạn có muốn thêm phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var phongs = from a in data.Phongs
                             select a;
                bool kiemtra = true;
                foreach (var phong in phongs)
                {
                    if (txtSP.Text == phong.SoPhong.Trim())
                    {
                        kiemtra = false;
                        break;
                    }
                }
                if (kiemtra == false)
                {
                    MessageBox.Show("Đã tồn tại số phòng này !!");
                    return;
                }
                else
                {
                    if(lp == "")
                    {
                        MessageBox.Show("Vui lòng chọn loại phòng !!");
                        return;
                    }
                    else
                    {
                        data.addPhong(txtSP.Text, lp, giaphong, time);
                        MessageBox.Show("Thêm thành công !!");
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Thêm không thành công !!");
            }
            txtSP.Text = "";
            comboBoxLP.SelectedItem = "[Loại Phòng]";
            labelGP.Text = "0 đ";
            txtSP.Enabled = true;
            labelTT.Text = "";
            dataGridViewX1.DataSource = bus.getDataPhong();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
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

            int giaphong = 0;
            if (labelGP.Text == "300.000  đ")
            {
                giaphong = 300000;
            }
            else if (labelGP.Text == "500.000  đ")
            {
                giaphong = 500000;
            }
            else if (labelGP.Text == "1.000.000 đ")
            {
                giaphong = 1000000;
            }
            if (MessageBox.Show("Bạn có muốn sửa thông tin phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.editPhong(txtSP.Text, lp, giaphong, time);
                MessageBox.Show("Cập nhật thành công !!");
            }else
            {
                MessageBox.Show("Cập nhật không thành công !!");
            }

            txtSP.Text = "";
            comboBoxLP.SelectedItem = "[Loại Phòng]";
            labelGP.Text = "0 đ";
            labelTT.Text = "";
            txtSP.Enabled = true;
            btn_add.Show();
            btn_del.Hide();
            btn_edit.Hide();
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
            labelGP.Text = "0 đ";
            labelTT.Text = "";
            txtSP.Enabled = true;
            btn_add.Show();
            btn_del.Hide();
            btn_edit.Hide();
            dataGridViewX1.DataSource = bus.getDataPhong();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_add.Hide();
            btn_edit.Show();
            btn_del.Show();
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
            int giaphong = Convert.ToInt32(dataGridViewX1.Rows[rowindex].Cells[2].Value.ToString());
            labelGP.Text = string.Format("{0,-10:N0}đ", giaphong) ;
            string TT = dataGridViewX1.Rows[rowindex].Cells[3].Value.ToString();
            if (TT == "True")
            {
                labelTT.Text = "Đang sử dụng";
            }
            else if ( TT == "False")
            {
                labelTT.Text = "Đang trống";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSP.Text = "";
            comboBoxLP.SelectedItem = "[Loại Phòng]";
            labelGP.Text = "0 đ";
            labelTT.Text = "";
            txtSP.Enabled = true;
            btn_add.Show();
            btn_del.Hide();
            btn_edit.Hide();
            dataGridViewX1.DataSource = bus.getDataPhong();
        }
    }
}
