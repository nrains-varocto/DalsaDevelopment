using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DALSA.SaperaLT.SapClassBasic;


namespace DALSA.SaperaLT.SapClassGui
{
    public partial class AbortDlg : Form
    {
        public AbortDlg(SapTransfer pXfer)
        {
            InitializeComponent();
            m_pXfer = pXfer;
            timer.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_pXfer.Wait(0))
            {
                timer.Enabled = false;
                this.DialogResult = DialogResult.OK;
                this.Close();           
            }
            // Show window if time is out
            else if (!m_bShow )
            {
                this.Opacity = 100;
                m_bShow = true;
            }
        }   
    }
}