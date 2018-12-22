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

        //bien' test dang ky khach hang`
        string dataImgCustomer;
        public ThongTinTaiKhoan(TaiKhoan _taiKhoan)
        {
            InitializeComponent();
            taiKhoan = _taiKhoan;
        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            //var taiKhoanList = requestData.GetTaiKhoan(taiKhoan.Token, taiKhoan.MaTaiKhoan);

            nhanVien = requestData.GetNhanVienByMaNhanVien(taiKhoan.Id.ToString());

            txtUserName.Text = taiKhoan.UserName;
            txtId.Text = taiKhoan.Id.ToString();
            txtName.Text = taiKhoan.Identity;
            // gioi tinh;
            if (nhanVien.GioiTinh == true)
            {
                cbNam.Checked = true;
                cbNu.Checked = false;
            }
            else
            {
                cbNam.Checked = false;
                cbNu.Checked = true;
            }
            dtNgaySinh.Value = Convert.ToDateTime(nhanVien.NgaySinh);
            txtDiaChi.Text = nhanVien.DiaChi;
            txtSDT.Text = nhanVien.SDT;
            txtEmail.Text = nhanVien.Email;
            dtNgayBatDau.Value = Convert.ToDateTime(nhanVien.NgayBatDau);
            txtToken.Text = taiKhoan.Token.ToString();

            var bytes = StrToByte(nhanVien.HinhAnh);
            MemoryStream stream = new MemoryStream(bytes);
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
            var _nhanVien = new NhanVienViewModel()
            {
                MaNhanVien = nhanVien.MaNhanVien,
                TenNhanVien = txtName.Text.ToString().Trim(),
                NgaySinh = dtNgaySinh.Value,
                DiaChi = txtDiaChi.Text.ToString(),
                Email = txtEmail.Text.ToString(),
                GioiTinh = true,
                NgayBatDau = dtNgayBatDau.Value,
                SDT = txtSDT.Text.ToString(),
                HinhAnh = nhanVien.HinhAnh
            };

            if (cbNam.Checked == true)
            {
                _nhanVien.GioiTinh = true;
            }
            else
            {
                _nhanVien.GioiTinh = false;
            }

            //var _nhanVienOthen = requestData.GetNhanVienByMaNhanVien(taiKhoan.Id.ToString());
            if (txtMatKhauXacNhan.Text == taiKhoan.PassWord)
            {
                var _taiKhoan = new TaiKhoanViewModel()
                {
                    MaTaiKhoan = taiKhoan.MaTaiKhoan,
                    MaNhanVien = nhanVien.MaNhanVien,
                    MatKhau = txtMatKhauMoi.Text.Trim(),
                    TenNhanVien = taiKhoan.Identity,
                    TenTaiKhoan = taiKhoan.UserName
                };
                var checkNhanVien = requestData.PutNhanVien(_nhanVien);
                var checkTaiKhoan = false;
                if (txtMatKhauMoi.Text != "")
                {
                    checkTaiKhoan = requestData.PutTaiKhoan(_taiKhoan, taiKhoan.Token);
                }
                if (checkNhanVien == true && checkTaiKhoan == true)
                {
                    MessageBox.Show("Done!");
                }
                else
                {
                    MessageBox.Show("!");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác!");
            }
        }

        //test dang ky khach  hang`
        private void button1_Click(object sender, EventArgs e)
        {
            var quyenList = new List<string>();
            quyenList.Add("KhachHang");
            var _taiKhoan = new TaiKhoanKhachHang
            {
                MaKhachHang = -1,
                MaTaiKhoan = -1,
                TenTaiKhoan = txtTenTaiKhoanKhachHang.Text.ToString(),
                TenKhachHang = txtTenTaiKhoanKhachHang.Text.ToString().Trim(),
                NgaySinh = dtNgaySinhKhachHang.Value,
                DiaChi = txtDiaChiKhachHang.Text.ToString(),
                Email = txtDiaChiEmail.Text.ToString(),
                GioiTinh = true,
                SDT = txtSDT.Text.ToString(),
                HinhAnh = null,
                Quyen = quyenList

            };

            if (cbKhachHangNam.Checked == true)
            {
                _taiKhoan.GioiTinh = true;
            }
            else
            {
                _taiKhoan.GioiTinh = false;
            }


            if(dataImgCustomer != "" || dataImgCustomer != null)
            {
                _taiKhoan.HinhAnh = dataImgCustomer;
            }
            requestData.PostTaiKhoan(_taiKhoan);

        }

        private void btnCapNhatAnhKhachHang_Click(object sender, EventArgs e)
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
                        pbKhachHang.ImageLocation = imageLocation;

                        Image image = Image.FromFile(imageLocation);

                        MemoryStream stream = new MemoryStream();
                        image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                        byte[] bPic = stream.ToArray();
                        var sPic = System.Text.Encoding.Default.GetString(bPic);

                        dataImgCustomer = sPic;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("!");
            }
        }
    }
}
