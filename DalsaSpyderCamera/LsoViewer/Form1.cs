using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;
using LsoViewer;

namespace Varocto.Cameras
{
    public partial class VaroctoCameraViewer : Form
    {


        // Delegate to display number of frame acquired 
        // Delegate is needed because .NEt framework does not support  cross thread control modification
        private delegate void DisplayOctFrameAcquired(int number, bool trash);
        private delegate void DisplayLsoFrameAcquired(int number, bool trash);

        private void Frame_Captured(TransferNotifyEventArgs argsNotify)
        {

               // LsoViewerDlg.Invoke(new DisplayFrameAcquired(LsoViewerDlg.ShowFrameNumber), argsNotify.EventCount, false);
              //  ShowFrameNumber(argsNotify.EventCount, false);
                lsloImageBox.View.Show();


        }

        private SaperaCameraManager saperaCameraManager;

        private void ShowFrameNumber(int number, bool trash)
        {
            String str;
            if (trash)
            {
                str = String.Format("Frames acquired in trash buffer: {0}", number);
                this.StatusLabelInfoTrash.Text = str;
            }
            else
            {
                str = String.Format("Frames acquired :{0}", number);
                this.StatusLabelInfoTrash.Text = str;
            }
        }
        public VaroctoCameraViewer()
        {
            InitializeComponent();

            // Note:
            //  The code to initialize m_ImageBox was originally in the InitializeComponent function
            //  called above. However, it has been moved to the dialog constructor as a workaround
            //  to a Visual Studio Designer error when loading the DALSA.SaperaLT.SapClassBasic
            //  assembly under 64-bit Windows.
            //  As a consequence, it is not possible to adjust the m_ImageBox properties
            //  automatically using the Designer anymore, this has to be done manually.
            // 
            this.lsloImageBox = new DALSA.SaperaLT.SapClassGui.ImageBox();
            this.lsloImageBox.Location = new System.Drawing.Point(208, 112);
            this.lsloImageBox.Name = "lsloImageBox";
            // this.m_ImageBox.PixelValueDisplay = this.PixelDataValue;
            this.lsloImageBox.Size = new System.Drawing.Size(512, 512);
            this.lsloImageBox.SliderEnable = false;
            this.lsloImageBox.SliderMaximum = 10;
            this.lsloImageBox.SliderMinimum = 0;
            this.lsloImageBox.SliderValue = 0;
            this.lsloImageBox.SliderVisible = false;
            this.lsloImageBox.TrackerEnable = false;
            this.lsloImageBox.View = null;
            this.lsloImageBox.MaximumSize = new Size(512, 512);



            this.octImageBox = new DALSA.SaperaLT.SapClassGui.ImageBox();
            this.octImageBox.Location = new System.Drawing.Point(1006,112);
            this.octImageBox.Name = "octImageBox";
            // this.m_ImageBox.PixelValueDisplay = this.PixelDataValue;
            this.octImageBox.Size = new System.Drawing.Size(512, 512);
            this.octImageBox.SliderEnable = false;
            this.octImageBox.SliderMaximum = 10;
            this.octImageBox.SliderMinimum = 0;
            this.octImageBox.SliderValue = 0;
            this.octImageBox.SliderVisible = false;
            this.octImageBox.TrackerEnable = false;
            this.octImageBox.View = null;
            this.octImageBox.MaximumSize = new Size(512, 512);

            this.Controls.Add(this.octImageBox);
            this.Controls.Add(this.lsloImageBox);

            saperaCameraManager = new SaperaCameraManager();
            saperaCameraManager.Initialize();

            this.lsloImageBox.View = saperaCameraManager.lsoCamera.m_View;
            this.octImageBox.View = saperaCameraManager.octCamera.m_View;




            saperaCameraManager.CreateObjects();
            saperaCameraManager.OpenSerialConnections();

            saperaCameraManager.octCamera.EnableTestPattern(true);
            saperaCameraManager.octCamera.CameraLinkOutputFrequency = 3;
            saperaCameraManager.octCamera.LinePeriodInMicroSeconds = 1210;
            saperaCameraManager.octCamera.ExposureTimeInMicroSeconds = "1140";
            saperaCameraManager.octCamera.TestImageHeight = 2048;
            saperaCameraManager.octCamera.RoiSensorWidth = "2048";          //  saperaCameraManager.lsoCamera.FrameCaptured += Frame_Captured;
            saperaCameraManager.octCamera.FrameCaptured += OctCamera_FrameCaptured;
            saperaCameraManager.octCamera.OutputMode = "16912";
            saperaCameraManager.octCamera.SetTriggerMode(false, true);

            float scaledWidth = 512f / 2048f;
            float scaledHeight = 512f / 2048f;
            this.lsloImageBox.View.SetScalingMode(scaledWidth*2f, scaledHeight*2f);
            this.octImageBox.View.SetScalingMode(scaledWidth, scaledHeight);

            this.lsloImageBox.OnSize();
            this.octImageBox.OnSize();

            EnableSignalStatus();
            UpdateControls();
        }

        private void OctCamera_FrameCaptured(TransferNotifyEventArgs argsNotify)
        {
            octImageBox.View.Show();
        }

        private void Instance_FrameCaptured(TransferNotifyEventArgs argsNotify)
        {
            lsloImageBox.View.Show();
            //VaroctoCameraViewer lsoViewer = argsNotify.Context as VaroctoCameraViewer;
            // If grabbing in trash buffer, do not display the image, update the
            // appropriate number of frames on the status bar instead
            //if (argsNotify.Trash)
            //    lsoViewer.Invoke(new DisplayFrameAcquired(lsoViewer.ShowFrameNumber), argsNotify.EventCount, true);
            //// Refresh view
            //else
            //{
            //    lsoViewer.Invoke(new DisplayFrameAcquired(lsoViewer.ShowFrameNumber), argsNotify.EventCount, false);
            //    saperaCameraManager.lsoCamera.m_View.Show();
            //}
        }

        private void EnableSignalStatus()
        {
            bool status = saperaCameraManager.lsoCamera.IsSignalDetected();
            if (status == false)
                StatusLabelInfo.Text = "Online... No camera signal detected";
            else
                StatusLabelInfo.Text = "Online... Camera signal detected";
            status = saperaCameraManager.octCamera.IsSignalDetected();
            if (status == false)
                octSignalStatus.Text = "Online... No camera signal detected";
            else
                octSignalStatus.Text = "Online... Camera signal detected";
        }

        private void button_Snap_Click(object sender, EventArgs e)
        {
            AbortDlg abort = new AbortDlg(saperaCameraManager.lsoCamera.m_Xfer);
            if (saperaCameraManager.lsoCamera.Snap())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    saperaCameraManager.lsoCamera.m_Xfer.Abort();
                UpdateControls();
            }
        }



        // Updates the menu items enabling/disabling the proper items depending on the state of the application
        void UpdateControls()
        {
            bool bLsoAcqNoGrab = (saperaCameraManager.lsoCamera.Grabbing == false);
            bool bLsoAcqGrab = (saperaCameraManager.lsoCamera.Grabbing == true);
            bool bLsoNoGrab =  (saperaCameraManager.lsoCamera.Grabbing == false);

            bool bOctAcqNoGrab = (saperaCameraManager.octCamera.Grabbing == false);
            bool bOctAcqGrab = (saperaCameraManager.octCamera.Grabbing == true);
            bool bOctNoGrab = (saperaCameraManager.octCamera.Grabbing == false);

            //// Acquisition Control
            //button_Grab.Enabled = bAcqNoGrab && m_online;
            //button_Snap.Enabled = bAcqNoGrab && m_online;
            //button_Freeze.Enabled = bAcqGrab && m_online;

            // Acquisition Control
            button_Grab.Enabled = bLsoAcqNoGrab;
            button_Snap.Enabled = bLsoAcqNoGrab;
            button_Freeze.Enabled = bLsoAcqGrab;

            octGrabButton.Enabled = bOctAcqNoGrab;
            octSnapButton.Enabled = bOctAcqNoGrab;
            octFreezeButton.Enabled = bOctAcqGrab;

            //// File Options
            //button_New.Enabled = bNoGrab;
            //button_Load.Enabled = bNoGrab;
            //button_Save.Enabled = bNoGrab;

            //button_LoadConfig.Enabled = bAcqNoGrab || bNoGrab;
            //button_Buffer.Enabled = bNoGrab;
        }

        private void button_Grab_Click_1(object sender, EventArgs e)
        {
            StatusLabelInfoTrash.Text = "";
            if (saperaCameraManager.lsoCamera.Grab())
                UpdateControls();
        }

        private void button_Freeze_Click_1(object sender, EventArgs e)
        {
           // AbortDlg abort = new AbortDlg(saperaCameraManager.lsoCamera.m_Xfer);
            if (saperaCameraManager.lsoCamera.Freeze())
            {
           
                UpdateControls();
            }
        }

        private void octSnapButton_Click(object sender, EventArgs e)
        {
           // AbortDlg abort = new AbortDlg(saperaCameraManager.octCamera.m_Xfer);
            if (saperaCameraManager.octCamera.Snap())
            {
                UpdateControls();
            }

        }

        private void octGrabButton_Click(object sender, EventArgs e)
        {
            StatusLabelInfoTrash.Text = "";
            if (saperaCameraManager.octCamera.Grab())
                UpdateControls();
        }

        private void octFreezeButton_Click(object sender, EventArgs e)
        {
           if (saperaCameraManager.octCamera.m_Xfer.Freeze())
            { 
                UpdateControls();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OctCameraConfig configFrm = new OctCameraConfig(saperaCameraManager.octCamera);
            configFrm.Show();
        }

        private void bufferDialogButton_Click(object sender, EventArgs e)
        {
            BufferDlg bufferDialog = new BufferDlg(saperaCameraManager.octCamera.m_Buffers, saperaCameraManager.octCamera.m_Display, false);
                
            if (bufferDialog.ShowDialog() == DialogResult.OK)
                octImageBox.OnSize();
            octImageBox.Refresh();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            ViewDlg viewDlg = new ViewDlg(octImageBox.View, octImageBox.ViewRectangle);
            if (viewDlg.ShowDialog() == DialogResult.OK)
            {
                octImageBox.OnSize();
            }
            octImageBox.Refresh();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            LoadSaveDlg loadSaveDlg = new LoadSaveDlg(saperaCameraManager.octCamera.m_Buffers, false, false);
            loadSaveDlg.ShowDialog();
        }

        private void VaroctoCameraViewer_Load(object sender, EventArgs e)
        {

        }
    }
}

