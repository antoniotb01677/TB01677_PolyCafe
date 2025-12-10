using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BLLSanPham
    {
        DALSanPham dalSanPham = new DALSanPham();
        public List<SanPham> GetSanPhamlist() { return dalSanPham.selectAll(); }

        public string ThemSanPham(SanPham sp)
        {
            try
            {
                sp.MaSanPham = dalSanPham.generateMaSanPham();
                if (string.IsNullOrEmpty(sp.MaSanPham))
                {
                    return "Mã sản phẩm không hợp lệ.";
                }

                dalSanPham.ThemSanPham(sp);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string SuaSanPham(SanPham sp)
        {
            try
            {
                if (string.IsNullOrEmpty(sp.MaSanPham))
                {
                    return "Mã sản phẩm không hợp lệ.";
                }

                

                dalSanPham.SuaSanPham(sp);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string XoaSanPham(string maSP)
        {
            try
            {
                if (string.IsNullOrEmpty(maSP))
                {
                    return "Mã sản phẩm không hợp lệ.";
                }

                dalSanPham.XoaSanPham(maSP);
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
