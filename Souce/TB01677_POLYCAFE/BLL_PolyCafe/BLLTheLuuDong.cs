using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BLLTheLuuDong
    {
        DALTheLuuDong dalTheLuuDong = new DALTheLuuDong();

        public List<TheLuuDong> GetTheLuuDongList()
        {
            return dalTheLuuDong.selectAll();
        }
        public string ThemTheLuuDong(TheLuuDong the)
        {
            try
            {
                the.MaThe= dalTheLuuDong.generateMaThe();
                if (string.IsNullOrEmpty(the.MaThe))
                {
                    return "Mã thẻ không hợp lệ.";
                }
                
                dalTheLuuDong.ThemTheLuuDong(the);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public string SuaTheLuuDong(TheLuuDong the)
        {
            try
            {
                if (string.IsNullOrEmpty(the.MaThe))
                {
                    return "Mã thẻ không hợp lệ.";
                }

                dalTheLuuDong.SuaTheLuuDong(the);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string XoaTheLuuDong(string maThe)
        {
            try
            {
                if (string.IsNullOrEmpty(maThe))
                {
                    return "Mã thẻ không hợp lệ.";
                }

                dalTheLuuDong.XoaThe(maThe);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
