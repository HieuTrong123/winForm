namespace DeTaiNhom_QLNH
{
    partial class frmTaiKhoan
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.txtSoDu = new System.Windows.Forms.TextBox();
            this.txtLaiSuat = new System.Windows.Forms.TextBox();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSTK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(132, 312);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(122, 29);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(292, 312);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(122, 29);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày bắt đầu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã KH:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã loại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số dư:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Lãi suất:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(138, 82);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(548, 22);
            this.txtMaKH.TabIndex = 6;
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Location = new System.Drawing.Point(138, 125);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.ReadOnly = true;
            this.txtMaLoai.Size = new System.Drawing.Size(548, 22);
            this.txtMaLoai.TabIndex = 6;
            // 
            // txtSoDu
            // 
            this.txtSoDu.Location = new System.Drawing.Point(138, 176);
            this.txtSoDu.Name = "txtSoDu";
            this.txtSoDu.Size = new System.Drawing.Size(548, 22);
            this.txtSoDu.TabIndex = 0;
            // 
            // txtLaiSuat
            // 
            this.txtLaiSuat.Location = new System.Drawing.Point(138, 224);
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(548, 22);
            this.txtLaiSuat.TabIndex = 1;
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Enabled = false;
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBD.Location = new System.Drawing.Point(138, 268);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayBD.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Số TK:";
            // 
            // txtSTK
            // 
            this.txtSTK.Location = new System.Drawing.Point(138, 34);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.ReadOnly = true;
            this.txtSTK.Size = new System.Drawing.Size(548, 22);
            this.txtSTK.TabIndex = 6;
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 410);
            this.Controls.Add(this.dtpNgayBD);
            this.Controls.Add(this.txtLaiSuat);
            this.Controls.Add(this.txtSoDu);
            this.Controls.Add(this.txtMaLoai);
            this.Controls.Add(this.txtSTK);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Name = "frmTaiKhoan";
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtMaKH;
        public System.Windows.Forms.TextBox txtMaLoai;
        public System.Windows.Forms.TextBox txtSoDu;
        public System.Windows.Forms.TextBox txtLaiSuat;
        public System.Windows.Forms.DateTimePicker dtpNgayBD;
        public System.Windows.Forms.Button btnThem;
        public System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSTK;
    }
}