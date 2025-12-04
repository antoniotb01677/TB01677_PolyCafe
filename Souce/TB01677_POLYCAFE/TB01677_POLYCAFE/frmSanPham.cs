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
        private void LoadLoaiSanPham()
        {
            try
            {
                BLLLoaiSanPham bUSLoaiSanPham = new BLLLoaiSanPham();
                List<LoaiSanPham> dsLoai = bUSLoaiSanPham.GetLoaiSanPhamlist();
                cboLoaiSanPham.DataSource = dsLoai;
                cboLoaiSanPham.ValueMember = "MaLoai";
                cboLoaiSanPham.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            clearForm();
            LoadDanhSachSanPham();
            LoadLoaiSanPham();
        }
        private void dgvDanhSachSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDanhSachSanPham.Rows[e.RowIndex];
            // Đổ dữ liệu vào các ô nhập liệu trên form
            txtMaSanPham.Text = row.Cells["MaSanPham"].Value.ToString();
            txtTenSanPham.Text = row.Cells["TenSanPham"].Value.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            cboLoaiSanPham.SelectedValue = row.Cells["MaLoai"].Value.ToString();
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
            LoadLoaiSanPham();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSanPham.Text.Trim();

            string Dongia = txtDonGia.Text.Trim();
            string Maloai = cboLoaiSanPham.SelectedValue?.ToString();
            bool trangThai = rdbHoatDong.Checked;

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(Dongia) || string.IsNullOrEmpty(Maloai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SanPham sp = new SanPham
            {
                TenSanPham = tenSP,
                DonGia = decimal.Parse(Dongia),
                MaLoai = Maloai,
                TrangThai = trangThai,
            };
            BLLSanPham bll = new BLLSanPham();
            string result = bll.SuaSanPham(sp);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                clearForm();
                LoadDanhSachSanPham();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTenSanPham.Text.Trim();
                string donGia = txtDonGia.Text.Trim();
                string maLoai = cboLoaiSanPham.SelectedValue?.ToString();
                bool trangThai = rdbHoatDong.Checked;
                string maSP = txtMaSanPham.Text.Trim();

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(donGia) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




                SanPham sp = new SanPham
                {
                    MaSanPham = maSP,
                    TenSanPham = tenSP,
                    DonGia = decimal.Parse(donGia),
                    MaLoai = maLoai,
                    TrangThai = trangThai,
                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                BLLSanPham bllSanPham = new BLLSanPham();
                string result = bllSanPham.SuaSanPham(sp);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật thông tin thành công");
                    clearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSanPham.Text.Trim();
            string tenSP = string.Empty;
            

            if (string.IsNullOrEmpty(maSP))
            {
                if (dgvDanhSachSanPham.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDanhSachSanPham.SelectedRows[0];
                    maSP = selectedRow.Cells["MaSanPham"].Value.ToString();
                    tenSP = selectedRow.Cells["TenSanPham"].Value.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                tenSP = txtTenSanPham.Text.Trim();
            }

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {maSP} - {tenSP}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BLLSanPham bll = new BLLSanPham();
                string kq = bll.XoaSanPham(maSP);

                if (string.IsNullOrEmpty(kq))
                {

                    MessageBox.Show($"Xóa thông tin sản phẩm {maSP} - {tenSP} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
