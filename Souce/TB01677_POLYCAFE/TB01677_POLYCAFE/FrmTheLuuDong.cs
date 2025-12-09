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
    public partial class FrmTheLuuDong : Form
    {
        public FrmTheLuuDong()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaThe.Clear();
            txtChuSoHuu.Clear();
            rdbHoatDong.Checked = true;
        }
        private void LoadTheLuuDong()
        {
            BLLTheLuuDong bllTheLuuDong = new BLLTheLuuDong();
            dgvDanhSachThe.DataSource = null;
            dgvDanhSachThe.DataSource = bllTheLuuDong.GetTheLuuDongList();
        }

        private void txtChuSoHuu_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachThe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDanhSachThe.Rows[e.RowIndex];
            // Đổ dữ liệu vào các ô nhập liệu trên form
            txtMaThe.Text = row.Cells["MaThe"].Value.ToString();
            txtChuSoHuu.Text = row.Cells["ChuSoHuu"].Value.ToString();

            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            rdbHoatDong.Checked = trangThai;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaThe.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadTheLuuDong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maThe = txtMaThe.Text.Trim();
            string ChuSoHuu = txtChuSoHuu.Text.Trim();


            bool TrangThai;
            if (rdbHoatDong.Checked)
            {
                TrangThai = false;
            }
            else
            {
                TrangThai = true;
            }
            if (string.IsNullOrEmpty(maThe) || string.IsNullOrEmpty(ChuSoHuu))
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
                ClearForm();
                LoadTheLuuDong();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maThe = txtMaThe.Text.Trim();
            string chuSoHuu = txtChuSoHuu.Text.Trim();

            bool trangThai;

            if (rdbHoatDong.Checked)
            {
                trangThai = true;
            }
            else
            {
                trangThai = false;
            }
            if (string.IsNullOrEmpty(chuSoHuu))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin thẻ lưu động.");
                return;
            }
            TheLuuDong theLuuDong = new TheLuuDong
            {
                MaThe = maThe,
                ChuSoHuu = chuSoHuu,
                TrangThai = trangThai
            };
            BLLTheLuuDong bus = new BLLTheLuuDong();
            string result = bus.ThemTheLuuDong(theLuuDong);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadTheLuuDong();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maThe = txtMaThe.Text.Trim();
            string name = txtChuSoHuu.Text.Trim();
            if (string.IsNullOrEmpty(maThe))
            {
                if (dgvDanhSachThe.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDanhSachThe.SelectedRows[0];
                    maThe = selectedRow.Cells["MaThe"].Value.ToString();
                    name = selectedRow.Cells["ChuSoHuu"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một thẻ lưu động để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(maThe))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thẻ {maThe} - {name}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BLLTheLuuDong bLLTheLuuDong = new BLLTheLuuDong();
                string kq = bLLTheLuuDong.XoaTheLuuDong(maThe);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin thẻ {maThe} - {name} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadTheLuuDong();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}

