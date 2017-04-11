namespace  DALSA.SaperaLT.SapClassGui
{
    partial class BayerDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BayerDlg));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Method3 = new System.Windows.Forms.RadioButton();
            this.radioButton_Method2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Method1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButton_Align_GR_BG = new System.Windows.Forms.RadioButton();
            this.radioButton_Align_RG_GB = new System.Windows.Forms.RadioButton();
            this.radioButton_Align_BG_GR = new System.Windows.Forms.RadioButton();
            this.radioButton_Align_GB_RG = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_AutoWhite = new System.Windows.Forms.Button();
            this.textBox_Blue_Gain = new System.Windows.Forms.TextBox();
            this.textBox_Green_Gain = new System.Windows.Forms.TextBox();
            this.textBox_Red_Gain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_Gamma = new System.Windows.Forms.CheckBox();
            this.textBox_Gamma = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Apply = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.radioButton_Method4 = new System.Windows.Forms.RadioButton();
            this.radioButton_Method5 = new System.Windows.Forms.RadioButton();
            this.radioButton_Method6 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Method6);
            this.groupBox1.Controls.Add(this.radioButton_Method5);
            this.groupBox1.Controls.Add(this.radioButton_Method4);
            this.groupBox1.Controls.Add(this.radioButton_Method3);
            this.groupBox1.Controls.Add(this.radioButton_Method2);
            this.groupBox1.Controls.Add(this.radioButton_Method1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conversion Method";
            // 
            // radioButton_Method3
            // 
            this.radioButton_Method3.AutoSize = true;
            this.radioButton_Method3.Location = new System.Drawing.Point(15, 75);
            this.radioButton_Method3.Name = "radioButton_Method3";
            this.radioButton_Method3.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Method3.TabIndex = 2;
            this.radioButton_Method3.TabStop = true;
            this.radioButton_Method3.Text = "Method 3";
            this.radioButton_Method3.UseVisualStyleBackColor = true;
            this.radioButton_Method3.CheckedChanged += new System.EventHandler(this.radioButton_Method3_CheckedChanged);
            // 
            // radioButton_Method2
            // 
            this.radioButton_Method2.AutoSize = true;
            this.radioButton_Method2.Location = new System.Drawing.Point(15, 52);
            this.radioButton_Method2.Name = "radioButton_Method2";
            this.radioButton_Method2.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Method2.TabIndex = 1;
            this.radioButton_Method2.TabStop = true;
            this.radioButton_Method2.Text = "Method 2";
            this.radioButton_Method2.UseVisualStyleBackColor = true;
            this.radioButton_Method2.CheckedChanged += new System.EventHandler(this.radioButton_Method2_CheckedChanged);
            // 
            // radioButton_Method1
            // 
            this.radioButton_Method1.AutoSize = true;
            this.radioButton_Method1.Location = new System.Drawing.Point(15, 29);
            this.radioButton_Method1.Name = "radioButton_Method1";
            this.radioButton_Method1.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Method1.TabIndex = 0;
            this.radioButton_Method1.TabStop = true;
            this.radioButton_Method1.Text = "Method 1";
            this.radioButton_Method1.UseVisualStyleBackColor = true;
            this.radioButton_Method1.CheckedChanged += new System.EventHandler(this.radioButton_Method1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.radioButton_Align_GR_BG);
            this.groupBox2.Controls.Add(this.radioButton_Align_RG_GB);
            this.groupBox2.Controls.Add(this.radioButton_Align_BG_GR);
            this.groupBox2.Controls.Add(this.radioButton_Align_GB_RG);
            this.groupBox2.Location = new System.Drawing.Point(136, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(93, 191);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alignement";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(36, 114);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 17);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(36, 84);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 17);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(36, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // radioButton_Align_GR_BG
            // 
            this.radioButton_Align_GR_BG.AutoSize = true;
            this.radioButton_Align_GR_BG.Location = new System.Drawing.Point(16, 116);
            this.radioButton_Align_GR_BG.Name = "radioButton_Align_GR_BG";
            this.radioButton_Align_GR_BG.Size = new System.Drawing.Size(14, 13);
            this.radioButton_Align_GR_BG.TabIndex = 3;
            this.radioButton_Align_GR_BG.TabStop = true;
            this.radioButton_Align_GR_BG.UseVisualStyleBackColor = true;
            this.radioButton_Align_GR_BG.CheckedChanged += new System.EventHandler(this.radioButton_Align_GR_BG_CheckedChanged);
            // 
            // radioButton_Align_RG_GB
            // 
            this.radioButton_Align_RG_GB.AutoSize = true;
            this.radioButton_Align_RG_GB.Location = new System.Drawing.Point(16, 86);
            this.radioButton_Align_RG_GB.Name = "radioButton_Align_RG_GB";
            this.radioButton_Align_RG_GB.Size = new System.Drawing.Size(14, 13);
            this.radioButton_Align_RG_GB.TabIndex = 2;
            this.radioButton_Align_RG_GB.TabStop = true;
            this.radioButton_Align_RG_GB.UseVisualStyleBackColor = true;
            this.radioButton_Align_RG_GB.CheckedChanged += new System.EventHandler(this.radioButton_Align_RG_GB_CheckedChanged);
            // 
            // radioButton_Align_BG_GR
            // 
            this.radioButton_Align_BG_GR.AutoSize = true;
            this.radioButton_Align_BG_GR.Location = new System.Drawing.Point(16, 58);
            this.radioButton_Align_BG_GR.Name = "radioButton_Align_BG_GR";
            this.radioButton_Align_BG_GR.Size = new System.Drawing.Size(14, 13);
            this.radioButton_Align_BG_GR.TabIndex = 1;
            this.radioButton_Align_BG_GR.TabStop = true;
            this.radioButton_Align_BG_GR.UseVisualStyleBackColor = true;
            this.radioButton_Align_BG_GR.CheckedChanged += new System.EventHandler(this.radioButton_Align_BG_GR_CheckedChanged);
            // 
            // radioButton_Align_GB_RG
            // 
            this.radioButton_Align_GB_RG.AutoSize = true;
            this.radioButton_Align_GB_RG.Location = new System.Drawing.Point(16, 29);
            this.radioButton_Align_GB_RG.Name = "radioButton_Align_GB_RG";
            this.radioButton_Align_GB_RG.Size = new System.Drawing.Size(14, 13);
            this.radioButton_Align_GB_RG.TabIndex = 0;
            this.radioButton_Align_GB_RG.TabStop = true;
            this.radioButton_Align_GB_RG.UseVisualStyleBackColor = true;
            this.radioButton_Align_GB_RG.CheckedChanged += new System.EventHandler(this.radioButton_Align_GB_RG_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_AutoWhite);
            this.groupBox3.Controls.Add(this.textBox_Blue_Gain);
            this.groupBox3.Controls.Add(this.textBox_Green_Gain);
            this.groupBox3.Controls.Add(this.textBox_Red_Gain);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(235, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 191);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gain Calibration";
            // 
            // button_AutoWhite
            // 
            this.button_AutoWhite.Location = new System.Drawing.Point(22, 150);
            this.button_AutoWhite.Name = "button_AutoWhite";
            this.button_AutoWhite.Size = new System.Drawing.Size(109, 23);
            this.button_AutoWhite.TabIndex = 6;
            this.button_AutoWhite.Text = "AutoWhiteBalance";
            this.button_AutoWhite.UseVisualStyleBackColor = true;
            this.button_AutoWhite.Click += new System.EventHandler(this.button_AutoWhite_Click);
            // 
            // textBox_Blue_Gain
            // 
            this.textBox_Blue_Gain.Location = new System.Drawing.Point(79, 106);
            this.textBox_Blue_Gain.Name = "textBox_Blue_Gain";
            this.textBox_Blue_Gain.Size = new System.Drawing.Size(70, 20);
            this.textBox_Blue_Gain.TabIndex = 5;
            this.textBox_Blue_Gain.Text = "1.0";
            this.textBox_Blue_Gain.TextChanged += new System.EventHandler(this.textBox_Blue_Gain_TextChanged);
            // 
            // textBox_Green_Gain
            // 
            this.textBox_Green_Gain.Location = new System.Drawing.Point(79, 67);
            this.textBox_Green_Gain.Name = "textBox_Green_Gain";
            this.textBox_Green_Gain.Size = new System.Drawing.Size(70, 20);
            this.textBox_Green_Gain.TabIndex = 4;
            this.textBox_Green_Gain.Text = "1.0";
            this.textBox_Green_Gain.TextChanged += new System.EventHandler(this.textBox_Green_Gain_TextChanged);
            // 
            // textBox_Red_Gain
            // 
            this.textBox_Red_Gain.Location = new System.Drawing.Point(79, 26);
            this.textBox_Red_Gain.Name = "textBox_Red_Gain";
            this.textBox_Red_Gain.Size = new System.Drawing.Size(70, 20);
            this.textBox_Red_Gain.TabIndex = 3;
            this.textBox_Red_Gain.Text = "1.0";
            this.textBox_Red_Gain.TextChanged += new System.EventHandler(this.textBox_Red_Gain_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue Gain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green Gain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red Gain";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_Gamma);
            this.groupBox4.Controls.Add(this.textBox_Gamma);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 209);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(384, 61);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gamma Correction";
            // 
            // checkBox_Gamma
            // 
            this.checkBox_Gamma.AutoSize = true;
            this.checkBox_Gamma.Location = new System.Drawing.Point(234, 26);
            this.checkBox_Gamma.Name = "checkBox_Gamma";
            this.checkBox_Gamma.Size = new System.Drawing.Size(59, 17);
            this.checkBox_Gamma.TabIndex = 2;
            this.checkBox_Gamma.Text = "Enable";
            this.checkBox_Gamma.UseVisualStyleBackColor = true;
            this.checkBox_Gamma.CheckedChanged += new System.EventHandler(this.checkBox_Gamma_CheckedChanged);
            // 
            // textBox_Gamma
            // 
            this.textBox_Gamma.Location = new System.Drawing.Point(124, 23);
            this.textBox_Gamma.Name = "textBox_Gamma";
            this.textBox_Gamma.Size = new System.Drawing.Size(83, 20);
            this.textBox_Gamma.TabIndex = 1;
            this.textBox_Gamma.Text = "1.0";
            this.textBox_Gamma.TextChanged += new System.EventHandler(this.textBox_Gamma_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gamma Factor";
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(109, 287);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(82, 24);
            this.button_Apply.TabIndex = 3;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(213, 287);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(81, 23);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Close";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // radioButton_Method4
            // 
            this.radioButton_Method4.AutoSize = true;
            this.radioButton_Method4.Location = new System.Drawing.Point(15, 98);
            this.radioButton_Method4.Name = "radioButton_Method4";
            this.radioButton_Method4.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Method4.TabIndex = 3;
            this.radioButton_Method4.TabStop = true;
            this.radioButton_Method4.Text = "Method 4";
            this.radioButton_Method4.UseVisualStyleBackColor = true;
            // 
            // radioButton_Method5
            // 
            this.radioButton_Method5.AutoSize = true;
            this.radioButton_Method5.Location = new System.Drawing.Point(15, 121);
            this.radioButton_Method5.Name = "radioButton_Method5";
            this.radioButton_Method5.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Method5.TabIndex = 4;
            this.radioButton_Method5.TabStop = true;
            this.radioButton_Method5.Text = "Method 5";
            this.radioButton_Method5.UseVisualStyleBackColor = true;
            // 
            // radioButton_Method6
            // 
            this.radioButton_Method6.AutoSize = true;
            this.radioButton_Method6.Location = new System.Drawing.Point(15, 144);
            this.radioButton_Method6.Name = "radioButton_Method6";
            this.radioButton_Method6.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Method6.TabIndex = 5;
            this.radioButton_Method6.TabStop = true;
            this.radioButton_Method6.Text = "Method 6";
            this.radioButton_Method6.UseVisualStyleBackColor = true;
            // 
            // BayerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 323);
            this.ControlBox = false;
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BayerDlg";
            this.Text = "BayerDlg";
            this.Load += new System.EventHandler(this.BayerDlg_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BayerDlg_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_Apply;
       private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.RadioButton radioButton_Method3;
        private System.Windows.Forms.RadioButton radioButton_Method2;
        private System.Windows.Forms.RadioButton radioButton_Method1;
        private System.Windows.Forms.RadioButton radioButton_Align_GR_BG;
        private System.Windows.Forms.RadioButton radioButton_Align_RG_GB;
        private System.Windows.Forms.RadioButton radioButton_Align_BG_GR;
        private System.Windows.Forms.RadioButton radioButton_Align_GB_RG;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox_Green_Gain;
        private System.Windows.Forms.TextBox textBox_Red_Gain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_AutoWhite;
        private System.Windows.Forms.TextBox textBox_Blue_Gain;
        private System.Windows.Forms.CheckBox checkBox_Gamma;
        private System.Windows.Forms.TextBox textBox_Gamma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_Method6;
        private System.Windows.Forms.RadioButton radioButton_Method5;
        private System.Windows.Forms.RadioButton radioButton_Method4;
    }
}