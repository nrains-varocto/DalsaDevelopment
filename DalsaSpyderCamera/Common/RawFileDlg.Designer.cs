using DALSA.SaperaLT.SapClassBasic;

namespace DALSA.SaperaLT.SapClassGui
{
    partial class RawFileDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.textBox_Offset = new System.Windows.Forms.TextBox();
            this.comboBox_RawFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width (in Pixels)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height (in pixels)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Offset (in bytes)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Format:";
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(34, 155);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(61, 23);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(104, 155);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(62, 23);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(114, 13);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(77, 20);
            this.textBox_Width.TabIndex = 5;
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(114, 43);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(77, 20);
            this.textBox_Height.TabIndex = 6;
            // 
            // textBox_Offset
            // 
            this.textBox_Offset.Location = new System.Drawing.Point(114, 72);
            this.textBox_Offset.Name = "textBox_Offset";
            this.textBox_Offset.Size = new System.Drawing.Size(77, 20);
            this.textBox_Offset.TabIndex = 7;
            // 
            // comboBox_RawFormat
            // 
            this.comboBox_RawFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RawFormat.FormattingEnabled = true;
            this.comboBox_RawFormat.Location = new System.Drawing.Point(70, 108);
            this.comboBox_RawFormat.Name = "comboBox_RawFormat";
            this.comboBox_RawFormat.Size = new System.Drawing.Size(138, 21);
            this.comboBox_RawFormat.TabIndex = 9;
            // 
            // RawFileDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 190);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_RawFormat);
            this.Controls.Add(this.textBox_Offset);
            this.Controls.Add(this.textBox_Height);
            this.Controls.Add(this.textBox_Width);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RawFileDlg";
            this.Text = "Raw Image Option";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox textBox_Offset;
        private System.Windows.Forms.ComboBox comboBox_RawFormat;

        private int m_Height;
        private int m_Width;
        private int m_Offset;
        private SapFormat m_Format;

        private static SapFormatInfo[] m_FormatInfo = 
        {
            new SapFormatInfo(SapFormat.Mono1, "Monochrome 1-bit"),
            new SapFormatInfo(SapFormat.Mono8, "Monochrome 8-bit"),
            new SapFormatInfo(SapFormat.Mono16, "Monochrome 16-bit"),
            new SapFormatInfo(SapFormat.RGB5551, "RGB 5551"),
            new SapFormatInfo(SapFormat.RGB565, "RGB 565"),
            new SapFormatInfo(SapFormat.RGB888, "RGB 888 (blue first)"),
            new SapFormatInfo(SapFormat.RGBR888, "RGBR 888 (red first)"),
            new SapFormatInfo(SapFormat.RGB8888, "RGB 8888"),
            new SapFormatInfo(SapFormat.RGB101010,"RGB 101010"),
            new SapFormatInfo(SapFormat.RGB161616,"RGB 161616"),
            new SapFormatInfo(SapFormat.RGB16161616,"RGB 16161616"),
            new SapFormatInfo(SapFormat.RGBP8, "RGB Planar 8-bit"),
            new SapFormatInfo(SapFormat.RGBP16, "RGB Planar 16-bit"),
            new SapFormatInfo(SapFormat.HSI, "HSI"),
            new SapFormatInfo(SapFormat.HSIP8, "HSI Planar 8-bit"),
            new SapFormatInfo(SapFormat.HSV, "HSV"),
            new SapFormatInfo(SapFormat.UYVY, "UYVY"),
            new SapFormatInfo(SapFormat.YUY2,"YUY2"),
            new SapFormatInfo(SapFormat.YUYV, "YUYV"),
            new SapFormatInfo(SapFormat.LAB, "LAB"),
            new SapFormatInfo(SapFormat.LABP8, "LAB Planar 8-bit"),
            new SapFormatInfo(SapFormat.LAB101010,"LAB 101010"),
            new SapFormatInfo(SapFormat.LABP16, "LAB Planar 16-bit"),
            new SapFormatInfo(SapFormat.BICOLOR88, "BICOLOR 8-bit"),
            new SapFormatInfo(SapFormat.BICOLOR1616, "BICOLOR 16-bit"),
            new SapFormatInfo(SapFormat.RGB888_MONO8, "RGB-IR 8-bit"),
            new SapFormatInfo(SapFormat.RGB161616_MONO16, "RGB-IR 16-bit"),
            new SapFormatInfo(SapFormat.Mono8P2, "Monochrome 8-bit (2 planes)"),
            new SapFormatInfo(SapFormat.Mono8P3, "Monochrome 8-bit (3 planes)"),
            new SapFormatInfo(SapFormat.Mono16P2, "Monochrome 16-bit (2 planes)"),
            new SapFormatInfo(SapFormat.Mono16P3, "Monochrome 16-bit (3 planes)")
        };
    }
}