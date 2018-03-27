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
    public partial class QLTaiKhoan : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        public QLTaiKhoan()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            dataGridViewX1.DataSource = csdl.getData();
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewX1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewX1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.DangKy dk = new GUI.DangKy();
            dk.Show();
            this.Hide();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_submit.Show();
            btn_delete.Visible = true;
            lbl_notice.Visible = true;
        }

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            btn_submit.Hide();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            data.editUser(txt_matk.Text, txt_username.Text, txt_mk.Text, txt_hoten.Text, txt_email.Text, txt_phone.Text, time);
            MessageBox.Show("Chỉnh sửa thành công !!");
            txt_matk.Text = "";
            txt_username.Text = "";
            txt_hoten.Text = "";
            txt_email.Text = "";
            txt_phone.Text = "";
            txt_mk.Text = "";
            txt_matk.Enabled = true;
            dataGridViewX1.DataSource = csdl.getData();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            int rowindex = dataGridViewX1.CurrentCell.RowIndex;
            int columnindex = dataGridViewX1.CurrentCell.ColumnIndex;

            txt_matk.Text = dataGridViewX1.Rows[rowindex].Cells[0].Value.ToString();
            txt_username.Text = dataGridViewX1.Rows[rowindex].Cells[1].Value.ToString();
            txt_mk.Text = dataGridViewX1.Rows[rowindex].Cells[2].Value.ToString();
            txt_hoten.Text = dataGridViewX1.Rows[rowindex].Cells[3].Value.ToString();
            txt_email.Text = dataGridViewX1.Rows[rowindex].Cells[4].Value.ToString();
            txt_phone.Text = dataGridViewX1.Rows[rowindex].Cells[5].Value.ToString();

            txt_matk.Enabled = false;
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.RemoveUser(txt_matk.Text);
                MessageBox.Show("Xóa thành công !!");
            }
            
            dataGridViewX1.DataSource = csdl.getData();
        }
    }
}
