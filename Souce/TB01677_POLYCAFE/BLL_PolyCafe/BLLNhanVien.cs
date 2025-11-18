using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BLLNhanVien
    {
        DALNhanVien dalNhanVien = new DALNhanVien();
        public NhanVien DangNhap(string username,string password)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            return dalNhanVien.getNhanVien(username, password);
        }
    }
}
