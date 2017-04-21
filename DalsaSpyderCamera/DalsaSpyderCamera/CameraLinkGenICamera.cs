
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DALSA.SaperaLT.SapClassBasic;
    using Microsoft.Win32;
    using System.IO;
    using System.IO.Ports;

    namespace Varocto.Cameras
    {

        // Singleton implemenation of the Dalsa Spyder III camera library
        public delegate void FrameCaptured(TransferNotifyEventArgs argsNotify);
        public delegate void GetSignalStatusEventHandler(SignalNotifyEventArgs argsSignal);

        public class CameraLinkGenICamera : IVaroctoCamera
        {


        //DalsaSapera support
            internal SapAcquisition m_Acquisition;
            public SapBuffer m_Buffers;
            public SapAcqToBuf m_Xfer;
            public SapView m_View;
            public SapDisplay m_Display;
            internal bool m_IsSignalDetected;
            internal bool m_online;
            internal bool m_restore;
            internal SapLocation m_ServerLocation;
            internal string m_ConfigFileName;
            internal string m_ServerName;

        public IntPtr[] buffer; 

            internal System.Threading.ManualResetEvent serialReplyEvent = new System.Threading.ManualResetEvent(false);
            internal int serialLastByteRead; 

            // delegates
            public event FrameCaptured FrameCaptured;
            public event GetSignalStatusEventHandler SignalStatus;

        //thread safe implementation
             internal readonly object padlock = new object();

            internal SerialPort serialPort;

            public CameraLinkGenICamera()
            { }
            public CameraLinkGenICamera(string ServerName, string ConfigFile, int ResourceIndex)
            {
                if (!String.IsNullOrEmpty(ServerName) && !(String.IsNullOrEmpty(ConfigFile)))
                {
                    m_ServerName = ServerName;
                    m_ConfigFileName = ConfigFile;
                    m_ServerLocation = new SapLocation(ServerName, ResourceIndex);
                }
                else
                    throw new SaperaCameraException("No configuration file");

            }


            // Call Create method  
            public bool Initialize()
            {

                // define on-line object
               
                m_Acquisition = new SapAcquisition(m_ServerLocation, m_ConfigFileName);
                if (SapBuffer.IsBufferTypeSupported(m_ServerLocation, SapBuffer.MemoryType.Contiguous))
                {
                    m_Buffers = new SapBufferWithTrash(2, m_Acquisition, SapBuffer.MemoryType.ScatterGatherPhysical );
                }
                else
                    m_Buffers = new SapBufferWithTrash(2, m_Acquisition, SapBuffer.MemoryType.ScatterGatherPhysical);

            //m_Buffers.Format = SapFormat.Mono16;
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

            public bool Grab()
            {
                bool retVal = true;
                lock (padlock)
                {
                    retVal = m_Xfer.Grab();
                }
                return retVal;
            }
            public bool Snap()
            {
                bool retVal = true;
                lock (padlock)
                {
                    retVal = m_Xfer.Snap();
                }
                return retVal;
            }
            public bool Freeze()
            {
                bool retVal = true;
                lock (padlock)
                {
                    retVal = m_Xfer.Freeze();
                }
                return retVal;
            }

            public bool Grabbing
            {
               get
                {
                    bool retVal = true;
                    lock (padlock)
                    {
                        retVal = m_Xfer.Grabbing;
                    }
                    return retVal;
                }
            }

            internal void OpenSerialConnection()
            {
                serialPort = new SerialPort(m_Acquisition.SerialPortName, 9600, Parity.None, 8);
                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;

            }

             internal void CloseSerialConnection()
            {
                if (serialPort != null)
                    serialPort.Close();
            }

            internal string serialBuffer = "";
            internal void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                lock (padlock)
                {
                    System.Threading.Thread.Sleep(100);
                    serialBuffer += serialPort.ReadExisting();
                    if (!serialBuffer.Contains("Ok"))
                    {
                        serialBuffer = "";
                        serialReplyEvent.Set();
                    }
                    else
                        serialReplyEvent.Set();
                        
                }
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
            internal void DestroyObjects()
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

            internal void DisposeObjects()
            {
                if (m_Xfer != null)
                { m_Xfer.Dispose(); m_Xfer = null; }
                if (m_View != null)
                { m_View.Dispose(); m_View = null; }
                if (m_Buffers != null)
                { m_Buffers.Dispose(); m_Buffers = null; }
                if (m_Acquisition != null)
                { m_Acquisition.Dispose(); m_Acquisition = null; }

            }


            void XferNotify(object sender, SapXferNotifyEventArgs argsNotify)
            {
                TransferNotifyEventArgs transferNotifyEventArgs = new TransferNotifyEventArgs(argsNotify);

                FrameCaptured?.Invoke(transferNotifyEventArgs);
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


            void GetSignalStatus(object sender, SapSignalNotifyEventArgs argsSignal)
            {
                SignalStatus?.Invoke(new SignalNotifyEventArgs(argsSignal));

            }

            public virtual void EnableTestPattern(bool enable)
            {

            }


            internal string manufactureName;
            internal string modelName;
            internal string version;
            internal string manufactureInfo;
            internal string serialNumber;
            internal string userDefinedDeviceName;
            internal string firmwareVersion;

            public virtual string ManufactureName
            {
                get
                {
                    return manufactureName;
                }
            }
            public virtual string ModelName
            {
                get
                {
                    return modelName;
                }
            }

            public virtual string Version
            {
                get
                {
                    return version;
                }
            }

            public virtual string ManufactureInfo
            {
                get
                {
                    return manufactureInfo;
                }
            }

            public virtual string SerialNumber
            {
                get
                {
                    return serialNumber;
                }
            }

            public virtual string UserDefinedDeviceName
            {
                get
                {
                    return userDefinedDeviceName;
                }
                set
                {
                    if (value.Length <= 64)
                        userDefinedDeviceName = value;
                }
            }

            public virtual string FirmwareVersion
            {
                get
                {
                    return firmwareVersion;
                }
            }

            internal string sensorWidth;
            public virtual string SensorPhysicalWidth
            {
                get
                {
                    return sensorWidth;
                }
            }

            internal string roiSensorWidth;
            public virtual string RoiSensorWidth
            {
                get
                {
                    return roiSensorWidth;
                }
                set
                {
                    if (value.Length > 4)
                    {
                        roiSensorWidth = value;
                    }
                }
            }

            internal string outputMode;
        public virtual string OutputMode
        {
            get
            {
                return outputMode;
            }
            set
            {
                outputMode = value;
            }
        }


            internal int cameraLinkOutputFrequency;
            public virtual  int CameraLinkOutputFrequency
            {
                get
                {
                    return cameraLinkOutputFrequency;
                }
                set
                {
                    cameraLinkOutputFrequency = value;
                }
            }

            internal bool reverseModeEnabled;
            public virtual bool ReverseModeEnabled
            {
                get
                {
                    return reverseModeEnabled;
                }
                set
                {
                    reverseModeEnabled = value;
                }
            }

            public virtual void SetTestPattern(TestPattern testPattern)
            {

               

            }


            internal int testImageHeight;
            public virtual int TestImageHeight
            {

                set
                {
                    testImageHeight = value;
                }
            }

        internal UInt16 linePeriodInMicroSeconds;
            public virtual UInt16 LinePeriodInMicroSeconds
        {
                get
                {
                    return linePeriodInMicroSeconds;
                }

                set
                {
                linePeriodInMicroSeconds = value;
                }
            }

        /// <summary>
        /// ExposureTimeMinimum Max Value 65535 us
        /// min value 0;
        /// </summary>
        internal string exposureTimeMininumInMicroSecs;
        public virtual string MinExposureTimeInMicroSeconds
        {
            get
            {
                return exposureTimeMininumInMicroSecs;
            }

            set
            {
                // evaluate exposureTimeMax
                if ((Convert.ToUInt16(value) >= 0) && (Convert.ToUInt16(value) <= ushort.MaxValue))
                    exposureTimeMininumInMicroSecs = value;
            }
        }

            internal string exposureTimeInMicroSeconds;
            public virtual string ExposureTimeInMicroSeconds
            {
                get
                {
                    return exposureTimeInMicroSeconds;
                }
                set
                { }
            }
            internal string maxExposureTimeInMicroSeconds;
            public virtual string MaxExposureTimeInMicroSeconds
            {
                get
                {
                    return maxExposureTimeInMicroSeconds;
                }
            }


            public virtual void SetTriggerMode(bool ExternalModeEnabled, bool ProgrammableExposureTimeEnabled)
            {

            }

        internal UInt16 triggerMissedSinceLastReset;
            public virtual  UInt16 TriggerMissedSinceLastReset
            {
                get
                {
                    return triggerMissedSinceLastReset;
                }
            }

        internal virtual UInt16 WriteString(string command)
            {

                if (serialPort.IsOpen)
                {

                    serialPort.Write(command);
                }
                else
                    throw new IOException("Serial Port is closed.");
                return 0;
            }








        }
    }

