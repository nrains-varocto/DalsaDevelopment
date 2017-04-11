namespace DALSA.SaperaLT.SapClassGui
{
    partial class FlatFieldDlg
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.textBox_Max_Dev = new System.Windows.Forms.TextBox();
         this.textBox_Vert_Offset = new System.Windows.Forms.TextBox();
         this.textBox_Frame_Avg = new System.Windows.Forms.TextBox();
         this.textBox_Line_Avg = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.comboBox_Correction_Type = new System.Windows.Forms.ComboBox();
         this.comboBox_Video_Type = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.comboBox_Calibration_Index = new System.Windows.Forms.ComboBox();
         this.label9 = new System.Windows.Forms.Label();
         this.label_darkImage1 = new System.Windows.Forms.Label();
         this.label_darkImage2 = new System.Windows.Forms.Label();
         this.label_brightImage2 = new System.Windows.Forms.Label();
         this.label_brightImage1 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.button_Acq_Dark = new System.Windows.Forms.Button();
         this.button_Acq_Bright = new System.Windows.Forms.Button();
         this.LogMessageBox = new System.Windows.Forms.ListBox();
         this.button_OK = new System.Windows.Forms.Button();
         this.button_Cancel = new System.Windows.Forms.Button();
         this.ClippedCoefsDefects_checkbox = new System.Windows.Forms.CheckBox();
         this.label10 = new System.Windows.Forms.Label();
         this.button_Save_and_Upload = new System.Windows.Forms.Button();
         this.saveLabel = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.comboBox_FlatField_Selector = new System.Windows.Forms.ComboBox();
         this.label_flatField = new System.Windows.Forms.Label();
         this.button_load_cluster = new System.Windows.Forms.Button();
         this.label_load_cluster = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label_load_cluster);
         this.groupBox1.Controls.Add(this.button_load_cluster);
         this.groupBox1.Controls.Add(this.textBox_Max_Dev);
         this.groupBox1.Controls.Add(this.textBox_Vert_Offset);
         this.groupBox1.Controls.Add(this.textBox_Frame_Avg);
         this.groupBox1.Controls.Add(this.textBox_Line_Avg);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.comboBox_Correction_Type);
         this.groupBox1.Controls.Add(this.comboBox_Video_Type);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(458, 214);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Parameters";
         // 
         // textBox_Max_Dev
         // 
         this.textBox_Max_Dev.Location = new System.Drawing.Point(265, 141);
         this.textBox_Max_Dev.Name = "textBox_Max_Dev";
         this.textBox_Max_Dev.Size = new System.Drawing.Size(117, 20);
         this.textBox_Max_Dev.TabIndex = 12;
         // 
         // textBox_Vert_Offset
         // 
         this.textBox_Vert_Offset.Location = new System.Drawing.Point(18, 142);
         this.textBox_Vert_Offset.Name = "textBox_Vert_Offset";
         this.textBox_Vert_Offset.Size = new System.Drawing.Size(109, 20);
         this.textBox_Vert_Offset.TabIndex = 11;
         // 
         // textBox_Frame_Avg
         // 
         this.textBox_Frame_Avg.Location = new System.Drawing.Point(265, 89);
         this.textBox_Frame_Avg.Name = "textBox_Frame_Avg";
         this.textBox_Frame_Avg.Size = new System.Drawing.Size(117, 20);
         this.textBox_Frame_Avg.TabIndex = 10;
         // 
         // textBox_Line_Avg
         // 
         this.textBox_Line_Avg.Location = new System.Drawing.Point(18, 89);
         this.textBox_Line_Avg.Name = "textBox_Line_Avg";
         this.textBox_Line_Avg.Size = new System.Drawing.Size(109, 20);
         this.textBox_Line_Avg.TabIndex = 9;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(262, 125);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(86, 13);
         this.label7.TabIndex = 8;
         this.label7.Text = "mean pixel value";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(262, 112);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(120, 13);
         this.label6.TabIndex = 7;
         this.label6.Text = "Maximum deviation from";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(15, 124);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(112, 13);
         this.label5.TabIndex = 6;
         this.label5.Text = "Vertical offset from top";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(262, 73);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(139, 13);
         this.label4.TabIndex = 5;
         this.label4.Text = "Number of frame to average";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(15, 73);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(129, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Number of line to average";
         // 
         // comboBox_Correction_Type
         // 
         this.comboBox_Correction_Type.FormattingEnabled = true;
         this.comboBox_Correction_Type.Location = new System.Drawing.Point(18, 32);
         this.comboBox_Correction_Type.Name = "comboBox_Correction_Type";
         this.comboBox_Correction_Type.Size = new System.Drawing.Size(159, 21);
         this.comboBox_Correction_Type.TabIndex = 3;
         this.comboBox_Correction_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Correction_Type_SelectedIndexChanged);
         // 
         // comboBox_Video_Type
         // 
         this.comboBox_Video_Type.FormattingEnabled = true;
         this.comboBox_Video_Type.Location = new System.Drawing.Point(265, 33);
         this.comboBox_Video_Type.Name = "comboBox_Video_Type";
         this.comboBox_Video_Type.Size = new System.Drawing.Size(153, 21);
         this.comboBox_Video_Type.TabIndex = 2;
         this.comboBox_Video_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Video_Type_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(279, 17);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(61, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Video Type";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(15, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(82, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Correction Type";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(9, 247);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(84, 13);
         this.label8.TabIndex = 1;
         this.label8.Text = "Calibration index";
         // 
         // comboBox_Calibration_Index
         // 
         this.comboBox_Calibration_Index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_Calibration_Index.FormattingEnabled = true;
         this.comboBox_Calibration_Index.Location = new System.Drawing.Point(99, 246);
         this.comboBox_Calibration_Index.Name = "comboBox_Calibration_Index";
         this.comboBox_Calibration_Index.Size = new System.Drawing.Size(100, 21);
         this.comboBox_Calibration_Index.TabIndex = 2;
         this.comboBox_Calibration_Index.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(11, 292);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(44, 13);
         this.label9.TabIndex = 3;
         this.label9.Text = "Step 1 :";
         // 
         // label_darkImage1
         // 
         this.label_darkImage1.AutoSize = true;
         this.label_darkImage1.Location = new System.Drawing.Point(50, 292);
         this.label_darkImage1.Name = "label_darkImage1";
         this.label_darkImage1.Size = new System.Drawing.Size(107, 13);
         this.label_darkImage1.TabIndex = 4;
         this.label_darkImage1.Text = "Acquire a dark image";
         // 
         // label_darkImage2
         // 
         this.label_darkImage2.AutoSize = true;
         this.label_darkImage2.Location = new System.Drawing.Point(50, 307);
         this.label_darkImage2.Name = "label_darkImage2";
         this.label_darkImage2.Size = new System.Drawing.Size(203, 13);
         this.label_darkImage2.TabIndex = 5;
         this.label_darkImage2.Text = "Pixels mean under 20 level recommanded";
         // 
         // label_brightImage2
         // 
         this.label_brightImage2.AutoSize = true;
         this.label_brightImage2.Location = new System.Drawing.Point(50, 351);
         this.label_brightImage2.Name = "label_brightImage2";
         this.label_brightImage2.Size = new System.Drawing.Size(215, 13);
         this.label_brightImage2.TabIndex = 8;
         this.label_brightImage2.Text = "Pixels mean around 128 level recommanded";
         // 
         // label_brightImage1
         // 
         this.label_brightImage1.AutoSize = true;
         this.label_brightImage1.Location = new System.Drawing.Point(50, 335);
         this.label_brightImage1.Name = "label_brightImage1";
         this.label_brightImage1.Size = new System.Drawing.Size(180, 13);
         this.label_brightImage1.TabIndex = 7;
         this.label_brightImage1.Text = "Acquire a non-saturated bright image";
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(11, 335);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(44, 13);
         this.label14.TabIndex = 6;
         this.label14.Text = "Step 2 :";
         // 
         // button_Acq_Dark
         // 
         this.button_Acq_Dark.Location = new System.Drawing.Point(297, 292);
         this.button_Acq_Dark.Name = "button_Acq_Dark";
         this.button_Acq_Dark.Size = new System.Drawing.Size(168, 21);
         this.button_Acq_Dark.TabIndex = 9;
         this.button_Acq_Dark.Text = "Acquire Dark Image";
         this.button_Acq_Dark.UseVisualStyleBackColor = true;
         this.button_Acq_Dark.Click += new System.EventHandler(this.button_Acq_Dark_Click);
         // 
         // button_Acq_Bright
         // 
         this.button_Acq_Bright.Location = new System.Drawing.Point(297, 335);
         this.button_Acq_Bright.Name = "button_Acq_Bright";
         this.button_Acq_Bright.Size = new System.Drawing.Size(168, 21);
         this.button_Acq_Bright.TabIndex = 10;
         this.button_Acq_Bright.Text = "Acquire Bright Image";
         this.button_Acq_Bright.UseVisualStyleBackColor = true;
         this.button_Acq_Bright.Click += new System.EventHandler(this.button_Acq_Bright_Click);
         // 
         // LogMessageBox
         // 
         this.LogMessageBox.FormattingEnabled = true;
         this.LogMessageBox.Location = new System.Drawing.Point(12, 484);
         this.LogMessageBox.Name = "LogMessageBox";
         this.LogMessageBox.Size = new System.Drawing.Size(453, 108);
         this.LogMessageBox.TabIndex = 12;
         // 
         // button_OK
         // 
         this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button_OK.Location = new System.Drawing.Point(141, 614);
         this.button_OK.Name = "button_OK";
         this.button_OK.Size = new System.Drawing.Size(75, 23);
         this.button_OK.TabIndex = 13;
         this.button_OK.Text = "OK";
         this.button_OK.UseVisualStyleBackColor = true;
         this.button_OK.Click += new System.EventHandler(this.button1_Click);
         // 
         // button_Cancel
         // 
         this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button_Cancel.Location = new System.Drawing.Point(266, 614);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(75, 23);
         this.button_Cancel.TabIndex = 14;
         this.button_Cancel.Text = "Cancel";
         this.button_Cancel.UseVisualStyleBackColor = true;
         this.button_Cancel.Click += new System.EventHandler(this.button2_Click);
         // 
         // ClippedCoefsDefects_checkbox
         // 
         this.ClippedCoefsDefects_checkbox.AutoSize = true;
         this.ClippedCoefsDefects_checkbox.Location = new System.Drawing.Point(450, 254);
         this.ClippedCoefsDefects_checkbox.Name = "ClippedCoefsDefects_checkbox";
         this.ClippedCoefsDefects_checkbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.ClippedCoefsDefects_checkbox.Size = new System.Drawing.Size(15, 14);
         this.ClippedCoefsDefects_checkbox.TabIndex = 15;
         this.ClippedCoefsDefects_checkbox.UseVisualStyleBackColor = true;
         // 
         // label10
         // 
         this.label10.Location = new System.Drawing.Point(286, 243);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(160, 41);
         this.label10.TabIndex = 16;
         this.label10.Text = "Consider as defective pixel with offset or gain coefficient that reaches the hard" +
    "ware limit\n";
         // 
         // button_Save_and_Upload
         // 
         this.button_Save_and_Upload.Location = new System.Drawing.Point(297, 381);
         this.button_Save_and_Upload.Name = "button_Save_and_Upload";
         this.button_Save_and_Upload.Size = new System.Drawing.Size(168, 21);
         this.button_Save_and_Upload.TabIndex = 17;
         this.button_Save_and_Upload.Text = "Save and Upload";
         this.button_Save_and_Upload.UseVisualStyleBackColor = true;
         this.button_Save_and_Upload.Click += new System.EventHandler(this.button_Save_and_Upload_Click_1);
         // 
         // saveLabel
         // 
         this.saveLabel.AutoSize = true;
         this.saveLabel.Location = new System.Drawing.Point(50, 381);
         this.saveLabel.Name = "saveLabel";
         this.saveLabel.Size = new System.Drawing.Size(226, 13);
         this.saveLabel.TabIndex = 20;
         this.saveLabel.Text = "Save Calibration offset and gain files (Optional)";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(50, 381);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(180, 13);
         this.label12.TabIndex = 19;
         this.label12.Text = "Acquire a non-saturated bright image";
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(11, 381);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(41, 13);
         this.label13.TabIndex = 18;
         this.label13.Text = "Step 3:";
         // 
         // comboBox_FlatField_Selector
         // 
         this.comboBox_FlatField_Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_FlatField_Selector.FormattingEnabled = true;
         this.comboBox_FlatField_Selector.Location = new System.Drawing.Point(297, 444);
         this.comboBox_FlatField_Selector.Name = "comboBox_FlatField_Selector";
         this.comboBox_FlatField_Selector.Size = new System.Drawing.Size(168, 21);
         this.comboBox_FlatField_Selector.TabIndex = 21;
         // 
         // label_flatField
         // 
         this.label_flatField.AutoSize = true;
         this.label_flatField.Location = new System.Drawing.Point(300, 420);
         this.label_flatField.Name = "label_flatField";
         this.label_flatField.Size = new System.Drawing.Size(140, 13);
         this.label_flatField.TabIndex = 22;
         this.label_flatField.Text = "to user Flat Field Destination";
         // 
         // button_load_cluster
         // 
         this.button_load_cluster.Location = new System.Drawing.Point(18, 179);
         this.button_load_cluster.Name = "button_load_cluster";
         this.button_load_cluster.Size = new System.Drawing.Size(109, 23);
         this.button_load_cluster.TabIndex = 13;
         this.button_load_cluster.Text = "Load cluster map";
         this.button_load_cluster.UseVisualStyleBackColor = true;
         this.button_load_cluster.Click += new System.EventHandler(this.button_load_cluster_Click);
         // 
         // label_load_cluster
         // 
         this.label_load_cluster.AutoSize = true;
         this.label_load_cluster.Location = new System.Drawing.Point(133, 184);
         this.label_load_cluster.Name = "label_load_cluster";
         this.label_load_cluster.Size = new System.Drawing.Size(116, 13);
         this.label_load_cluster.TabIndex = 14;
         this.label_load_cluster.Text = "No defined cluster map";
         // 
         // FlatFieldDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(482, 682);
         this.ControlBox = false;
         this.Controls.Add(this.label_flatField);
         this.Controls.Add(this.comboBox_FlatField_Selector);
         this.Controls.Add(this.saveLabel);
         this.Controls.Add(this.label12);
         this.Controls.Add(this.label13);
         this.Controls.Add(this.button_Save_and_Upload);
         this.Controls.Add(this.label10);
         this.Controls.Add(this.ClippedCoefsDefects_checkbox);
         this.Controls.Add(this.button_Cancel);
         this.Controls.Add(this.button_OK);
         this.Controls.Add(this.LogMessageBox);
         this.Controls.Add(this.button_Acq_Bright);
         this.Controls.Add(this.button_Acq_Dark);
         this.Controls.Add(this.label_brightImage2);
         this.Controls.Add(this.label_brightImage1);
         this.Controls.Add(this.label14);
         this.Controls.Add(this.label_darkImage2);
         this.Controls.Add(this.label_darkImage1);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.comboBox_Calibration_Index);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.groupBox1);
         this.Name = "FlatFieldDlg";
         this.Text = "FlatFieldDlg";
         this.Load += new System.EventHandler(this.FlatFieldDlg_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Correction_Type;
        private System.Windows.Forms.ComboBox comboBox_Video_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Max_Dev;
        private System.Windows.Forms.TextBox textBox_Vert_Offset;
        private System.Windows.Forms.TextBox textBox_Frame_Avg;
        private System.Windows.Forms.TextBox textBox_Line_Avg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_Calibration_Index;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_darkImage1;
        private System.Windows.Forms.Label label_darkImage2;
        private System.Windows.Forms.Label label_brightImage2;
        private System.Windows.Forms.Label label_brightImage1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_Acq_Dark;
        private System.Windows.Forms.Button button_Acq_Bright;
        private System.Windows.Forms.ListBox LogMessageBox;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
       private System.Windows.Forms.CheckBox ClippedCoefsDefects_checkbox;
       private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_Save_and_Upload;
        private System.Windows.Forms.Label saveLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox_FlatField_Selector;
        private System.Windows.Forms.Label label_flatField;
        private System.Windows.Forms.Label label_load_cluster;
        private System.Windows.Forms.Button button_load_cluster;
    }
}