namespace Form_QLTS.GUI
{
    partial class ThemSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTopping = new System.Windows.Forms.DataGridView();
            this.MaTopping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTopping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.MaLuaChon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuaChon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnXoaTopping = new System.Windows.Forms.Button();
            this.btnThemVaoGioHang = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemTopping = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTopping
            // 
            this.dgvTopping.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTopping,
            this.TenTopping,
            this.HinhAnh,
            this.DonGia});
            this.dgvTopping.Location = new System.Drawing.Point(11, 22);
            this.dgvTopping.Name = "dgvTopping";
            this.dgvTopping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopping.Size = new System.Drawing.Size(365, 144);
            this.dgvTopping.TabIndex = 0;
            this.dgvTopping.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopping_CellClick);
            // 
            // MaTopping
            // 
            this.MaTopping.DataPropertyName = "MaTopping";
            this.MaTopping.HeaderText = "Mã topping";
            this.MaTopping.Name = "MaTopping";
            this.MaTopping.Visible = false;
            // 
            // TenTopping
            // 
            this.TenTopping.DataPropertyName = "TenTopping";
            this.TenTopping.HeaderText = "Tên topping";
            this.TenTopping.Name = "TenTopping";
            this.TenTopping.Width = 210;
            // 
            // HinhAnh
            // 
            this.HinhAnh.DataPropertyName = "HinhAnh";
            this.HinhAnh.HeaderText = "Hình ảnh";
            this.HinhAnh.Name = "HinhAnh";
            this.HinhAnh.Visible = false;
            // 
            // DonGia
            // 
            this.DonGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn giá (VND)";
            this.DonGia.Name = "DonGia";
            // 
            // dgvList
            // 
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLuaChon,
            this.LuaChon});
            this.dgvList.Location = new System.Drawing.Point(11, 226);
            this.dgvList.Name = "dgvList";
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(365, 144);
            this.dgvList.TabIndex = 0;
            // 
            // MaLuaChon
            // 
            this.MaLuaChon.HeaderText = "Mã sản phẩm";
            this.MaLuaChon.Name = "MaLuaChon";
            this.MaLuaChon.Visible = false;
            // 
            // LuaChon
            // 
            this.LuaChon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LuaChon.HeaderText = "Tên topping";
            this.LuaChon.Name = "LuaChon";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số lượng cốc:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(11, 438);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(236, 20);
            this.txtSoLuong.TabIndex = 2;
            // 
            // btnXoaTopping
            // 
            this.btnXoaTopping.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaTopping.FlatAppearance.BorderSize = 2;
            this.btnXoaTopping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnXoaTopping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaTopping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTopping.Location = new System.Drawing.Point(11, 376);
            this.btnXoaTopping.Name = "btnXoaTopping";
            this.btnXoaTopping.Size = new System.Drawing.Size(111, 34);
            this.btnXoaTopping.TabIndex = 3;
            this.btnXoaTopping.Text = "Xóa topping -";
            this.btnXoaTopping.UseVisualStyleBackColor = true;
            this.btnXoaTopping.Click += new System.EventHandler(this.btnXoaTopping_Click);
            // 
            // btnThemVaoGioHang
            // 
            this.btnThemVaoGioHang.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThemVaoGioHang.FlatAppearance.BorderSize = 2;
            this.btnThemVaoGioHang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnThemVaoGioHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThemVaoGioHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoGioHang.Location = new System.Drawing.Point(267, 430);
            this.btnThemVaoGioHang.Name = "btnThemVaoGioHang";
            this.btnThemVaoGioHang.Size = new System.Drawing.Size(111, 34);
            this.btnThemVaoGioHang.TabIndex = 3;
            this.btnThemVaoGioHang.Text = "Thêm vào giỏ hàng";
            this.btnThemVaoGioHang.UseVisualStyleBackColor = true;
            this.btnThemVaoGioHang.Click += new System.EventHandler(this.btnThemVaoGioHang_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Danh sách topping";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Topping được lựa chọn";
            // 
            // btnThemTopping
            // 
            this.btnThemTopping.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThemTopping.FlatAppearance.BorderSize = 2;
            this.btnThemTopping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnThemTopping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThemTopping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTopping.Location = new System.Drawing.Point(11, 172);
            this.btnThemTopping.Name = "btnThemTopping";
            this.btnThemTopping.Size = new System.Drawing.Size(111, 35);
            this.btnThemTopping.TabIndex = 4;
            this.btnThemTopping.Text = "Thêm topping +";
            this.btnThemTopping.UseVisualStyleBackColor = true;
            this.btnThemTopping.Click += new System.EventHandler(this.btnThemTopping_Click);
            // 
            // ThemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 469);
            this.Controls.Add(this.btnThemTopping);
            this.Controls.Add(this.btnThemVaoGioHang);
            this.Controls.Add(this.btnXoaTopping);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.dgvTopping);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ThemSanPham";
            this.Text = "ThemSanPham";
            this.Load += new System.EventHandler(this.ThemSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTopping;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnXoaTopping;
        private System.Windows.Forms.Button btnThemVaoGioHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThemTopping;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTopping;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTopping;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLuaChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuaChon;
    }
}