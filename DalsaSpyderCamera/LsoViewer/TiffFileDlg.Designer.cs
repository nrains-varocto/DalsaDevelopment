namespace DALSA.SaperaLT.SapClassGui
{
    partial class TiffFileDlg
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
            this.button_OK = new System.Windows.Forms.Button();
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.comboBox_compression_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpDown_compression_level = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_compression_level)).BeginInit();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(87, 143);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_CANCEL.Location = new System.Drawing.Point(168, 143);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(75, 23);
            this.button_CANCEL.TabIndex = 1;
            this.button_CANCEL.Text = "Cancel";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            // 
            // comboBox_compression_type
            // 
            this.comboBox_compression_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_compression_type.FormattingEnabled = true;
            this.comboBox_compression_type.Items.AddRange(new object[] {
            "None",
            "RLE",
            "LZW",
            "JPEG"});
            this.comboBox_compression_type.Location = new System.Drawing.Point(120, 26);
            this.comboBox_compression_type.Name = "comboBox_compression_type";
            this.comboBox_compression_type.Size = new System.Drawing.Size(164, 21);
            this.comboBox_compression_type.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Compression Type:";
            // 
            // UpDown_compression_level
            // 
            this.UpDown_compression_level.Location = new System.Drawing.Point(186, 75);
            this.UpDown_compression_level.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.UpDown_compression_level.Name = "UpDown_compression_level";
            this.UpDown_compression_level.Size = new System.Drawing.Size(97, 20);
            this.UpDown_compression_level.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Compression Level [1...99]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "(JPEG only)";
            // 
            // TiffFileDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 179);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpDown_compression_level);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_compression_type);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Name = "TiffFileDlg";
            this.Text = "Tiff image options";
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_compression_level)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_CANCEL;
        private System.Windows.Forms.ComboBox comboBox_compression_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown UpDown_compression_level;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private int m_Compression_Level;
        private int m_Compression_Type;


    }
}