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
    public partial class FlatFieldDlg : Form
    {
       private const String DEFAULT_FFC_FILENAME = "FFC.tif";
        private const String STANDARD_FILTER = "TIFF Files (*.tif)|*.tif||";
        private const string DEFAULT_FFC_CLUSTER_MAP_FILENAME = "clustermap.csv";
        private const string FFC_CLUSTER_MAP_FILTER = "CSV (Comma delimited) (*.csv)|*.csv||";
       Boolean m_isGenie = false;
       int m_UserFlatFieldCount = 0;
       int[] flatFieldIndexes = new int[16];
       const float SapDefFlatFieldAvgFactorBlack = 0.25f;
       const float SapDefFlatFieldAvgFactorWhite = 0.80f;
       const float SapDefFlatFieldDefectRatio = 1.00f;
       const float SapDefFlatFieldPixelRatio = 99.00f;
       // Various constants
       const int DefNumFramesAverage = 10;
    

       // Log message types
       enum LogTypes
       {
          Error,
          Warning,
          Info
       };

       SapFlatField m_pFlatField;
       SapTransfer m_pXfer;
       SapBuffer m_pBuffer;
       SapBuffer m_pLocalBuffer;
       SapFlatField.ScanCorrectionType m_CorrectionType;
       SapAcquisition.VideoType m_VideoType;
	    int m_RecommendedDark;
	    int m_RecommendedBright;

  
       public FlatFieldDlg(SapFlatField pFlatField, SapTransfer pXfer, SapBuffer pBuffer)
        {
            InitializeComponent();
            m_pBuffer = pBuffer;
            m_pFlatField = pFlatField;
            m_pXfer = pXfer;

	         m_RecommendedDark = 0;
	         m_RecommendedBright = 0;
        }

       private void FlatFieldDlg_Load(object sender, EventArgs e)
       {
            if( m_pBuffer == null || !m_pBuffer.Initialized)
            {
	            MessageBox.Show("Invalid buffer object");
	            this.Close();
	            return;
            }

            if (m_pFlatField == null)
            {
                MessageBox.Show("Invalid flat-field object");
                this.Close();
                return;
            }

            String str;
            bool    isOffLine = (m_pXfer == null);

            str = String.Format("Step 1: {0} a Dark image", isOffLine ? "Load": "Acquire");
            label_darkImage1.Text = str; 

            str = String.Format("{0} a Dark Image", isOffLine ? "Load": "Acquire");
            button_Acq_Dark.Text = str;

            str = String.Format("Step 2: {0} a non-saturated bright image", isOffLine ? "Load": "Acquire");
            label_brightImage1.Text = str;

            str = String.Format("{0} Bright Image", isOffLine ? "Load": "Acquire");
            button_Acq_Bright.Text = str;

            // Calculate recommended values for dark and bright images
            int maxPixelValue = (int) Math.Pow(2.0, m_pBuffer.PixelDepth);
	         m_RecommendedDark = (int)(maxPixelValue * SapDefFlatFieldAvgFactorBlack);
	         m_RecommendedBright = (int)(maxPixelValue * SapDefFlatFieldAvgFactorWhite);

            // Adjust the recommended dark value according to the hardware limit for offset coefficients
            int offsetMax = m_pFlatField.OffsetMax;

            if (m_RecommendedDark > offsetMax)
                m_RecommendedDark = offsetMax;

            str = String.Format("(recommended average pixel\nvalue below {0})", m_RecommendedDark);
            label_darkImage2.Text = str;

            str = String.Format("(recommended average pixel\nvalue around {0})", m_RecommendedBright);
            label_brightImage2.Text = str;

            // Adjust maximum black deviation from the adjusted recommended dark value
            if (m_pFlatField.DeviationMaxBlack > m_RecommendedDark)
                m_pFlatField.DeviationMaxBlack = m_RecommendedDark;

            // Query correction type, video type, number of lines to average (line scan),
            // vertical offset, gain divisor, maximum deviation, and calibration index
            // for the dark image from flat field object
            m_CorrectionType          = m_pFlatField.CorrectionType;
            m_VideoType               = m_pFlatField.AcqVideoType;
            textBox_Line_Avg.Text     = m_pFlatField.NumLinesAverage.ToString();
            textBox_Vert_Offset.Text  = m_pFlatField.VerticalOffset.ToString();
            textBox_Max_Dev.Text      = m_pFlatField.DeviationMaxBlack.ToString();
            //m_CalibrationIndex = m_pFlatField->GetIndex();
            textBox_Frame_Avg.Text = DefNumFramesAverage.ToString();
            ClippedCoefsDefects_checkbox.Checked = m_pFlatField.ClippedGainOffsetDefects ? true : false;

            // Set correction type
            comboBox_Correction_Type.Items.Add("Flat Field");
            comboBox_Correction_Type.Items.Add("Flat Line");
            comboBox_Correction_Type.SelectedIndex = m_CorrectionType == SapFlatField.ScanCorrectionType.Field ? 0 : 1;

            // Set video type
            comboBox_Video_Type.Items.Add( "Monochrome");
            comboBox_Video_Type.Items.Add( "Bayer");
            comboBox_Video_Type.SelectedIndex =  m_VideoType != SapAcquisition.VideoType.Bayer ? 0: 1;

           
          ///////////////////////////////////////////////////
          //Multi flat-field not implemented in .NET/////////
          //////////////////////////////////////////////////
            // Set calibration index
            // String indexStr;

            //for (int index = 0; index < m_pFlatFieldGetNumFlatField(); index++)
            //{
            //   indexStr.Format("%d", index);
            //   m_CalibrationIndexCtrl.AddString( indexStr);
            //}

            comboBox_Calibration_Index.Items.Add(0);
            comboBox_Calibration_Index.SelectedIndex = 0;


           if (m_pFlatField.AcqDevice != null)
           {
               SapFeature feature = new SapFeature(m_pFlatField.AcqDevice.Location);
                feature.Create();

                Boolean status = false;
                String deviceModel;

                //for all Genies except Genie TS, do not try to do a file access
                status = m_pFlatField.AcqDevice.IsFeatureAvailable("DeviceModelName");
                if(status)
                {
                    m_pFlatField.AcqDevice.GetFeatureValue("DeviceModelName", out deviceModel);
                    if (deviceModel.Contains("Genie") && !deviceModel.Contains("TS"))
                    {
                        //device is a Genie but not Genie TS
                        
                        m_isGenie = true;
                        button_Save_and_Upload.Text = "Save";
                        comboBox_FlatField_Selector.Visible = false;
                        label_flatField.Visible = false;
                        goto nextPart;
                    }
                }
               
               for (int i = 0; i < m_pFlatField.AcqDevice.FileCount ; i++)
               {
                    if (m_pFlatField.AcqDevice.FileNames[i].Contains("FlatField"))
                    {
                        String featureName = "##FileSelector." + m_pFlatField.AcqDevice.FileNames[i];

                        if (!m_pFlatField.AcqDevice.FileNames[i].Contains("0"))
                        {
                            if (m_pFlatField.AcqDevice.GetFeatureInfo(featureName, feature))
                            {
                                comboBox_FlatField_Selector.Items.Add(feature.DisplayName);               
                            }
                            else
                            {
                                comboBox_FlatField_Selector.Items.Add(m_pFlatField.AcqDevice.FileNames[i]); 
                            }
                            flatFieldIndexes[m_UserFlatFieldCount++] = i;
                           // comboBox_FlatField_Selector.items (m_UserFlatFieldCount++, i);
                        }
                    }
                }

                comboBox_FlatField_Selector.SelectedIndex = 0;
                feature.Destroy();
                saveLabel.Text = "Save Calibration offset and gain files";
            }
            else
            {
                button_Save_and_Upload.Text = "Save";
                comboBox_FlatField_Selector.Visible = false;
                label_flatField.Visible = false;
            }
           nextPart:
            // Enable/disable controls according to current properties
            // Changing the correction type (flat-field vs flat-line) is only relevant when operating
            // offline, that is, when this information is not available from the acquisition hardware.
            bool isOnline = (m_pXfer != null && m_pXfer.Initialized);
            comboBox_Correction_Type.Enabled = !isOnline && m_VideoType != SapAcquisition.VideoType.Bayer;
            comboBox_Video_Type.Enabled = m_pXfer == null;

            textBox_Frame_Avg.Enabled = m_pXfer != null;
            textBox_Line_Avg.Enabled = m_CorrectionType == SapFlatField.ScanCorrectionType.Line;
            textBox_Vert_Offset.Enabled = m_CorrectionType == SapFlatField.ScanCorrectionType.Line;
            textBox_Max_Dev.Enabled = true;

            //Multi flat-field not implemented in .NET
            comboBox_Calibration_Index.Enabled = false; //m_pFlatField->GetNumFlatField() > 1);

            button_Acq_Dark.Enabled = true;
            button_Acq_Bright.Enabled = false;
            button_OK.Enabled = false;
            button_Save_and_Upload.Enabled = false;
            comboBox_FlatField_Selector.Enabled = false;
           
       }

       private void button_Acq_Dark_Click(object sender, EventArgs e)
       {
          int nbImagesUsed = m_pFlatField.CorrectionType == SapFlatField.ScanCorrectionType.Field ? int.Parse(textBox_Frame_Avg.Text) : 1;
	      
          // Set correction type
          m_pFlatField.CorrectionType =  m_CorrectionType;

	       // Set video type
          m_pFlatField.SetVideoType(m_VideoType, SapBayer.AlignMode.BGGR);

	       // Set maximum deviation from average pixel value for dark image
	       m_pFlatField.DeviationMaxBlack =  int.Parse(textBox_Max_Dev.Text);

	       // Set number of lines to average and vertical offset
          m_pFlatField.NumLinesAverage = int.Parse(textBox_Line_Avg.Text);
	       m_pFlatField.VerticalOffset = int.Parse(textBox_Vert_Offset.Text);

	       // Set wether to declare pixels with clipped coefficient as defective
	       m_pFlatField.ClippedGainOffsetDefects = ClippedCoefsDefects_checkbox.Checked;

          //Multi flat-field not implemented in .NET
         // Set calibration index
         //m_pFlatField->SetIndex(m_CalibrationIndex);
         
         LogMessageBox.ResetText();

         if (m_pXfer != null && m_pXfer.Initialized)
         {
		      m_pLocalBuffer = new SapBuffer(nbImagesUsed, m_pBuffer, SapBuffer.MemoryType.Default );
		      m_pLocalBuffer.Create();

            // Acquire an image
            if (!Snap())
            {
               LogMessage(LogTypes.Error, "Unable to acquire an image");
               if (m_pLocalBuffer != null)
	            {
		            m_pLocalBuffer.Destroy();
		            m_pLocalBuffer.Dispose();
		            m_pLocalBuffer = null;
	            }
               return;
            }
         }
         else
         {
            // Load an image

            m_pLocalBuffer = new SapBuffer(1, m_pBuffer, SapBuffer.MemoryType.Default);
		      m_pLocalBuffer.Create();

            LoadSaveDlg dlg = new LoadSaveDlg( null, true,false);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
               if (m_pLocalBuffer != null)
	            {
		            m_pLocalBuffer.Destroy();
		            m_pLocalBuffer.Dispose();
		            m_pLocalBuffer = null;
	            }
               return;
            }

            String path = dlg.PathName;

            // Create a temporary buffer in order to know the selected file's native format and pixel depth

            SapBuffer loadBuffer = new SapBuffer(path, SapBuffer.MemoryType.Default);
            loadBuffer.Create();

            if(loadBuffer.Format != m_pBuffer.Format || loadBuffer.PixelDepth != m_pBuffer.PixelDepth)
            {
               LogMessage(LogTypes.Warning, "Image file has a different format than expected.  Pixel values may get shifted.");
            }

            if( loadBuffer.Width != m_pBuffer.Width || loadBuffer.Height != m_pBuffer.Height)
            {
               LogMessage(LogTypes.Error, "Image file selected doesn't have same dimensions as buffer.");
               if (m_pLocalBuffer != null)
               {
                  m_pLocalBuffer.Destroy();
                  m_pLocalBuffer.Dispose();
                  m_pLocalBuffer = null;
               }
               return;
            }

            //loadBuffer.Load(path,1);
            m_pLocalBuffer.Copy(loadBuffer);

		      String str;
            str = String.Format("Loaded dark image: {}", path);
            LogMessage(LogTypes.Info, str);
         }
         DarkImage();
       }


       //
       // Step 2: Snap a bright image to calculate the gain coefficients
       //
       private void button_Acq_Bright_Click(object sender, EventArgs e)
       {
         int nbImagesUsed = m_pFlatField.CorrectionType == SapFlatField.ScanCorrectionType.Field ? int.Parse(textBox_Frame_Avg.Text) : 1;

	      // Set maximum deviation from average pixel value for bright image
	      m_pFlatField.DeviationMaxWhite = int.Parse(textBox_Max_Dev.Text);

	      // Set number of lines to average and vertical offset
	      m_pFlatField.NumLinesAverage = int.Parse(textBox_Line_Avg.Text);
	      m_pFlatField.VerticalOffset = int.Parse(textBox_Vert_Offset.Text);

	      // Set wether to declare pixels with clipped coefficient as defective
	      m_pFlatField.ClippedGainOffsetDefects = ClippedCoefsDefects_checkbox.Checked;

	      if (m_pXfer != null && m_pXfer.Initialized)
         {
		      m_pLocalBuffer = new SapBuffer(nbImagesUsed, m_pBuffer, SapBuffer.MemoryType.Default);
		      m_pLocalBuffer.Create();

            // Acquire an image
            if (!Snap())
            {
               LogMessage(LogTypes.Error, "Unable to acquire an image");
               if (m_pLocalBuffer != null)
	            {
		            m_pLocalBuffer.Destroy();
		            m_pLocalBuffer.Dispose();
		            m_pLocalBuffer = null;
	            }
               return;
            }
         }
         else
         {
            // Load an image
		      m_pLocalBuffer = new SapBuffer(1, m_pBuffer, SapBuffer.MemoryType.Default);
		      m_pLocalBuffer.Create();


            LoadSaveDlg dlg = new LoadSaveDlg( null, true,false);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
               if (m_pLocalBuffer != null)
	            {
		            m_pLocalBuffer.Destroy();
		            m_pLocalBuffer.Dispose();
		            m_pLocalBuffer = null;
	            }
               return;
            }

            String path = dlg.PathName;

            // Create a temporary buffer in order to know the selected file's native format and pixel depth

            SapBuffer loadBuffer = new SapBuffer(path, SapBuffer.MemoryType.Default);
            loadBuffer.Create();

            if(loadBuffer.Format != m_pBuffer.Format || loadBuffer.PixelDepth != m_pBuffer.PixelDepth)
            {
               LogMessage(LogTypes.Warning, "Image file has a different format than expected.  Pixel values may get shifted.");
            }

            if( loadBuffer.Width != m_pBuffer.Width || loadBuffer.Height != m_pBuffer.Height )
            {
               LogMessage(LogTypes.Error, "Image file selected doesn't have same dimensions as buffer.");
               if (m_pLocalBuffer != null)
	            {
		            m_pLocalBuffer.Destroy();
		            m_pLocalBuffer.Dispose();
		            m_pLocalBuffer = null;
	            }
               return;
            }

            loadBuffer.Load(path,1);
            m_pLocalBuffer.Copy(loadBuffer);

		      String str;
            str = String.Format( "Loaded bright image: '{0}'", path);
            LogMessage(LogTypes.Info, str);
	      }

         BrightImage();
       }

       private void button1_Click(object sender, EventArgs e)
       {
          if (m_pBuffer != null && m_pBuffer.Initialized)
             m_pBuffer.Clear();
       }

       private void button2_Click(object sender, EventArgs e)
       {
          if (m_pBuffer != null && m_pBuffer.Initialized)
             m_pBuffer.Clear();
       }

       private void comboBox_Correction_Type_SelectedIndexChanged(object sender, EventArgs e)
       {
            m_CorrectionType = comboBox_Correction_Type.SelectedIndex == 0 ? SapFlatField.ScanCorrectionType.Field : SapFlatField.ScanCorrectionType.Line;

            textBox_Line_Avg.Enabled = m_CorrectionType == SapFlatField.ScanCorrectionType.Line;
	         textBox_Vert_Offset.Enabled = m_CorrectionType == SapFlatField.ScanCorrectionType.Line;
	         comboBox_Video_Type.Enabled = m_CorrectionType == SapFlatField.ScanCorrectionType.Field ;
       }

       private void comboBox_Video_Type_SelectedIndexChanged(object sender, EventArgs e)
       {
            m_VideoType = comboBox_Video_Type.SelectedIndex == 0 ? SapAcquisition.VideoType.Mono : SapAcquisition.VideoType.Bayer;
	         comboBox_Correction_Type.Enabled = m_VideoType == SapAcquisition.VideoType.Mono;
       }

       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
       {
          //int curSel = m_CalibrationIndexCtrl.GetCurSel();
          //if (curSel != CB_ERR)
          //   m_CalibrationIndex = curSel;
       }

       private void DarkImage()
       {
         String str;
	      SapFlatFieldStats stats = new SapFlatFieldStats();

	      str = String.Format( "Correction type: {0}", m_CorrectionType);
         LogMessage(LogTypes.Info, str);

	      str = String.Format( "Video type: {0}", m_VideoType);
         LogMessage(LogTypes.Info, str);

	      if( m_pXfer != null)
	      {
		      str = String.Format( "Number of frames to average: {0}",textBox_Frame_Avg.Text);
            LogMessage(LogTypes.Info, str);
	      }

	      if( m_CorrectionType == SapFlatField.ScanCorrectionType.Line)
	      {
		      str = String.Format( "Number of lines to average: {0}", textBox_Line_Avg.Text);
            LogMessage(LogTypes.Info, str);

		      str = String.Format( "Vertical offset from top: {0}",textBox_Vert_Offset.Text);
            LogMessage(LogTypes.Info, str);	
	      }

         LogMessage(LogTypes.Info, "Dark image calibration");

         if (!m_pFlatField.GetStats(m_pLocalBuffer, stats))
         {
            LogMessage(LogTypes.Error, "   Unable to get image statistics");
            return;
         }

         bool tooManyBadPixels = false;
         int numComponents = stats.NumComponents;

         for (int i = 0; i < numComponents; i++)
         {
            if (stats.get_Average(i) > m_RecommendedDark)
            {
               tooManyBadPixels = true;
               break;
            }
         }

         if (tooManyBadPixels && m_pFlatField.ClippedGainOffsetDefects)
         {
            str = "The following statistics have been computed on the dark image: \n";
            str += String.Format("The average pixel value is {0}\n", GetAverageStr(stats));
            str += String.Format("\nThis yields too many bad pixels above the hardware limit of {0}\n", m_RecommendedDark);
            str += String.Format("\nTo disable bad pixels, uncheck the \'Consider as defective ...\'\n");
            str += String.Format("checkbox, then acquire the dark image again\n");

            MessageBox.Show(str, "",  MessageBoxButtons.OK);
            return;
         }
         else
         {
            str = "The following statistics have been computed on the dark image: \n";
            str += String.Format("The average pixel value is {0}\n", GetAverageStr(stats));
            str += String.Format("\nWe recommend an average pixel value of less than {0}\n", m_RecommendedDark);
            str += String.Format("\nDo you want to use this image?");

            if (MessageBox.Show(str, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
         }

         // Log pixel statistics
         str = String.Format("    Average pixel value: {0}", GetAverageStr( stats));
         LogMessage(LogTypes.Info, str);

	      str = String.Format("    Maximum deviation allowed from average pixel value: {0}", textBox_Max_Dev.Text);
         LogMessage(LogTypes.Info, str);

         // Compute offset coefficients using last acquired image
         m_pFlatField.NumFramesAverage = m_pLocalBuffer.Count;
         if (m_pFlatField.ComputeOffset(m_pLocalBuffer))
         {
            button_Acq_Dark.Enabled = false;
            button_Acq_Bright.Enabled = true;

            comboBox_Correction_Type.Enabled = false;
            comboBox_Video_Type.Enabled = false;
            comboBox_Calibration_Index.Enabled = false;

            LogMessage(LogTypes.Info, "Calibration with a dark image has been done successfully");
            textBox_Max_Dev.Text =  m_pFlatField.DeviationMaxWhite.ToString();
		     
         }
       }
      
       private void BrightImage()
       {
         String str;
         SapFlatFieldStats stats = new SapFlatFieldStats();

	      if( m_pXfer != null)
	      {
		      str = String.Format( "Number of frames to average: {0}", textBox_Frame_Avg.Text);
            LogMessage(LogTypes.Info, str);
	      }

	      if( m_CorrectionType == SapFlatField.ScanCorrectionType.Line)
	      {
		      str = String.Format( "Number of lines to average: {0}", textBox_Line_Avg.Text);
	         LogMessage(LogTypes.Info, str);

		      str = String.Format( "Vertical offset from top: {0}", textBox_Vert_Offset.Text);
	         LogMessage(LogTypes.Info, str);	
	      }

	      LogMessage(LogTypes.Info, "Bright image calibration");

         // Get statistics on the (bright - dark) image
         if (!m_pFlatField.GetStats(m_pLocalBuffer, stats))
         {
            LogMessage(LogTypes.Error, "Unable to get image statistic");
            return;
         }

         str = "The following statistics have been computed on the bright image\n";
         str += "after the substraction of the dark image:\n\n";
         str += String.Format("    The average pixel value is {0}levels.\n",GetAverageStr( stats));
			str += String.Format("    The highest peak has been detected at {0}.\n",GetPeakPositionStr( stats));
         str += String.Format("    {0} pixels {1} have a luminance value between {2} to {3}\n",GetNumPixelsStr( stats),GetPixelRatioStr( stats),GetLowStr( stats),GetHighStr( stats));
         str += String.Format("\nWe recommend at least {0} levels for the highest peak value\n", m_RecommendedBright);
         str += String.Format("with {0}% pixels lying between the lower and the higher bound.\n",SapDefFlatFieldPixelRatio);
         str +="\nDo you want to use this image?";
                 
         if (MessageBox.Show(str,"", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

         // Log average pixel value, lower and higher bounds and pixel ratio
         str = String.Format("    Average pixel value: {0}", GetAverageStr( stats));
         LogMessage(LogTypes.Info, str);
	      str = String.Format("    Maximum deviation allowed from average pixel value: {0}", textBox_Max_Dev.Text);
         LogMessage(LogTypes.Info, str);
         str = String.Format("    Highest peak position: {0}", GetPeakPositionStr( stats));
         LogMessage(LogTypes.Info, str);
         str = String.Format("    Lower bound: {0}", GetLowStr( stats));
         LogMessage(LogTypes.Info, str);
         str = String.Format("    Upper bound: {0}", GetHighStr( stats));
         LogMessage(LogTypes.Info, str);
         str = String.Format("    Number of pixels inside bounds: {0} ({1})", GetNumPixelsStr( stats), GetPixelRatioStr( stats));
         LogMessage(LogTypes.Info, str);

         SapFlatFieldDefects defects  = new SapFlatFieldDefects();

         // Compute gain coefficient using last acquired image

         m_pFlatField.NumFramesAverage = m_pLocalBuffer.Count;
         if (m_pFlatField.ComputeGain(m_pLocalBuffer, defects, true))
         {
            // Check for the presence of cluster (adjacent defective pixels)
            if (defects.NumClusters != 0)
            {
               str = String.Format("{0} pixels ({1} %) have been identified as being defective\n", defects.NumDefects, defects.DefectRatio);
               str += String.Format("with {0} clusters.\n",defects.NumClusters);
               str += String.Format("\nWe recommend less than {0}% of defective pixels with no cluster.\n", SapDefFlatFieldDefectRatio);
               str += String.Format("\nDo you still want to use this image?\n");
                   
               if( MessageBox.Show(str,"", MessageBoxButtons.YesNo) != DialogResult.Yes)
                  return;
            }

            // Log number of defective pixels detected
            str = String.Format("    Number of defective pixels detected: {0} ({1})", defects.NumDefects, defects.DefectRatio);
            LogMessage(LogTypes.Info, str);

            // Log number of cluster detected
            str = String.Format("    Number of clusters detected: {0}", defects.NumClusters);
            LogMessage(LogTypes.Info, str);

            button_Acq_Dark.Enabled = true;
            button_Acq_Bright.Enabled = false;
            button_OK.Enabled = true;
            bool isOnline = (m_pXfer != null && m_pXfer.Initialized);
            comboBox_Correction_Type.Enabled = !isOnline && m_VideoType == SapAcquisition.VideoType.Mono;
            comboBox_Video_Type.Enabled = m_pXfer == null;
            textBox_Frame_Avg.Enabled = m_pXfer != null;
            textBox_Line_Avg.Enabled = m_CorrectionType == SapFlatField.ScanCorrectionType.Line;
            textBox_Vert_Offset.Enabled = m_CorrectionType == SapFlatField.ScanCorrectionType.Line;
            textBox_Max_Dev.Enabled = true;
            button_Save_and_Upload.Enabled = true;
            comboBox_FlatField_Selector.Enabled = true;

            //Multi flat-field not implemented in .NET
            //m_CalibrationIndexCtrl.EnableWindow( m_pFlatField->GetNumFlatField() > 1);

		      LogMessage(LogTypes.Info, "Calibration with a bright image has been done successfully");

		      textBox_Max_Dev.Text = m_pFlatField.DeviationMaxBlack.ToString();
         }
       }

       // Snap
       //    Acquire image(s)
       //
       private bool Snap()
       {
         // Check if the transfer object is available
         if( m_pXfer == null || !m_pXfer.Initialized)
            return false;

         for( int iFrame= 0; iFrame < m_pLocalBuffer.Count; iFrame++)
         {
	         // Acquire one image
	         m_pXfer.Snap();

	         // Wait until the acquired image has been transferred into system memory
            AbortDlg abort = new AbortDlg(m_pXfer);
            if (abort.ShowDialog() != DialogResult.OK)
            {
               m_pXfer.Abort();
               return false;
            }

            //Add a short delay to ensure the transfer callback has time to arrive
            System.Threading.Thread.Sleep(100);

	        if( m_pLocalBuffer != null)
	        {
		        m_pLocalBuffer.Index = iFrame;
		        m_pLocalBuffer.Copy(m_pBuffer);
	        }
         }
         return true;
       }

       private void LogMessage(LogTypes messageType, String str)
       {
         String message = "";

         // Message header
         switch (messageType)
         {
            case LogTypes.Error:
               message = "[Err] ";
               break;
            case LogTypes.Warning:
               message = "[Wrn] ";
               break;
            case LogTypes.Info:
               message = "[Msg] ";
               break;
         }

         message += str;
         LogMessageBox.BeginUpdate();
         LogMessageBox.Items.Add(message);
         LogMessageBox.EndUpdate();
     
      }
	
	   String GetAverageStr( SapFlatFieldStats stats) 
      {
         String str = "";

         if (stats.NumComponents > 1)
         {
            str += "[ ";
            for (int iComponent = 0; iComponent < stats.NumComponents; iComponent++)
            {
               String szComponent; 
               szComponent = String.Format("{0}", stats.get_Average(iComponent));
               str += szComponent;

               if (iComponent != stats.NumComponents - 1)
                  str += ", ";
            }
            str += " ]";
         }
         else
         {
            str = String.Format("{0}", stats.Average);
         }

         return str;
      }

	   String GetLowStr( SapFlatFieldStats stats) 
      {
        String str = "";

         if (stats.NumComponents > 1)
         {
            str += "[ ";
            for (int iComponent = 0; iComponent < stats.NumComponents; iComponent++)
            {
               String szComponent; ;
               szComponent = String.Format("{0}", stats.get_Low(iComponent));
               str += szComponent;

               if (iComponent != stats.NumComponents - 1)
                  str += ", ";
            }
            str += " ]";
         }
         else
         {
            str = String.Format("{0}", stats.Low);
         }

         return str;
      }
	
       String GetHighStr( SapFlatFieldStats stats)
       {
          String str = "";

          if (stats.NumComponents > 1)
          {
             str += "[ ";
             for (int iComponent = 0; iComponent < stats.NumComponents; iComponent++)
             {
                String szComponent; 
                szComponent = String.Format("{0}", stats.get_High(iComponent));
                str += szComponent;

                if (iComponent != stats.NumComponents - 1)
                   str += ", ";
             }
             str += " ]";
          }
          else
          {
             str = String.Format("{0}", stats.High);
          }

          return str;
       }
	
       String GetPixelRatioStr( SapFlatFieldStats stats)
       {
          String str = "";

          if (stats.NumComponents > 1)
          {
             str += "[ ";
             for (int iComponent = 0; iComponent < stats.NumComponents; iComponent++)
             {
                String szComponent; ;
                szComponent = String.Format("{0}", stats.get_PeakPosition(iComponent));
                str += szComponent;

                if (iComponent != stats.NumComponents - 1)
                   str += ", ";
             }
             str += " ]";
          }
          else
          {
             str = String.Format("{0}", stats.PeakPosition);
          }

          return str;
       }
	
       String GetNumPixelsStr( SapFlatFieldStats stats)
       {
          String str = "";

          if (stats.NumComponents > 1)
          {
             str += "[ ";
             for (int iComponent = 0; iComponent < stats.NumComponents; iComponent++)
             {
                String szComponent; ;
                szComponent = String.Format("{0}", stats.get_PixelRatio(iComponent));
                str += szComponent;

                if (iComponent != stats.NumComponents - 1)
                   str += ", ";
             }
             str += " ]";
          }
          else
          {
             str = String.Format("{0}", stats.PixelRatio);
          }

          return str;
       }
	
       String GetPeakPositionStr( SapFlatFieldStats stats) 
       {
         String str = "";

         if (stats.NumComponents > 1)
         {
            str += "[ ";
            for (int iComponent = 0; iComponent < stats.NumComponents; iComponent++)
            {
               String szComponent; ;
               szComponent = String.Format("{0}", stats.get_NumPixels(iComponent));
               str += szComponent;

               if (iComponent != stats.NumComponents - 1)
                  str += ", ";
            }
            str += " ]";
         }
         else
         {
            str = String.Format("{0}", stats.NumPixels);
         }

         return str;
       }

       private void button_Save_and_Upload_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save Flat Field Correction";
            dlg.FileName = DEFAULT_FFC_FILENAME;
            dlg.Filter = STANDARD_FILTER;
           
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Save flat field offset correction file
                m_pFlatField.Save(dlg.FileName);
                LogMessage(LogTypes.Info, "File saved successfully.");
                if (m_UserFlatFieldCount > 1 && !m_isGenie)
                {
                    //CWaitCursor waitCursor;
                    LogMessage(LogTypes.Info, "Uploading file to device... Please wait.");
                    int index = flatFieldIndexes[comboBox_FlatField_Selector.SelectedIndex];
                    int timeout = SapManager.CommandTimeout;
                    SapManager.CommandTimeout = 5 * 60 * 1000; //5 minutes timeout
                    if (m_pFlatField.AcqDevice.WriteFile(dlg.FileName, index))
                        LogMessage(LogTypes.Info, "File upload completed successfully.");
                    else
                        LogMessage(LogTypes.Error, "File upload failed.");
                    //restore original timeout
                    SapManager.CommandTimeout = timeout;
                }
            }
        }

       private void button_load_cluster_Click(object sender, EventArgs e)
       {
          OpenFileDialog dlg = new OpenFileDialog();
          dlg.Title = "Load defective pixels cluster map";
          dlg.FileName = DEFAULT_FFC_CLUSTER_MAP_FILENAME;
          dlg.Filter = FFC_CLUSTER_MAP_FILTER;

          if(dlg.ShowDialog() == DialogResult.OK)
          {
             if(m_pFlatField.SetClusterMap(dlg.FileName))
               label_load_cluster.Text = "Cluster map loaded with " + m_pFlatField.ClusterMapPixelCount + " defective pixels";
             else
                label_load_cluster.Text = "Invalid cluster map";
          }
       }
      
    }
}