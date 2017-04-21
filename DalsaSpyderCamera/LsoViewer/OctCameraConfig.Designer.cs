namespace LsoViewer
{
    partial class OctCameraConfig
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
            this.testPatternLabel = new System.Windows.Forms.Label();
            this.testPatterComboBox = new System.Windows.Forms.ComboBox();
            this.triggerModeLabel = new System.Windows.Forms.Label();
            this.triggerModeComboBox = new System.Windows.Forms.ComboBox();
            this.linePeriodTextBox = new System.Windows.Forms.TextBox();
            this.exposureTimeTextBox = new System.Windows.Forms.TextBox();
            this.maxExposureTimeTextBox = new System.Windows.Forms.TextBox();
            this.bitDepthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bitDepthLabel = new System.Windows.Forms.Label();
            this.maxExposureTimeLabel = new System.Windows.Forms.Label();
            this.exposureTimeLabel = new System.Windows.Forms.Label();
            this.linePeriodLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testImageHeightLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.reverseEnabledCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bitDepthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // testPatternLabel
            // 
            this.testPatternLabel.AutoSize = true;
            this.testPatternLabel.Location = new System.Drawing.Point(47, 234);
            this.testPatternLabel.Name = "testPatternLabel";
            this.testPatternLabel.Size = new System.Drawing.Size(65, 13);
            this.testPatternLabel.TabIndex = 11;
            this.testPatternLabel.Text = "Test Pattern";
            // 
            // testPatterComboBox
            // 
            this.testPatterComboBox.FormattingEnabled = true;
            this.testPatterComboBox.Location = new System.Drawing.Point(142, 234);
            this.testPatterComboBox.Name = "testPatterComboBox";
            this.testPatterComboBox.Size = new System.Drawing.Size(285, 21);
            this.testPatterComboBox.TabIndex = 10;
            this.testPatterComboBox.SelectedValueChanged += new System.EventHandler(this.testPatterComboBox_SelectedValueChanged);
            // 
            // triggerModeLabel
            // 
            this.triggerModeLabel.AutoSize = true;
            this.triggerModeLabel.Location = new System.Drawing.Point(47, 273);
            this.triggerModeLabel.Name = "triggerModeLabel";
            this.triggerModeLabel.Size = new System.Drawing.Size(70, 13);
            this.triggerModeLabel.TabIndex = 13;
            this.triggerModeLabel.Text = "Trigger Mode";
            // 
            // triggerModeComboBox
            // 
            this.triggerModeComboBox.FormattingEnabled = true;
            this.triggerModeComboBox.Location = new System.Drawing.Point(142, 273);
            this.triggerModeComboBox.Name = "triggerModeComboBox";
            this.triggerModeComboBox.Size = new System.Drawing.Size(285, 21);
            this.triggerModeComboBox.TabIndex = 12;
            this.triggerModeComboBox.SelectedIndexChanged += new System.EventHandler(this.triggerModeComboBox_SelectedIndexChanged);
            // 
            // linePeriodTextBox
            // 
            this.linePeriodTextBox.Location = new System.Drawing.Point(395, 52);
            this.linePeriodTextBox.Name = "linePeriodTextBox";
            this.linePeriodTextBox.Size = new System.Drawing.Size(25, 20);
            this.linePeriodTextBox.TabIndex = 14;
            // 
            // exposureTimeTextBox
            // 
            this.exposureTimeTextBox.Location = new System.Drawing.Point(395, 88);
            this.exposureTimeTextBox.Name = "exposureTimeTextBox";
            this.exposureTimeTextBox.Size = new System.Drawing.Size(25, 20);
            this.exposureTimeTextBox.TabIndex = 15;
            // 
            // maxExposureTimeTextBox
            // 
            this.maxExposureTimeTextBox.Location = new System.Drawing.Point(395, 127);
            this.maxExposureTimeTextBox.Name = "maxExposureTimeTextBox";
            this.maxExposureTimeTextBox.Size = new System.Drawing.Size(25, 20);
            this.maxExposureTimeTextBox.TabIndex = 16;
            // 
            // bitDepthNumericUpDown
            // 
            this.bitDepthNumericUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.bitDepthNumericUpDown.Location = new System.Drawing.Point(395, 168);
            this.bitDepthNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.bitDepthNumericUpDown.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.bitDepthNumericUpDown.Name = "bitDepthNumericUpDown";
            this.bitDepthNumericUpDown.Size = new System.Drawing.Size(36, 20);
            this.bitDepthNumericUpDown.TabIndex = 17;
            this.bitDepthNumericUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // bitDepthLabel
            // 
            this.bitDepthLabel.AutoSize = true;
            this.bitDepthLabel.Location = new System.Drawing.Point(341, 168);
            this.bitDepthLabel.Name = "bitDepthLabel";
            this.bitDepthLabel.Size = new System.Drawing.Size(48, 13);
            this.bitDepthLabel.TabIndex = 18;
            this.bitDepthLabel.Text = "bit depth";
            // 
            // maxExposureTimeLabel
            // 
            this.maxExposureTimeLabel.AutoSize = true;
            this.maxExposureTimeLabel.Location = new System.Drawing.Point(275, 130);
            this.maxExposureTimeLabel.Name = "maxExposureTimeLabel";
            this.maxExposureTimeLabel.Size = new System.Drawing.Size(114, 13);
            this.maxExposureTimeLabel.TabIndex = 19;
            this.maxExposureTimeLabel.Text = "max exposure time (us)";
            // 
            // exposureTimeLabel
            // 
            this.exposureTimeLabel.AutoSize = true;
            this.exposureTimeLabel.Location = new System.Drawing.Point(297, 91);
            this.exposureTimeLabel.Name = "exposureTimeLabel";
            this.exposureTimeLabel.Size = new System.Drawing.Size(92, 13);
            this.exposureTimeLabel.TabIndex = 20;
            this.exposureTimeLabel.Text = "exposure time (us)";
            // 
            // linePeriodLabel
            // 
            this.linePeriodLabel.AutoSize = true;
            this.linePeriodLabel.Location = new System.Drawing.Point(314, 55);
            this.linePeriodLabel.Name = "linePeriodLabel";
            this.linePeriodLabel.Size = new System.Drawing.Size(75, 13);
            this.linePeriodLabel.TabIndex = 21;
            this.linePeriodLabel.Text = "line period (us)";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(395, 12);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(25, 20);
            this.widthTextBox.TabIndex = 22;
            this.widthTextBox.TextChanged += new System.EventHandler(this.widthTextBox_TextChanged);
            this.widthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "width";
            // 
            // testImageHeightLabel
            // 
            this.testImageHeightLabel.AutoSize = true;
            this.testImageHeightLabel.Location = new System.Drawing.Point(297, 207);
            this.testImageHeightLabel.Name = "testImageHeightLabel";
            this.testImageHeightLabel.Size = new System.Drawing.Size(87, 13);
            this.testImageHeightLabel.TabIndex = 25;
            this.testImageHeightLabel.Text = "test image height";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(395, 204);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(25, 20);
            this.textBox1.TabIndex = 24;
            // 
            // reverseEnabledCheckBox
            // 
            this.reverseEnabledCheckBox.AutoSize = true;
            this.reverseEnabledCheckBox.Location = new System.Drawing.Point(339, 321);
            this.reverseEnabledCheckBox.Name = "reverseEnabledCheckBox";
            this.reverseEnabledCheckBox.Size = new System.Drawing.Size(112, 17);
            this.reverseEnabledCheckBox.TabIndex = 26;
            this.reverseEnabledCheckBox.Text = "reverse X enabled";
            this.reverseEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // OctCameraConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 400);
            this.Controls.Add(this.reverseEnabledCheckBox);
            this.Controls.Add(this.testImageHeightLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.linePeriodLabel);
            this.Controls.Add(this.exposureTimeLabel);
            this.Controls.Add(this.maxExposureTimeLabel);
            this.Controls.Add(this.bitDepthLabel);
            this.Controls.Add(this.bitDepthNumericUpDown);
            this.Controls.Add(this.maxExposureTimeTextBox);
            this.Controls.Add(this.exposureTimeTextBox);
            this.Controls.Add(this.linePeriodTextBox);
            this.Controls.Add(this.triggerModeLabel);
            this.Controls.Add(this.triggerModeComboBox);
            this.Controls.Add(this.testPatternLabel);
            this.Controls.Add(this.testPatterComboBox);
            this.Name = "OctCameraConfig";
            this.Text = "OctCameraConfig";
            ((System.ComponentModel.ISupportInitialize)(this.bitDepthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testPatternLabel;
        private System.Windows.Forms.ComboBox testPatterComboBox;
        private System.Windows.Forms.Label triggerModeLabel;
        private System.Windows.Forms.ComboBox triggerModeComboBox;
        private System.Windows.Forms.TextBox linePeriodTextBox;
        private System.Windows.Forms.TextBox exposureTimeTextBox;
        private System.Windows.Forms.TextBox maxExposureTimeTextBox;
        private System.Windows.Forms.NumericUpDown bitDepthNumericUpDown;
        private System.Windows.Forms.Label bitDepthLabel;
        private System.Windows.Forms.Label maxExposureTimeLabel;
        private System.Windows.Forms.Label exposureTimeLabel;
        private System.Windows.Forms.Label linePeriodLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label testImageHeightLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox reverseEnabledCheckBox;
    }
}