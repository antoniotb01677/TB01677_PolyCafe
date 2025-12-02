using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_PolyCafe;
using DTO_PolyCafe;

namespace GUI_PolyCafe
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void clearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtDonGia.Clear();
            txtLoaiSanPham.Clear();
            rdbHoatDong.Checked = true;
        }
        private void LoadDanhSachSanPham()
        {
            BLLSanPham bLLSanPham = new BLLSanPham();
            dgvDanhSachSanPham.DataSource = null;
            dgvDanhSachSanPham.DataSource = bLLSanPham.GetSanPhamlist();
            dgvDanhSachSanPham.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
            dgvDanhSachSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dgvDanhSachSanPham.Columns["TrangThai"].Visible = false;
            dgvDanhSachSanPham.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvDanhSachSanPham.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvDanhSachSanPham.Columns["MaLoai"].HeaderText = "Loại Sản Phẩm";
        }
        //private void LoadLoaiSanPham() 
        //{
        //    BLLLoaiSanPham bLLLoaiSanPham = new BLLLoaiSanPham();
        //    List<LoaiSanPham> dsLoai = bLLLoaiSanPham.GetLoaiSanPhamList();
        //    cboLoaiSanPham.DataSource = dsLoai;
        //    cboLoaiSanPham.ValueMember = "MaLoai";
        //    cboLoaiSanPham.DisplayMember = "TenLoai";
        //}
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            clearForm();
            LoadDanhSachSanPham();
            //LadLoaiSanPham();
        }
        private void dgvDanhSachSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDanhSachSanPham.Rows[e.RowIndex];
            // Đổ dữ liệu vào các ô nhập liệu trên form
            txtMaSanPham.Text = row.Cells["MaSanPham"].Value.ToString();
            txtTenSanPham.Text = row.Cells["TenSanPham"].Value.ToString();


            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai == false)
            {
                rdbHoatDong.Checked = true;
            }
            else
            {
                rdbHoatDong.Checked = true;
            }

            // Bật nút "Sửa"
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Tắt chỉnh sửa mã sản phẩm
            txtMaSanPham.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
            LoadDanhSachSanPham();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSanPham = txtMaSanPham.Text.Trim();
            string TenSanPham = txtTenSanPham.Text.Trim();
            string donGia = txtDonGia.Text.Trim();
            string LoaiSanPham = txtLoaiSanPham.Text.Trim() ;
            bool TrangThai;
            if (rdbHoatDong.Checked)
            {
                TrangThai = false;
            }
            else
            {
                TrangThai = true;
            }
            if (string.IsNullOrEmpty(maSanPham)  || 
                string.IsNullOrEmpty(TenSanPham) ||
                string.IsNullOrEmpty(donGia) ||
                string.IsNullOrEmpty(LoaiSanPham))
            {
                MessageBox.Show("Vui long điền đầy đủ thông tin");
                return;
            }
            TheLuuDong the = new TheLuuDong()
            {
                MaThe = maThe,
                ChuSoHuu = ChuSoHuu,

                TrangThai = TrangThai,
            };
            BLLTheLuuDong bll = new BLLTheLuuDong();
            string result = bll.ThemTheLuuDong(the);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                clearForm();
                LoadTheLuuDong();
            }
            else
            {
                MessageBox.Show(result);
            }
        }
    }
}
