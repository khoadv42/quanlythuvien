namespace BaiTapLonQuanLySachThuVien
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.grDangNhap = new System.Windows.Forms.GroupBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MatKhau = new System.Windows.Forms.TextBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.grDangNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // grDangNhap
            // 
            this.grDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.grDangNhap.BackColor = System.Drawing.SystemColors.HotTrack;
            this.grDangNhap.Controls.Add(this.btnDangNhap);
            this.grDangNhap.Controls.Add(this.label2);
            this.grDangNhap.Controls.Add(this.MatKhau);
            this.grDangNhap.Controls.Add(this.lblTaiKhoan);
            this.grDangNhap.Controls.Add(this.txtTaiKhoan);
            this.grDangNhap.Location = new System.Drawing.Point(171, 226);
            this.grDangNhap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grDangNhap.Name = "grDangNhap";
            this.grDangNhap.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grDangNhap.Size = new System.Drawing.Size(433, 176);
            this.grDangNhap.TabIndex = 1;
            this.grDangNhap.TabStop = false;
            this.grDangNhap.Text = "Đăng Nhập ";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(121, 116);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(100, 25);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật Khẩu :";
            // 
            // MatKhau
            // 
            this.MatKhau.Location = new System.Drawing.Point(121, 68);
            this.MatKhau.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Size = new System.Drawing.Size(304, 22);
            this.MatKhau.TabIndex = 3;
            this.MatKhau.UseSystemPasswordChar = true;
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(28, 36);
            this.lblTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(78, 14);
            this.lblTaiKhoan.TabIndex = 2;
            this.lblTaiKhoan.Text = "Tài Khoản :";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(121, 32);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(304, 22);
            this.txtTaiKhoan.TabIndex = 0;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.grDangNhap);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.grDangNhap.ResumeLayout(false);
            this.grDangNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grDangNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MatKhau;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Button btnDangNhap;
    }
}

