using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using DAL;
using BUS;
namespace TTCSDL.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        CSDLConnected csdl = new CSDLConnected();
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (csdl.check_login(txt_username.Text,txt_pass.Text) == true)
            {
                this.Hide();
                GUI.Main_admin main1 = new GUI.Main_admin(txt_username.Text);
                main1.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
             
        }
        #region Ma hoa mk md5
        private string encrypt(string mk)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte va ma hoa
            byte[] data = mh.ComputeHash(Encoding.UTF8.GetBytes(mk));
            
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion
        #region Giai ma mk
        private bool decrypt(string mk, string hash)
        {
            // Hash the input.
            string hashOfInput = encrypt(mk);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_login.PerformClick();
            }
        }
    }
}
