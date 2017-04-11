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
    public partial class TiffFileDlg : Form
    {
        public TiffFileDlg(int compressionLevel, int compressionType)
        {
            InitializeComponent(); 
            // Read file name
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(keyPath);
            if (regkey != null)
            {
                UpDown_compression_level.Value = Convert.ToDecimal(regkey.GetValue("Tiff Compression Level", compressionLevel));
                comboBox_compression_type.SelectedIndex = Convert.ToInt32(regkey.GetValue("Tiff Compression Type", compressionType));          
            }   
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            m_Compression_Level = (int)UpDown_compression_level.Value;
            m_Compression_Type = comboBox_compression_type.SelectedIndex;
            // Write compression type and level values
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(keyPath);
            regKey.SetValue("Tiff Compression Level", m_Compression_Level);
            regKey.SetValue("Tiff Compression Type", m_Compression_Type);
        }

        public int CompressionLevel
        { 
            get {return m_Compression_Level;}   
        }

        public int CompressionType
        {
            get {return m_Compression_Type;}
        }

    }
}