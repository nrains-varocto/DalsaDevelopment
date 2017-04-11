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

namespace Varocto.Cameras
{
    public partial class LsoViewer : Form
    {


        // Delegate to display number of frame acquired 
        // Delegate is needed because .NEt framework does not support  cross thread control modification
        private delegate void DisplayFrameAcquired(int number, bool trash);

        private void Frame_Captured(TransferNotifyEventArgs argsNotify)
        {

               // LsoViewerDlg.Invoke(new DisplayFrameAcquired(LsoViewerDlg.ShowFrameNumber), argsNotify.EventCount, false);
              //  ShowFrameNumber(argsNotify.EventCount, false);
                m_ImageBox.View.Show();


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
        public LsoViewer()
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
            this.m_ImageBox =  new DALSA.SaperaLT.SapClassGui.ImageBox(); 
            this.m_ImageBox.Location = new System.Drawing.Point(241, 4);
            this.m_ImageBox.Name = "m_ImageBox";
            // this.m_ImageBox.PixelValueDisplay = this.PixelDataValue;
            this.m_ImageBox.Size = new System.Drawing.Size(386, 406);
            this.m_ImageBox.SliderEnable = false;
            this.m_ImageBox.SliderMaximum = 10;
            this.m_ImageBox.SliderMinimum = 0;
            this.m_ImageBox.SliderValue = 0;
            this.m_ImageBox.SliderVisible = false;
            this.m_ImageBox.TabIndex = 13;
            this.m_ImageBox.TrackerEnable = false;
            this.m_ImageBox.View = null;
            this.Controls.Add(this.m_ImageBox);
            saperaCameraManager = new SaperaCameraManager();
            saperaCameraManager.Initialize();

            this.m_ImageBox.View = SpyderCamera.Instance.m_View;

            saperaCameraManager.CreateObjects();
            SpyderCamera.Instance.FrameCaptured += new FrameCaptured(Frame_Captured);
           
            m_ImageBox.OnSize();
            EnableSignalStatus();
            UpdateControls();
        }

        private void Instance_FrameCaptured(TransferNotifyEventArgs argsNotify)
        {
            LsoViewer lsoViewer = argsNotify.Context as LsoViewer;
            // If grabbing in trash buffer, do not display the image, update the
            // appropriate number of frames on the status bar instead
            if (argsNotify.Trash)
                lsoViewer.Invoke(new DisplayFrameAcquired(lsoViewer.ShowFrameNumber), argsNotify.EventCount, true);
            // Refresh view
            else
            {
                lsoViewer.Invoke(new DisplayFrameAcquired(lsoViewer.ShowFrameNumber), argsNotify.EventCount, false);
                SpyderCamera.Instance.m_View.Show();
            }
        }

        private void EnableSignalStatus()
        {
            bool status = SpyderCamera.Instance.IsSignalDetected();
            if (status == false)
                StatusLabelInfo.Text = "Online... No camera signal detected";
            else
                StatusLabelInfo.Text = "Online... Camera signal detected";
        }

        private void button_Snap_Click(object sender, EventArgs e)
        {
            AbortDlg abort = new AbortDlg(SpyderCamera.Instance.m_Xfer);
            if (SpyderCamera.Instance.m_Xfer.Snap())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    SpyderCamera.Instance.m_Xfer.Abort();
                UpdateControls();
            }
        }



        // Updates the menu items enabling/disabling the proper items depending on the state of the application
        void UpdateControls()
        {
            bool bAcqNoGrab = (SpyderCamera.Instance.m_Xfer != null) && (SpyderCamera.Instance.m_Xfer.Grabbing == false);
            bool bAcqGrab = (SpyderCamera.Instance.m_Xfer != null) && (SpyderCamera.Instance.m_Xfer.Grabbing == true);
            bool bNoGrab = (SpyderCamera.Instance.m_Xfer == null) || (SpyderCamera.Instance.m_Xfer.Grabbing == false);

            //// Acquisition Control
            //button_Grab.Enabled = bAcqNoGrab && m_online;
            //button_Snap.Enabled = bAcqNoGrab && m_online;
            //button_Freeze.Enabled = bAcqGrab && m_online;

            // Acquisition Control
            button_Grab.Enabled = bAcqNoGrab;
            button_Snap.Enabled = bAcqNoGrab;
            button_Freeze.Enabled = bAcqGrab;

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
            if (SpyderCamera.Instance.m_Xfer.Grab())
                UpdateControls();
        }

        private void button_Freeze_Click_1(object sender, EventArgs e)
        {
            AbortDlg abort = new AbortDlg(SpyderCamera.Instance.m_Xfer);
            if (SpyderCamera.Instance.m_Xfer.Freeze())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    SpyderCamera.Instance.m_Xfer.Abort();
                UpdateControls();
            }
        }
    }
}

