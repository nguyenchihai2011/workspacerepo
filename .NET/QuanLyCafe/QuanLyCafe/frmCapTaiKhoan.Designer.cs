﻿namespace QuanLyCafe
{
    partial class frmCapTaiKhoan
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
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCheckPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCapTaiKhoan = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(208, 225);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(221, 24);
            this.cboNhanVien.TabIndex = 25;
            this.cboNhanVien.DropDown += new System.EventHandler(this.cboNhanVien_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Nhân viên:";
            // 
            // txtCheckPass
            // 
            this.txtCheckPass.Location = new System.Drawing.Point(208, 187);
            this.txtCheckPass.Name = "txtCheckPass";
            this.txtCheckPass.PasswordChar = '*';
            this.txtCheckPass.Size = new System.Drawing.Size(221, 22);
            this.txtCheckPass.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nhập lại mật khẩu:";
            // 
            // btnCapTaiKhoan
            // 
            this.btnCapTaiKhoan.Location = new System.Drawing.Point(281, 274);
            this.btnCapTaiKhoan.Name = "btnCapTaiKhoan";
            this.btnCapTaiKhoan.Size = new System.Drawing.Size(148, 29);
            this.btnCapTaiKhoan.TabIndex = 21;
            this.btnCapTaiKhoan.Text = "Cấp tài khoản";
            this.btnCapTaiKhoan.UseVisualStyleBackColor = true;
            this.btnCapTaiKhoan.Click += new System.EventHandler(this.btnCapTaiKhoan_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(208, 150);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(221, 22);
            this.txtPwd.TabIndex = 20;
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(208, 113);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(221, 22);
            this.txtUid.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tên tài khoản:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(276, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cấp tài khoản";
            // 
            // frmCapTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCheckPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCapTaiKhoan);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCapTaiKhoan";
            this.Text = "frmCapTaiKhoan";
            this.Load += new System.EventHandler(this.frmCapTaiKhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCheckPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCapTaiKhoan;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}