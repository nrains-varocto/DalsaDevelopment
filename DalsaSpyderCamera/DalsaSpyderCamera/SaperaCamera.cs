using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using DALSA.SaperaLT.SapClassBasic;
using Microsoft.Win32;
using System.IO;

namespace Varocto.Cameras
{

    // Singleton implemenation of the Dalsa Spyder III camera library
    public delegate void FrameCaptured(TransferNotifyEventArgs argsNotify);
    public delegate void GetSignalStatusEventHandler(SignalNotifyEventArgs argsSignal);

    public class SpyderCamera
    {
        private static SpyderCamera instance;

        //DalsaSapera support
        private SapAcquisition m_Acquisition;
        public SapBuffer m_Buffers;
        public SapAcqToBuf m_Xfer;
        public SapView m_View;
        private bool m_IsSignalDetected;
        private  bool m_online;
        private bool m_restore;
        private SapLocation m_ServerLocation;
        private string m_ConfigFileName;
        private string m_ServerName;
        private int resourceIndex = 0;

        // delegates
        public event FrameCaptured FrameCaptured;
        public event GetSignalStatusEventHandler SignalStatus;

        //thread safe implementation
        private static readonly object padlock = new object();  
        private SpyderCamera()
        {

            
        }


        public static SpyderCamera Instance
        {
            get
            {
                lock (padlock)
                {
                    if (SpyderCamera.instance == null)
                    {
                        instance = new SpyderCamera();
                    }
                    return instance;
                }
            }
        }

        // Call Create method  
        public bool Initialize(string ServerName, string ConfigFile)
        {

            if (!String.IsNullOrEmpty(ServerName) && !(String.IsNullOrEmpty(ConfigFile)))
            {
                m_ServerName = ServerName;
                m_ConfigFileName = ConfigFile;
                m_ServerLocation = new SapLocation(ServerName, resourceIndex);
            }
            else
                throw new SaperaCameraException("No configuration file");

            // define on-line object
            m_Acquisition = new SapAcquisition(m_ServerLocation, m_ConfigFileName);
            if (SapBuffer.IsBufferTypeSupported(m_ServerLocation, SapBuffer.MemoryType.ScatterGather))
                m_Buffers = new SapBufferWithTrash(2, m_Acquisition, SapBuffer.MemoryType.ScatterGather);
            else
                m_Buffers = new SapBufferWithTrash(2, m_Acquisition, SapBuffer.MemoryType.ScatterGatherPhysical);
            m_Xfer = new SapAcqToBuf(m_Acquisition, m_Buffers);
            m_View = new SapView(m_Buffers);


            //event for view
            m_Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            m_Xfer.XferNotify += new SapXferNotifyHandler(XferNotify);
            m_Xfer.XferNotifyContext = this;

            // event for signal status
            m_Acquisition.SignalNotify += new SapSignalNotifyHandler(GetSignalStatus);
            m_Acquisition.SignalNotifyContext = this;


            return true;
        }

        public bool CreateObjects()
        { 
         // Create acquisition object
            if (m_Acquisition != null && !m_Acquisition.Initialized)
            {
                if (m_Acquisition.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
}
            // Create buffer object
            if (m_Buffers != null && !m_Buffers.Initialized)
            {
                if (m_Buffers.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
                m_Buffers.Clear();
            }
            // Create view object
            if (m_View != null && !m_View.Initialized)
            {
                if (m_View.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
            }
            // Create Xfer object
            if (m_Xfer != null && !m_Xfer.Initialized)
            {
                if (m_Xfer.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
            }
            return true;
        }

        public bool IsSignalDetected()
        {
            bool status = (m_Acquisition.SignalStatus != SapAcquisition.AcqSignalStatus.None);
            m_Acquisition.SignalNotifyEnable = true;
            return status;
        }

        //Call Destroy method
        private void DestroyObjects()
        {
            if (m_Xfer != null && m_Xfer.Initialized)
                m_Xfer.Destroy();
            if (m_View != null && m_View.Initialized)
                m_View.Destroy();
            if (m_Buffers != null && m_Buffers.Initialized)
                m_Buffers.Destroy();
            if (m_Acquisition != null && m_Acquisition.Initialized)
                m_Acquisition.Destroy();
        }

        private void DisposeObjects()
        {
            if (m_Xfer != null)
            { m_Xfer.Dispose(); m_Xfer = null; }
            if (m_View != null)
            { m_View.Dispose(); m_View = null;  }
            if (m_Buffers != null)
            { m_Buffers.Dispose(); m_Buffers = null; }
            if (m_Acquisition != null)
            { m_Acquisition.Dispose(); m_Acquisition = null; }

        }


        static void XferNotify(object sender, SapXferNotifyEventArgs argsNotify)
        {
            TransferNotifyEventArgs transferNotifyEventArgs = new TransferNotifyEventArgs(argsNotify);

            instance.FrameCaptured?.Invoke(transferNotifyEventArgs);
          //  instance.FrameCaptured?.Invoke(new TransferNotifyEventArgs(argsNotify));

            //GrabDemoDlg GrabDlg = argsNotify.Context as GrabDemoDlg;
            //// If grabbing in trash buffer, do not display the image, update the
            //// appropriate number of frames on the status bar instead
            //if (argsNotify.Trash)
            //    GrabDlg.Invoke(new DisplayFrameAcquired(GrabDlg.ShowFrameNumber), argsNotify.EventCount, true);
            //// Refresh view
            //else
            //{
            //    GrabDlg.Invoke(new DisplayFrameAcquired(GrabDlg.ShowFrameNumber), argsNotify.EventCount, false);
            //    GrabDlg.m_View.Show();
            //}
        }


        static void GetSignalStatus(object sender, SapSignalNotifyEventArgs argsSignal)
        {
            instance.SignalStatus?.Invoke(new SignalNotifyEventArgs(argsSignal));
            ////GrabDemoDlg GrabDlg = argsSignal.Context as GrabDemoDlg;
            //SapAcquisition.AcqSignalStatus signalStatus = argsSignal.SignalStatus;

            //GrabDlg.m_IsSignalDetected = (signalStatus != SapAcquisition.AcqSignalStatus.None);
            //if (GrabDlg.m_IsSignalDetected == false)
            //    GrabDlg.StatusLabelInfo.Text = "Online... No camera signal detected";
            //else GrabDlg.StatusLabelInfo.Text = "Online... Camera signal detected";
        }


    }
}
