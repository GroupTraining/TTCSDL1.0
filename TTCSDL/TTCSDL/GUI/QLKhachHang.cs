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
            dataGridViewKH.DataSource = csdl.getDataKH();
            dataGridViewKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewKH.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewKH.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var khachhang = from a in data.KhachHangs
                               select a;
                bool kiemtra = true;
                foreach (var kh in khachhang)
                {
                    if (textMakh.Text == kh.MaKH.Trim())
                    {
                        kiemtra = false;
                        break;
                    }
                }
                if (kiemtra == false)
                {
                    MessageBox.Show("Đã tồn tại mã khách hàng này !!");
                    return;
                }
                else
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
                    int grp = Convert.ToInt32(comboBoxLevel.SelectedItem.ToString());
                    DateTime time = DateTime.Now;
                    data.addkhachhang(textMakh.Text, textTenkh.Text, Convert.ToDateTime(dateNS.Text), gt, textSocmt.Text, textPhone.Text, textDiachi.Text, grp, time);
                    MessageBox.Show("Thêm thành công !!");
                }
                textMakh.Text = "";
                textTenkh.Text = "";
                dateNS.Text = "";
                radioNam.Checked = false;
                radioNu.Checked = false;
                textSocmt.Text = "";
                textPhone.Text = "";
                textDiachi.Text = "";
                comboBoxLevel.Text = "";
                textMakh.Enabled = true;
                dataGridViewKH.Refresh();
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
                btnThem.Enabled = true;
                dataGridViewKH.Refresh();
                dataGridViewKH.DataSource = csdl.getDataKH();
            }
        }


        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            int count = 1;
            var khachhang = from a in data.KhachHangs
                           select a;
            foreach (var kh in khachhang)
            {
                count++;
            }
            textMakh.Text = "KH" + Convert.ToString(count);
            this.CenterToScreen();
            comboBoxLevel.Items.Add("[Level]");
            comboBoxLevel.Items.Add("1");
            comboBoxLevel.Items.Add("2");
            comboBoxLevel.Items.Add("3");
            comboBoxLevel.SelectedItem = "[Level]";
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            dataGridViewKH.Refresh();
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnThem.Enabled = true;
            dataGridViewKH.DataSource = csdl.getDataKH();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa  thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.RemoveKhachHang(textMakh.Text);
                MessageBox.Show("Xóa thành công !!");
            }
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnThem.Enabled = true;
            dataGridViewKH.DataSource = csdl.getDataKH();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textMakh.Text = "";
            textTenkh.Text = "";
            dateNS.Text = "";
            radioNam.Checked = false;
            radioNu.Checked = false;
            textSocmt.Text = "";
            textPhone.Text = "";
            textDiachi.Text = "";
            comboBoxLevel.Text = "";
            textMakh.Enabled = true;
            dataGridViewKH.Refresh();
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnThem.Enabled = true;
            int count = 1;
            var khachhang = from a in data.KhachHangs
                            select a;
            foreach (var kh in khachhang)
            {
                count++;
            }
            textMakh.Text = "KH" + Convert.ToString(count);
            this.CenterToScreen();
            comboBoxLevel.SelectedItem = "[Level]";
            dataGridViewKH.DataSource = csdl.getDataKH();
        }

        private void dataGridViewKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDel.Enabled = true;
            btnEdit.Enabled = true;
            btnThem.Enabled = false;

            int rowindex = dataGridViewKH.CurrentCell.RowIndex;
            int columnindex = dataGridViewKH.CurrentCell.ColumnIndex;
            textMakh.Enabled = false;
            textMakh.Text = dataGridViewKH.Rows[rowindex].Cells[0].Value.ToString();
            textTenkh.Text = dataGridViewKH.Rows[rowindex].Cells[1].Value.ToString();
            dateNS.Text = dataGridViewKH.Rows[rowindex].Cells[2].Value.ToString();
            if (dataGridViewKH.Rows[rowindex].Cells[3].Value.ToString() == "True")
                radioNu.Checked = true;
            else
                radioNam.Checked = true;
            textSocmt.Text = dataGridViewKH.Rows[rowindex].Cells[4].Value.ToString();
            textPhone.Text = dataGridViewKH.Rows[rowindex].Cells[5].Value.ToString();
            textDiachi.Text = dataGridViewKH.Rows[rowindex].Cells[6].Value.ToString();
            comboBoxLevel.Text = dataGridViewKH.Rows[rowindex].Cells[7].Value.ToString();
        }
    }
}
