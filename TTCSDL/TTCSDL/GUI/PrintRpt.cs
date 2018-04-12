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
using System.Globalization;

namespace TTCSDL.GUI
{
    public partial class PrintRpt : Form
    {
        TTCSDLDataContext data = new TTCSDLDataContext();
        public PrintRpt()
        {
            InitializeComponent();
        }
        string mahd = "";
        public PrintRpt(string name) : this()
        {
            string text = name;
            mahd = text;
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {
            var hoadontt = data.HDThanhToans.Single(a => a.MaHDTT.Trim() == mahd);
            var kh = data.KhachHangs.Single(b => b.MaKH == hoadontt.MaKHTT);
            var phong = data.ChiTietThuePhongs.Single(c => c.MaPhong == hoadontt.MaPhong);
            var hoadontp = data.HDThuePhongs.Single(d => d.MaPhong == hoadontt.MaPhong);
            
            TimeSpan thoigianthue = Convert.ToDateTime(hoadontp.NgayTra) - Convert.ToDateTime(hoadontp.NgayThue);

            rptHDTT1.SetParameterValue("pSoHD", hoadontt.MaHDTT);
            rptHDTT1.SetParameterValue("pPhong", phong.SoPhong);
            rptHDTT1.SetParameterValue("pTenKH", kh.TenKH);
            rptHDTT1.SetParameterValue("pNgayDen", hoadontp.NgayThue);
            rptHDTT1.SetParameterValue("pNgayTra", hoadontp.NgayTra);
            if(thoigianthue.TotalDays == 0)
            {
                rptHDTT1.SetParameterValue("pThoiGianO", "1 ngày");
            }else
            {
                rptHDTT1.SetParameterValue("pThoiGianO", thoigianthue.TotalDays + " ngày");
            }
            

            crystalReportViewer.ReportSource = rptHDTT1;
        }
    }
}
