using Form_QLTS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_QLTS.GUI
{
    public partial class ThemHoaDon : Form
    {
        #region bien'
        TaiKhoan taiKhoan = new TaiKhoan();

        CallAPI requestData = new CallAPI();

        List<GioHang> gioHangList = new List<GioHang>();

        double khuyenMai;

        List<ToppingViewModel> listTopping = new List<ToppingViewModel>();

        List<SanPhamViewModel> listSanPham = new List<SanPhamViewModel>();



        #endregion

        #region Func
        /// <summary>
        /// lay data tra? nguoc. ve` from them san? pham?
        /// </summary>
        /// <param name="gioHang"></param>
        /// <returns></returns>
        public void GetDataFromChild(GioHang gioHang, List<ToppingViewModel> _listTopping)
        {
            pnlMoTa.Visible = true;

            AddDataDgvGioHang(dgvGioHang, gioHang, dgvGioHang.Rows.Count - 1);

            if (_listTopping != null)
            {
                if (listTopping == null)
                {
                    listTopping = _listTopping;
                }
                else
                {
                    _listTopping.ForEach(v =>
                    {
                        if (!listTopping.Any(n => n.MaTopping == v.MaTopping))
                        {
                            listTopping.Add(v);
                        }
                    });
                }
            }

            int _sumSanPham = 0;
            if (gioHangList != null)
            {
                gioHangList.ForEach(v =>
                {
                    _sumSanPham += v.SoLuong;
                });
            }
            lbSoLuong.Text = _sumSanPham.ToString();

            lbTongTien.Text = TongTien(gioHangList, listSanPham, listTopping).ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")) + " VNĐ";
            lbThanhTien.Text = ThanhTien(TongTien(gioHangList, listSanPham, listTopping), khuyenMai).ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")) + " VNĐ";

            if (listTopping.Count > 0)
                lbTopping.Text = "Topping";
        }

        public double TongTien(List<GioHang> listGioHang, List<SanPhamViewModel> listSanPham, List<ToppingViewModel> listTopping)
        {
            double _tongTien = 0;
            listGioHang.ForEach(v =>
            {
                double _tongTienSanPham = 0;
                _tongTienSanPham += Convert.ToDouble(listSanPham.Single(n => n.MaSanPham == v.MaSanPham).DonGia);

                v.MaTopping.ForEach(n =>
                {
                    _tongTienSanPham += Convert.ToDouble(listTopping.Single(m => m.MaTopping == n).DonGia);
                });

                _tongTien += (_tongTienSanPham * v.SoLuong);

            });

            return _tongTien;
        }

        public double ThanhTien(double tongTien, double _khuyenMai)
        {
            return ((tongTien * (100 - _khuyenMai)) / 100);
        }

        /// <summary>
        /// add du lieu vao bang? gio hang`
        /// </summary>
        /// <param name="_gioHang"></param>
        /// <param name="countRows"></param>
        public void AddDataDgvGioHang(DataGridView dgvGioHang, GioHang _gioHang, int countRows)
        {
            //dgvGioHang.Rows.Clear();
            //dgvGioHang.Refresh();
            if (dgvGioHang.Rows.Count == 0)
            {
                gioHangList.Add(_gioHang);
                dgvGioHang.Rows.Add();
                dgvGioHang.Rows[0].Cells["_MaSanPham"].Value = _gioHang.MaSanPham;
                dgvGioHang.Rows[0].Cells["_TenSanPham"].Value = _gioHang.TenSanPham;
                dgvGioHang.Rows[0].Cells["_SoLuong"].Value = _gioHang.SoLuong;
            }
            else
            {

                gioHangList.Add(_gioHang);
                dgvGioHang.Rows.Add();
                dgvGioHang.Rows[countRows].Cells["_MaSanPham"].Value = _gioHang.MaSanPham;
                dgvGioHang.Rows[countRows].Cells["_TenSanPham"].Value = _gioHang.TenSanPham;
                dgvGioHang.Rows[countRows].Cells["_SoLuong"].Value = _gioHang.SoLuong;
            }
        }

        /// <summary>
        /// add du lieu. vao bang? topping
        /// </summary>
        /// <param name="_topping"></param>
        /// <param name="countRows"></param>
        public void AddDataDgvTopping(ToppingViewModel _topping, int countRows)
        {
            if (dgvTopping.Rows.Count == 0)
            {
                dgvTopping.Rows.Add();
                dgvTopping.Rows[0].Cells["MaTopping"].Value = _topping.MaTopping;
                dgvTopping.Rows[0].Cells["TenTopping"].Value = _topping.TenTopping;

            }
            else
            {
                dgvTopping.Rows.Add();
                dgvTopping.Rows[countRows].Cells["MaTopping"].Value = _topping.MaTopping;
                dgvTopping.Rows[countRows].Cells["TenTopping"].Value = _topping.TenTopping;
            }

        }

        #endregion


        public ThemHoaDon(TaiKhoan _taiKhoan, double _khuyenMai)
        {
            InitializeComponent();
            taiKhoan = _taiKhoan;
            khuyenMai = _khuyenMai;
        }


        private void ThemHoaDon_Load(object sender, EventArgs e)
        {
            //hide bang? mota 
            pnlMoTa.Visible = false;

            listSanPham = requestData.GetListSanPham();

            //lbkhuyenmai
            lbKhuyenMai.Text = khuyenMai.ToString() + " %";
            lbTongTien.Text = "0 VNĐ";
            lbThanhTien.Text = "0 VNĐ";

            // do? du~ lieu. vao` combobox
            var chuDeList = requestData.GetListChuDe().ToList();
            Dictionary<int, string> data = new Dictionary<int, string>();
            chuDeList.ForEach(v =>
            {
                data.Add(v.MaChuDe, v.TenChuDe);
            });
            cbChuDe.DataSource = new BindingSource(data, null);
            cbChuDe.DisplayMember = "Value";
            cbChuDe.ValueMember = "Key";

            // do? du~ lieu. vao data grid view
            dgvSanPham.DataSource = requestData.GetListSanPhamByMaChuDe(chuDeList.First().MaChuDe);

            //place holder
            txtSearch.Text = "Tìm kiếm...";

            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("haha");
            if (dgvTopping.Rows.Count > 0)
                dgvTopping.Rows.Clear();
            // duyet. trong list gio? hang` de? lay ra list ma~ topping
            gioHangList.ForEach(v =>
            {
                if (v.MaSanPham == Convert.ToInt32(dgvGioHang.CurrentRow.Cells["_MaSanPham"].Value))
                {
                    v.MaTopping.ForEach(maToppingItem =>
                    {
                        var _tmp = listTopping.SingleOrDefault(n => n.MaTopping == maToppingItem);
                        if (_tmp != null)
                        {
                            AddDataDgvTopping(_tmp, dgvTopping.Rows.Count - 1);
                        }
                    });
                }
            });
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            var idSanPham = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString());
            var tenSanPham = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
            using (ThemSanPham themSanPham = new ThemSanPham(idSanPham, tenSanPham))
            {
                themSanPham.ShowDialog(this);
            }
        }

        private void cbChuDe_Click(object sender, EventArgs e)
        {

        }

        private void cbChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<int, string> selectedEntry = (KeyValuePair<int, string>)cbChuDe.SelectedItem;
            int temp = selectedEntry.Key;

            dgvSanPham.DataSource = requestData.GetListSanPhamByMaChuDe(temp);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<DataGridViewRow> tmp = new List<DataGridViewRow>();
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (txtSearch.Text != "")
            {
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (txtSearch.Text.ToString().Equals(row.Cells["TenSanPham"].Value))
                    {
                        dgvSanPham.CurrentCell = dgvSanPham.Rows[row.Index].Cells["TenSanPham"];
                    }
                }
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("dddd dd/MM/yyyy hh:mm:ss");
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show(dgvGioHang.CurrentRow.Cells["_MaSanPham"].Value.ToString());
            // duyet. trong list gio? hang` de? lay ra list ma~ topping

        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (gioHangList.Count > 0)
            {
                var luaChonList = new List<LuaChonViewModel>();
                gioHangList.ForEach(v =>
                {
                    if (v.MaTopping.Count == 1)
                    {
                        luaChonList.Add(new LuaChonViewModel(-1, v.MaSanPham, v.MaTopping.Last()));
                    }
                    else
                    {
                        v.MaTopping.ForEach(n =>
                        {
                            luaChonList.Add(new LuaChonViewModel(-1, v.MaSanPham, n));
                        });
                    }


                });

                // ma lua chon.
                var listId = requestData.PostLuaChon(luaChonList).ToList();

                // call ham get lua chon tu` server de? lay' du lieu. loc theo ma lua chon.
                var _luaChonList = requestData.GetListLuaChon();

                var luaChonListItem = new List<LuaChonViewModel>();

                listId.ForEach(v =>
                {
                    luaChonListItem.AddRange(_luaChonList.Where(n => n.MaLuaChon == v));
                });



                if (listId != null)
                {
                    //tao dictionary luu thong tin lua. chon
                    var thongTinLuaChonList = new Dictionary<int, int>();

                    // so sanh voi gio hang de lay thong tin cua san pham de? them vao` hoa' don
                    gioHangList.ForEach(v =>
                    {
                        listId.ForEach(n =>
                        {
                            if (luaChonListItem.Where(m => m.MaLuaChon == n && m.MaSanPham == v.MaSanPham).Count() == v.MaTopping.Count())
                            {
                                thongTinLuaChonList.Add(n, v.SoLuong);
                            }
                        });

                    });

                    // tao bien thong tin hoa don de? thao tac ham` them vao hoa don 
                    ThongTinHoaDon thongTinHoaDon = new ThongTinHoaDon(thongTinLuaChonList, taiKhoan.Id, DateTime.Now, txtMoTa.Text);
                    bool check = requestData.PostHoaDon(thongTinHoaDon);

                    if (check == true)
                    {
                        MessageBox.Show("Tạo hóa đơn thành công!", "OK!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gioHangList.Clear();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Tạo hóa đơn thất bại!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gioHangList.Clear();
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Thêm lựa chọn thất bại!");
                }

                //listId.ForEach(v =>
                //{
                //    MessageBox.Show(v.ToString());

                //});





            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm để tạo hóa đơn!", "EEROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow.Cells["_MaSanPham"].Value != null || (dgvGioHang.Rows.Count - 1) == 0)
            {
                var _idSanPham = Convert.ToInt32(dgvGioHang.CurrentRow.Cells["_MaSanPham"].Value.ToString());
                GioHang _index = new GioHang();
                gioHangList.ForEach(v =>
                {
                    if (v.MaSanPham == _idSanPham)
                    {
                        _index = v;
                    }
                });

                gioHangList.Remove(_index);

                //int numRows = dgvGioHang.Rows.Count;
                foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                {
                    dgvGioHang.Rows.RemoveAt(row.Index);
                }
                dgvGioHang.Refresh();
            }
            else
            {
                MessageBox.Show("Không có sản phẩm!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTopping_Click(object sender, EventArgs e)
        {
            if ((dgvTopping.CurrentRow.Cells["MaTopping"].Value != null))
            {
                // lay ra ma~ san pham? can` xoas
                var _idSanPham = Convert.ToInt32(dgvGioHang.CurrentRow.Cells["_MaSanPham"].Value.ToString());
                // lay ra ma~ topping can` xoas
                var _idTopping = Convert.ToInt32(dgvTopping.CurrentRow.Cells["MaTopping"].Value.ToString());

                // bien lua gia tri can` xoas'
                int _index = -1;
                // duyet trong list gio? hang` de? xoa'
                gioHangList.ForEach(v =>
                {
                    // lay ra coc' co topping can` xoas'
                    if (v.MaSanPham == _idSanPham)
                    {
                        v.MaTopping.ForEach(n =>
                        {
                            // lay topping day' roi` xoa'
                            if (n == _idTopping)
                            {
                                _index = n;
                            }
                        });
                    }

                    if (_index != -1)
                    {
                        v.MaTopping.Remove(_index);

                        foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                        {
                            dgvGioHang.Rows.RemoveAt(row.Index);
                        }
                        dgvGioHang.Refresh();
                    }
                });
            }
            else
            {
                MessageBox.Show("Không có topping", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
