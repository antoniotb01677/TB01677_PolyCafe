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
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void clearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            rdbNhanVien.Checked = true;
            rdbHoatDong.Checked = true;
        }
        private void LoadDanhSachNhanVien()
        {
            BLLNhanVien bLLNhanVien = new BLLNhanVien();
            dgvDanhSachNhanVien.DataSource = null;
            dgvDanhSachNhanVien.DataSource = bLLNhanVien.GetNhanVienList();
            dgvDanhSachNhanVien.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvDanhSachNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvDanhSachNhanVien.Columns["Email"].HeaderText = "Email";
            dgvDanhSachNhanVien.Columns["MatKhau"].HeaderText = "MatKhau";
            dgvDanhSachNhanVien.Columns["VaiTro"].Visible = false;
            dgvDanhSachNhanVien.Columns["TrangThai"].Visible = false;
            dgvDanhSachNhanVien.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvDanhSachNhanVien.Columns["VaiTroText"].HeaderText = "Vai Trò";
        }


        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            clearForm();
            LoadDanhSachNhanVien();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text.Trim();
            string Ten = txtHoTen.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string MatKhau = txtMatKhau.Text.Trim();
            bool VaiTro;
            if (rdbNhanVien.Checked)
            {
                VaiTro = false;
            }
            else
            {
                VaiTro = true;
            }
            bool TrangThai;
            if (rdbHoatDong.Checked)
            {
                TrangThai = false;
            }
            else
            {
                TrangThai = true;
            }
            if (string.IsNullOrEmpty(Ten) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(MatKhau))
            {
                MessageBox.Show("Vui long điền đầy đủ thông tin");
                return;
            }
            NhanVien nv = new NhanVien()
            {
                MaNhanVien = maNV,
                HoTen = Ten,
                Email = Email,
                MatKhau = MatKhau,
                VaiTro = VaiTro,
                TrangThai = TrangThai,
            };
            BLLNhanVien bll = new BLLNhanVien();
            string result = bll.ThemNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                clearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result);
            }
        }


        private void dgvDanhSachNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDanhSachNhanVien.Rows[e.RowIndex];
            // Đổ dữ liệu vào các ô nhập liệu trên form
            txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            //txtXacNhanMK.Text = row.Cells["MatKhau"].Value.ToString();

            bool vaiTro = Convert.ToBoolean(row.Cells["VaiTro"].Value);
            if (vaiTro == false)
            {
                rdbNhanVien.Checked = true;
            }
            else
            {
                rdbQuanLy.Checked = true;
            }

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
            // Tắt chỉnh sửa mã nhân viên
            txtMaNhanVien.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text.Trim();
            string Ten = txtHoTen.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string MatKhau = txtMatKhau.Text.Trim();
            bool VaiTro;
            if (rdbNhanVien.Checked)
            {
                VaiTro = false;
            }
            else
            {
                VaiTro = true;
            }
            bool TrangThai;
            if (rdbHoatDong.Checked)
            {
                TrangThai = false;
            }
            else
            {
                TrangThai = true;
            }
            if (string.IsNullOrEmpty(Ten) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(MatKhau))
            {
                MessageBox.Show("Vui long điền đầy đủ thông tin");
                return;
            }
            NhanVien nv = new NhanVien()
            {
                MaNhanVien = maNV,
                HoTen = Ten,
                Email = Email,
                MatKhau = MatKhau,
                VaiTro = VaiTro,
                TrangThai = TrangThai,
            };
            BLLNhanVien bll = new BLLNhanVien();
            string result = bll.SuaNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                clearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text.Trim();
            string name = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(maNhanVien))
            {
                if (dgvDanhSachNhanVien.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDanhSachNhanVien.SelectedRows[0];
                    maNhanVien = selectedRow.Cells["MaNhanVien"].Value.ToString();
                    name = selectedRow.Cells["HoTen"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {maNhanVien} - {name}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BLLNhanVien bll = new BLLNhanVien();
                string kq = bll.XoaNhanVien(maNhanVien);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin nhân viên {maNhanVien} - {name} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearForm();
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
            LoadDanhSachNhanVien();
        }
    }
}


