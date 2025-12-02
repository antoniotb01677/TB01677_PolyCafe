using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_PolyCafe;
using Microsoft.Data.SqlClient;

namespace DAL_PolyCafe
{
    public class DALSanPham
    {
        public List<SanPham> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<SanPham> list = new List<SanPham>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    SanPham entity = new SanPham();
                    entity.MaSanPham = reader.GetString("MaSanPham");
                    entity.TenSanPham = reader.GetString("TenSanPham");
                    entity.DonGia = reader.GetDecimal("DonGia");
                    entity.MaLoai = reader.GetString("MaLoai");
                    entity.TenLoai = reader.GetString("TenLoai");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<SanPham> selectAll()
        {
            String sql = "SELECT * FROM SanPham";
            return SelectBySql(sql, new List<object>());
        }
        //hàm tự động tạo mã san pham
        public string generateMaSanPham()
        {
            string prefix = "SANPHAM";
            string sql = "SELECT MAX(MaSanPham) FROM SanPham";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
        public void ThemSanPham(SanPham sanpham)
        {
            try
            {
                string sql = @"INSERT INTO SanPham (MaSanPham, TenSanPham, DonGia, MaLoai, TrangThai) 
                   VALUES (@0, @1, @2, @3, @4 )";
                List<object> thamSo = new List<object>();
                thamSo.Add(sanpham.MaSanPham);
                thamSo.Add(sanpham.TenSanPham);
                thamSo.Add(sanpham.DonGia);
                thamSo.Add(sanpham.MaLoai);
                thamSo.Add(sanpham.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void SuaSanPham(SanPham sp)
        {
            try
            {
                string sql = @"UPDATE SanPham 
                   SET TenSanPham = @1, DonGia = @2, MaLoai = @3, TrangThai = @4 
                   WHERE MaSanPham = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(sp.MaSanPham);
                thamSo.Add(sp.TenSanPham);
                thamSo.Add(sp.DonGia);
                thamSo.Add(sp.MaLoai);
                thamSo.Add(sp.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void XoaSanPham(string maSp)
        {
            try
            {
                string sql = "DELETE FROM SanPham WHERE MaSanPham = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maSp);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
