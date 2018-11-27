using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_QLTS.GUI
{
    public partial class Login : Form
    {
        CallAPI requestData = new CallAPI();
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var taiKhoan = requestData.GetToken(txtUserName.Text, txtPassWord.Text);
            if(taiKhoan != null)
            {
               // MessageBox.Show(taiKhoan);
                using (Form1 form2 = new Form1(taiKhoan))
                {
                    form2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  Application.Exit();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
