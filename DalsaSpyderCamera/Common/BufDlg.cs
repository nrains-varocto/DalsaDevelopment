using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

using DALSA.SaperaLT.SapClassBasic;


namespace DALSA.SaperaLT.SapClassGui
{
  
    public partial class BufferDlg : Form
    {
        public BufferDlg(SapBuffer buffer, SapDisplay display, bool Online)
        {
            InitializeComponent();
            m_isXfer = Online;
            m_sapDisplay = display;

            textBox1_Count.Text = buffer.Count.ToString();
            textBox1_Width.Text = buffer.Width.ToString();
            textBox1_Height.Text = buffer.Height.ToString();
            textBox1_PixelDepth.Text = buffer.PixelDepth.ToString();

            m_Count = buffer.Count;
            m_Width = buffer.Width;
            m_Height = buffer.Height;
            m_pixelDepth = buffer.PixelDepth;
            m_format = buffer.Format;
            m_type = buffer.Type;
            m_ScatterGatherType = SapBuffer.MemoryType.ScatterGather;

            // For acquisition hardware with DMA transfers using 32-bit addresses in 64-bit Windows (e.g., X64-CL iPro)
            if (buffer.SrcNode != null)
            {
                if (!SapBuffer.IsBufferTypeSupported(buffer.SrcNode.Location, SapBuffer.MemoryType.ScatterGather))
                    m_ScatterGatherType = SapBuffer.MemoryType.ScatterGatherPhysical;
            }

            Initialize_Format_Combo();
            Initialize_Type_Flags();
            EnableControls();  			
        }

        // Initialize format combo
        private void Initialize_Format_Combo()
        {
            int Index = 0;
            SapFormatInfo formatInfo = new SapFormatInfo(SapFormat.Mono1, "Monochrome 1-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 0;
            formatInfo = new SapFormatInfo(SapFormat.Mono8, "Monochrome 8-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 1;
            formatInfo = new SapFormatInfo(SapFormat.Mono16, "Monochrome 16-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 2;
            formatInfo = new SapFormatInfo(SapFormat.RGB5551, "RGB 5551");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 3;
            formatInfo = new SapFormatInfo(SapFormat.RGB565, "RGB 565");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 4;
            formatInfo = new SapFormatInfo(SapFormat.RGB888, "RGB 888 (blue first)");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 5;
            formatInfo = new SapFormatInfo(SapFormat.RGBR888, "RGBR 888 (red first)");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 6;
            formatInfo = new SapFormatInfo(SapFormat.RGB8888, "RGB 8888");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 7;
            formatInfo = new SapFormatInfo(SapFormat.RGB101010, "RGB 101010");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 8;
            formatInfo = new SapFormatInfo(SapFormat.RGB161616, "RGB 161616");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 9;
            formatInfo = new SapFormatInfo(SapFormat.RGB16161616, "RGB 16161616");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 10;
            formatInfo = new SapFormatInfo(SapFormat.RGBP8, "RGB Planar 8-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 11;
            formatInfo = new SapFormatInfo(SapFormat.RGBP16, "RGB Planar 16-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 12;
            formatInfo = new SapFormatInfo(SapFormat.HSI, "HSI");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 13;
            formatInfo = new SapFormatInfo(SapFormat.HSIP8, "HSI Planar 8-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 14;
            formatInfo = new SapFormatInfo(SapFormat.HSV, "HSV");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 15;
            formatInfo = new SapFormatInfo(SapFormat.UYVY, "UYVY");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 16;
            formatInfo = new SapFormatInfo(SapFormat.YUY2, "YUY2");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 17;
            formatInfo = new SapFormatInfo(SapFormat.YUYV, "YUYV");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 18;
            formatInfo = new SapFormatInfo(SapFormat.LAB, "LAB");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 19;
            formatInfo = new SapFormatInfo(SapFormat.LABP8, "LAB Planar 8-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 20;
            formatInfo = new SapFormatInfo(SapFormat.LAB101010, "LAB 101010");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 21;
            formatInfo = new SapFormatInfo(SapFormat.LABP16, "LAB Planar 16-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 22;
            formatInfo = new SapFormatInfo(SapFormat.BICOLOR88, "BICOLOR 8-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 23;
            formatInfo = new SapFormatInfo(SapFormat.BICOLOR1616, "BICOLOR 16-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 24;
            formatInfo = new SapFormatInfo(SapFormat.RGB888_MONO8, "RGB-IR 8-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 25;
            formatInfo = new SapFormatInfo(SapFormat.RGB161616_MONO16, "RGB-IR 16-bit");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 26;
            formatInfo = new SapFormatInfo(SapFormat.Mono8P2, "Monochrome 8-bit (2 planes)");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 27;
            formatInfo = new SapFormatInfo(SapFormat.Mono8P3, "Monochrome 8-bit (3 planes)");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 28;
            formatInfo = new SapFormatInfo(SapFormat.Mono16P2, "Monochrome 16-bit (2 planes)");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 29;
            formatInfo = new SapFormatInfo(SapFormat.Mono16P3, "Monochrome 16-bit (3 planes)");
            comboBox1_Format.Items.Add(formatInfo);
            if (m_format == formatInfo.Value) Index = 30;

            comboBox1_Format.SelectedIndex = Index;
       
        }

        private void Initialize_Type_Flags()
        {
            radioButton1_Contiguous.Checked = (m_type == SapBuffer.MemoryType.Contiguous);
            radioButton1_ScatterGather.Checked = (m_type == m_ScatterGatherType);
            radioButton1_Offscreen_Video.Checked = (m_type == SapBuffer.MemoryType.OffscreenVideo);
            radioButton1_Overlay.Checked = (m_type == SapBuffer.MemoryType.Overlay);
            radioButton1_Virtual.Checked = (m_type == SapBuffer.MemoryType.Virtual);
        }

        // Set new parameters
        private void button1_OK_Click(object sender, EventArgs e)
        {
            m_Count = int.Parse(textBox1_Count.Text);
            m_Width = int.Parse(textBox1_Width.Text);
            m_Height = int.Parse(textBox1_Height.Text);
            m_pixelDepth = int.Parse(textBox1_PixelDepth.Text); 
        }

        private void radioButton1_Contiguous_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1_Contiguous.Checked)	    
                m_type = SapBuffer.MemoryType.Contiguous;
        }

        private void radioButton1_ScatterGather_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1_ScatterGather.Checked)
                m_type = m_ScatterGatherType;
        }

        private void radioButton1_Offscreen_Video_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1_Offscreen_Video.Checked)
                m_type = SapBuffer.MemoryType.OffscreenVideo;
        }

        private void radioButton1_Overlay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1_Overlay.Checked)
            {
                m_type = SapBuffer.MemoryType.Overlay;
                textBox1_Count.Text = "1";
                textBox1_Count.Enabled = false;
            }
            else
            {
                textBox1_Count.Text = m_Count.ToString();
                textBox1_Count.Enabled = true;
            }
        }

        private void radioButton1_Virtual_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1_Virtual.Checked)
                m_type = SapBuffer.MemoryType.Virtual;
        }

        private void EnableControls()
        {
            bool isOffscreenAvailable = (m_sapDisplay != null) ? m_sapDisplay.IsOffscreenAvailable(m_format) : true;
            bool isOverLayAvailable = (m_sapDisplay != null) ? m_sapDisplay.IsOverlayAvailable(m_format) : true;
            radioButton1_Offscreen_Video.Enabled = isOffscreenAvailable;
            radioButton1_Overlay.Enabled = isOverLayAvailable;
            radioButton1_Virtual.Enabled = !m_isXfer;
            textBox1_Width.Enabled = !m_isXfer;
            textBox1_Height.Enabled = !m_isXfer;
            comboBox1_Format.Enabled = !m_isXfer;
       
            // Is pixel depth adjustable?
            if (SapManager.GetPixelDepthMin(m_format) != SapManager.GetPixelDepthMax(m_format))
            {
                textBox1_PixelDepth.Enabled = true;
                textBox1_PixelDepth.Text = m_pixelDepth.ToString();
            }
            else
                textBox1_PixelDepth.Enabled = false;
        }    

        private void comboBox1_Format_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Update format 
            SapFormatInfo formatInfo = (SapFormatInfo)comboBox1_Format.SelectedItem;
            m_format = formatInfo.Value;
            EnableControls();
        }


        public int BWidth
        {
            get { return m_Width; }
        }

        public int BHeight
        {
            get { return m_Height; }
        }

        public int Count
        {
            get { return m_Count; }
        }

        public SapFormat Format
        {
            get { return m_format; }
        }

        public SapBuffer.MemoryType Type
        {
            get { return m_type; }
        }
    }


    // Format table
    public class SapFormatInfo
    {
        public SapFormatInfo(SapFormat format, string name)
        {
            m_Value = format;
            m_Name = name;
        }

        public override string ToString()
        {
            return m_Name;
        }

        public SapFormat Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        private SapFormat m_Value;
        private string m_Name;
    }

}

