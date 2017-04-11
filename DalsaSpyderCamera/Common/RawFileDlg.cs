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
    public partial class RawFileDlg : Form
    {
        public RawFileDlg(int width, int height, int offset, SapFormat format)
        {
            InitializeComponent();

            // Read file name
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";

            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(keyPath);
            if (regkey != null)
            {
               textBox_Width.Text = regkey.GetValue("Raw Width", width).ToString();
               textBox_Height.Text = regkey.GetValue("Raw Height",height).ToString();
               textBox_Offset.Text = regkey.GetValue("Raw Offset",offset).ToString();
               m_Format = (SapFormat)Enum.Parse(typeof(SapFormat), regkey.GetValue("Raw Format", format).ToString(), true);
           }

            for (int i = 0; i < m_FormatInfo.Length ; i++)
            {
                comboBox_RawFormat.Items.Add(m_FormatInfo[i].ToString());
                if ((m_FormatInfo[i].Value == m_Format) || ((m_Format == 0) && (m_FormatInfo[i].Value == SapFormat.Mono8)))
                    comboBox_RawFormat.SelectedIndex = i;
            }

            if (m_Format != 0)
                comboBox_RawFormat.Enabled = false;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            m_Width = int.Parse(textBox_Width.Text);
            m_Height = int.Parse(textBox_Height.Text);
            m_Offset = int.Parse(textBox_Offset.Text);
            if (comboBox_RawFormat.SelectedIndex != -1)
                m_Format = m_FormatInfo[comboBox_RawFormat.SelectedIndex].Value;

            // Write compression type and level values
            string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(keyPath);
            regKey.SetValue("Raw Width",m_Width);
            regKey.SetValue("Raw Height",m_Height);
            regKey.SetValue("Raw Offset",m_Offset);
            regKey.SetValue("Raw Format", m_Format);
        }

        public int RawFileHeight
        {
            get { return m_Height; }
        }

        public int RawFileWidth
        {
            get { return m_Width; }
        }

        public int RawFileOffset
        {
            get { return m_Offset; }
        }

        public SapFormat RawFileFormat
        {
            get { return m_Format; }
        }
    }
}