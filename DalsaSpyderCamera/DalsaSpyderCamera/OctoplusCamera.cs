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

    public partial class OctoplusCamera : CameraLinkGenICamera
    {
        public OctoplusCamera()
        { }

        public OctoplusCamera(string ServerName, string ConfigFile, int ResourceIndex)
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
        public override void EnableTestPattern(bool enable)
        {
            //cmnd = w srce 1 for horizontal ramp
            string cmd;
            //size 4 bytes
            if (enable)
                cmd = WRITE + BLANK_SPACE + TEST_PATTERN + BLANK_SPACE + "7" + CARRIAGE_RETURN;
            else
                cmd = WRITE + BLANK_SPACE + TEST_PATTERN + BLANK_SPACE + "0" + CARRIAGE_RETURN;
            WriteString(cmd);

        }

        public override string ManufactureName
        {
            get
            {
                string cmd = READ + BLANK_SPACE + MFG_NAME + CARRIAGE_RETURN;
                WriteString(cmd);
                manufactureName = serialPort.ReadExisting();
                return manufactureName;
            }
        }
        public override string ModelName
        {
            get
            {
                string cmd = READ + BLANK_SPACE + MODEL_NAME + CARRIAGE_RETURN;
                WriteString(cmd);
                modelName = serialPort.ReadExisting();
                return modelName;
           }
        }

        public override string Version
        {
            get
            {
                string cmd = READ + BLANK_SPACE + DEVICE_VERSION + CARRIAGE_RETURN;
                WriteString(cmd);
                version = serialPort.ReadExisting();
                return version;
            }
        }

        public override string ManufactureInfo
        {
            get
            {
                string cmd = READ + BLANK_SPACE + MFG_INFO + CARRIAGE_RETURN;
                WriteString(cmd);
                version = serialPort.ReadExisting();
                return manufactureInfo;
            }
        }

        public override string SerialNumber
        {
            get
            {
                string cmd = READ + BLANK_SPACE + SERIAL_NUMBER + CARRIAGE_RETURN;
                WriteString(cmd);
                serialNumber = serialPort.ReadExisting();
                return serialNumber;
            }
        }

        public override string UserDefinedDeviceName
        {
            get
            {
                string cmd = READ + BLANK_SPACE + USER_DEFINED_NAME + CARRIAGE_RETURN;
                WriteString(cmd);
                userDefinedDeviceName = serialPort.ReadExisting();
                return userDefinedDeviceName;
            }
            set
            {
                if (value.Length <= 64)
                {
                    string cmd = WRITE + BLANK_SPACE + USER_DEFINED_NAME + BLANK_SPACE + value.ToString()+ CARRIAGE_RETURN;
                    WriteString(cmd);
                    userDefinedDeviceName = value.ToString();
                }
            }
        }

        public override string FirmwareVersion
        {
            get
            {
                string cmd = READ + BLANK_SPACE + FW_VERSION + CARRIAGE_RETURN;
                WriteString(cmd);
                firmwareVersion = serialPort.ReadExisting();
                return firmwareVersion;
            }
        }

        
        public override string SensorPhysicalWidth
        {
            get
            {
                string cmd = READ + BLANK_SPACE + SENSOR_WIDTH + CARRIAGE_RETURN;
                WriteString(cmd);
                sensorWidth = serialPort.ReadExisting();
                return sensorWidth;
            }
        }

       
        public override string RoiSensorWidth
        {
            get
            {
                string cmd = READ + BLANK_SPACE + ROI_WIDTH + CARRIAGE_RETURN;
                WriteString(cmd);
                sensorWidth = serialPort.ReadExisting();
                return roiSensorWidth;
            }
            set
            {
                if (true)
                {
                    
                    roiSensorWidth = value;
                }
            }
        }

        string outputMode;
        public override string OutputMode
        {
            get
            {
                return outputMode;
            }
            set
            {
                if (value.Length > 4)
                {
                    outputMode = value;
                }
            }
        }


        string cameraLinkOutputFrequency;
        public override string CameraLinkOutputFrequency
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
        public override bool ReverseModeEnabled
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

        public override void EnableTestMode()
        {

        }

        public override void SetTestPattern(string patternType, int testImageHeight, int testImageWidth)
        {

        }


        public override UInt16 LinePeriodInMicroSeconds
        {
            get
            {
                string cmd = READ + BLANK_SPACE + LINE_PERIOD + CARRIAGE_RETURN;
                WriteString(cmd);
                linePeriodInMicroSeconds = (ushort)(serialLastByteRead);
                return linePeriodInMicroSeconds;
            }

            set
            {
                if ((value > 0) && (value <= ushort.MaxValue))
                {
                    linePeriodInMicroSeconds = value;
                    string cmd = WRITE + BLANK_SPACE + LINE_PERIOD + BLANK_SPACE + value.ToString() + CARRIAGE_RETURN;
                    WriteString(cmd);
                }
            }
        }


        public override ushort MinExposureTimeInMicroSeconds
        {
            get
            {
                string cmd = READ + BLANK_SPACE + EXPOSURE_TIME_MIN + CARRIAGE_RETURN;
                WriteString(cmd);
                exposureTimeMininumInMicroSecs = (ushort)serialLastByteRead;
                return exposureTimeMininumInMicroSecs;
            }

            set
            {
                // evaluate exposureTimeMax
                if ((value >= 0) && (value <= ushort.MaxValue))
                    exposureTimeMininumInMicroSecs = value;
                string cmd = WRITE + BLANK_SPACE + EXPOSURE_TIME_MAX + BLANK_SPACE + value.ToString() + CARRIAGE_RETURN;
                WriteString(cmd);
            }
        }


        public override UInt16 MaxExposureTimeInMicroSeconds
        {
            get
            {
                return maxExposureTimeInMicroSeconds;
            }
        }


        public override UInt16 ExposureTimeInMicroSeconds
        {
            get
            {
                return exposureTimeInMicroSeconds;
            }
        }


        public override void SetTriggerMode(bool ExternalModeEnabled, bool ProgrammableExposureTimeEnabled)
        {

        }

        public override UInt16 TriggerMissedSinceLastReset
        {
            get
            {
                return triggerMissedSinceLastReset;
            }
        }

        internal override UInt16 WriteString(string command)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(command);
                serialReplyEvent.WaitOne();

                if (serialLastByteRead == 0)
                    serialReplyEvent.Reset();
                else
                {
                    string errorString = "";
                    switch (serialLastByteRead)
                    {
                        case 32769:
                            errorString = "Command Not Implemented in the camera.";
                            break;
                        case 32770:
                            errorString = "At least one parameter is invalid or out of range.";
                            break;
                        case 32771:
                            errorString = "Attempt to access to a not existing register address.";
                            break;
                        case 32772:
                            errorString = "Attempt to write to a read only register";
                            break;
                        case 32773:
                            errorString = "Attempt to access registers with an address which is not aligned according to the underlying technology";
                            break;
                        case 32774:
                            errorString = "Attempt to read an non-readable or write an non-writable register address";
                            break;
                        case 32775:
                            errorString = "The command receiver is currently busy";
                            break;
                        case 32779:
                            errorString = "Timeout waiting for an acknowledge";
                            break;
                    }

                    throw new IOException("Serial Communication Error: " + errorString);
                }
            }
            else
                throw new IOException("Serial Port is closed.");
            return 0;
        }
    
    }
}
