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
    public partial class JpegFileDlg : Form
    {
        public JpegFileDlg(int quality)
        {
            InitializeComponent();
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(keyPath);
            if (regkey != null)
                UpDown_compression_level.Value = Convert.ToDecimal(regkey.GetValue("Jpeg Quality",quality));
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            m_Compression_Level = (int)UpDown_compression_level.Value;  
            // Write compression type and level values
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(keyPath);
            regKey.SetValue("Jpeg Quality", m_Compression_Level);
        }

        public int JpegFileQuality
        {
            get { return m_Compression_Level; }
            private set { m_Compression_Level = value; }
        }


    }
}