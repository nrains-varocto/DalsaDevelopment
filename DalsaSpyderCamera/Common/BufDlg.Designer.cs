using System;
using System.Collections;

using DALSA.SaperaLT.SapClassBasic;



namespace DALSA.SaperaLT.SapClassGui
{

    partial class BufferDlg
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
            this.groupBox1_Count = new System.Windows.Forms.GroupBox();
            this.textBox1_Height = new System.Windows.Forms.TextBox();
            this.textBox1_Width = new System.Windows.Forms.TextBox();
            this.textBox1_Count = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1_OK = new System.Windows.Forms.Button();
            this.button1_Cancel = new System.Windows.Forms.Button();
            this.groupBox1_Type = new System.Windows.Forms.GroupBox();
            this.radioButton1_Virtual = new System.Windows.Forms.RadioButton();
            this.radioButton1_Overlay = new System.Windows.Forms.RadioButton();
            this.radioButton1_Offscreen_Video = new System.Windows.Forms.RadioButton();
            this.radioButton1_ScatterGather = new System.Windows.Forms.RadioButton();
            this.radioButton1_Contiguous = new System.Windows.Forms.RadioButton();
            this.groupBox1_Format = new System.Windows.Forms.GroupBox();
            this.comboBox1_Format = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1_PixelDepth = new System.Windows.Forms.TextBox();
            this.groupBox1_Count.SuspendLayout();
            this.groupBox1_Type.SuspendLayout();
            this.groupBox1_Format.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1_Count
            // 
            this.groupBox1_Count.Controls.Add(this.textBox1_Height);
            this.groupBox1_Count.Controls.Add(this.textBox1_Width);
            this.groupBox1_Count.Controls.Add(this.textBox1_Count);
            this.groupBox1_Count.Controls.Add(this.label3);
            this.groupBox1_Count.Controls.Add(this.label2);
            this.groupBox1_Count.Controls.Add(this.label1);
            this.groupBox1_Count.Location = new System.Drawing.Point(12, 21);
            this.groupBox1_Count.Name = "groupBox1_Count";
            this.groupBox1_Count.Size = new System.Drawing.Size(136, 145);
            this.groupBox1_Count.TabIndex = 0;
            this.groupBox1_Count.TabStop = false;
            this.groupBox1_Count.Text = "Count and Size";
            // 
            // textBox1_Height
            // 
            this.textBox1_Height.Location = new System.Drawing.Point(64, 96);
            this.textBox1_Height.Name = "textBox1_Height";
            this.textBox1_Height.Size = new System.Drawing.Size(56, 20);
            this.textBox1_Height.TabIndex = 5;
            // 
            // textBox1_Width
            // 
            this.textBox1_Width.Location = new System.Drawing.Point(64, 64);
            this.textBox1_Width.Name = "textBox1_Width";
            this.textBox1_Width.Size = new System.Drawing.Size(56, 20);
            this.textBox1_Width.TabIndex = 4;
            // 
            // textBox1_Count
            // 
            this.textBox1_Count.Location = new System.Drawing.Point(64, 28);
            this.textBox1_Count.Name = "textBox1_Count";
            this.textBox1_Count.Size = new System.Drawing.Size(56, 20);
            this.textBox1_Count.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Count :";
            // 
            // button1_OK
            // 
            this.button1_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1_OK.Location = new System.Drawing.Point(85, 292);
            this.button1_OK.Name = "button1_OK";
            this.button1_OK.Size = new System.Drawing.Size(75, 23);
            this.button1_OK.TabIndex = 1;
            this.button1_OK.Text = "OK";
            this.button1_OK.UseVisualStyleBackColor = true;
            this.button1_OK.Click += new System.EventHandler(this.button1_OK_Click);
            // 
            // button1_Cancel
            // 
            this.button1_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1_Cancel.Location = new System.Drawing.Point(175, 292);
            this.button1_Cancel.Name = "button1_Cancel";
            this.button1_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button1_Cancel.TabIndex = 2;
            this.button1_Cancel.Text = "Cancel";
            this.button1_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1_Type
            // 
            this.groupBox1_Type.Controls.Add(this.radioButton1_Virtual);
            this.groupBox1_Type.Controls.Add(this.radioButton1_Overlay);
            this.groupBox1_Type.Controls.Add(this.radioButton1_Offscreen_Video);
            this.groupBox1_Type.Controls.Add(this.radioButton1_ScatterGather);
            this.groupBox1_Type.Controls.Add(this.radioButton1_Contiguous);
            this.groupBox1_Type.Location = new System.Drawing.Point(175, 21);
            this.groupBox1_Type.Name = "groupBox1_Type";
            this.groupBox1_Type.Size = new System.Drawing.Size(127, 145);
            this.groupBox1_Type.TabIndex = 3;
            this.groupBox1_Type.TabStop = false;
            this.groupBox1_Type.Text = "Type";
            // 
            // radioButton1_Virtual
            // 
            this.radioButton1_Virtual.AutoSize = true;
            this.radioButton1_Virtual.Location = new System.Drawing.Point(14, 122);
            this.radioButton1_Virtual.Name = "radioButton1_Virtual";
            this.radioButton1_Virtual.Size = new System.Drawing.Size(54, 17);
            this.radioButton1_Virtual.TabIndex = 4;
            this.radioButton1_Virtual.TabStop = true;
            this.radioButton1_Virtual.Text = "Virtual";
            this.radioButton1_Virtual.UseVisualStyleBackColor = true;
            this.radioButton1_Virtual.CheckedChanged += new System.EventHandler(this.radioButton1_Virtual_CheckedChanged);
            // 
            // radioButton1_Overlay
            // 
            this.radioButton1_Overlay.AutoSize = true;
            this.radioButton1_Overlay.Location = new System.Drawing.Point(13, 97);
            this.radioButton1_Overlay.Name = "radioButton1_Overlay";
            this.radioButton1_Overlay.Size = new System.Drawing.Size(61, 17);
            this.radioButton1_Overlay.TabIndex = 3;
            this.radioButton1_Overlay.TabStop = true;
            this.radioButton1_Overlay.Text = "Overlay";
            this.radioButton1_Overlay.UseVisualStyleBackColor = true;
            this.radioButton1_Overlay.CheckedChanged += new System.EventHandler(this.radioButton1_Overlay_CheckedChanged);
            // 
            // radioButton1_Offscreen_Video
            // 
            this.radioButton1_Offscreen_Video.AutoSize = true;
            this.radioButton1_Offscreen_Video.Location = new System.Drawing.Point(13, 73);
            this.radioButton1_Offscreen_Video.Name = "radioButton1_Offscreen_Video";
            this.radioButton1_Offscreen_Video.Size = new System.Drawing.Size(101, 17);
            this.radioButton1_Offscreen_Video.TabIndex = 2;
            this.radioButton1_Offscreen_Video.TabStop = true;
            this.radioButton1_Offscreen_Video.Text = "Offscreen Video";
            this.radioButton1_Offscreen_Video.UseVisualStyleBackColor = true;
            this.radioButton1_Offscreen_Video.CheckedChanged += new System.EventHandler(this.radioButton1_Offscreen_Video_CheckedChanged);
            // 
            // radioButton1_ScatterGather
            // 
            this.radioButton1_ScatterGather.AutoSize = true;
            this.radioButton1_ScatterGather.Location = new System.Drawing.Point(13, 48);
            this.radioButton1_ScatterGather.Name = "radioButton1_ScatterGather";
            this.radioButton1_ScatterGather.Size = new System.Drawing.Size(94, 17);
            this.radioButton1_ScatterGather.TabIndex = 1;
            this.radioButton1_ScatterGather.TabStop = true;
            this.radioButton1_ScatterGather.Text = "Scatter-Gather";
            this.radioButton1_ScatterGather.UseVisualStyleBackColor = true;
            this.radioButton1_ScatterGather.CheckedChanged += new System.EventHandler(this.radioButton1_ScatterGather_CheckedChanged);
            // 
            // radioButton1_Contiguous
            // 
            this.radioButton1_Contiguous.AutoSize = true;
            this.radioButton1_Contiguous.Location = new System.Drawing.Point(13, 24);
            this.radioButton1_Contiguous.Name = "radioButton1_Contiguous";
            this.radioButton1_Contiguous.Size = new System.Drawing.Size(78, 17);
            this.radioButton1_Contiguous.TabIndex = 0;
            this.radioButton1_Contiguous.TabStop = true;
            this.radioButton1_Contiguous.Text = "Contiguous";
            this.radioButton1_Contiguous.UseVisualStyleBackColor = true;
            this.radioButton1_Contiguous.CheckedChanged += new System.EventHandler(this.radioButton1_Contiguous_CheckedChanged);
            // 
            // groupBox1_Format
            // 
            this.groupBox1_Format.Controls.Add(this.comboBox1_Format);
            this.groupBox1_Format.Location = new System.Drawing.Point(13, 183);
            this.groupBox1_Format.Name = "groupBox1_Format";
            this.groupBox1_Format.Size = new System.Drawing.Size(289, 56);
            this.groupBox1_Format.TabIndex = 4;
            this.groupBox1_Format.TabStop = false;
            this.groupBox1_Format.Text = "Format";
            // 
            // comboBox1_Format
            // 
            this.comboBox1_Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1_Format.FormattingEnabled = true;
            this.comboBox1_Format.Location = new System.Drawing.Point(18, 23);
            this.comboBox1_Format.Name = "comboBox1_Format";
            this.comboBox1_Format.Size = new System.Drawing.Size(258, 21);
            this.comboBox1_Format.TabIndex = 0;
            this.comboBox1_Format.SelectedIndexChanged += new System.EventHandler(this.comboBox1_Format_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pixel Depth (significant bits) :";
            // 
            // textBox1_PixelDepth
            // 
            this.textBox1_PixelDepth.Location = new System.Drawing.Point(221, 250);
            this.textBox1_PixelDepth.Name = "textBox1_PixelDepth";
            this.textBox1_PixelDepth.Size = new System.Drawing.Size(68, 20);
            this.textBox1_PixelDepth.TabIndex = 6;
            // 
            // BufferDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 323);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1_PixelDepth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1_Format);
            this.Controls.Add(this.groupBox1_Type);
            this.Controls.Add(this.button1_Cancel);
            this.Controls.Add(this.button1_OK);
            this.Controls.Add(this.groupBox1_Count);
            this.Name = "BufferDlg";
            this.Text = "Buffer";
            this.groupBox1_Count.ResumeLayout(false);
            this.groupBox1_Count.PerformLayout();
            this.groupBox1_Type.ResumeLayout(false);
            this.groupBox1_Type.PerformLayout();
            this.groupBox1_Format.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1_Count;
        private System.Windows.Forms.Button button1_OK;
        private System.Windows.Forms.Button button1_Cancel;
        private System.Windows.Forms.TextBox textBox1_Count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1_Height;
        private System.Windows.Forms.TextBox textBox1_Width;
        private System.Windows.Forms.GroupBox groupBox1_Type;
        private System.Windows.Forms.RadioButton radioButton1_Contiguous;
        private System.Windows.Forms.RadioButton radioButton1_ScatterGather;
        private System.Windows.Forms.RadioButton radioButton1_Virtual;
        private System.Windows.Forms.RadioButton radioButton1_Overlay;
        private System.Windows.Forms.RadioButton radioButton1_Offscreen_Video;
        private System.Windows.Forms.GroupBox groupBox1_Format;
        private System.Windows.Forms.ComboBox comboBox1_Format;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1_PixelDepth;

        private int m_Count; 
        private int m_Width; 
        private int m_Height;
        private int m_pixelDepth;
        private SapFormat m_format;
        private SapBuffer.MemoryType m_type; 
        private SapBuffer.MemoryType m_ScatterGatherType; 
        private SapDisplay m_sapDisplay;
        private bool m_isXfer;
    }
}