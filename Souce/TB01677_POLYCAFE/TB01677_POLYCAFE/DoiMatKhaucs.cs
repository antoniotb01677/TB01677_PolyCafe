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
using UTIL_Polycafe;

namespace GUI_PolyCafe
{
    public partial class DoiMatKhaucs : Form
    {
        public DoiMatKhaucs()
        {
            InitializeComponent();
        }
        BLLNhanVien bllNhanVien     = new BLLNhanVien();

        private void DoiMatKhaucs_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!AuthUtil.user.MatKhau.Equals(txtMatkhaucu.Text))
            {
                MessageBox.Show(this, "Mật khẩu cũ chưa đúng!!!");
            }
            else
            {
                if (!txtMatKhaumoi.Text.Equals(txtNhapLai.Text))
                {
                    MessageBox.Show(this, "Xác nhận mật khẩu mới chưa trùng khớp!!!");
                }
                else
                {
                    AuthUtil.user.MatKhau = txtMatKhaumoi.Text;

                    if (bllNhanVien.ResetMatKhau(AuthUtil.user.Email, txtMatKhaumoi.Text))
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công!!!");
                    }
                    else MessageBox.Show("Đổi mật khẩu thất bại, vui lòng kiểm tra lại!!!");
                }
            }
        }
    }
}
