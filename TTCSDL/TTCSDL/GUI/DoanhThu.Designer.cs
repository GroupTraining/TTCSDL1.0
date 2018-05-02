namespace TTCSDL.GUI
{
    partial class DoanhThu
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBoxDT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewDT = new System.Windows.Forms.DataGridView();
            this.comboBoxDoanhthu = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDT)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.textBoxDT);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.dataGridViewDT);
            this.groupPanel1.Controls.Add(this.comboBoxDoanhthu);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupPanel1.Location = new System.Drawing.Point(-2, -5);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(760, 348);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Doanh thu";
            // 
            // textBoxDT
            // 
            // 
            // 
            // 
            this.textBoxDT.Border.Class = "TextBoxBorder";
            this.textBoxDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxDT.Location = new System.Drawing.Point(581, 272);
            this.textBoxDT.Name = "textBoxDT";
            this.textBoxDT.Size = new System.Drawing.Size(121, 26);
            this.textBoxDT.TabIndex = 9;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX2.Location = new System.Drawing.Point(515, 270);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 28);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "Tổng";
            // 
            // dataGridViewDT
            // 
            this.dataGridViewDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDT.Location = new System.Drawing.Point(-2, 60);
            this.dataGridViewDT.Name = "dataGridViewDT";
            this.dataGridViewDT.Size = new System.Drawing.Size(755, 186);
            this.dataGridViewDT.TabIndex = 7;
            // 
            // comboBoxDoanhthu
            // 
            this.comboBoxDoanhthu.DisplayMember = "Text";
            this.comboBoxDoanhthu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxDoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxDoanhthu.FormattingEnabled = true;
            this.comboBoxDoanhthu.ItemHeight = 20;
            this.comboBoxDoanhthu.Location = new System.Drawing.Point(216, 10);
            this.comboBoxDoanhthu.Name = "comboBoxDoanhthu";
            this.comboBoxDoanhthu.Size = new System.Drawing.Size(150, 26);
            this.comboBoxDoanhthu.TabIndex = 6;
            this.comboBoxDoanhthu.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX1.Location = new System.Drawing.Point(45, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(165, 28);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Thống kê Doanh thu";
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(758, 342);
            this.Controls.Add(this.groupPanel1);
            this.Name = "DoanhThu";
            this.Text = "DoanhThu";
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxDT;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.DataGridView dataGridViewDT;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxDoanhthu;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}