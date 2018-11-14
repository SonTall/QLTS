using Form_QLTS.ViewModel;
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
    public partial class ThemSanPham : Form
    {
        #region khai bao bien'
        CallAPI requestData = new CallAPI();
        // tao. 1 list topping de luu vao` gio? hang`
        GioHang gioHang = new GioHang();
        // bien' dem' kiem soat' khi lua. chon topping bi. trung`
        int rowCount = 0;
        // tao list luu danh sach topping
        List<ToppingViewModel> toppingList;
        #endregion

        public ThemSanPham(int maSanPham, string tenSanPham)
        {
            InitializeComponent();
            //khoi tao. coc' dung` ma san pham lay tu form cha
            gioHang.MaSanPham = maSanPham;
            gioHang.TenSanPham = tenSanPham;
            this.Text = "Tên sản phẩm: " + tenSanPham.ToString();
        }

        private void ThemSanPham_Load(object sender, EventArgs e)
        {
            toppingList = requestData.GetListTopping();
            dgvTopping.DataSource = toppingList;
        }

        private void dgvTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        /// <summary>
        ///them topping nay` vao coc'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTopping_Click(object sender, EventArgs e)
        {
            int cell;
            cell = dgvTopping.CurrentCell.ColumnIndex;
            var idStr = dgvTopping.CurrentRow.Cells[0].Value.ToString();
            var valueStr = dgvTopping.CurrentRow.Cells[1].Value.ToString();

            int checkValue = 1;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (valueStr.Equals(row.Cells["LuaChon"].Value))
                {
                    checkValue = 0;
                }
            }
            if (checkValue == 1)
            {
                //row = dgvTopping.CurrentRow.Index;
                dgvList.Rows.Add();
                dgvList.Rows[rowCount].Cells["MaLuaChon"].Value = idStr;
                dgvList.Rows[rowCount].Cells["LuaChon"].Value = valueStr;

                // focus vao dong` cuoi' cung` cua? datagridview
                dgvList.CurrentCell = dgvList.Rows[rowCount].Cells["LuaChon"];

                // bien dong` +1 de? add dong` moi'
                rowCount++;

                // them topping duoc chon vao gio? hang`
                gioHang.ThemTopping(Convert.ToInt32(dgvTopping.CurrentRow.Cells["MaTopping"].Value.ToString()));
            }
            else
            {
                MessageBox.Show("Topping này đã được chọn!");
            }
        }

        /// <summary>
        /// them coc nay` vao hoa' don
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Nhập số lượng sản phẩm!");
            }
            else
            {
                if (Convert.ToInt32(txtSoLuong.Text.ToString()) < 0)
                {
                    MessageBox.Show("Số lượng > 0!");
                }
                else
                {
                    gioHang.SoLuong = Convert.ToInt32(txtSoLuong.Text.ToString());

                    // gui lai giu lieu ve form cha
                    ThemHoaDon parent = (ThemHoaDon)this.Owner;

                    // list topping
                    Dictionary<int, string> pairs = null;

                    if (gioHang.MaTopping != null)
                    {
                        pairs = new Dictionary<int, string>();
                        //add ten va ma topping vao Dictionary
                        gioHang.MaTopping.ForEach(v =>
                        {
                            pairs.Add(v, toppingList.Find(n => n.MaTopping == v).TenTopping);
                        });

                        //gui du~ lieu.
                        parent.GetDataFromChild(gioHang, pairs);
                        parent.GetListTopping(pairs);

                    }
                    this.Close();
                }
            }
        }

        /// <summary>
        ///  xoa topping nay` khoi? coc'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTopping_Click(object sender, EventArgs e)
        {
            if (rowCount > 0)
            {
                gioHang.XoaTopping(Convert.ToInt32(dgvList.CurrentRow.Cells["MaLuaChon"].Value.ToString()));
                dgvList.Rows.RemoveAt(dgvList.CurrentRow.Index);
                rowCount--;
            }
            else
            {
                MessageBox.Show("Chưa lựa chọn topping!");
            }
        }
    }
}
