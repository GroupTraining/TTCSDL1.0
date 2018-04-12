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
    public partial class DSPhong : Form
    {
        public DSPhong()
        {
            InitializeComponent();
            picturePhongdoi.Hide();
            picturePhongvip.Hide();
        }

        private void buttonPdon_Click(object sender, EventArgs e)
        {
            picturePhongdon.Show();
            picturePhongdoi.Hide();
            picturePhongvip.Hide();
        }

        private void buttonPdoi_Click(object sender, EventArgs e)
        {
            picturePhongdon.Hide();
            picturePhongdoi.Show();
            picturePhongvip.Hide();
        }

        private void buttonPvip_Click(object sender, EventArgs e)
        {
            picturePhongdon.Hide();
            picturePhongdoi.Hide();
            picturePhongvip.Show();
        }
    }
}
