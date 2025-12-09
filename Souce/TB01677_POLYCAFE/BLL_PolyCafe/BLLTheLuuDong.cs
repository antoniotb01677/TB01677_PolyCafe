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
                the.MaThe = dalTheLuuDong.generateMaTheLuuDong();
                if (string.IsNullOrEmpty(the.MaThe))
                {
                    return "Mã thẻ lưu động không hợp lệ.";
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

        public string SuaTheLuuDong(TheLuuDong nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.MaThe))
                {
                    return "Mã thẻ lưu động không hợp lệ.";
                }

                dalTheLuuDong.SuaTheLuuDong(nv);
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
                    return "Mã thẻ lưu động không hợp lệ.";
                }

                dalTheLuuDong.XoaTheLuuDong(maThe);
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
