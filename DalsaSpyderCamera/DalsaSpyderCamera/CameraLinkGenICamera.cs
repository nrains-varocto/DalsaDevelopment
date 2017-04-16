﻿
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
            internal bool m_IsSignalDetected;
            internal bool m_online;
            internal bool m_restore;
            internal SapLocation m_ServerLocation;
            internal string m_ConfigFileName;
            internal string m_ServerName;


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

            internal void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                lock (padlock)
                {
                    string returnValue = serialPort.ReadExisting();


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

            private string sensorWidth;
            public virtual string SensorPhysicalWidth
            {
                get
                {
                    return sensorWidth;
                }
            }

            private string roiSensorWidth;
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

            private string outputMode;
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


            private string cameraLinkOutputFrequency;
            public virtual  string CameraLinkOutputFrequency
            {
                get
                {
                    return cameraLinkOutputFrequency;
                }
                set
                {
                    if (value.Length > 4)
                    {
                        cameraLinkOutputFrequency = value;
                    }
                }
            }

            private bool reverseModeEnabled;
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

            public virtual void EnableTestMode()
            {

            }

            public virtual void SetTestPattern(string patternType, int testImageHeight, int testImageWidth)
            {

            }

        internal UInt16 linePeriodInMinutes;
            public virtual UInt16 LinePeriodInMinutes
            {
                get
                {
                    return linePeriodInMinutes;
                }

                set
                {
                    linePeriodInMinutes = value;
                }
            }

        internal UInt16 exposureTimeInMinutes;
            public virtual UInt16 ExposureTimeInMinutes
            {
                get
                {
                    return exposureTimeInMinutes;
                }

                set
                {
                    // evaluate exposureTimeMax
                    if (value <= 5000)
                        exposureTimeInMinutes = value;
                }
            }

        internal UInt16 maxExposureTimeInMinutes;
            public virtual UInt16 MaxExposureTimeInMinutes
            {
                get
                {
                    return maxExposureTimeInMinutes;
                }
            }
        internal UInt16 minExposureTimeInMinutes;
            public virtual UInt16 MinExposureTimeInMinutes
            {
                get
                {
                    return minExposureTimeInMinutes;
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

        internal UInt16 WriteString(string command)
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

