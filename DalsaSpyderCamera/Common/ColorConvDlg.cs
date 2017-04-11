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
   public partial class ColorConvDlg : Form
   {
      private SapColorConversion m_pColorConv;
      private SapTransfer m_pXfer;
      private SapProcessing m_pPro;
      private ImageBox m_pImageWnd;
      SapColorConversion.ColorAlign m_Align;
      SapColorConversion.ColorMethod m_Method;
      private System.Collections.Generic.Dictionary<SapColorConversion.ColorMethod,string> m_MethodDict;

      public ColorConvDlg(SapColorConversion pColorConv, SapTransfer pXfer, ImageBox pImageWnd, SapProcessing pPro)
      {
         InitializeComponent();

         m_pColorConv = pColorConv;
         m_pXfer = pXfer;
         m_pPro = pPro;
         m_pImageWnd = pImageWnd;

         m_MethodDict = new Dictionary<SapColorConversion.ColorMethod, string>();
         m_MethodDict.Add(SapColorConversion.ColorMethod.Method1, "Bayer Method 1");
         m_MethodDict.Add(SapColorConversion.ColorMethod.Method2, "Bayer Method 2");
         m_MethodDict.Add(SapColorConversion.ColorMethod.Method3, "Bayer Method 3");
         m_MethodDict.Add(SapColorConversion.ColorMethod.Method4, "Bayer Method 4");
         m_MethodDict.Add(SapColorConversion.ColorMethod.Method5, "Bayer Method 5");
         m_MethodDict.Add(SapColorConversion.ColorMethod.Method6, "Bi-Color Method 6 (compatible with Basler Sprint)");
         m_MethodDict.Add(SapColorConversion.ColorMethod.Method7, "Bi-Color Method 7 (compatible with TDALSA P4)");
      }

      private void ColorConvDlg_Load(object sender, EventArgs e)
      {
         if (m_pColorConv == null)
         {
            MessageBox.Show("No Color Conversion object specified");
            this.Close();
            return;
         }
         m_Align = m_pColorConv.Align;
         m_Method = m_pColorConv.Method;
         m_pImageWnd.TrackerEnable = true;
         UpdateInterface();
      }

      private void UpdateInterface()
      {
         SapColorConversion.ColorAlign AlignCap = m_pColorConv.AvailAlign;
         SapColorConversion.ColorMethod MethodCap = m_pColorConv.AvailMethod;

         switch (m_Align)
         {
            case SapColorConversion.ColorAlign.BGGR: radioButton_Align_BG_GR.Checked = true; break;
            case SapColorConversion.ColorAlign.GBRG: radioButton_Align_GB_RG.Checked = true; break;
            case SapColorConversion.ColorAlign.GRBG: radioButton_Align_GR_BG.Checked = true; break;
            case SapColorConversion.ColorAlign.RGGB: radioButton_Align_RG_GB.Checked = true; break;
            case SapColorConversion.ColorAlign.RGBG: radioButton_Align_RG_BG.Checked = true; break;
            case SapColorConversion.ColorAlign.BGRG: radioButton_Align_BG_RG.Checked = true; break;

         }

         // Check which alignment is available
         radioButton_Align_GB_RG.Enabled = (AlignCap & SapColorConversion.ColorAlign.GBRG) > 0;
         radioButton_Align_BG_GR.Enabled = (AlignCap & SapColorConversion.ColorAlign.BGGR) > 0;
         radioButton_Align_GR_BG.Enabled = (AlignCap & SapColorConversion.ColorAlign.GRBG) > 0;
         radioButton_Align_RG_GB.Enabled = (AlignCap & SapColorConversion.ColorAlign.RGGB) > 0;
         radioButton_Align_RG_BG.Enabled = (AlignCap & SapColorConversion.ColorAlign.RGBG) > 0;
         radioButton_Align_BG_RG.Enabled = (AlignCap & SapColorConversion.ColorAlign.BGRG) > 0;


         switch (m_Method)
         {
            case SapColorConversion.ColorMethod.Method1: radioButton_Method1.Checked = true; break;
            case SapColorConversion.ColorMethod.Method2: radioButton_Method2.Checked = true; break;
            case SapColorConversion.ColorMethod.Method3: radioButton_Method3.Checked = true; break;
            case SapColorConversion.ColorMethod.Method4: radioButton_Method4.Checked = true; break;
            case SapColorConversion.ColorMethod.Method5: radioButton_Method5.Checked = true; break;
            case SapColorConversion.ColorMethod.Method6: radioButton_Method6.Checked = true; break;
            case SapColorConversion.ColorMethod.Method7: radioButton_Method7.Checked = true; break;
         }

         // Check which interpolation method is available
         radioButton_Method1.Enabled = (MethodCap & SapColorConversion.ColorMethod.Method1) > 0;
         radioButton_Method2.Enabled = (MethodCap & SapColorConversion.ColorMethod.Method2) > 0;
         radioButton_Method3.Enabled = (MethodCap & SapColorConversion.ColorMethod.Method3) > 0;
         radioButton_Method4.Enabled = (MethodCap & SapColorConversion.ColorMethod.Method4) > 0;
         radioButton_Method5.Enabled = (MethodCap & SapColorConversion.ColorMethod.Method5) > 0;
         radioButton_Method6.Enabled = (MethodCap & SapColorConversion.ColorMethod.Method6) > 0;
         radioButton_Method7.Enabled = (MethodCap & SapColorConversion.ColorMethod.Method7) > 0;


         // Initialize gain values
         SapDataFRGB wbGain = m_pColorConv.WBGain;

         textBox_Red_Gain.Text = wbGain.Red.ToString();
         textBox_Green_Gain.Text = wbGain.Green.ToString();
         textBox_Blue_Gain.Text = wbGain.Blue.ToString();

         button_AutoWhite.Enabled = m_pImageWnd != null;

         // Initialize Gamma correction factor
         textBox_Gamma.Text = m_pColorConv.Gamma.ToString();
         checkBox_Gamma.Checked = m_pColorConv.LutEnabled;

         // Check if color decoder is enabled and if a lookup table is available
         textBox_Gamma.Enabled = m_pColorConv.Enabled && checkBox_Gamma.Checked;
         checkBox_Gamma.Enabled = m_pColorConv.Enabled;

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
         m_Method = SapColorConversion.ColorMethod.Method1;
         OnChange();
      }

      private void radioButton_Method2_CheckedChanged(object sender, EventArgs e)
      {
         m_Method = SapColorConversion.ColorMethod.Method2;
         OnChange();
      }

      private void radioButton_Method3_CheckedChanged(object sender, EventArgs e)
      {
         m_Method = SapColorConversion.ColorMethod.Method3;
         OnChange();
      }

      private void radioButton_Method4_CheckedChanged(object sender, EventArgs e)
      {
         m_Method = SapColorConversion.ColorMethod.Method4;
         OnChange();
      }

      private void radioButton_Method5_CheckedChanged(object sender, EventArgs e)
      {
         m_Method = SapColorConversion.ColorMethod.Method5;
         OnChange();
      }

      private void radioButton_Method6_CheckedChanged(object sender, EventArgs e)
      {
         m_Method = SapColorConversion.ColorMethod.Method6;
         OnChange();
      }

      private void radioButton_Method7_CheckedChanged(object sender, EventArgs e)
      {
         m_Method = SapColorConversion.ColorMethod.Method7;
         OnChange();
      }

      private void radioButton_Align_GB_RG_CheckedChanged(object sender, EventArgs e)
      {
         m_Align = SapColorConversion.ColorAlign.GBRG;
         OnChange();
      }

      private void radioButton_Align_BG_GR_CheckedChanged(object sender, EventArgs e)
      {
         m_Align = SapColorConversion.ColorAlign.BGGR;
         OnChange();
      }

      private void radioButton_Align_RG_GB_CheckedChanged(object sender, EventArgs e)
      {
         m_Align = SapColorConversion.ColorAlign.RGGB;
         OnChange();
      }

      private void radioButton_Align_GR_BG_CheckedChanged(object sender, EventArgs e)
      {
         m_Align = SapColorConversion.ColorAlign.GRBG;
         OnChange();
      }

      private void radioButton_Align_RG_BG_CheckedChanged(object sender, System.EventArgs e)
      {
         m_Align = SapColorConversion.ColorAlign.RGBG;
         OnChange();
      }

      private void radioButton_Align_BG_RG_CheckedChanged(object sender, System.EventArgs e)
      {
         m_Align = SapColorConversion.ColorAlign.BGRG;
         OnChange();
      }

      private void OnChange()
      {
         SetSelectedMethodDescription();
         
         // Something change so enable the Apply button
         button_Apply.Enabled = true;
      }

      private void SetSelectedMethodDescription()
      {
         if (m_pColorConv.AvailMethod == 0)
            methodDescText.Text = "No method";
         else
            methodDescText.Text = m_MethodDict[m_Method];

         methodDescText.Text += " is selected";
      }

      private void checkBox_Gamma_CheckedChanged(object sender, EventArgs e)
      {
         textBox_Gamma.Enabled = m_pColorConv.Enabled && checkBox_Gamma.Checked;
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

         Rectangle rect = m_pImageWnd.Tracker;

         if (rect.Width > 1 && rect.Height > 1)
         {
            // Compute new white balance factors from region of interest
            if (m_pColorConv.WhiteBalance(rect.Left, rect.Top, rect.Width, rect.Height))
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
         m_pColorConv.Align = m_Align;

         // Set interpolation method
         m_pColorConv.Method = m_Method;

         // Set white balance's gain
         m_pColorConv.WBGain = new SapDataFRGB(float.Parse(textBox_Red_Gain.Text), float.Parse(textBox_Green_Gain.Text), float.Parse(textBox_Blue_Gain.Text));

         if (checkBox_Gamma.Checked)
         {
            // Set new gamma factor
            m_pColorConv.Gamma = int.Parse(textBox_Gamma.Text);
         }

         // Enable/Disable lookup table
         m_pColorConv.LutEnabled = checkBox_Gamma.Checked;

         // Redraw the image
         UpdateView();

         // Disable apply button
         button_Apply.Enabled = false;
      }

      private void UpdateView()
      {
         if (m_pColorConv.Enabled)
         {
            // Check if we are operating on-line
            if (m_pXfer != null && m_pXfer.Initialized)
            {
               // Check if we are grabbing
               if (m_pXfer.Grabbing)
                  // The view will be automatically updated on the next acquired frame
                  return;

               // Check if we are using an hardware color decoder
               if (m_pColorConv.HardwareEnabled)
               {
                  // Acquire one frame
                  m_pXfer.Snap();
                  return;
               }
            }

            // Else, apply color conversion to current buffer's content
            if (m_pPro != null)
            {
               m_pPro.Execute();
            }
            else
            {
               m_pColorConv.Convert();
               if (m_pImageWnd != null)
               {
                  // Redraw the color decoded image
                  m_pImageWnd.Refresh();
               }
            }
         }
      }

      private void ColorConvDlg_FormClosed(object sender, FormClosedEventArgs e)
      {
         m_pImageWnd.TrackerEnable = false;
      }

      private void button_Cancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      

   }
}