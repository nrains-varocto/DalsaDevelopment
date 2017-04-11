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
    public partial class HighFrameDlg : Form
    {
        public HighFrameDlg(int Frame, int Frame_Onboard, SapTransfer pXfer)
        {
            InitializeComponent();
            UpDown_Frame.Value = (decimal)Frame;
            
            if (pXfer != null)
            {
                UpDown_Frame_Onboard.Value = (decimal)Frame_Onboard;
                // Check if on-board buffers is supported
                int capIntBuffers = 0;

                if (pXfer.IsCapabilityAvailable(SapTransfer.Cap.NB_INT_BUFFERS))
                    pXfer.GetCapability(SapTransfer.Cap.NB_INT_BUFFERS, out capIntBuffers);

                if (!(capIntBuffers == (int)SapTransfer.Val.NB_INT_BUFFERS_AUTO))
                {
                    // This feature is not supported; disable control
                    UpDown_Frame_Onboard.Value = 2;
                    UpDown_Frame_Onboard.Enabled = false;
                }
            }
            else
            {
                UpDown_Frame_Onboard.Enabled = false;
                UpDown_Frame_Onboard.Hide();
                label2.Hide();
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            m_Frame_per_Callback = (int)UpDown_Frame.Value;
            m_Frame_on_Board = (int)UpDown_Frame_Onboard.Value;
        }

        public int Frame_Per_Callback
        {
            get { return m_Frame_per_Callback; } 
        }

        public int Frame_On_Board
        {
            get { return m_Frame_on_Board; }
        }
    }
}