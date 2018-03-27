namespace TTCSDL.GUI
{
    partial class ChangePassword
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_oldpass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_renewpass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_newpass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_submit = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(22, 75);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(112, 35);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Mật khẩu hiện tại";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(22, 109);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(112, 35);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Mật khẩu mới";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(22, 143);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(112, 35);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Nhập lại mật khẩu ";
            // 
            // txt_oldpass
            // 
            // 
            // 
            // 
            this.txt_oldpass.Border.Class = "TextBoxBorder";
            this.txt_oldpass.Location = new System.Drawing.Point(141, 82);
            this.txt_oldpass.Name = "txt_oldpass";
            this.txt_oldpass.PasswordChar = '*';
            this.txt_oldpass.Size = new System.Drawing.Size(241, 22);
            this.txt_oldpass.TabIndex = 1;
            // 
            // txt_renewpass
            // 
            // 
            // 
            // 
            this.txt_renewpass.Border.Class = "TextBoxBorder";
            this.txt_renewpass.Location = new System.Drawing.Point(141, 150);
            this.txt_renewpass.Name = "txt_renewpass";
            this.txt_renewpass.PasswordChar = '*';
            this.txt_renewpass.Size = new System.Drawing.Size(241, 22);
            this.txt_renewpass.TabIndex = 3;
            // 
            // txt_newpass
            // 
            // 
            // 
            // 
            this.txt_newpass.Border.Class = "TextBoxBorder";
            this.txt_newpass.Location = new System.Drawing.Point(141, 116);
            this.txt_newpass.Name = "txt_newpass";
            this.txt_newpass.PasswordChar = '*';
            this.txt_newpass.Size = new System.Drawing.Size(241, 22);
            this.txt_newpass.TabIndex = 2;
            // 
            // btn_submit
            // 
            this.btn_submit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_submit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_submit.Location = new System.Drawing.Point(195, 202);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(101, 36);
            this.btn_submit.TabIndex = 4;
            this.btn_submit.Text = "Cập nhật";
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(71, 30);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(311, 38);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "Thay đổi mật  khẩu đăng nhập";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(443, 299);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txt_newpass);
            this.Controls.Add(this.txt_renewpass);
            this.Controls.Add(this.txt_oldpass);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangePassword";
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_oldpass;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_renewpass;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_newpass;
        private DevComponents.DotNetBar.ButtonX btn_submit;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}