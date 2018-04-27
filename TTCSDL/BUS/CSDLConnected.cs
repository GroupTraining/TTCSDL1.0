using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DAL;

namespace BUS
{
    public class CSDLConnected
    {
        TTCSDLDataContext db = new TTCSDLDataContext();
        public bool check_login(string username, string pass)
        {
            int taikhoan = (from tk in db.TKUsers
                            where tk.Username == username && tk.Pass == pass
                            select tk).Count();
            if (taikhoan == 1)
                return true;
            else
                return false;
        }
        public string getGroup(string username) //lay so nhom 
        {
            TKUser tks = db.TKUsers.Single(p => p.Username == username);
            GroupUser gr = db.GroupUsers.Single(g => g.Ma == tks.Ma);
            string grid = gr.Nhom.ToString();
            return grid;
        }
        public object getDataSingle(string username) //lay du lieu user theo username
        {
            var user = from u in db.TKUsers
                          where u.Username == username
                          select u;
            return user;
        }
        public void updateDataSingle(string username) //lay du lieu user theo username
        {
            var user = from u in db.TKUsers
                       where u.Username == username
                       select u;
            db.SubmitChanges();
        }
        public object getData()
        {
            var data = from tks in db.TKUsers
                       select tks;
            return data;
        }

        #region Ma hoa mk md5
        public string encrypt(string mk)
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

        public object getDataKH()
        {
            var data = from u in db.KhachHangs
                       select u;
            return data;
        }

        public object getDataNV()
        {
            var data = from u in db.NhanViens
                       select u;
            return data;
        }

        public object getDataDV()
        {
            var data = from u in db.DichVus
                       select u;
            return data;
        }

        public object getDataDVu()
        {
            var data = from u in db.DichVus
                       select new
                       {
                           TenDichVu = u.TenDV.Trim(),
                           GiaDichVu = u.GiaDV,
                       };
            return data;
        }
        public object getDataPhong()
        {
            var data = from p in db.Phongs
                       select new
                       {
                           So = p.SoPhong.Trim(),
                           LoaiPhong = p.LoaiPhong.Trim(),
                           GiaPhong = p.GiaPhong,
                           TinhTrang = p.TinhTrangPhong,
                           TimeEdited = p.TimeEdited
                       };
            return data;
        }
        public object getDataHDTT(string tenkh)
        {
            var data = from u in db.HDDichVus
                       from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from z in db.HDThanhToans
                       from a in db.ChiTietThuePhongs
                       from b in db.Phongs
                       where u.MaKH == v.MaKH
                       where v.MaKH == t.MaKHThue
                       where z.MaKHTT == v.MaKH
                       where z.MaPhong == t.MaPhong
                       where u.MaHD == z.MaHDDV
                       where t.MaPhong == a.MaPhong
                       where a.SoPhong == b.SoPhong
                       where v.TrangThai == "checkin"
                       where DateTime.Compare(DateTime.Now, Convert.ToDateTime(t.NgayThue)) >= 0 && DateTime.Compare(DateTime.Now, Convert.ToDateTime(t.NgayTra)) < 0
                       select new
                       {
                           SoPhong = a.SoPhong.Trim(),
                           TenKH = v.TenKH.Trim(),
                           SoDT = v.SoDT.Trim(),
                           TienDV = u.TongTien,
                           TienPhong = t.TienPhong,
                           NgayThanhToan = z.NgayThanhToan,
                           TongTienThanhToan = z.TongTienThanhToan
                       } into timkiemhdtt
                       where timkiemhdtt.TenKH.Contains(tenkh)
                       select timkiemhdtt
                       ;

            return data;


        }

        public object getDataHDTT1(string tenkh)//Lọc khách hàng có tên đang ở trạng thái checkin
        {
            var data = from u in db.HDDichVus
                       from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from z in db.HDThanhToans
                       from a in db.ChiTietThuePhongs
                       where u.MaKH == v.MaKH
                       where v.MaKH == t.MaKHThue
                       where z.MaKHTT == v.MaKH
                       where z.MaPhong == t.MaPhong
                       where u.MaHD == z.MaHDDV
                       where t.MaPhong == a.MaPhong
                       where v.TrangThai == "checkin"
                       where DateTime.Compare(DateTime.Now, Convert.ToDateTime(t.NgayThue)) >= 0 && DateTime.Compare(DateTime.Now, Convert.ToDateTime(t.NgayTra)) < 0
                       select new
                       {
                           MaHD = z.MaHDTT.Trim(),
                           SoPhong = a.SoPhong.Trim(),
                           TenKH = v.TenKH.Trim(),
                           SoDT = v.SoDT.Trim(),
                           NgayThanhToan = z.NgayThanhToan
                       } into timkiemhdtt
                       where timkiemhdtt.TenKH.Contains(tenkh) 
                       select timkiemhdtt
                       ;

            return data;
        }
        public object getDataHDTT2(string tenkh)//Lọc khách hàng có tên để xem lịch sử thanh toán
        {
            var data = from u in db.HDDichVus
                       from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from z in db.HDThanhToans
                       from a in db.ChiTietThuePhongs
                       where u.MaKH == v.MaKH
                       where v.MaKH == t.MaKHThue
                       where z.MaKHTT == v.MaKH
                       where z.MaPhong == t.MaPhong
                       where u.MaHD == z.MaHDDV
                       where t.MaPhong == a.MaPhong
                       where DateTime.Compare(DateTime.Now, Convert.ToDateTime(t.NgayTra)) >= 0 || v.TrangThai =="checkout"
                       select new
                       {
                           SoPhong = a.SoPhong.Trim(),
                           TenKH = v.TenKH.Trim(),
                           SoDT = v.SoDT.Trim(),
                           TienDV = u.TongTien,
                           TienPhong = t.TienPhong,
                           NgayThanhToan = z.NgayThanhToan,
                           TongTien = z.TongTienThanhToan
                       } into timkiemhdtt
                       where timkiemhdtt.TenKH.Contains(tenkh)
                       select timkiemhdtt
                       ;

            return data;
        }
        public object getDataHDTT3(string tenkh,string tungay, string denngay)//Lọc theo ngay để xem lịch sử thanh toán
        {
            var data = from u in db.HDDichVus
                       from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from z in db.HDThanhToans
                       from a in db.ChiTietThuePhongs
                       where u.MaKH == v.MaKH
                       where v.MaKH == t.MaKHThue
                       where z.MaKHTT == v.MaKH
                       where z.MaPhong == t.MaPhong
                       where u.MaHD == z.MaHDDV
                       where t.MaPhong == a.MaPhong
                       where DateTime.Compare(Convert.ToDateTime(tungay), Convert.ToDateTime(t.NgayTra)) <= 0
                       where DateTime.Compare(Convert.ToDateTime(denngay), Convert.ToDateTime(t.NgayTra)) >= 0
                       select new
                       {
                           SoPhong = a.SoPhong.Trim(),
                           TenKH = v.TenKH.Trim(),
                           SoDT = v.SoDT.Trim(),
                           TienDV = u.TongTien,
                           TienPhong = t.TienPhong,
                           NgayThanhToan = z.NgayThanhToan,
                           TongTien = z.TongTienThanhToan
                       } into timkiemhdtt
                       where timkiemhdtt.TenKH.Contains(tenkh)
                       select timkiemhdtt
                       ;

            return data;
        }
        //lấy ds khách hàng đã đặt phòng
        public object getDataKHDP()
        {
            var data = from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from a in db.ChiTietThuePhongs
                       from b in db.Phongs
                       where v.MaKH == t.MaKHThue
                       where a.MaPhong == t.MaPhong
                       where a.SoPhong == b.SoPhong
                       where  v.TrangThai =="checkout"
                       where DateTime.Compare(DateTime.Now, Convert.ToDateTime(t.NgayThue)) <= 0 
                       select new
                       {
                           SoPhong = a.SoPhong,
                           TenKH = v.TenKH,
                           CMTND = v.SoCMT,
                           SDT = v.SoDT,
                           NgayDen = t.NgayThue,
                           NgayTra = t.NgayTra 
                       };
              return data;
        }
        public object getDataKHDP1(string tungay, string denngay)//lọc theo ngày để xem ds khách hàng đã đặt phòng
        {
            var data = from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from a in db.ChiTietThuePhongs
                       from b in db.Phongs
                       where v.MaKH == t.MaKHThue
                       where a.MaPhong == t.MaPhong
                       where a.SoPhong == b.SoPhong
                       where b.TinhTrangPhong == true && v.TrangThai == "checkout"
                       where DateTime.Compare(Convert.ToDateTime(tungay), Convert.ToDateTime(t.NgayThue)) <= 0
                       where DateTime.Compare(Convert.ToDateTime(denngay), Convert.ToDateTime(t.NgayThue)) >= 0
                       select new
                       {
                           SoPhong = a.SoPhong,
                           TenKH = v.TenKH,
                           CMTND = v.SoCMT,
                           SDT = v.SoDT,
                           NgayDen = t.NgayThue,
                           NgayDuTra = t.NgayTra
                       };
            return data;
        }
        public object getDataHDDV(string tenkh)
        {
            var data = from u in db.HDDichVus
                       from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from z in db.HDThanhToans
                       from y in db.ChiTietDVs
                       from p in db.DichVus
                       from a in db.ChiTietThuePhongs
                       where u.MaKH == v.MaKH
                       where v.MaKH == t.MaKHThue
                       where z.MaKHTT == v.MaKH
                       where z.MaPhong == t.MaPhong
                       where p.MaDV == y.MaDV
                       where y.MaHD == u.MaHD
                       where u.MaHD == z.MaHDDV
                       where a.MaPhong == t.MaPhong
                       select new
                       {
                           SoPhong = a.SoPhong.Trim(),
                           TenKH = v.TenKH.Trim(),
                           NgayLapHD = u.NgayLapHD,
                           TenDV = p.TenDV.Trim(),
                           SoLuong = y.SoLuongDV,
                           ThanhTien = y.ThanhTien,
                       } into timkiemhddv
                       where timkiemhddv.TenKH.Contains(tenkh)
                       select timkiemhddv
                       ;

            return data;


        }

        public object getDataHDDV2(string tenkh)
        {
            var data = from u in db.HDDichVus
                       from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from z in db.HDThanhToans
                       from y in db.ChiTietDVs
                       from p in db.DichVus
                       where u.MaKH == v.MaKH
                       where v.MaKH == t.MaKHThue
                       where z.MaKHTT == v.MaKH
                       where z.MaPhong == t.MaPhong
                       where p.MaDV == y.MaDV
                       where y.MaHD == u.MaHD
                       where u.MaHD == z.MaHDDV
       
                       select new
                       {
                           MaKH = v.MaKH.Trim(),
                           TenKH = v.TenKH.Trim(),
                           MaHDDV = z.MaHDDV,
                           TenDV = p.TenDV.Trim(),
                           SoLuong = y.SoLuongDV,
                           ThanhTien = y.ThanhTien,
                       } into timkiemhddv
                       where timkiemhddv.TenKH.Contains(tenkh)
                       select timkiemhddv
                       ;

            return data;
        }


        public int EditCtHddv(string makh, string mahddv, string madv, string sl)
        {
            var hdtt = db.HDThanhToans.Single(p => p.MaHDDV == mahddv);
            var kh = db.KhachHangs.Single(p => p.MaKH == makh) ;
            var hddv = db.HDDichVus.Single(p => p.MaHD == mahddv);
            var ctdv = db.ChiTietDVs.Single(p => p.MaHD == mahddv && p.MaDV == madv);
            var dv = db.DichVus.Single(p => p.MaDV == madv);
            
            kh.MaKH = hdtt.MaKHTT;
            ctdv.MaDV = dv.MaDV;
            ctdv.SoLuongDV = Convert.ToInt32(sl);
            ctdv.ThanhTien = dv.GiaDV * Convert.ToInt32(sl);
            db.SubmitChanges();
            return 1;
        }

        public int delHddv(string makh, string mahddv, string madv, string sl)
        {
            var hdtt = db.HDThanhToans.Single(p => p.MaHDDV == mahddv);
            var kh = db.KhachHangs.Single(p => p.MaKH == makh);
            var hddv = db.HDDichVus.Single(p => p.MaHD == mahddv);
            var ctdv = db.ChiTietDVs.Single(p => p.MaHD == mahddv && p.MaDV == madv);
            db.ChiTietDVs.DeleteOnSubmit(ctdv);
            db.SubmitChanges();
            return 1;
        }

        public object Doanthutheongay()
        {
            var doanhthu = from a in db.HDThanhToans
                           from b in db.KhachHangs
                           where a.MaKHTT == b.MaKH && Convert.ToDateTime(a.NgayThanhToan).Day == DateTime.Now.Day
                         select new
                         {
                             MaHDTT = a.MaHDTT,
                             TenKH = b.TenKH,
                             NgayThanhToan = a.NgayThanhToan,
                             Total = a.Total,
                         }; 
            return doanhthu;
        }

        public object Doanthutheothang()
        {
            var doanhthu = from a in db.HDThanhToans
                           from b in db.KhachHangs
                           where a.MaKHTT == b.MaKH && Convert.ToDateTime(a.NgayThanhToan).Month == DateTime.Now.Month
                           select new
                           {
                               MaHDTT = a.MaHDTT,
                               TenKH = b.TenKH,
                               NgayThanhToan = a.NgayThanhToan,
                               Total = a.Total,
                           };
            return doanhthu;
        }

        public object Doanthutheonam()
        {
            var doanhthu = from a in db.HDThanhToans
                           from b in db.KhachHangs
                           where a.MaKHTT == b.MaKH && Convert.ToDateTime(a.NgayThanhToan).Year == DateTime.Now.Year
                           select new
                           {
                               MaHDTT = a.MaHDTT,
                               TenKH = b.TenKH,
                               NgayThanhToan = a.NgayThanhToan,
                               Total = a.Total,
                           };
            return doanhthu;
        }

        public int? Dtngay()
        {
            var doanhthu = from a in db.HDThanhToans
                           from b in db.KhachHangs
                           where a.MaKHTT == b.MaKH && Convert.ToDateTime(a.NgayThanhToan).Day == DateTime.Now.Day
                           select new
                           {
                               MaHDTT = a.MaHDTT,
                               TenKH = b.TenKH,
                               NgayThanhToan = a.NgayThanhToan,
                               Total = a.Total,
                           };
            int? total = 0;
            foreach(var dt in doanhthu)
            {
                total += dt.Total;
            }
            return total;
        }
        public int? Dtthang()
        {
            var doanhthu = from a in db.HDThanhToans
                           from b in db.KhachHangs
                           where a.MaKHTT == b.MaKH && Convert.ToDateTime(a.NgayThanhToan).Month == DateTime.Now.Month
                           select new
                           {
                               MaHDTT = a.MaHDTT,
                               TenKH = b.TenKH,
                               NgayThanhToan = a.NgayThanhToan,
                               Total = a.Total,
                           };
            int? total = 0;
            foreach (var dt in doanhthu)
            {
                total += dt.Total;
            }
            return total;
        }
        public int? Dtnam()
        {
            var doanhthu = from a in db.HDThanhToans
                           from b in db.KhachHangs
                           where a.MaKHTT == b.MaKH && Convert.ToDateTime(a.NgayThanhToan).Year == DateTime.Now.Year
                           select new
                           {
                               MaHDTT = a.MaHDTT,
                               TenKH = b.TenKH,
                               NgayThanhToan = a.NgayThanhToan,
                               Total = a.Total,
                           };
            int? total = 0;
            foreach (var dt in doanhthu)
            {
                total += dt.Total;
            }
            return total;
        }
    }
}
