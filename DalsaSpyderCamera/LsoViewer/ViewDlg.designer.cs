using System;
using System.Collections;
using System.Drawing;

using DALSA.SaperaLT.SapClassBasic;

namespace DALSA.SaperaLT.SapClassGui
{
    partial class ViewDlg
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
            this.groupBox1_Scaling = new System.Windows.Forms.GroupBox();
            this.button_No_Scaling = new System.Windows.Forms.Button();
            this.button_Fit = new System.Windows.Forms.Button();
            this.checkBox_lock = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NUpDown_height_scalor = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.NUpDown_width_scalor = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NUpDown_height = new System.Windows.Forms.NumericUpDown();
            this.NUpDown_width = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.RangeBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Range = new System.Windows.Forms.TextBox();
            this.Slider_Range = new System.Windows.Forms.TrackBar();
            this.ViewFormatBox = new System.Windows.Forms.GroupBox();
            this.comboBox1_ViewFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1_Scaling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_height_scalor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_width_scalor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_width)).BeginInit();
            this.RangeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider_Range)).BeginInit();
            this.ViewFormatBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1_Scaling
            // 
            this.groupBox1_Scaling.Controls.Add(this.button_No_Scaling);
            this.groupBox1_Scaling.Controls.Add(this.button_Fit);
            this.groupBox1_Scaling.Controls.Add(this.checkBox_lock);
            this.groupBox1_Scaling.Controls.Add(this.label6);
            this.groupBox1_Scaling.Controls.Add(this.NUpDown_height_scalor);
            this.groupBox1_Scaling.Controls.Add(this.label5);
            this.groupBox1_Scaling.Controls.Add(this.NUpDown_width_scalor);
            this.groupBox1_Scaling.Controls.Add(this.label4);
            this.groupBox1_Scaling.Controls.Add(this.label3);
            this.groupBox1_Scaling.Controls.Add(this.NUpDown_height);
            this.groupBox1_Scaling.Controls.Add(this.NUpDown_width);
            this.groupBox1_Scaling.Controls.Add(this.label2);
            this.groupBox1_Scaling.Controls.Add(this.label1);
            this.groupBox1_Scaling.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1_Scaling.Location = new System.Drawing.Point(13, 13);
            this.groupBox1_Scaling.Name = "groupBox1_Scaling";
            this.groupBox1_Scaling.Size = new System.Drawing.Size(351, 159);
            this.groupBox1_Scaling.TabIndex = 0;
            this.groupBox1_Scaling.TabStop = false;
            this.groupBox1_Scaling.Text = "Scaling";
            // 
            // button_No_Scaling
            // 
            this.button_No_Scaling.Location = new System.Drawing.Point(256, 122);
            this.button_No_Scaling.Name = "button_No_Scaling";
            this.button_No_Scaling.Size = new System.Drawing.Size(89, 23);
            this.button_No_Scaling.TabIndex = 13;
            this.button_No_Scaling.Text = "No scaling";
            this.button_No_Scaling.UseVisualStyleBackColor = true;
            this.button_No_Scaling.Click += new System.EventHandler(this.button_No_Scaling_Click);
            // 
            // button_Fit
            // 
            this.button_Fit.Location = new System.Drawing.Point(163, 122);
            this.button_Fit.Name = "button_Fit";
            this.button_Fit.Size = new System.Drawing.Size(87, 23);
            this.button_Fit.TabIndex = 12;
            this.button_Fit.Text = "Fit to Window";
            this.button_Fit.UseVisualStyleBackColor = true;
            this.button_Fit.Click += new System.EventHandler(this.button_Fit_Click);
            // 
            // checkBox_lock
            // 
            this.checkBox_lock.AutoSize = true;
            this.checkBox_lock.Location = new System.Drawing.Point(33, 126);
            this.checkBox_lock.Name = "checkBox_lock";
            this.checkBox_lock.Size = new System.Drawing.Size(108, 17);
            this.checkBox_lock.TabIndex = 11;
            this.checkBox_lock.Text = "Lock aspect ratio";
            this.checkBox_lock.UseVisualStyleBackColor = true;
            this.checkBox_lock.CheckedChanged += new System.EventHandler(this.checkBox_lock_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "%";
            // 
            // NUpDown_height_scalor
            // 
            this.NUpDown_height_scalor.Cursor = System.Windows.Forms.Cursors.Default;
            this.NUpDown_height_scalor.DecimalPlaces = 2;
            this.NUpDown_height_scalor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NUpDown_height_scalor.Location = new System.Drawing.Point(242, 77);
            this.NUpDown_height_scalor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUpDown_height_scalor.Name = "NUpDown_height_scalor";
            this.NUpDown_height_scalor.Size = new System.Drawing.Size(71, 20);
            this.NUpDown_height_scalor.TabIndex = 9;
            this.NUpDown_height_scalor.ValueChanged += new System.EventHandler(this.NUpDown_height_scalor_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "%";
            // 
            // NUpDown_width_scalor
            // 
            this.NUpDown_width_scalor.DecimalPlaces = 2;
            this.NUpDown_width_scalor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NUpDown_width_scalor.Location = new System.Drawing.Point(242, 29);
            this.NUpDown_width_scalor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUpDown_width_scalor.Name = "NUpDown_width_scalor";
            this.NUpDown_width_scalor.Size = new System.Drawing.Size(71, 20);
            this.NUpDown_width_scalor.TabIndex = 7;
            this.NUpDown_width_scalor.ValueChanged += new System.EventHandler(this.NUpDown_width_scalor_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "lines";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "pixels";
            // 
            // NUpDown_height
            // 
            this.NUpDown_height.Location = new System.Drawing.Point(81, 77);
            this.NUpDown_height.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUpDown_height.Name = "NUpDown_height";
            this.NUpDown_height.Size = new System.Drawing.Size(82, 20);
            this.NUpDown_height.TabIndex = 4;
            this.NUpDown_height.ValueChanged += new System.EventHandler(this.NUpDown_height_ValueChanged);
            // 
            // NUpDown_width
            // 
            this.NUpDown_width.Location = new System.Drawing.Point(81, 30);
            this.NUpDown_width.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUpDown_width.Name = "NUpDown_width";
            this.NUpDown_width.Size = new System.Drawing.Size(82, 20);
            this.NUpDown_width.TabIndex = 3;
            this.NUpDown_width.ValueChanged += new System.EventHandler(this.NUpDown_width_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // button_OK
            // 
            this.button_OK.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(70, 413);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(232, 413);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(151, 413);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 3;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button1_Apply_Click);
            // 
            // RangeBox
            // 
            this.RangeBox.Controls.Add(this.label8);
            this.RangeBox.Controls.Add(this.label7);
            this.RangeBox.Controls.Add(this.textBox_Range);
            this.RangeBox.Controls.Add(this.Slider_Range);
            this.RangeBox.Location = new System.Drawing.Point(15, 181);
            this.RangeBox.Name = "RangeBox";
            this.RangeBox.Size = new System.Drawing.Size(348, 103);
            this.RangeBox.TabIndex = 4;
            this.RangeBox.TabStop = false;
            this.RangeBox.Text = "Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "are not to be viewed.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(303, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Range: specifies how many of the most significant bits ";
            // 
            // textBox_Range
            // 
            this.textBox_Range.Location = new System.Drawing.Point(269, 23);
            this.textBox_Range.Name = "textBox_Range";
            this.textBox_Range.Size = new System.Drawing.Size(51, 20);
            this.textBox_Range.TabIndex = 1;
            this.textBox_Range.TextChanged += new System.EventHandler(this.textBox_Range_TextChanged);
            // 
            // Slider_Range
            // 
            this.Slider_Range.Location = new System.Drawing.Point(12, 23);
            this.Slider_Range.Maximum = 8;
            this.Slider_Range.Name = "Slider_Range";
            this.Slider_Range.Size = new System.Drawing.Size(236, 45);
            this.Slider_Range.TabIndex = 0;
            this.Slider_Range.Scroll += new System.EventHandler(this.Slider_Range_Scroll);
            // 
            // ViewFormatBox
            // 
            this.ViewFormatBox.Controls.Add(this.label10);
            this.ViewFormatBox.Controls.Add(this.label9);
            this.ViewFormatBox.Controls.Add(this.comboBox1_ViewFormat);
            this.ViewFormatBox.Location = new System.Drawing.Point(15, 300);
            this.ViewFormatBox.Name = "ViewFormatBox";
            this.ViewFormatBox.Size = new System.Drawing.Size(347, 99);
            this.ViewFormatBox.TabIndex = 5;
            this.ViewFormatBox.TabStop = false;
            this.ViewFormatBox.Text = "View Format";
            // 
            // comboBox1_ViewFormat
            // 
            this.comboBox1_ViewFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1_ViewFormat.FormattingEnabled = true;
            this.comboBox1_ViewFormat.Location = new System.Drawing.Point(18, 22);
            this.comboBox1_ViewFormat.Name = "comboBox1_ViewFormat";
            this.comboBox1_ViewFormat.Size = new System.Drawing.Size(310, 21);
            this.comboBox1_ViewFormat.TabIndex = 0;
            this.comboBox1_ViewFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox1_ViewFormat_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "View Format: specifies what to display for multi-format";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "buffers (like RGB-IR 8-bit)";
            // 
            // ViewDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 449);
            this.Controls.Add(this.ViewFormatBox);
            this.Controls.Add(this.RangeBox);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox1_Scaling);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ViewDlg";
            this.Text = "View";
            this.groupBox1_Scaling.ResumeLayout(false);
            this.groupBox1_Scaling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_height_scalor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_width_scalor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDown_width)).EndInit();
            this.RangeBox.ResumeLayout(false);
            this.RangeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider_Range)).EndInit();
            this.ViewFormatBox.ResumeLayout(false);
            this.ViewFormatBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1_Scaling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUpDown_height;
        private System.Windows.Forms.NumericUpDown NUpDown_width;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NUpDown_height_scalor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NUpDown_width_scalor;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.CheckBox checkBox_lock;
        private System.Windows.Forms.Button button_No_Scaling;
        private System.Windows.Forms.Button button_Fit;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.GroupBox RangeBox;
        private System.Windows.Forms.TrackBar Slider_Range;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Range;
        private System.Windows.Forms.Label label8;

        private SapView m_pView;
        private Rectangle m_ViewArea;
        private int m_Range;
        private int m_RangeInit;
       private bool m_bLockAspectRatio;
       private System.Windows.Forms.GroupBox ViewFormatBox;
       private System.Windows.Forms.ComboBox comboBox1_ViewFormat;
       private System.Windows.Forms.Label label10;
       private System.Windows.Forms.Label label9;     
    }
}