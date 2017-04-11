namespace DALSA.SaperaLT.SapClassGui
{
    partial class ImageBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           this.picBox = new System.Windows.Forms.PictureBox();
           this.vScroll = new System.Windows.Forms.VScrollBar();
           this.hScroll = new System.Windows.Forms.HScrollBar();
           this.Slider = new System.Windows.Forms.TrackBar();
           ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
           this.SuspendLayout();
           // 
           // picBox
           // 
           this.picBox.Location = new System.Drawing.Point(0, 0);
           this.picBox.Name = "picBox";
           this.picBox.Size = new System.Drawing.Size(366, 340);
           this.picBox.TabIndex = 0;
           this.picBox.TabStop = false;
           // 
           // vScroll
           // 
           this.vScroll.Location = new System.Drawing.Point(368, 0);
           this.vScroll.Name = "vScroll";
           this.vScroll.Size = new System.Drawing.Size(17, 340);
           this.vScroll.TabIndex = 1;
           // 
           // hScroll
           // 
           this.hScroll.Location = new System.Drawing.Point(0, 340);
           this.hScroll.Name = "hScroll";
           this.hScroll.Size = new System.Drawing.Size(362, 17);
           this.hScroll.TabIndex = 2;
           // 
           // Slider
           // 
           this.Slider.Location = new System.Drawing.Point(3, 360);
           this.Slider.Name = "Slider";
           this.Slider.Size = new System.Drawing.Size(382, 42);
           this.Slider.TabIndex = 7; 
           // 
           // ImageBox
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.Slider);
           this.Controls.Add(this.hScroll);
           this.Controls.Add(this.vScroll);
           this.Controls.Add(this.picBox);
           this.Name = "ImageBox";
           this.Size = new System.Drawing.Size(386, 406);
           ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion 
    }
}