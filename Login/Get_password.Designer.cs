namespace Login
{
    partial class Get_password
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnMk = new System.Windows.Forms.Button();
            this.rtxtPhone = new System.Windows.Forms.RichTextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.btnGetmk = new System.Windows.Forms.Button();
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập số điện thoại của bạn";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(106, 241);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(414, 56);
            this.lblTime.TabIndex = 2;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTime.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnMk
            // 
            this.btnMk.BackColor = System.Drawing.Color.DarkGray;
            this.btnMk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMk.Location = new System.Drawing.Point(375, 123);
            this.btnMk.Name = "btnMk";
            this.btnMk.Size = new System.Drawing.Size(122, 40);
            this.btnMk.TabIndex = 3;
            this.btnMk.Text = "Xác Nhận";
            this.btnMk.UseVisualStyleBackColor = false;
            this.btnMk.Click += new System.EventHandler(this.btnMk_Click);
            // 
            // rtxtPhone
            // 
            this.rtxtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtPhone.Location = new System.Drawing.Point(124, 123);
            this.rtxtPhone.Name = "rtxtPhone";
            this.rtxtPhone.Size = new System.Drawing.Size(194, 40);
            this.rtxtPhone.TabIndex = 4;
            this.rtxtPhone.Text = "";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.ForeColor = System.Drawing.Color.Blue;
            this.lblMatKhau.Location = new System.Drawing.Point(107, 409);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(414, 64);
            this.lblMatKhau.TabIndex = 5;
            this.lblMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGetmk
            // 
            this.btnGetmk.BackColor = System.Drawing.Color.Lime;
            this.btnGetmk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetmk.Location = new System.Drawing.Point(224, 334);
            this.btnGetmk.Name = "btnGetmk";
            this.btnGetmk.Size = new System.Drawing.Size(169, 43);
            this.btnGetmk.TabIndex = 6;
            this.btnGetmk.Text = "Lấy Mật Khẩu";
            this.btnGetmk.UseVisualStyleBackColor = false;
            this.btnGetmk.Click += new System.EventHandler(this.btnGetmk_Click);
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // Get_password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(661, 516);
            this.Controls.Add(this.btnGetmk);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.rtxtPhone);
            this.Controls.Add(this.btnMk);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label1);
            this.Name = "Get_password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lấy lại mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnMk;
        private System.Windows.Forms.RichTextBox rtxtPhone;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Button btnGetmk;
        private System.Windows.Forms.ErrorProvider errorProvider3;
    }
}