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
    public partial class EditHDDichVu : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        public EditHDDichVu()
        {
            InitializeComponent();
            groupPanel1.Hide();
            this.CenterToParent();
        }
        string namekh = "";
        public EditHDDichVu(string name) : this()
        {
            string text = name;
            namekh = text;
        } 




        private void dataGridViewEditCTDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupPanel1.Show();
            textBoxMahddv.Enabled = false;
            textBoxMakh.Enabled = false;
            //textBoxTenkh.Enabled = false;
            textBoxDv.Enabled = false;
            textBoxMakh.Text = dataGridViewEditCTDV.CurrentRow.Cells["MaKH"].Value.ToString();
            textBoxMahddv.Text = dataGridViewEditCTDV.CurrentRow.Cells["MaHDDV"].Value.ToString();
            textBoxDv.Text = dataGridViewEditCTDV.CurrentRow.Cells["TenDV"].Value.ToString();
            textBoxSl.Text = dataGridViewEditCTDV.CurrentRow.Cells["SoLuong"].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin dịch vụ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
            var dichvu = data.DichVus.Single(a => a.TenDV == textBoxDv.Text);
            csdl.EditCtHddv(textBoxMakh.Text, textBoxMahddv.Text, dichvu.MaDV, textBoxSl.Text);
            MessageBox.Show("Cập nhật thành công!!");
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công !!");
            }
            textBoxMakh.Text = "";
            textBoxMahddv.Text = "";
            textBoxDv.Text = "";
            textBoxSl.Text = "";
            data.Update_TongTien();
            data.CTHDTT();
            dataGridViewEditCTDV.DataSource = csdl.getDataHDDV2(namekh);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            var dichvu = data.DichVus.Single(a => a.TenDV == textBoxDv.Text);
            csdl.delHddv(textBoxMakh.Text, textBoxMahddv.Text, dichvu.MaDV, textBoxSl.Text);
            MessageBox.Show("Xoá thành công!!");
            }
            else
            {
                MessageBox.Show("Xóa không thành công !!");
            }
            textBoxMakh.Text = "";
            textBoxMahddv.Text = "";
            textBoxDv.Text = "";
            textBoxSl.Text = "";
            data.Update_TongTien();
            data.CTHDTT();
            dataGridViewEditCTDV.DataSource = csdl.getDataHDDV2(namekh);
        }

        private void EditHDDichVu_Load(object sender, EventArgs e)
        {
            groupPanel1.Hide();
            dataGridViewEditCTDV.DataSource = csdl.getDataHDDV2(namekh);
            dataGridViewEditCTDV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
