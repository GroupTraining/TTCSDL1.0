using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DAL;
using BUS;

namespace TTCSDL.GUI
{
    public partial class DangKy : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        public DangKy()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            TTCSDLDataContext data = new TTCSDLDataContext();
            int grp = Convert.ToInt32(cbb_pq.SelectedItem.ToString());
            DateTime time = DateTime.Now;
            data.adduser(txt_ma.Text, txt_username.Text, txt_pass.Text, txt_name.Text, txt_email.Text, txt_phone.Text, time, grp);
            MessageBox.Show("Thêm thành công !!");
            this.Close();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cbb_pq.Items.Add("[Phân quyền]");
            cbb_pq.Items.Add("1");
            cbb_pq.Items.Add("2");
            cbb_pq.Items.Add("3");
            cbb_pq.SelectedItem = "[Phân quyền]";
        }

        private void DangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            GUI.QLTaiKhoan ql = new GUI.QLTaiKhoan();
            ql.Show();
        }
    }
}
