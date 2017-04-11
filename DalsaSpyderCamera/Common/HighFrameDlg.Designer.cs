namespace DALSA.SaperaLT.SapClassGui
{
    partial class HighFrameDlg
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UpDown_Frame = new System.Windows.Forms.NumericUpDown();
            this.UpDown_Frame_Onboard = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Frame_Onboard)).BeginInit();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(288, 9);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(288, 42);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Frame per Callback :";
            // 
            // UpDown_Frame
            // 
            this.UpDown_Frame.Location = new System.Drawing.Point(178, 9);
            this.UpDown_Frame.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.UpDown_Frame.Name = "UpDown_Frame";
            this.UpDown_Frame.Size = new System.Drawing.Size(65, 20);
            this.UpDown_Frame.TabIndex = 3;
            // 
            // UpDown_Frame_Onboard
            // 
            this.UpDown_Frame_Onboard.Location = new System.Drawing.Point(178, 45);
            this.UpDown_Frame_Onboard.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.UpDown_Frame_Onboard.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.UpDown_Frame_Onboard.Name = "UpDown_Frame_Onboard";
            this.UpDown_Frame_Onboard.Size = new System.Drawing.Size(65, 20);
            this.UpDown_Frame_Onboard.TabIndex = 5;
            this.UpDown_Frame_Onboard.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Frame on Board :";
            // 
            // HighFrameDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 78);
            this.ControlBox = false;
            this.Controls.Add(this.UpDown_Frame_Onboard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpDown_Frame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Name = "HighFrameDlg";
            this.Text = "High Frame Rate Setting";
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Frame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Frame_Onboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown UpDown_Frame;
        private System.Windows.Forms.NumericUpDown UpDown_Frame_Onboard;
        private System.Windows.Forms.Label label2;
        private int m_Frame_per_Callback = 1;
        private int m_Frame_on_Board = 2;
       
    }
}