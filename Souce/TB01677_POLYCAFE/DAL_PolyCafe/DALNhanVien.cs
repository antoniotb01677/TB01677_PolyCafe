using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_PolyCafe;

namespace DAL_PolyCafe
{
    public class DALNhanVien
    {
        public NhanVien getNhanVien( string Email, string Password)
        {
            string sql = "SELECT * from NhanVien where Email=@0 and MatKhau=@1";
            List<object> thamso = new List<object>();
            thamso.Add(Email);
            thamso.Add(Password);
            NhanVien nv = DBUtil.Value<NhanVien>(sql, thamso);
            return nv;
        }
    }
}
