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
    public partial class AviFileDlg : Form
    {
        public AviFileDlg(bool bLoad, int firstFrame, int compressionLevel, int compressionType)
        {
            InitializeComponent();
            m_bload = bLoad;
            // Read file name
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(keyPath);

            if (regkey != null)
            {
                UpDown_FirstFrame.Value = Convert.ToDecimal(regkey.GetValue("Avi First Frame", firstFrame));
                UpDown_Compression_level.Value = Convert.ToDecimal(regkey.GetValue("Avi Compression Level", compressionLevel));
                comboBox_Compression_type.SelectedIndex = Convert.ToInt32(regkey.GetValue("Avi Compression Type", compressionType));

            }
            UpdateControls();
            
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            m_FirstFrame = (int)UpDown_FirstFrame.Value;
            m_CompressionLevel = (int)UpDown_Compression_level.Value;
            m_CompressionType = comboBox_Compression_type.SelectedIndex;

            // Write AVI compression type and level values
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(keyPath);
            regKeyAppRoot.SetValue("Avi First Frame", m_FirstFrame);
            regKeyAppRoot.SetValue("Avi Compression Level", m_CompressionLevel);
            regKeyAppRoot.SetValue("Avi Compression Type", m_CompressionType);
        
        }

        private void UpdateControls()
        {
            UpDown_FirstFrame.Enabled = m_bload;
            UpDown_Compression_level.Enabled = !m_bload;
            comboBox_Compression_type.Enabled = !m_bload;
        }

        public int FirstFrame
        {
            get { return m_FirstFrame; }
        }

        public int CompressionLevel
        {
            get { return m_CompressionLevel; }
        }

        public int CompressionType
        {
            get { return m_CompressionType; }
        }
    }
}