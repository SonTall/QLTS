﻿namespace Form_QLTS.GUI
{
    partial class Home1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home1));
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MoTaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhuyenMai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MaKhuyenMai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbSoHoaDon = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbLuaChon = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSoTopping = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSoSanPham = new System.Windows.Forms.Label();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNgay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnThemHoaDon.FlatAppearance.BorderSize = 3;
            this.btnThemHoaDon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThemHoaDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnThemHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHoaDon.Location = new System.Drawing.Point(39, 178);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(210, 43);
            this.btnThemHoaDon.TabIndex = 30;
            this.btnThemHoaDon.Text = "Tạo hóa đơn +";
            this.btnThemHoaDon.UseVisualStyleBackColor = true;
            // 
            // NgayTao
            // 
            this.NgayTao.DataPropertyName = "NgayTao";
            this.NgayTao.HeaderText = "Ngày tạo hóa đơn";
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Width = 105;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 73;
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.DataPropertyName = "MaKhachHang";
            this.MaKhachHang.HeaderText = "MaKhachHang";
            this.MaKhachHang.Name = "MaKhachHang";
            this.MaKhachHang.Visible = false;
            this.MaKhachHang.Width = 5;
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.DataPropertyName = "MaHoaDon";
            this.MaHoaDon.HeaderText = "Mã hóa đơn";
            this.MaHoaDon.Name = "MaHoaDon";
            this.MaHoaDon.Width = 68;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHoaDon,
            this.MaKhachHang,
            this.MaNhanVien,
            this.NgayTao,
            this.MoTaHoaDon});
            this.dgvHoaDon.Location = new System.Drawing.Point(540, 263);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(455, 289);
            this.dgvHoaDon.TabIndex = 26;
            // 
            // MoTaHoaDon
            // 
            this.MoTaHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MoTaHoaDon.DataPropertyName = "MoTa";
            this.MoTaHoaDon.HeaderText = "Mô tả";
            this.MoTaHoaDon.Name = "MoTaHoaDon";
            // 
            // NgayKetThuc
            // 
            this.NgayKetThuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayKetThuc.DataPropertyName = "NgayKetThuc";
            this.NgayKetThuc.HeaderText = "Ngày kết thúc";
            this.NgayKetThuc.Name = "NgayKetThuc";
            // 
            // NgayBatDau
            // 
            this.NgayBatDau.DataPropertyName = "NgayBatDau";
            this.NgayBatDau.HeaderText = "Ngày bắt đầu";
            this.NgayBatDau.Name = "NgayBatDau";
            this.NgayBatDau.Width = 90;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.Name = "MoTa";
            this.MoTa.Width = 92;
            // 
            // GiaTri
            // 
            this.GiaTri.DataPropertyName = "GiaTri";
            this.GiaTri.HeaderText = "Giá trị(%)";
            this.GiaTri.Name = "GiaTri";
            this.GiaTri.Width = 40;
            // 
            // TenKhuyenMai
            // 
            this.TenKhuyenMai.DataPropertyName = "TenKhuyenMai";
            this.TenKhuyenMai.HeaderText = "Tên khuyến mãi";
            this.TenKhuyenMai.Name = "TenKhuyenMai";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(82, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(66, 67);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tổng số hóa đơn đã\r\n bán trong ngày hôm nay\r\n";
            // 
            // MaKhuyenMai
            // 
            this.MaKhuyenMai.DataPropertyName = "MaKhuyenMai";
            this.MaKhuyenMai.HeaderText = "Mã khuyến mãi";
            this.MaKhuyenMai.Name = "MaKhuyenMai";
            this.MaKhuyenMai.Visible = false;
            this.MaKhuyenMai.Width = 5;
            // 
            // lbSoHoaDon
            // 
            this.lbSoHoaDon.AutoSize = true;
            this.lbSoHoaDon.Font = new System.Drawing.Font("Century Gothic", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoHoaDon.Location = new System.Drawing.Point(17, 13);
            this.lbSoHoaDon.Name = "lbSoHoaDon";
            this.lbSoHoaDon.Size = new System.Drawing.Size(48, 55);
            this.lbSoHoaDon.TabIndex = 0;
            this.lbSoHoaDon.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbSoHoaDon);
            this.panel3.Location = new System.Drawing.Point(39, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 124);
            this.panel3.TabIndex = 25;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(112, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(66, 67);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 26);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tổng số lựa chọn\r\nđang có";
            // 
            // lbLuaChon
            // 
            this.lbLuaChon.AutoSize = true;
            this.lbLuaChon.Font = new System.Drawing.Font("Century Gothic", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLuaChon.Location = new System.Drawing.Point(13, 12);
            this.lbLuaChon.Name = "lbLuaChon";
            this.lbLuaChon.Size = new System.Drawing.Size(48, 55);
            this.lbLuaChon.TabIndex = 2;
            this.lbLuaChon.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lbLuaChon);
            this.panel2.Location = new System.Drawing.Point(810, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 123);
            this.panel2.TabIndex = 24;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(112, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 67);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tổng số topping\r\nđang có\r\n";
            // 
            // lbSoTopping
            // 
            this.lbSoTopping.AutoSize = true;
            this.lbSoTopping.Font = new System.Drawing.Font("Century Gothic", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoTopping.Location = new System.Drawing.Point(13, 11);
            this.lbSoTopping.Name = "lbSoTopping";
            this.lbSoTopping.Size = new System.Drawing.Size(48, 55);
            this.lbSoTopping.TabIndex = 2;
            this.lbSoTopping.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbSoTopping);
            this.panel1.Location = new System.Drawing.Point(557, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 123);
            this.panel1.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(121, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 65);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng số sản phẩm \r\nđang có\r\n";
            // 
            // lbSoSanPham
            // 
            this.lbSoSanPham.AutoSize = true;
            this.lbSoSanPham.Font = new System.Drawing.Font("Century Gothic", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoSanPham.Location = new System.Drawing.Point(20, 14);
            this.lbSoSanPham.Name = "lbSoSanPham";
            this.lbSoSanPham.Size = new System.Drawing.Size(48, 55);
            this.lbSoSanPham.TabIndex = 2;
            this.lbSoSanPham.Text = "0";
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhuyenMai,
            this.TenKhuyenMai,
            this.GiaTri,
            this.MoTa,
            this.NgayBatDau,
            this.NgayKetThuc});
            this.dgvKhuyenMai.Location = new System.Drawing.Point(39, 263);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(455, 289);
            this.dgvKhuyenMai.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(130)))), ((int)(((byte)(19)))));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.lbSoSanPham);
            this.panel5.Location = new System.Drawing.Point(291, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(185, 126);
            this.panel5.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Khuyến mãi đang được áp dụng";
            // 
            // lbNgay
            // 
            this.lbNgay.AutoSize = true;
            this.lbNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay.Location = new System.Drawing.Point(537, 240);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(193, 18);
            this.lbNgay.TabIndex = 31;
            this.lbNgay.Text = "Hóa đơn đã bán được ngày: ";
            // 
            // Home1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 578);
            this.Controls.Add(this.lbNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThemHoaDon);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home1";
            this.Text = "Home1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThemHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhuyenMai;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhuyenMai;
        private System.Windows.Forms.Label lbSoHoaDon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbLuaChon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSoTopping;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSoSanPham;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNgay;
    }
}