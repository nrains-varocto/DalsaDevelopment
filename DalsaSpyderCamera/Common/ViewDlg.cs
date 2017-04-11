using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using DALSA.SaperaLT.SapClassBasic;

namespace DALSA.SaperaLT.SapClassGui
{
    

    
   
    public partial class ViewDlg : Form
    {
        public ViewDlg(SapView pView,Rectangle ViewArea)
        {
            InitializeComponent();
          
            m_pView = pView;
            Slider_Range.Maximum = m_pView.RangeMax;
            Slider_Range.Minimum = m_pView.RangeMin;

            m_Range = m_pView.Range;
            m_RangeInit = m_Range;
            Slider_Range.Value = m_Range;
            textBox_Range.Text = m_Range.ToString();

            NUpDown_height_scalor.Value = (decimal)(m_pView.ScalingZoomVert * 100.0f);
            NUpDown_width_scalor.Value = (decimal)(m_pView.ScalingZoomHorz * 100.0f);

            NUpDown_height.Value = Decimal.Floor((decimal)((m_pView.Buffer.Height * (float)NUpDown_height_scalor.Value / 100) + 0.5f));
            NUpDown_width.Value = Decimal.Floor((decimal)((m_pView.Buffer.Width * (float)NUpDown_width_scalor.Value / 100) + 0.5f));

            m_bLockAspectRatio = checkBox_lock.Checked;
            m_ViewArea = ViewArea;

            Initialize_ViewFormat_Combo();

            LoadSettings();
        }

        private void Initialize_ViewFormat_Combo()
        {
            SapBuffer buffer = m_pView.Buffer;

            if (buffer.MultiFormat)
            {
                int numPages = buffer.NumPages;
                SapFormat[] pageFormats = buffer.PageFormats;
                for (int i = 0; i < numPages; i++)
                    comboBox1_ViewFormat.Items.Add(pageFormats[i] + " (page " + i + ")");
                int currentPage = buffer.Page;
                comboBox1_ViewFormat.SelectedIndex = currentPage;
                comboBox1_ViewFormat.Enabled = true;
            }
            else
            {
                comboBox1_ViewFormat.Enabled = false;
            }
        }

        private void LoadSettings() 
        {
            // Read file name
            string sAspectRatio = "";
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapView";
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(keyPath);

            if (regkey != null)
            {
               // Read view settings
               sAspectRatio = regkey.GetValue("Aspect Ratio","False").ToString();
               if (sAspectRatio == "True")
                   checkBox_lock.Checked = true;
               else
                   checkBox_lock.Checked = false;
            }
        }

        private void SaveSettings()
        {
            // Write file name
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapView";
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(keyPath);
            regKeyAppRoot.SetValue("Aspect Ratio", checkBox_lock.Checked);
        }

        private void SetRange()
        {
	        m_pView.Range = m_Range;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
	        m_pView.SetScalingMode((float)NUpDown_width_scalor.Value/100.0f, (float)NUpDown_height_scalor.Value/100.0f);
	        SaveSettings();        	       
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            m_Range = m_RangeInit;
            SetRange();
        }

        private void button_Fit_Click(object sender, EventArgs e)
        { 
           decimal WidthScalor = (decimal)(100.0f * m_ViewArea.Width / m_pView.Buffer.Width);
           decimal HeightScalor = (decimal)(100.0f * m_ViewArea.Height / m_pView.Buffer.Height);
          
           if (m_bLockAspectRatio)
           {
              if (WidthScalor < HeightScalor)
                 HeightScalor = WidthScalor;
              else
                 WidthScalor = HeightScalor;
           }

           NUpDown_width_scalor.Value = WidthScalor;
           NUpDown_height_scalor.Value = HeightScalor;
 
           NUpDown_width.Value = Decimal.Floor((decimal)(m_pView.Buffer.Width * (float)NUpDown_width_scalor.Value / 100 + 0.5f));
           NUpDown_height.Value = Decimal.Floor((decimal)(m_pView.Buffer.Height * (float)NUpDown_height_scalor.Value / 100 + 0.5f));
        }

        private void button_No_Scaling_Click(object sender, EventArgs e)
        {
            NUpDown_width_scalor.Value = (decimal)100.0f;
            NUpDown_height_scalor.Value = (decimal)100.0f;

            NUpDown_width.Value = Decimal.Floor((decimal)(m_pView.Buffer.Width * (float)NUpDown_width_scalor.Value / 100 + 0.5f));
            NUpDown_height.Value = Decimal.Floor((decimal)(m_pView.Buffer.Height * (float)NUpDown_height_scalor.Value / 100 + 0.5f));
        }

        private void checkBox_lock_CheckedChanged(object sender, EventArgs e)
        {
            m_bLockAspectRatio = checkBox_lock.Checked;           
            if (m_bLockAspectRatio)
            {
                NUpDown_height_scalor.Value = NUpDown_width_scalor.Value;
                NUpDown_height.Value = Decimal.Floor((decimal)((float)NUpDown_height_scalor.Value * m_pView.Buffer.Height / 100 + 0.5f));
            }
        }

        private void NUpDown_width_ValueChanged(object sender, EventArgs e)
        {
            NUpDown_width_scalor.Value = (decimal)((100.0f * (float)NUpDown_width.Value / m_pView.Buffer.Width));      
            if (m_bLockAspectRatio)
            {
                NUpDown_height_scalor.Value = NUpDown_width_scalor.Value;
                NUpDown_height.Value = Decimal.Floor((decimal)((float)NUpDown_height_scalor.Value * m_pView.Buffer.Height / 100 + 0.5f));
            }      
        }

        private void NUpDown_width_scalor_ValueChanged(object sender, EventArgs e)
        {         
            NUpDown_width.Value = Decimal.Floor((decimal)((float)NUpDown_width_scalor.Value * m_pView.Buffer.Width / 100 + 0.5f));
            if (m_bLockAspectRatio)
             {
                 NUpDown_height_scalor.Value = NUpDown_width_scalor.Value;
                 NUpDown_height.Value = Decimal.Floor((decimal)((float)NUpDown_height_scalor.Value * m_pView.Buffer.Height / 100 + 0.5f));
             }    
        }

        private void NUpDown_height_ValueChanged(object sender, EventArgs e)
        {
            NUpDown_height_scalor.Value = (decimal)(100.0f * (float)NUpDown_height.Value / m_pView.Buffer.Height);
            if (m_bLockAspectRatio)
            {
                NUpDown_height_scalor.Value = NUpDown_height_scalor.Value;
                NUpDown_width.Value = Decimal.Floor((decimal)((float)NUpDown_height_scalor.Value * m_pView.Buffer.Width / 100 + 0.5f));
            }
        }

        private void NUpDown_height_scalor_ValueChanged(object sender, EventArgs e)
        {
            NUpDown_height.Value = Decimal.Floor((decimal)((float)NUpDown_height_scalor.Value * m_pView.Buffer.Height / 100 + 0.5f));
            if (m_bLockAspectRatio)
            {
                NUpDown_height_scalor.Value = NUpDown_height_scalor.Value;
                NUpDown_width.Value = Decimal.Floor((decimal)((float)NUpDown_height_scalor.Value * m_pView.Buffer.Width / 100 + 0.5f));
            }
        }
  
        private void button1_Apply_Click(object sender, EventArgs e)
        {
            m_pView.SetScalingMode((float)NUpDown_width_scalor.Value / 100.0f, (float)NUpDown_height_scalor.Value / 100.0f);
            SaveSettings();
        }

        private void textBox_Range_TextChanged(object sender, EventArgs e)
        {
            int oldRange = m_Range;

            m_Range = int.Parse(textBox_Range.Text);
            if ((m_Range < m_pView.RangeMin) || (m_Range > m_pView.RangeMax))
                m_Range = oldRange;

            SetRange();   
        }

        private void Slider_Range_Scroll(object sender, EventArgs e)
        {
            m_Range = Slider_Range.Value;
            textBox_Range.Text = m_Range.ToString();
        }

        private void comboBox1_ViewFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1_ViewFormat.SelectedIndex;
            if (index != -1)
                m_pView.Buffer.AllPage = index;
        }  
    }
}