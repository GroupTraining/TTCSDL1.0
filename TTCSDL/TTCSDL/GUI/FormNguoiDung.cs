using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTCSDL.GUI
{
    public partial class FormNguoiDung : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormNguoiDung()
        {
            InitializeComponent();
            this.CenterToParent();
            this.WindowState = FormWindowState.Maximized;
            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            GUI.ChangePassword form = new GUI.ChangePassword();
            form.Show();
        }


        private void btn_infobill_Click(object sender, EventArgs e)
        {
            GUI.HoaDonThanhToan hd = new HoaDonThanhToan();
            hd.Show();
        }

        private void btn_inforoom_Click(object sender, EventArgs e)
        {
            GUI.DSPhong list = new GUI.DSPhong();
            list.Show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            GUI.Login lg = new GUI.Login();
            lg.Show();
        }

        private void btn_dv_Click(object sender, EventArgs e)
        {
            GUI.DSDichVu dv = new GUI.DSDichVu();
            dv.Show();
        }
    }
}
