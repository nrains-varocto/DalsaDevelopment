using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;

namespace DALSA.SaperaLT.SapClassGui
{
    public partial class BayerDlg : Form
    {

       private SapBayer m_pBayer;
       private SapTransfer m_pXfer;
       private SapProcessing m_pPro;
       private ImageBox m_pImageWnd;
       SapBayer.AlignMode m_Align;
       SapBayer.CalculationMethod m_Method;

       public BayerDlg(SapBayer pBayer, SapTransfer pXfer, ImageBox pImageWnd, SapProcessing pPro)
       {
            InitializeComponent();

            m_pBayer = pBayer;
            m_pXfer = pXfer;
            m_pPro = pPro;
            m_pImageWnd = pImageWnd;
       }

       private void BayerDlg_Load(object sender, EventArgs e)
       {
         if (m_pBayer == null)
         {
            MessageBox.Show("No Bayer object specified");
            this.Close();
            return;
         }
         m_Align = m_pBayer.Align;
         m_Method = m_pBayer.Method;
         m_pImageWnd.TrackerEnable = true;
         UpdateInterface();
       }

      private void UpdateInterface()
      {
	      SapBayer.AlignMode  AlignCap = m_pBayer.AvailAlign;
	      SapBayer.CalculationMethod MethodCap= m_pBayer.AvailMethod;

         switch (m_Align)
         {
            case SapBayer.AlignMode.BGGR: radioButton_Align_BG_GR.Checked = true; break;
            case SapBayer.AlignMode.GBRG: radioButton_Align_GB_RG.Checked = true; break;
            case SapBayer.AlignMode.GRBG: radioButton_Align_GR_BG.Checked = true; break;
            case SapBayer.AlignMode.RGGB: radioButton_Align_RG_GB.Checked = true; break;
         }
      
	      // Check which alignment is available
         radioButton_Align_GB_RG.Enabled =  (AlignCap & SapBayer.AlignMode.GBRG) > 0;
         radioButton_Align_BG_GR.Enabled =  (AlignCap & SapBayer.AlignMode.BGGR) > 0;
         radioButton_Align_GR_BG.Enabled =  (AlignCap & SapBayer.AlignMode.GRBG) > 0;
         radioButton_Align_RG_GB.Enabled =  (AlignCap & SapBayer.AlignMode.RGGB) > 0;

         switch (m_Method)
         {
            case SapBayer.CalculationMethod.Method1: radioButton_Method1.Checked = true; break;
            case SapBayer.CalculationMethod.Method2: radioButton_Method2.Checked = true; break;
            case SapBayer.CalculationMethod.Method3: radioButton_Method3.Checked = true; break;
            case SapBayer.CalculationMethod.Method4: radioButton_Method4.Checked = true; break;
            case SapBayer.CalculationMethod.Method5: radioButton_Method5.Checked = true; break;
            case SapBayer.CalculationMethod.Method6: radioButton_Method6.Checked = true; break;
         }

	      // Check which interpolation method is available
         radioButton_Method1.Enabled = (MethodCap & SapBayer.CalculationMethod.Method1) > 0;
         radioButton_Method2.Enabled = (MethodCap & SapBayer.CalculationMethod.Method2) > 0;
         radioButton_Method3.Enabled = (MethodCap & SapBayer.CalculationMethod.Method3) > 0;
         radioButton_Method4.Enabled = (MethodCap & SapBayer.CalculationMethod.Method4) > 0;
         radioButton_Method5.Enabled = (MethodCap & SapBayer.CalculationMethod.Method5) > 0;
         radioButton_Method6.Enabled = (MethodCap & SapBayer.CalculationMethod.Method6) > 0;


         // Initialize gain values
         SapDataFRGB wbGain = m_pBayer.WBGain;

         textBox_Red_Gain.Text = wbGain.Red.ToString();
         textBox_Green_Gain.Text = wbGain.Green.ToString();
         textBox_Blue_Gain.Text = wbGain.Blue.ToString();

         button_AutoWhite.Enabled = m_pImageWnd != null;
        
         // Initialize Gamma correction factor
         textBox_Gamma.Text = m_pBayer.Gamma.ToString();
	      checkBox_Gamma.Checked = m_pBayer.LutEnable;

	      // Check if bayer decoder is enabled and if a lookup table is available
         textBox_Gamma.Enabled = m_pBayer.Enabled && checkBox_Gamma.Checked;
         checkBox_Gamma.Enabled = m_pBayer.Enabled;
        
	      // Disable Apply button until something change
         button_Apply.Enabled = false;
      }

       private void textBox_Red_Gain_TextChanged(object sender, EventArgs e)
       {
          OnChange();
       }

       private void textBox_Green_Gain_TextChanged(object sender, EventArgs e)
       {
          OnChange();
       }

       private void textBox_Blue_Gain_TextChanged(object sender, EventArgs e)
       {
          OnChange();
       }

       private void textBox_Gamma_TextChanged(object sender, EventArgs e)
       {
          OnChange();
       }

       private void radioButton_Method1_CheckedChanged(object sender, EventArgs e)
       {
          m_Method = SapBayer.CalculationMethod.Method1;
          OnChange();
       }

       private void radioButton_Method2_CheckedChanged(object sender, EventArgs e)
       {
          m_Method = SapBayer.CalculationMethod.Method2;
          OnChange();
       }

       private void radioButton_Method3_CheckedChanged(object sender, EventArgs e)
       {
          m_Method = SapBayer.CalculationMethod.Method3;
          OnChange();
       }

       private void radioButton_Method4_CheckedChanged(object sender, EventArgs e)
       {
          m_Method = SapBayer.CalculationMethod.Method4;
          OnChange();
       }

       private void radioButton_Method5_CheckedChanged(object sender, EventArgs e)
       {
          m_Method = SapBayer.CalculationMethod.Method5;
          OnChange();
       }

       private void radioButton_Method6_CheckedChanged(object sender, EventArgs e)
       {
          m_Method = SapBayer.CalculationMethod.Method6;
          OnChange();
       }

       private void radioButton_Align_GB_RG_CheckedChanged(object sender, EventArgs e)
       {
          m_Align = SapBayer.AlignMode.GBRG;
          OnChange();
       }

       private void radioButton_Align_BG_GR_CheckedChanged(object sender, EventArgs e)
       {
          m_Align = SapBayer.AlignMode.BGGR;
          OnChange();
       }

       private void radioButton_Align_RG_GB_CheckedChanged(object sender, EventArgs e)
       {
          m_Align = SapBayer.AlignMode.RGGB;
          OnChange();
       }

       private void radioButton_Align_GR_BG_CheckedChanged(object sender, EventArgs e)
       {
          m_Align = SapBayer.AlignMode.GRBG;
          OnChange();
       }

       private void OnChange() 
       {
         // Something change so enable the Apply button
         button_Apply.Enabled = true;
       }

       private void checkBox_Gamma_CheckedChanged(object sender, EventArgs e)
       {
          textBox_Gamma.Enabled = m_pBayer.Enabled && checkBox_Gamma.Checked;
          // Something change so enable the Apply button
          button_Apply.Enabled = true;	
       }

       private void button_AutoWhite_Click(object sender, EventArgs e)
       {
          if (m_pImageWnd == null)
             return;

          if (m_pImageWnd.IsTrackerEmpty)
          {
             MessageBox.Show("You must select a ROI containing white pixels");
             return;
          }

          if (m_pBayer.Enabled && !m_pBayer.SoftwareConversion)
          {
             MessageBox.Show("White balance is not available when hardware Bayer conversion is enabled");
             return;
          }

          Rectangle rect = m_pImageWnd.Tracker;

          if (rect.Width > 1 && rect.Height > 1)
          {
             // Compute new white balance factors from region of interest
             if (m_pBayer.WhiteBalance(rect.Left, rect.Top, rect.Width, rect.Height))
             {
                // Update user interface
                UpdateInterface();

                // Redraw the image
                UpdateView();
             }
          }
       }

       private void button_Apply_Click(object sender, EventArgs e)
       {
          // Set alignment 
          m_pBayer.Align = m_Align;

          // Set interpolation method
          m_pBayer.Method = m_Method;

          // Set white balance's gain
          m_pBayer.WBGain = new SapDataFRGB(float.Parse(textBox_Red_Gain.Text),float.Parse(textBox_Green_Gain.Text),float.Parse(textBox_Blue_Gain.Text));

          if (checkBox_Gamma.Checked)
          {
             // Set new gamma factor
             m_pBayer.Gamma = int.Parse(textBox_Gamma.Text);
          }

          // Enable/Disable lookup table
          m_pBayer.LutEnable = checkBox_Gamma.Checked;

          // Redraw the image
          UpdateView();

          // Disable apply button
          button_Apply.Enabled =false; 
       }

       private void UpdateView() 
       {
         if (m_pBayer.Enabled)
	      {
		      // Check if we are operating on-line
		      if( m_pXfer != null && m_pXfer.Initialized)
		      {
			      // Check if we are grabbing
			      if( m_pXfer.Grabbing)
				      // The view will be automatically updated on the next acquired frame
				      return;

			      // Check if we are using an hardware bayer decoder
			      if( !m_pBayer.SoftwareConversion)
			      {
				      // Acquire one frame
				      m_pXfer.Snap();
				      return;
			      }
		      }

		      // Else, apply bayer conversion to current buffer's content
		      if( m_pPro != null)
		      {
			      m_pPro.Execute();
		      }
		      else
		      {
			      m_pBayer.Convert();
			      if( m_pImageWnd != null)
			      {
				      // Redraw the bayer decoded image
				      m_pImageWnd.Refresh();
			      }
		      }
	      }
      }

       private void BayerDlg_FormClosed(object sender, FormClosedEventArgs e)
       {
          m_pImageWnd.TrackerEnable = false;
       }

       private void button_Cancel_Click(object sender, EventArgs e)
       {
          this.Close();
       }
    
    }
}