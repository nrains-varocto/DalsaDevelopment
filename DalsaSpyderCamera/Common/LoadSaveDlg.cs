using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using DALSA.SaperaLT.SapClassBasic;

namespace DALSA.SaperaLT.SapClassGui
{
   class LoadSaveDlg
   {
      public LoadSaveDlg(SapBuffer pBuffer, bool isOpen, bool isSequence)
      {
         m_pBuffer = pBuffer;
         m_isOpen = isOpen;
         m_bSequence = isSequence;
         m_StartFrame = (isSequence || pBuffer == null) ? 0 : pBuffer.Index;

         if (IntPtr.Size == 8)
            m_StandardTypes = new SapBuffer.FileFormat[5];  // 64-bit
         else
            m_StandardTypes = new SapBuffer.FileFormat[6];  // 32-bit

         m_StandardTypes[0] = SapBuffer.FileFormat.BMP;
         m_StandardTypes[1] = SapBuffer.FileFormat.TIFF;
         m_StandardTypes[2] = SapBuffer.FileFormat.CRC;
         m_StandardTypes[3] = SapBuffer.FileFormat.RAW;
         m_StandardTypes[4] = SapBuffer.FileFormat.JPEG;

         // 32-bit
         if (IntPtr.Size == 4)
            m_StandardTypes[5] = SapBuffer.FileFormat.JPEG2000;

         Initialize();
         // Load parameters from registry
         LoadSettings();
         SetFilterIndex();
      }

      private void Initialize()
      {
         //Create Open or Save Dialog
         if (m_isOpen)
         {
            m_FileDialog = new OpenFileDialog();
            m_FileDialog.Title = "Loading a file...";
         }
         else
         {
            m_FileDialog = new SaveFileDialog();
            m_FileDialog.Title = "Saving a file...";
         }

         // Set filter for image or sequence
         if (m_bSequence)
         {
            m_FileDialog.Filter = SEQUENCE_FILTER;
         }
         else
         {
            // 64-bit
            if (IntPtr.Size == 8)
               m_FileDialog.Filter = "BMP Files (*.bmp)|*.bmp|TIF Files (*.tif)|*.tif|Teledyne DALSA Files (*.crc)|*.crc|RAW data Files (*.raw)|*.raw|JPEG Files (*.jpg)|*.jpg||";
            // 32-bit
            else
               m_FileDialog.Filter = "BMP Files (*.bmp)|*.bmp|TIF Files (*.tif)|*.tif|Teledyne DALSA Files (*.crc)|*.crc|RAW data Files (*.raw)|*.raw|JPEG Files (*.jpg)|*.jpg|JPEG 2000 Files (*.jp2)|*.jp2||";
         }

         // Set options and type
         m_FileDialog.AddExtension = true;
         m_FileDialog.FileName = m_PathName;
         m_FileDialog.RestoreDirectory = true;
      }

      public void Dispose()
      {
         m_FileDialog.Dispose();
         m_FileDialog = null;
      }

      protected void SetFilterIndex()
      {
         m_FileDialog.FilterIndex = 1;

         if (m_bSequence)
         {
            for (int i = 0; i < m_SequenceTypes.GetLength(0); i++)
            {
               if (m_Type == m_SequenceTypes[i])
               {
                  m_FileDialog.FilterIndex = i + 1;
                  return;
               }
            }
         }
         else
         {
            for (int i = 0; i < m_StandardTypes.GetLength(0); i++)
            {
               if (m_Type == m_StandardTypes[i])
               {
                  m_FileDialog.FilterIndex = i + 1;
                  return;
               }
            }
         }
      }

      private bool SetOptions()
      {
         bool success = true;
         switch (m_Type)
         {
         case SapBuffer.FileFormat.BMP:
            m_Options = "-format bmp";
            break;
         case SapBuffer.FileFormat.TIFF:
            m_Options = "-format tif";
            if(!m_isOpen)
               success = AddTiffOptions();
            break;
         case SapBuffer.FileFormat.CRC:
            m_Options = "-format crc";
            break;
         case SapBuffer.FileFormat.RAW:
            m_Options = "-format raw";
            if (m_isOpen)
               success = AddRawOptions();
            break;
         case SapBuffer.FileFormat.JPEG:
            m_Options = "-format jpg";
            if (!m_isOpen)
               success = AddJpegOptions();
            break;
         case SapBuffer.FileFormat.JPEG2000:
            m_Options = "-format jp2";
            if (!m_isOpen)
               success = AddJpegOptions();
            break;
         case SapBuffer.FileFormat.AVI:
            m_Options = "-format avi";
            if (m_isOpen)
               success = AddAviOptions();
            break;
         }
         return success;
      }

      private void LoadSettings()
      {
         // Read file name
         string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
         RegistryKey regkey = Registry.CurrentUser.OpenSubKey(keyPath, true);
         if (regkey != null)
         {
            m_PathName = regkey.GetValue("Name", "").ToString();
            m_Type = (SapBuffer.FileFormat)(regkey.GetValue("Type", 0));
         }
      }

      protected void SaveSettings()
      {
         // Write file name
         string keyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapFile";
         RegistryKey regKey = Registry.CurrentUser.CreateSubKey(keyPath);
         regKey.SetValue("Name", m_PathName);
         regKey.SetValue("Type", (int)m_Type);
      }

      private bool AddTiffOptions()
      {
         TiffFileDlg dlg = new TiffFileDlg(TIFF_DEFAULT_COMPRESSION_LEVEL, TIFF_DEFAULT_COMPRESSION_TYPE);

         if (dlg.ShowDialog() != DialogResult.OK)
            return false;

         string strType = " -c " + m_TiffCompressionTypes[dlg.CompressionType];
         m_Options += strType;
         string strLevel = " -q " + dlg.CompressionLevel.ToString();
         m_Options += strLevel;
         return true;
      }

      private bool AddJpegOptions()
      {
         JpegFileDlg dlg = new JpegFileDlg(JPEG_DEFAULT_QUALITY);

         if (dlg.ShowDialog() != DialogResult.OK)
            return false;

         string strQuality = " -q " + dlg.JpegFileQuality.ToString();
         m_Options += strQuality;
         return true;
      }

      private bool AddAviOptions()
      {
         AviFileDlg dlg = new AviFileDlg(true, AVI_DEFAULT_START_FRAME, AVI_DEFAULT_COMPRESSION_LEVEL, AVI_DEFAULT_COMPRESSION_TYPE);

         if (dlg.ShowDialog() != DialogResult.OK)
            return false;

         m_StartFrame = dlg.FirstFrame;
         return true;
      }

      private bool AddRawOptions()
      {
         int width = (m_pBuffer != null) ? m_pBuffer.Width : RAW_DEFAULT_WIDTH;
         int height = (m_pBuffer != null) ? m_pBuffer.Height : RAW_DEFAULT_HEIGHT;
         SapFormat format = (m_pBuffer != null) ? m_pBuffer.Format : 0;
         RawFileDlg dlg = new RawFileDlg(width, height, RAW_DEFAULT_OFFSET, format);

         if(dlg.ShowDialog() != DialogResult.OK)
            return false;

         string strQuality =" -width " + dlg.RawFileWidth.ToString() + " -height " + dlg.RawFileHeight.ToString() + " -offset " + dlg.RawFileOffset.ToString();
         m_Options += strQuality;
         return true;
      }

      public bool UpdateBuffer()
      {
         // Set load/save options
         if (!SetOptions())
            return false;
         m_PathName = m_FileDialog.FileName;
         if (m_pBuffer != null)
         {
            if (m_isOpen)
            {
               //Load File in the current buffer
               return m_pBuffer.Load(m_PathName, m_StartFrame, m_Options);
            }
            else
            {
               int conversionType = 0;
               SapFormat format = m_pBuffer.Format;

               for (int i = 0; i < m_ConversionTable.Length; i++)
               {
                  if (m_ConversionTable[i].m_BufferFormat == format)
                  {
                     switch (m_Type)
                     {
                     case SapBuffer.FileFormat.BMP:
                        conversionType = m_ConversionTable[i].m_FileFormat[0];
                        break;
                     case SapBuffer.FileFormat.TIFF:
                        conversionType = m_ConversionTable[i].m_FileFormat[1];
                        break;
                     case SapBuffer.FileFormat.CRC:
                        conversionType = m_ConversionTable[i].m_FileFormat[2];
                        break;
                     case SapBuffer.FileFormat.RAW:
                        conversionType = m_ConversionTable[i].m_FileFormat[3];
                        break;
                     case SapBuffer.FileFormat.JPEG:
                        conversionType = m_ConversionTable[i].m_FileFormat[4];
                        break;
                     case SapBuffer.FileFormat.JPEG2000:
                        conversionType = m_ConversionTable[i].m_FileFormat[5];
                        break;
                     default:
                        break;
                     }
                     break;
                  }
               }

               if (conversionType > 0)
               {
                  string message = "";

                  switch (conversionType)
                  {
                  case CONV_TO_MONO8:
                     message = "Warning: data conversion to MONO8 has taken place to save the image in this file format";
                     break;
                  case CONV_TO_RGB8:
                     message = "Warning: data conversion to RGB888 has taken place to save the image in this file format";
                     break;
                  case CONV_TO_RGB10:
                     message = "Warning: data conversion to RGB101010 has taken place to save the image in this file format";
                     break;
                  case CONV_TO_RGB16:
                     message = "Warning: data conversion to RGB161616 has taken place to save the image in this file format";
                     break;
                  }

                  MessageBox.Show(message);
               }

               return m_pBuffer.Save(m_PathName, m_Options, m_StartFrame,0);
            }
         }
         return true;
      }

      protected void UpdateTypeFromFilterIndex()
      {
         // Update type from filter index
         if (m_bSequence)
            m_Type = m_SequenceTypes[m_FileDialog.FilterIndex - 1];
         else
            m_Type = m_StandardTypes[m_FileDialog.FilterIndex - 1];
      }

      public DialogResult ShowDialog()
      {
         // Set name and type
         m_FileDialog.FileName = m_PathName;

         SetFilterIndex();
         if (m_FileDialog.ShowDialog() != DialogResult.OK)
            return DialogResult.Cancel;

         UpdateTypeFromFilterIndex();

         // Update file object
         if (!UpdateBuffer())
            return DialogResult.Abort;

         // Save parameters to registry
         SaveSettings();
         return DialogResult.OK;
      }

      public String PathName
      {
         get { return m_FileDialog.FileName; }
      }



      // General definitions
      const string SEQUENCE_FILTER = "AVI Files (*.avi)|*.avi||";

      /* File Formats */
      // Type table definition
      SapBuffer.FileFormat[] m_StandardTypes;
      static SapBuffer.FileFormat[] m_SequenceTypes = { SapBuffer.FileFormat.AVI };

      string[] m_TiffCompressionTypes = { "corfile_val_compression_none", "corfile_val_compression_rle", "corfile_val_compression_lzw", "corfile_val_compression_jpg" };

      // TIFF file definitions
      const int TIFF_DEFAULT_COMPRESSION_LEVEL = 90;
      const int TIFF_DEFAULT_COMPRESSION_TYPE = 0;
      // JPEG file definitions
      const int JPEG_DEFAULT_QUALITY = 90;

      // RAW File defintions
      const int RAW_DEFAULT_WIDTH = 640;
      const int RAW_DEFAULT_HEIGHT = 480;
      const int RAW_DEFAULT_OFFSET = 0;

      // AVI file definitions
      const int AVI_DEFAULT_START_FRAME = 0;
      const int AVI_DEFAULT_COMPRESSION_LEVEL = 90;
      const int AVI_DEFAULT_COMPRESSION_TYPE = 0;

      class ConversionTable
      {
         public SapFormat m_BufferFormat;
         // Support for saving respectively in BMP, TIFF, CRC, RAW, JPEG and JPEG2000
         public int[] m_FileFormat;

         public ConversionTable(SapFormat bufferFormat, int[] fileFormat)
         {
            m_BufferFormat = bufferFormat;
            m_FileFormat = fileFormat;
         }
      };

      const int UNSUPPORTED   = -1;       // Not supported
      const int NO_CONVERSION =  0;       // Supported without conversion
      const int CONV_TO_MONO8 =  1;       // Supported but converted to MONO8
      const int CONV_TO_RGB8  =  2;       // Supported but converted to RGB888
      const int CONV_TO_RGB10 =  3;       // Supported but converted to RGB101010
      const int CONV_TO_RGB16 =  4;       // Supported but converted to RGB161616

      static ConversionTable[] m_ConversionTable =
      {
         new ConversionTable(SapFormat.Mono8, new int[] {NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION}),
         new ConversionTable(SapFormat.Int8, new int[] {CONV_TO_MONO8, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, NO_CONVERSION}),
         new ConversionTable(SapFormat.Uint8, new int[] {NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION}),
         new ConversionTable(SapFormat.Mono16, new int[] {CONV_TO_MONO8, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, CONV_TO_MONO8, NO_CONVERSION}),
         new ConversionTable(SapFormat.Int16, new int[] {CONV_TO_MONO8, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, NO_CONVERSION}),
         new ConversionTable(SapFormat.Uint16, new int[] {CONV_TO_MONO8, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, CONV_TO_MONO8, NO_CONVERSION}),
         new ConversionTable(SapFormat.Mono32, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Int32, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Uint32, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Mono64, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Int64, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Uint64, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.RGB5551, new int[] {NO_CONVERSION, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.RGB565, new int[] {NO_CONVERSION, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, NO_CONVERSION}),
         new ConversionTable(SapFormat.RGB888, new int[] {NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION}),
         new ConversionTable(SapFormat.RGBR888, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, CONV_TO_RGB8, CONV_TO_RGB8}),
         new ConversionTable(SapFormat.RGB8888, new int[] {NO_CONVERSION, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION}),
         new ConversionTable(SapFormat.RGB101010, new int[] {NO_CONVERSION, CONV_TO_RGB16, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, NO_CONVERSION}),
         new ConversionTable(SapFormat.RGB161616, new int[] {CONV_TO_RGB10, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, NO_CONVERSION}),
         new ConversionTable(SapFormat.RGB16161616, new int[] {CONV_TO_RGB10, CONV_TO_RGB16, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.HSV, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.UYVY, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, CONV_TO_RGB8, CONV_TO_RGB8}),
         new ConversionTable(SapFormat.YUY2, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, CONV_TO_RGB8, CONV_TO_RGB8}),
         new ConversionTable(SapFormat.YVYU, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, CONV_TO_RGB8, CONV_TO_RGB8}),
         new ConversionTable(SapFormat.YUYV, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, CONV_TO_RGB8, CONV_TO_RGB8}),
         new ConversionTable(SapFormat.Y411, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Y211, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.YUV, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Float, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Complex, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Point, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.FPoint, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Mono1, new int[] {NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.HSI, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.RGBP8, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, NO_CONVERSION}),
         new ConversionTable(SapFormat.RGBP16, new int[] {CONV_TO_RGB10, CONV_TO_RGB16, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.BICOLOR88, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.BICOLOR1616, new int[] {CONV_TO_RGB8, CONV_TO_RGB8, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.RGB888_MONO8, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.RGB161616_MONO16, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Mono8P2, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Mono8P3, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Mono16P2, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED}),
         new ConversionTable(SapFormat.Mono16P3, new int[] {UNSUPPORTED, UNSUPPORTED, NO_CONVERSION, NO_CONVERSION, UNSUPPORTED, UNSUPPORTED})
      };

      protected FileDialog m_FileDialog;
      protected SapBuffer m_pBuffer;
      protected string m_PathName = "";
      protected SapBuffer.FileFormat m_Type = SapBuffer.FileFormat.BMP;
      private string m_Options;
      private int m_StartFrame;
      protected bool m_bSequence;
      private bool m_isOpen;
   }
}
