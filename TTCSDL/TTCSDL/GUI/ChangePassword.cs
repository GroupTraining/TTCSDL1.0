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

namespace TTCSDL.GUI
{
    public partial class ChangePassword : Form
    {
        string username = "";
        TTCSDLDataContext data = new TTCSDLDataContext();
        public ChangePassword()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        public ChangePassword(string txt) : this()
        {
            string text = txt;
            username = text;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            DateTime timedit = DateTime.Now;

            TKUser tk = data.TKUsers.Single(p => p.Username == username);
            if(tk.Pass.Trim() == txt_oldpass.Text.Trim() && txt_newpass.Text == txt_renewpass.Text)
            {
                tk.Pass = txt_newpass.Text;
                tk.TimeEdited = timedit;
                data.SubmitChanges();
                MessageBox.Show("Cập nhật thành công !!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công !!");
            }

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
