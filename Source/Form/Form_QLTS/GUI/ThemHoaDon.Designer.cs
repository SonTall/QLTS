﻿namespace Form_QLTS.GUI
{
    partial class ThemHoaDon
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
            this.components = new System.ComponentModel.Container();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlMoTa = new System.Windows.Forms.Panel();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnXoaTopping = new System.Windows.Forms.Button();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.btnXoaSanPham = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbThanhTien = new System.Windows.Forms.Label();
            this.lbKhuyenMai = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbChuDe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSanPham = new System.Windows.Forms.Label();
            this.lbTopping = new System.Windows.Forms.Label();
            this.dgvTopping = new System.Windows.Forms.DataGridView();
            this.MaTopping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTopping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this._MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.MaChuDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KichCo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.pnlMoTa.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pnlMoTa);
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Controls.Add(this.btnXoaTopping);
            this.panel4.Controls.Add(this.btnThemSanPham);
            this.panel4.Controls.Add(this.btnXoaSanPham);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.cbChuDe);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lbSanPham);
            this.panel4.Controls.Add(this.lbTopping);
            this.panel4.Controls.Add(this.dgvTopping);
            this.panel4.Controls.Add(this.dgvGioHang);
            this.panel4.Controls.Add(this.dgvSanPham);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(838, 510);
            this.panel4.TabIndex = 19;
            // 
            // pnlMoTa
            // 
            this.pnlMoTa.Controls.Add(this.txtMoTa);
            this.pnlMoTa.Controls.Add(this.label5);
            this.pnlMoTa.Location = new System.Drawing.Point(643, 335);
            this.pnlMoTa.Name = "pnlMoTa";
            this.pnlMoTa.Size = new System.Drawing.Size(187, 120);
            this.pnlMoTa.TabIndex = 18;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(6, 25);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(176, 92);
            this.txtMoTa.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mô tả:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(307, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(326, 22);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnXoaTopping
            // 
            this.btnXoaTopping.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaTopping.FlatAppearance.BorderSize = 3;
            this.btnXoaTopping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnXoaTopping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaTopping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTopping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTopping.Location = new System.Drawing.Point(383, 463);
            this.btnXoaTopping.Name = "btnXoaTopping";
            this.btnXoaTopping.Size = new System.Drawing.Size(168, 35);
            this.btnXoaTopping.TabIndex = 16;
            this.btnXoaTopping.Text = "Xóa topping -";
            this.btnXoaTopping.UseVisualStyleBackColor = true;
            this.btnXoaTopping.Click += new System.EventHandler(this.btnXoaTopping_Click);
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnThemSanPham.FlatAppearance.BorderSize = 3;
            this.btnThemSanPham.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThemSanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnThemSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSanPham.Location = new System.Drawing.Point(12, 205);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(168, 37);
            this.btnThemSanPham.TabIndex = 16;
            this.btnThemSanPham.Text = "Thêm sản phẩm +";
            this.btnThemSanPham.UseVisualStyleBackColor = true;
            this.btnThemSanPham.Click += new System.EventHandler(this.btnThemSanPham_Click);
            // 
            // btnXoaSanPham
            // 
            this.btnXoaSanPham.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaSanPham.FlatAppearance.BorderSize = 3;
            this.btnXoaSanPham.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnXoaSanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSanPham.Location = new System.Drawing.Point(12, 462);
            this.btnXoaSanPham.Name = "btnXoaSanPham";
            this.btnXoaSanPham.Size = new System.Drawing.Size(168, 35);
            this.btnXoaSanPham.TabIndex = 16;
            this.btnXoaSanPham.Text = "Xóa sản phẩm -";
            this.btnXoaSanPham.UseVisualStyleBackColor = true;
            this.btnXoaSanPham.Click += new System.EventHandler(this.btnXoaSanPham_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.btnInHoaDon);
            this.panel6.Controls.Add(this.btnThemHoaDon);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.lbDate);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.lbThanhTien);
            this.panel6.Controls.Add(this.lbKhuyenMai);
            this.panel6.Controls.Add(this.lbTongTien);
            this.panel6.Controls.Add(this.lbSoLuong);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(643, 13);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(187, 316);
            this.panel6.TabIndex = 15;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnInHoaDon.FlatAppearance.BorderSize = 3;
            this.btnInHoaDon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnInHoaDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHoaDon.Location = new System.Drawing.Point(7, 241);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(149, 35);
            this.btnInHoaDon.TabIndex = 16;
            this.btnInHoaDon.Text = "In hóa đơn ";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnThemHoaDon.FlatAppearance.BorderSize = 3;
            this.btnThemHoaDon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThemHoaDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnThemHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHoaDon.Location = new System.Drawing.Point(7, 198);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(149, 37);
            this.btnThemHoaDon.TabIndex = 16;
            this.btnThemHoaDon.Text = "Tạo hóa đơn +";
            this.btnThemHoaDon.UseVisualStyleBackColor = true;
            this.btnThemHoaDon.Click += new System.EventHandler(this.btnThemHoaDon_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 36);
            this.label8.TabIndex = 12;
            this.label8.Text = "Thành \r\ntiền:";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(12, 294);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(35, 15);
            this.lbDate.TabIndex = 12;
            this.lbDate.Text = "Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 34);
            this.label6.TabIndex = 12;
            this.label6.Text = "Khuyến \r\nmãi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tổng tiền:";
            // 
            // lbThanhTien
            // 
            this.lbThanhTien.AutoSize = true;
            this.lbThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanhTien.Location = new System.Drawing.Point(74, 144);
            this.lbThanhTien.Name = "lbThanhTien";
            this.lbThanhTien.Size = new System.Drawing.Size(15, 16);
            this.lbThanhTien.TabIndex = 12;
            this.lbThanhTien.Text = "0";
            // 
            // lbKhuyenMai
            // 
            this.lbKhuyenMai.AutoSize = true;
            this.lbKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKhuyenMai.Location = new System.Drawing.Point(74, 85);
            this.lbKhuyenMai.Name = "lbKhuyenMai";
            this.lbKhuyenMai.Size = new System.Drawing.Size(15, 16);
            this.lbKhuyenMai.TabIndex = 12;
            this.lbKhuyenMai.Text = "0";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(74, 48);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(15, 16);
            this.lbTongTien.TabIndex = 12;
            this.lbTongTien.Text = "0";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.Location = new System.Drawing.Point(74, 13);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(15, 16);
            this.lbSoLuong.TabIndex = 12;
            this.lbSoLuong.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Số lượng:";
            // 
            // cbChuDe
            // 
            this.cbChuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChuDe.FormattingEnabled = true;
            this.cbChuDe.Location = new System.Drawing.Point(12, 13);
            this.cbChuDe.Name = "cbChuDe";
            this.cbChuDe.Size = new System.Drawing.Size(204, 24);
            this.cbChuDe.TabIndex = 14;
            this.cbChuDe.SelectedIndexChanged += new System.EventHandler(this.cbChuDe_SelectedIndexChanged);
            this.cbChuDe.Click += new System.EventHandler(this.cbChuDe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tìm kiếm:";
            // 
            // lbSanPham
            // 
            this.lbSanPham.AutoSize = true;
            this.lbSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSanPham.Location = new System.Drawing.Point(9, 254);
            this.lbSanPham.Name = "lbSanPham";
            this.lbSanPham.Size = new System.Drawing.Size(65, 16);
            this.lbSanPham.TabIndex = 12;
            this.lbSanPham.Text = "Giỏ hàng:";
            // 
            // lbTopping
            // 
            this.lbTopping.AutoSize = true;
            this.lbTopping.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTopping.Location = new System.Drawing.Point(380, 245);
            this.lbTopping.Name = "lbTopping";
            this.lbTopping.Size = new System.Drawing.Size(211, 16);
            this.lbTopping.TabIndex = 12;
            this.lbTopping.Text = "Topping (không lựa chọn topping):";
            // 
            // dgvTopping
            // 
            this.dgvTopping.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTopping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTopping,
            this.TenTopping});
            this.dgvTopping.Location = new System.Drawing.Point(383, 274);
            this.dgvTopping.Name = "dgvTopping";
            this.dgvTopping.Size = new System.Drawing.Size(250, 181);
            this.dgvTopping.TabIndex = 11;
            // 
            // MaTopping
            // 
            this.MaTopping.HeaderText = "Matopping";
            this.MaTopping.Name = "MaTopping";
            this.MaTopping.Visible = false;
            // 
            // TenTopping
            // 
            this.TenTopping.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenTopping.HeaderText = "Tên topping";
            this.TenTopping.Name = "TenTopping";
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._MaSanPham,
            this._TenSanPham,
            this._SoLuong});
            this.dgvGioHang.Location = new System.Drawing.Point(12, 274);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(365, 181);
            this.dgvGioHang.TabIndex = 11;
            this.dgvGioHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellClick);
            this.dgvGioHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellContentClick);
            // 
            // _MaSanPham
            // 
            this._MaSanPham.HeaderText = "Mã sản phẩm";
            this._MaSanPham.Name = "_MaSanPham";
            this._MaSanPham.ReadOnly = true;
            this._MaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._MaSanPham.Visible = false;
            this._MaSanPham.Width = 20;
            // 
            // _TenSanPham
            // 
            this._TenSanPham.HeaderText = "Sản phẩm";
            this._TenSanPham.Name = "_TenSanPham";
            this._TenSanPham.ReadOnly = true;
            this._TenSanPham.Width = 215;
            // 
            // _SoLuong
            // 
            this._SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._SoLuong.HeaderText = "Số lượng";
            this._SoLuong.Name = "_SoLuong";
            this._SoLuong.ReadOnly = true;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChuDe,
            this.MaSanPham,
            this.TenSanPham,
            this.KichCo,
            this.HinhAnh,
            this.DonGia});
            this.dgvSanPham.Location = new System.Drawing.Point(12, 61);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(621, 138);
            this.dgvSanPham.TabIndex = 11;
            this.dgvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellContentClick);
            // 
            // MaChuDe
            // 
            this.MaChuDe.DataPropertyName = "MaChuDe";
            this.MaChuDe.HeaderText = "Mã chủ đề";
            this.MaChuDe.Name = "MaChuDe";
            this.MaChuDe.Visible = false;
            this.MaChuDe.Width = 70;
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã sản phẩm";
            this.MaSanPham.Name = "MaSanPham";
            // 
            // TenSanPham
            // 
            this.TenSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 215;
            // 
            // KichCo
            // 
            this.KichCo.DataPropertyName = "KichCo";
            this.KichCo.HeaderText = "Kích cỡ";
            this.KichCo.Name = "KichCo";
            this.KichCo.Width = 110;
            // 
            // HinhAnh
            // 
            this.HinhAnh.DataPropertyName = "HinhAnh";
            this.HinhAnh.HeaderText = "Hình ảnh";
            this.HinhAnh.Name = "HinhAnh";
            this.HinhAnh.Visible = false;
            this.HinhAnh.Width = 5;
            // 
            // DonGia
            // 
            this.DonGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.Name = "DonGia";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "___________________________";
            // 
            // ThemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 510);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ThemHoaDon";
            this.Text = "ThemHoaDon";
            this.Load += new System.EventHandler(this.ThemHoaDon_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlMoTa.ResumeLayout(false);
            this.pnlMoTa.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbThanhTien;
        private System.Windows.Forms.Label lbKhuyenMai;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbChuDe;
        private System.Windows.Forms.Label lbTopping;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTopping;
        private System.Windows.Forms.Label lbSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChuDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn KichCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.Button btnXoaSanPham;
        private System.Windows.Forms.Button btnXoaTopping;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemHoaDon;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn _SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTopping;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTopping;
        private System.Windows.Forms.Panel pnlMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label7;
    }
}