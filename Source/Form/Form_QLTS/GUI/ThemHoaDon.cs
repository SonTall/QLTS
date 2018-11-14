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
    public partial class ThemHoaDon : Form
    {
        #region bien'
        //public delegate void GetTenToppingDelegate(List<int> maTopping);
        CallAPI requestData = new CallAPI();
        List<GioHang> gioHangList = new List<GioHang>();
        //kiem soat row cua dgvGioHang`
        int countRows = 0;

        Dictionary<int, string> toppingList = new Dictionary<int, string>();
        #endregion

        /// <summary>
        /// lay data tra? nguoc. ve` from them san? pham?
        /// </summary>
        /// <param name="gioHang"></param>
        /// <returns></returns>
        public void GetDataFromChild(GioHang gioHang, Dictionary<int, string> toppingList)
        {
            if (gioHang != null)
            {
                gioHangList.Add(gioHang);
                dgvGioHang.Rows.Add();
                dgvGioHang.Rows[countRows].Cells["_MaSanPham"].Value = gioHang.MaSanPham;
                dgvGioHang.Rows[countRows].Cells["_TenSanPham"].Value = gioHang.TenSanPham;
                dgvGioHang.Rows[countRows].Cells["_SoLuong"].Value = gioHang.SoLuong;
                countRows++;
            }

        }

        public void GetListTopping(Dictionary<int, string> toppingListBack)
        {
            toppingList = toppingListBack;
        }

        public ThemHoaDon()
        {
            InitializeComponent();
        }

        private void ThemHoaDon_Load(object sender, EventArgs e)
        {
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
            MessageBox.Show("haha");
            if (dgvTopping.Rows.Count > 0)
                dgvTopping.Rows.Clear();
            // duyet. trong list gio? hang` de? lay ra list ma~ topping
            gioHangList.ForEach(v =>
            {
                if (v.MaSanPham == Convert.ToInt32(dgvGioHang.CurrentRow.Cells["_MaSanPham"].Value))
                {

                    int countRowsTopping = 0;
                    // duyet trong list ma~ topping de? them tung` ten topping vao` bang? topping
                    v.MaTopping.ForEach(maToppingItem =>
                    {
                        //var tmp = toppingList.f(n => n.Key == maToppingItem);
                        foreach (var item in toppingList)
                        {
                            if (maToppingItem == item.Key)
                            {
                                dgvTopping.Rows.Add();
                                dgvTopping.Rows[countRowsTopping].Cells["TenTopping"].Value = item.Value.ToString();
                                countRowsTopping++;
                                break;
                            }
                        }
                        //dgvTopping.Rows.Add();
                        //dgvTopping.Rows[countRowsTopping].Cells["TenTopping"].Value = tmp.Value.ToString();
                        //countRowsTopping++;
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
    }
}
