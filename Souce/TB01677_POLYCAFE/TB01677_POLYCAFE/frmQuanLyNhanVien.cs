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
        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }

}
