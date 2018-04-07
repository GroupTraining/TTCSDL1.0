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

        public object getDataDV()
        {
            var data = from u in db.DichVus
                       select u;
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
        public object getDataHDTT()
        {
            var data = from u in db.HDDichVus
                       from v in db.KhachHangs
                       from t in db.HDThuePhongs
                       from z in db.HDThanhToans
                       where u.MaKH == v.MaKH
                       where v.MaKH == t.MaKHThue
                       where z.MaKHTT == v.MaKH
                       where z.MaPhong == t.MaPhong
                       select new
                       {
                           MaPhong = z.MaPhong.Trim(),
                           TenKH = v.TenKH.Trim(),
                           TienDV = u.TongTien,
                           TienPhong = t.TienPhong,
                           NgayThanhToan = z.NgayThanhToan,
                           TongTienThanhToan = z.TongTienThanhToan
                       };
            return data;

        
        }
    }
}
