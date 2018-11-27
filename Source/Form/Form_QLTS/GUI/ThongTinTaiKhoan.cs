using Form_QLTS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_QLTS.GUI
{
    public partial class ThongTinTaiKhoan : Form
    {
        CallAPI requestData = new CallAPI();
        //chuoi~ token
        TaiKhoan taiKhoan = new TaiKhoan();

        NhanVienViewModel nhanVien = new NhanVienViewModel();
        public ThongTinTaiKhoan(TaiKhoan _taiKhoan)
        {
            InitializeComponent();
            taiKhoan = _taiKhoan;
        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            var taiKhoanList = requestData.GetListTaiKhoan(taiKhoan.Token);
            dgv.DataSource = taiKhoanList;

            txtUserName.Text = taiKhoan.UserName;
            txtId.Text = taiKhoan.Id.ToString();
            txtName.Text = taiKhoan.Identity;
            txtToken.Text = taiKhoan.Token.ToString();

            nhanVien = requestData.GetNhanVienByMaNhanVien(taiKhoan.Id.ToString());

            var bytes = StrToByte(nhanVien.HinhAnh);
            MemoryStream stream = new MemoryStream(bytes);
            //With the code below, you are in fact converting the byte array of image
            //to the real image.
            pictureBox1.Image = Image.FromStream(stream);
        }

        public byte[] StrToByte(string str)
        {
            return Encoding.Default.GetBytes(str);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png| All files(*.*)|*.*";

                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        imageLocation = openFileDialog.FileName;
                        pictureBox1.ImageLocation = imageLocation;

                        Image image = Image.FromFile(imageLocation);

                        MemoryStream stream = new MemoryStream();
                        image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                        byte[] bPic = stream.ToArray();
                        var sPic = System.Text.Encoding.Default.GetString(bPic);

                        nhanVien.HinhAnh = sPic;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("!");
            }
        }

        private void btnUpdateTK_Click(object sender, EventArgs e)
        {
            var check = requestData.PutNhanVien(nhanVien);
            if(check == true)
            {
                MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show("!");
            }
        }
    }
}
