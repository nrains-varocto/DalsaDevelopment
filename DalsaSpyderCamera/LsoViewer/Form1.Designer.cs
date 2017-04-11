
namespace Varocto.Cameras
{
    partial class LsoViewer
    {

        private DALSA.SaperaLT.SapClassGui.ImageBox m_ImageBox;
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
            this.StatusLabelInfoTrash = new System.Windows.Forms.Label();
            this.groupBox1_Acquisition = new System.Windows.Forms.GroupBox();
            this.button_Freeze = new System.Windows.Forms.Button();
            this.button_Grab = new System.Windows.Forms.Button();
            this.button_Snap = new System.Windows.Forms.Button();
            this.StatusLabelInfo = new System.Windows.Forms.Label();
            this.groupBox1_Acquisition.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusLabelInfoTrash
            // 
            this.StatusLabelInfoTrash.AutoSize = true;
            this.StatusLabelInfoTrash.Location = new System.Drawing.Point(12, 493);
            this.StatusLabelInfoTrash.Name = "StatusLabelInfoTrash";
            this.StatusLabelInfoTrash.Size = new System.Drawing.Size(69, 13);
            this.StatusLabelInfoTrash.TabIndex = 0;
            this.StatusLabelInfoTrash.Text = "Frame Status";
            // 
            // groupBox1_Acquisition
            // 
            this.groupBox1_Acquisition.Controls.Add(this.button_Freeze);
            this.groupBox1_Acquisition.Controls.Add(this.button_Grab);
            this.groupBox1_Acquisition.Controls.Add(this.button_Snap);
            this.groupBox1_Acquisition.Location = new System.Drawing.Point(12, 286);
            this.groupBox1_Acquisition.Name = "groupBox1_Acquisition";
            this.groupBox1_Acquisition.Size = new System.Drawing.Size(143, 164);
            this.groupBox1_Acquisition.TabIndex = 10;
            this.groupBox1_Acquisition.TabStop = false;
            this.groupBox1_Acquisition.Text = "Acquisition Control";
            // 
            // button_Freeze
            // 
            this.button_Freeze.Location = new System.Drawing.Point(20, 115);
            this.button_Freeze.Name = "button_Freeze";
            this.button_Freeze.Size = new System.Drawing.Size(105, 24);
            this.button_Freeze.TabIndex = 2;
            this.button_Freeze.Text = "Freeze";
            this.button_Freeze.UseVisualStyleBackColor = true;
            this.button_Freeze.Click += new System.EventHandler(this.button_Freeze_Click_1);
            // 
            // button_Grab
            // 
            this.button_Grab.Location = new System.Drawing.Point(20, 72);
            this.button_Grab.Name = "button_Grab";
            this.button_Grab.Size = new System.Drawing.Size(105, 24);
            this.button_Grab.TabIndex = 1;
            this.button_Grab.Text = "Grab";
            this.button_Grab.UseVisualStyleBackColor = true;
            this.button_Grab.Click += new System.EventHandler(this.button_Grab_Click_1);
            // 
            // button_Snap
            // 
            this.button_Snap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Snap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Snap.Location = new System.Drawing.Point(20, 29);
            this.button_Snap.Name = "button_Snap";
            this.button_Snap.Size = new System.Drawing.Size(105, 25);
            this.button_Snap.TabIndex = 0;
            this.button_Snap.Text = "Snap";
            this.button_Snap.UseVisualStyleBackColor = true;
            this.button_Snap.Click += new System.EventHandler(this.button_Snap_Click);
            // 
            // StatusLabelInfo
            // 
            this.StatusLabelInfo.AutoSize = true;
            this.StatusLabelInfo.Location = new System.Drawing.Point(12, 467);
            this.StatusLabelInfo.Name = "StatusLabelInfo";
            this.StatusLabelInfo.Size = new System.Drawing.Size(69, 13);
            this.StatusLabelInfo.TabIndex = 11;
            this.StatusLabelInfo.Text = "Signal Status";
            // 
            // LsoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 518);
            this.Controls.Add(this.StatusLabelInfo);
            this.Controls.Add(this.groupBox1_Acquisition);
            this.Controls.Add(this.StatusLabelInfoTrash);
            this.Name = "LsoViewer";
            this.Text = "Form1";
            this.groupBox1_Acquisition.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label StatusLabelInfoTrash;
        private System.Windows.Forms.GroupBox groupBox1_Acquisition;
        private System.Windows.Forms.Button button_Freeze;
        private System.Windows.Forms.Button button_Grab;
        private System.Windows.Forms.Button button_Snap;
        private System.Windows.Forms.Label StatusLabelInfo;
    }
}

