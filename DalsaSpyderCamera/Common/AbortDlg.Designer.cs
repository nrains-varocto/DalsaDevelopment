using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Windows;
using System.Windows.Forms;

namespace DALSA.SaperaLT.SapClassGui
{
    partial class AbortDlg
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
           this.components = new System.ComponentModel.Container();
           this.button_Abort = new System.Windows.Forms.Button();
           this.timer = new System.Windows.Forms.Timer(this.components);
           this.SuspendLayout();
           // 
           // button_Abort
           // 
           this.button_Abort.Location = new System.Drawing.Point(67, 19);
           this.button_Abort.Name = "button_Abort";
           this.button_Abort.Size = new System.Drawing.Size(121, 24);
           this.button_Abort.TabIndex = 0;
           this.button_Abort.Text = "Abort";
           this.button_Abort.UseVisualStyleBackColor = true;
           this.button_Abort.Click += new System.EventHandler(this.button1_Click);
           // 
           // timer
           // 
           this.timer.Tick += new System.EventHandler(this.timer1_Tick);
           // 
           // AbortDlg
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(264, 56);
           this.ControlBox = false;
           this.Controls.Add(this.button_Abort);
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "AbortDlg";
           this.Opacity = 0;
           this.Text = "Waiting for grab to terminate...";
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Abort;

        private SapTransfer m_pXfer;
        private bool m_bShow;
        public DialogResult result;
        private System.Windows.Forms.Timer timer;
    }
}