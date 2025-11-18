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
    public partial class frmlogin : Form
    {
        BLLNhanVien bllNhanVien = new BLLNhanVien();
        public frmlogin()
        {
            InitializeComponent();
        }

        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //lấy dữ liệu từ ô tài khoản và mật khẩu
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            //gọi hàm đăng nhập rồi nhét dữ liệu vào
            NhanVien nv = bllNhanVien.DangNhap(username, password);
            //kiểu tra đữ liệu
            if (nv == null)
            {
                MessageBox.Show(this, "Tài khoản hoặc mất khẩu không chính xác,vui lòng thử lại");
                return;
            }
            else
            {
                if(nv.TrangThai == false)
                {
                    MessageBox.Show(this, "tài khoản tạm khóa,vui lòng liên hệ với admin");
                    return;
                }
                //AuthUntil.user = nv;
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }

        }
    }
}
