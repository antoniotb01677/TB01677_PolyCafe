using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BLLLoaiSanPham
    {
        DALLoaiSanPham dalLoaiSanPham = new DALLoaiSanPham();
        public List<LoaiSanPham> GetLoaiSanPhamlist() 
        {
            return dalLoaiSanPham.selectAll();
        }
        public string ThemLoaiSanPham(LoaiSanPham loaiSP)
        {
            try
            {
                loaiSP.MaLoai = dalLoaiSanPham.generateMaLoaiSanPham();
                if (string.IsNullOrEmpty(loaiSP.MaLoai))
                {
                    return "Mã loại sản phẩm không hợp lệ.";
                }

                dalLoaiSanPham.ThemLoaiSanPham(loaiSP);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string SuaLoaiSanPham(LoaiSanPham loaiSP)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiSP.MaLoai))
                {
                    return "Mã loại sản phẩm không hợp lệ.";
                }

                dalLoaiSanPham.SuaLoaiSanPham(loaiSP);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string XoaLoaiSanPham(string maloaiSP)
        {
            try
            {
                if (string.IsNullOrEmpty(maloaiSP))
                {
                    return "Mã loại sản phẩm không hợp lệ.";
                }

                dalLoaiSanPham.XoaLoaiSanPham(maloaiSP);
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
