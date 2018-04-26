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
    public partial class QuanLyDV : Form
    {
        TTCSDLDataContext data = new TTCSDLDataContext();
        CSDLConnected bus = new CSDLConnected();
        public QuanLyDV()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            dataGridViewX1.DataSource = bus.getDataDV();
            btn_del.Hide();
            btn_edit.Hide();
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DichVu dv = data.DichVus.Single(p => p.MaDV.Trim() == txt_id.Text);
                    DichVu dv = data.DichVus.Single(p => p.TenDV.Trim() == txt_name.Text);
                    MessageBox.Show("Dữ liệu nhập không hợp lệ");
                }
                catch
                {
                    DateTime time = DateTime.Now;
                    data.addDV(txt_id.Text, txt_name.Text, txt_price.Text, time);
                    MessageBox.Show("Thêm thành công !!");
                    dataGridViewX1.DataSource = bus.getDataDV();
                }        
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime time = DateTime.Now;
                data.editDV(txt_id.Text, txt_name.Text.Trim(), txt_price.Text.Trim(), time);
                MessageBox.Show("Cập nhật thành công !!");
                txt_id.Text = "";
                txt_name.Text = "";
                txt_price.Text = "";
                txt_id.Enabled = true;
                btn_add.Show();
                btn_del.Hide();
                btn_edit.Hide();
                dataGridViewX1.DataSource = bus.getDataDV();
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.delDV(txt_id.Text.Trim());
                MessageBox.Show("Xóa thành công !!");
                btn_add.Show();
                btn_del.Hide();
                btn_edit.Hide();
                dataGridViewX1.DataSource = bus.getDataDV();
            }
            
        }

        private void QuanLyDV_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_add.Hide();
            btn_del.Show();
            btn_edit.Show();
            int rowindex = dataGridViewX1.CurrentCell.RowIndex;
            int columnindex = dataGridViewX1.CurrentCell.ColumnIndex;
            txt_id.Enabled = false;
            txt_id.Text = dataGridViewX1.Rows[rowindex].Cells[0].Value.ToString();
            txt_name.Text = dataGridViewX1.Rows[rowindex].Cells[1].Value.ToString();
            txt_price.Text = dataGridViewX1.Rows[rowindex].Cells[2].Value.ToString();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_price.Text = "";
            txt_id.Enabled = true;
            btn_add.Show();
            btn_del.Hide();
            btn_edit.Hide();
            dataGridViewX1.DataSource = bus.getDataDV();
        }
    }
}
