namespace TTCSDL.GUI
{
    partial class DatPhong
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
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.comboBoxSP = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dateTimeNgayDen = new System.Windows.Forms.DateTimePicker();
            this.dateTimeNgayTra = new System.Windows.Forms.DateTimePicker();
            this.labelHoTen = new DevComponents.DotNetBar.LabelX();
            this.labelQLKH = new DevComponents.DotNetBar.LabelX();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelThanhTien = new DevComponents.DotNetBar.LabelX();
            this.labelLP = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 67);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(108, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Họ Tên";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(12, 17);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(108, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "SĐT";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(12, 116);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(108, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "Quyền Lợi KH";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(12, 165);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(108, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Số Phòng";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(12, 254);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(108, 23);
            this.labelX5.TabIndex = 5;
            this.labelX5.Text = "Ngày Đến";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(12, 302);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(108, 23);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "Ngày Trả";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(138, 17);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(182, 22);
            this.txtSDT.TabIndex = 8;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // comboBoxSP
            // 
            this.comboBoxSP.DisplayMember = "Text";
            this.comboBoxSP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSP.FormattingEnabled = true;
            this.comboBoxSP.ItemHeight = 16;
            this.comboBoxSP.Location = new System.Drawing.Point(138, 166);
            this.comboBoxSP.Name = "comboBoxSP";
            this.comboBoxSP.Size = new System.Drawing.Size(182, 22);
            this.comboBoxSP.TabIndex = 10;
            this.comboBoxSP.SelectedIndexChanged += new System.EventHandler(this.comboBoxSP_SelectedIndexChanged);
            // 
            // dateTimeNgayDen
            // 
            this.dateTimeNgayDen.CustomFormat = "dd/MM/yyyy";
            this.dateTimeNgayDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeNgayDen.Location = new System.Drawing.Point(138, 255);
            this.dateTimeNgayDen.Name = "dateTimeNgayDen";
            this.dateTimeNgayDen.Size = new System.Drawing.Size(182, 22);
            this.dateTimeNgayDen.TabIndex = 11;
            // 
            // dateTimeNgayTra
            // 
            this.dateTimeNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dateTimeNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeNgayTra.Location = new System.Drawing.Point(138, 303);
            this.dateTimeNgayTra.Name = "dateTimeNgayTra";
            this.dateTimeNgayTra.Size = new System.Drawing.Size(182, 22);
            this.dateTimeNgayTra.TabIndex = 12;
            this.dateTimeNgayTra.ValueChanged += new System.EventHandler(this.dateTimeNgayTra_ValueChanged);
            // 
            // labelHoTen
            // 
            this.labelHoTen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHoTen.Location = new System.Drawing.Point(138, 66);
            this.labelHoTen.Name = "labelHoTen";
            this.labelHoTen.Size = new System.Drawing.Size(182, 23);
            this.labelHoTen.TabIndex = 14;
            // 
            // labelQLKH
            // 
            this.labelQLKH.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelQLKH.Location = new System.Drawing.Point(138, 116);
            this.labelQLKH.Name = "labelQLKH";
            this.labelQLKH.Size = new System.Drawing.Size(182, 23);
            this.labelQLKH.TabIndex = 15;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.Lime;
            this.btnXacNhan.Location = new System.Drawing.Point(50, 384);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(92, 32);
            this.btnXacNhan.TabIndex = 16;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelThanhTien);
            this.groupPanel1.Controls.Add(this.labelLP);
            this.groupPanel1.Controls.Add(this.labelX8);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.btnHuyBo);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.txtSDT);
            this.groupPanel1.Controls.Add(this.comboBoxSP);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.dateTimeNgayDen);
            this.groupPanel1.Controls.Add(this.labelHoTen);
            this.groupPanel1.Controls.Add(this.labelQLKH);
            this.groupPanel1.Controls.Add(this.dateTimeNgayTra);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.btnXacNhan);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(12, 1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(347, 446);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 17;
            this.groupPanel1.Text = "Đặt Phòng";
            // 
            // labelThanhTien
            // 
            this.labelThanhTien.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelThanhTien.Location = new System.Drawing.Point(138, 343);
            this.labelThanhTien.Name = "labelThanhTien";
            this.labelThanhTien.Size = new System.Drawing.Size(182, 23);
            this.labelThanhTien.TabIndex = 21;
            this.labelThanhTien.Text = "0 đ";
            // 
            // labelLP
            // 
            this.labelLP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelLP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLP.Location = new System.Drawing.Point(138, 213);
            this.labelLP.Name = "labelLP";
            this.labelLP.Size = new System.Drawing.Size(182, 23);
            this.labelLP.TabIndex = 20;
            // 
            // labelX8
            // 
            this.labelX8.Location = new System.Drawing.Point(12, 213);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(108, 23);
            this.labelX8.TabIndex = 19;
            this.labelX8.Text = "Loại Phòng";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX7
            // 
            this.labelX7.Location = new System.Drawing.Point(12, 343);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(108, 26);
            this.labelX7.TabIndex = 18;
            this.labelX7.Text = "Thành Tiền";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBo.ForeColor = System.Drawing.Color.Red;
            this.btnHuyBo.Location = new System.Drawing.Point(191, 384);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(92, 32);
            this.btnHuyBo.TabIndex = 17;
            this.btnHuyBo.Text = "Hủy Bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // DatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 453);
            this.Controls.Add(this.groupPanel1);
            this.Name = "DatPhong";
            this.Text = "DatPhong";
            this.Load += new System.EventHandler(this.DatPhong_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.TextBox txtSDT;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxSP;
        private System.Windows.Forms.DateTimePicker dateTimeNgayDen;
        private System.Windows.Forms.DateTimePicker dateTimeNgayTra;
        private DevComponents.DotNetBar.LabelX labelHoTen;
        private DevComponents.DotNetBar.LabelX labelQLKH;
        private System.Windows.Forms.Button btnXacNhan;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Button btnHuyBo;
        private DevComponents.DotNetBar.LabelX labelThanhTien;
        private DevComponents.DotNetBar.LabelX labelLP;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
    }
}