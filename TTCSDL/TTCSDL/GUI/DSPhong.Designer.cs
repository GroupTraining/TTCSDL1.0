namespace TTCSDL.GUI
{
    partial class DSPhong
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
            this.buttonPdon = new System.Windows.Forms.Button();
            this.buttonPdoi = new System.Windows.Forms.Button();
            this.buttonPvip = new System.Windows.Forms.Button();
            this.picturePhongdon = new System.Windows.Forms.PictureBox();
            this.picturePhongdoi = new System.Windows.Forms.PictureBox();
            this.picturePhongvip = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturePhongdon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePhongdoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePhongvip)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPdon
            // 
            this.buttonPdon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonPdon.Location = new System.Drawing.Point(183, 401);
            this.buttonPdon.Name = "buttonPdon";
            this.buttonPdon.Size = new System.Drawing.Size(136, 23);
            this.buttonPdon.TabIndex = 3;
            this.buttonPdon.Text = "Phòng Đơn";
            this.buttonPdon.UseVisualStyleBackColor = true;
            this.buttonPdon.Click += new System.EventHandler(this.buttonPdon_Click);
            // 
            // buttonPdoi
            // 
            this.buttonPdoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonPdoi.Location = new System.Drawing.Point(349, 401);
            this.buttonPdoi.Name = "buttonPdoi";
            this.buttonPdoi.Size = new System.Drawing.Size(131, 23);
            this.buttonPdoi.TabIndex = 4;
            this.buttonPdoi.Text = "Phòng Đôi";
            this.buttonPdoi.UseVisualStyleBackColor = true;
            this.buttonPdoi.Click += new System.EventHandler(this.buttonPdoi_Click);
            // 
            // buttonPvip
            // 
            this.buttonPvip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonPvip.Location = new System.Drawing.Point(523, 401);
            this.buttonPvip.Name = "buttonPvip";
            this.buttonPvip.Size = new System.Drawing.Size(131, 23);
            this.buttonPvip.TabIndex = 5;
            this.buttonPvip.Text = "Phòng VIP";
            this.buttonPvip.UseVisualStyleBackColor = true;
            this.buttonPvip.Click += new System.EventHandler(this.buttonPvip_Click);
            // 
            // picturePhongdon
            // 
            this.picturePhongdon.Image = global::TTCSDL.Properties.Resources._31;
            this.picturePhongdon.Location = new System.Drawing.Point(0, -4);
            this.picturePhongdon.Name = "picturePhongdon";
            this.picturePhongdon.Size = new System.Drawing.Size(856, 399);
            this.picturePhongdon.TabIndex = 2;
            this.picturePhongdon.TabStop = false;
            // 
            // picturePhongdoi
            // 
            this.picturePhongdoi.Image = global::TTCSDL.Properties.Resources._29;
            this.picturePhongdoi.Location = new System.Drawing.Point(0, -4);
            this.picturePhongdoi.Name = "picturePhongdoi";
            this.picturePhongdoi.Size = new System.Drawing.Size(856, 402);
            this.picturePhongdoi.TabIndex = 1;
            this.picturePhongdoi.TabStop = false;
            // 
            // picturePhongvip
            // 
            this.picturePhongvip.Image = global::TTCSDL.Properties.Resources._30;
            this.picturePhongvip.Location = new System.Drawing.Point(0, -4);
            this.picturePhongvip.Name = "picturePhongvip";
            this.picturePhongvip.Size = new System.Drawing.Size(856, 399);
            this.picturePhongvip.TabIndex = 0;
            this.picturePhongvip.TabStop = false;
            // 
            // DSPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 435);
            this.Controls.Add(this.buttonPvip);
            this.Controls.Add(this.buttonPdoi);
            this.Controls.Add(this.buttonPdon);
            this.Controls.Add(this.picturePhongdon);
            this.Controls.Add(this.picturePhongdoi);
            this.Controls.Add(this.picturePhongvip);
            this.Name = "DSPhong";
            this.Text = "DSPhong";
            ((System.ComponentModel.ISupportInitialize)(this.picturePhongdon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePhongdoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePhongvip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picturePhongvip;
        private System.Windows.Forms.PictureBox picturePhongdoi;
        private System.Windows.Forms.PictureBox picturePhongdon;
        private System.Windows.Forms.Button buttonPdon;
        private System.Windows.Forms.Button buttonPdoi;
        private System.Windows.Forms.Button buttonPvip;
    }
}