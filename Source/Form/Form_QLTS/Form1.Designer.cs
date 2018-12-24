namespace Form_QLTS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.lbUserName = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlLeft.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pnlLeft.Controls.Add(this.btnThongTin);
            this.pnlLeft.Controls.Add(this.btnSanPham);
            this.pnlLeft.Controls.Add(this.btnHoaDon);
            this.pnlLeft.Controls.Add(this.btnTrangChu);
            this.pnlLeft.Controls.Add(this.lbUserName);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(119, 650);
            this.pnlLeft.TabIndex = 0;
            // 
            // btnThongTin
            // 
            this.btnThongTin.FlatAppearance.BorderSize = 0;
            this.btnThongTin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnThongTin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTin.ForeColor = System.Drawing.SystemColors.Control;
            this.btnThongTin.Image = ((System.Drawing.Image)(resources.GetObject("btnThongTin.Image")));
            this.btnThongTin.Location = new System.Drawing.Point(10, 440);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(103, 104);
            this.btnThongTin.TabIndex = 4;
            this.btnThongTin.Text = "Thông tin tài khoản";
            this.btnThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThongTin.UseVisualStyleBackColor = true;
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSanPham.Image = ((System.Drawing.Image)(resources.GetObject("btnSanPham.Image")));
            this.btnSanPham.Location = new System.Drawing.Point(10, 322);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(103, 96);
            this.btnSanPham.TabIndex = 4;
            this.btnSanPham.Text = "Thực đơn";
            this.btnSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnHoaDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnHoaDon.Image")));
            this.btnHoaDon.Location = new System.Drawing.Point(10, 204);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(103, 96);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTrangChu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTrangChu.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.Image")));
            this.btnTrangChu.Location = new System.Drawing.Point(10, 86);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(103, 96);
            this.btnTrangChu.TabIndex = 4;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbUserName.Location = new System.Drawing.Point(7, 7);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(46, 18);
            this.lbUserName.TabIndex = 3;
            this.lbUserName.Text = "label1";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Silver;
            this.pnlTop.Controls.Add(this.button4);
            this.pnlTop.Controls.Add(this.button3);
            this.pnlTop.Controls.Add(this.button2);
            this.pnlTop.Controls.Add(this.button1);
            this.pnlTop.Controls.Add(this.btnExit);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(119, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1031, 72);
            this.pnlTop.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(869, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 24);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(824, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 24);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(898, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 24);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(933, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 24);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(990, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 24);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(119, 72);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1031, 578);
            this.pnlBody.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBody;
        //private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private System.Windows.Forms.Label lbUserName;
       // private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton3;
       // private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
       // private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
      //  private Bunifu.Framework.UI.BunifuImageButton btn;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnThongTin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        //  private BunifuAnimatorNS.DoubleBitmapControl doubleBitmapControl1;
    }
}

