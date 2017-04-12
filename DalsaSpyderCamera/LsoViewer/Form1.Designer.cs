
namespace Varocto.Cameras
{
    partial class LsoViewer
    {

        private DALSA.SaperaLT.SapClassGui.ImageBox lsloImageBox;
        private DALSA.SaperaLT.SapClassGui.ImageBox octImageBox;
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
            this.lsloGroupBox = new System.Windows.Forms.GroupBox();
            this.button_Freeze = new System.Windows.Forms.Button();
            this.button_Grab = new System.Windows.Forms.Button();
            this.button_Snap = new System.Windows.Forms.Button();
            this.StatusLabelInfo = new System.Windows.Forms.Label();
            this.octGroupBox = new System.Windows.Forms.GroupBox();
            this.octFreezeButton = new System.Windows.Forms.Button();
            this.octGrabButton = new System.Windows.Forms.Button();
            this.octSnapButton = new System.Windows.Forms.Button();
            this.octSignalStatus = new System.Windows.Forms.Label();
            this.octFrameStatus = new System.Windows.Forms.Label();
            this.lsloGroupBox.SuspendLayout();
            this.octGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusLabelInfoTrash
            // 
            this.StatusLabelInfoTrash.AutoSize = true;
            this.StatusLabelInfoTrash.Location = new System.Drawing.Point(24, 608);
            this.StatusLabelInfoTrash.Name = "StatusLabelInfoTrash";
            this.StatusLabelInfoTrash.Size = new System.Drawing.Size(69, 13);
            this.StatusLabelInfoTrash.TabIndex = 0;
            this.StatusLabelInfoTrash.Text = "Frame Status";
            // 
            // lsloGroupBox
            // 
            this.lsloGroupBox.Controls.Add(this.button_Freeze);
            this.lsloGroupBox.Controls.Add(this.button_Grab);
            this.lsloGroupBox.Controls.Add(this.button_Snap);
            this.lsloGroupBox.Location = new System.Drawing.Point(24, 401);
            this.lsloGroupBox.Name = "lsloGroupBox";
            this.lsloGroupBox.Size = new System.Drawing.Size(143, 164);
            this.lsloGroupBox.TabIndex = 10;
            this.lsloGroupBox.TabStop = false;
            this.lsloGroupBox.Text = "LSLO";
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
            this.StatusLabelInfo.Location = new System.Drawing.Point(24, 582);
            this.StatusLabelInfo.Name = "StatusLabelInfo";
            this.StatusLabelInfo.Size = new System.Drawing.Size(69, 13);
            this.StatusLabelInfo.TabIndex = 11;
            this.StatusLabelInfo.Text = "Signal Status";
            // 
            // octGroupBox
            // 
            this.octGroupBox.Controls.Add(this.octFreezeButton);
            this.octGroupBox.Controls.Add(this.octGrabButton);
            this.octGroupBox.Controls.Add(this.octSnapButton);
            this.octGroupBox.Location = new System.Drawing.Point(1007, 401);
            this.octGroupBox.Name = "octGroupBox";
            this.octGroupBox.Size = new System.Drawing.Size(143, 164);
            this.octGroupBox.TabIndex = 11;
            this.octGroupBox.TabStop = false;
            this.octGroupBox.Text = "OCT";
            // 
            // octFreezeButton
            // 
            this.octFreezeButton.Location = new System.Drawing.Point(20, 115);
            this.octFreezeButton.Name = "octFreezeButton";
            this.octFreezeButton.Size = new System.Drawing.Size(105, 24);
            this.octFreezeButton.TabIndex = 2;
            this.octFreezeButton.Text = "Freeze";
            this.octFreezeButton.UseVisualStyleBackColor = true;
            this.octFreezeButton.Click += new System.EventHandler(this.octFreezeButton_Click);
            // 
            // octGrabButton
            // 
            this.octGrabButton.Location = new System.Drawing.Point(20, 72);
            this.octGrabButton.Name = "octGrabButton";
            this.octGrabButton.Size = new System.Drawing.Size(105, 24);
            this.octGrabButton.TabIndex = 1;
            this.octGrabButton.Text = "Grab";
            this.octGrabButton.UseVisualStyleBackColor = true;
            this.octGrabButton.Click += new System.EventHandler(this.octGrabButton_Click);
            // 
            // octSnapButton
            // 
            this.octSnapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.octSnapButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.octSnapButton.Location = new System.Drawing.Point(20, 29);
            this.octSnapButton.Name = "octSnapButton";
            this.octSnapButton.Size = new System.Drawing.Size(105, 25);
            this.octSnapButton.TabIndex = 0;
            this.octSnapButton.Text = "Snap";
            this.octSnapButton.UseVisualStyleBackColor = true;
            this.octSnapButton.Click += new System.EventHandler(this.octSnapButton_Click);
            // 
            // octSignalStatus
            // 
            this.octSignalStatus.AutoSize = true;
            this.octSignalStatus.Location = new System.Drawing.Point(1004, 582);
            this.octSignalStatus.Name = "octSignalStatus";
            this.octSignalStatus.Size = new System.Drawing.Size(69, 13);
            this.octSignalStatus.TabIndex = 13;
            this.octSignalStatus.Text = "Signal Status";
            // 
            // octFrameStatus
            // 
            this.octFrameStatus.AutoSize = true;
            this.octFrameStatus.Location = new System.Drawing.Point(1004, 608);
            this.octFrameStatus.Name = "octFrameStatus";
            this.octFrameStatus.Size = new System.Drawing.Size(69, 13);
            this.octFrameStatus.TabIndex = 12;
            this.octFrameStatus.Text = "Frame Status";
            // 
            // LsoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1955, 647);
            this.Controls.Add(this.octSignalStatus);
            this.Controls.Add(this.octFrameStatus);
            this.Controls.Add(this.octGroupBox);
            this.Controls.Add(this.StatusLabelInfo);
            this.Controls.Add(this.lsloGroupBox);
            this.Controls.Add(this.StatusLabelInfoTrash);
            this.Name = "LsoViewer";
            this.Text = "Form1";
            this.lsloGroupBox.ResumeLayout(false);
            this.octGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label StatusLabelInfoTrash;
        private System.Windows.Forms.GroupBox lsloGroupBox;
        private System.Windows.Forms.Button button_Freeze;
        private System.Windows.Forms.Button button_Grab;
        private System.Windows.Forms.Button button_Snap;
        private System.Windows.Forms.Label StatusLabelInfo;
        private System.Windows.Forms.GroupBox octGroupBox;
        private System.Windows.Forms.Button octFreezeButton;
        private System.Windows.Forms.Button octGrabButton;
        private System.Windows.Forms.Button octSnapButton;
        private System.Windows.Forms.Label octSignalStatus;
        private System.Windows.Forms.Label octFrameStatus;
    }
}

