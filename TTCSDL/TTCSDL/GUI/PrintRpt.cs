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
using System.Data.SqlClient;

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
            var hoadondv = data.HDDichVus.Single(a => a.MaHD == hoadontt.MaHDDV);
            var chitiets = from a in data.ChiTietDVs
                           from b in data.DichVus
                           where a.MaHD == hoadontt.MaHDDV && a.MaDV == b.MaDV
                           select new
                           {
                               ten = b.TenDV,
                               sl = a.SoLuongDV,
                               dongia = b.GiaDV,
                               tien = a.ThanhTien
                           };
            
            GUI.DataSet ds = new GUI.DataSet();

            foreach (var chitiet in chitiets)
            {
                ds.chitiet.AddchitietRow(chitiet.ten, Convert.ToInt32(chitiet.sl), Convert.ToInt32(chitiet.dongia), Convert.ToInt32(chitiet.tien));
                ds.AcceptChanges();
            }
          

            rptHDTT1.SetDataSource(ds);

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

            rptHDTT1.SetParameterValue("pTienDV", string.Format("{0,-10:N0}đ", hoadondv.TongTien) );
            rptHDTT1.SetParameterValue("pTienPhong", string.Format("{0,-10:N0}đ", hoadontp.TienPhong) );
            rptHDTT1.SetParameterValue("pTong", string.Format("{0,-10:N0}đ", hoadontt.TongTienThanhToan) );
            rptHDTT1.SetParameterValue("pDatCoc", string.Format("{0,-10:N0}đ", hoadontp.DatCoc) );

            if (kh.CapBac == 2)
            {
                hoadontt.GiamGia = Convert.ToInt32(hoadontt.TongTienThanhToan * 0.05);
            }
            else if (kh.CapBac == 3)
            {
                hoadontt.GiamGia = Convert.ToInt32(hoadontt.TongTienThanhToan * 0.1);
            }
            else hoadontt.GiamGia = 0;
            hoadontt.Total = hoadontt.TongTienThanhToan - hoadontt.GiamGia - hoadontp.DatCoc;
            data.SubmitChanges();

            rptHDTT1.SetParameterValue("pGiamGia", string.Format("{0,-10:N0}đ", hoadontt.GiamGia) );
            rptHDTT1.SetParameterValue("pTongThu", string.Format("{0,-10:N0}đ", hoadontt.Total) );

            crystalReportViewer.ReportSource = rptHDTT1;

        }
    }
}
