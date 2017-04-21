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

    public partial class SpyderThree : CameraLinkGenICamera
    {
        public SpyderThree()
        { }

        public SpyderThree(string ServerName, string ConfigFile, int ResourceIndex)
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
                    string cmd = WRITE + BLANK_SPACE + USER_DEFINED_NAME + BLANK_SPACE + value.ToString() + CARRIAGE_RETURN;
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

                    string cmd = WRITE + BLANK_SPACE + ROI_WIDTH + BLANK_SPACE + value.ToString() + CARRIAGE_RETURN;
                    WriteString(cmd);
                    sensorWidth = serialPort.ReadExisting();
                    serialPort.DiscardOutBuffer();

                    roiSensorWidth = value;
                }
            }
        }

        string outputMode;
        public override string OutputMode
        {

            set
            {
                // output mode default to 1 taps, 12 bit depth
                string cmd = WRITE + BLANK_SPACE + OUTPUT_MODE + BLANK_SPACE + "16912" + CARRIAGE_RETURN;
                WriteString(cmd);
                string reply = serialPort.ReadExisting();
                serialPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ALLOWED VALUES
        /// 0 - 40 MHz
        /// 1 - 60 MHz
        /// 2 - 70 MHz
        /// 3 - 85 MHz
        /// default - 4
        /// </summary>

        public override int CameraLinkOutputFrequency
        {
            get
            {
                WriteString(READ + BLANK_SPACE + CAMERA_LINK_OUTPUT_FREQUENCY + CARRIAGE_RETURN);
                string reply = serialPort.ReadExisting();
                return cameraLinkOutputFrequency;
            }
            set
            {
                if (value != 0 || value != 1 || value != 2 || value != 3)
                {
                    cameraLinkOutputFrequency = value;
                    string cmd = WRITE + BLANK_SPACE + CAMERA_LINK_OUTPUT_FREQUENCY + BLANK_SPACE + value.ToString() + CARRIAGE_RETURN;
                    WriteString(cmd);
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
                string cmd = "";
                if (value)
                    cmd = WRITE + BLANK_SPACE + REVERSE_READING + BLANK_SPACE + "1" + CARRIAGE_RETURN;
                else
                    cmd = WRITE + BLANK_SPACE + REVERSE_READING + BLANK_SPACE + "0" + CARRIAGE_RETURN;
                WriteString(cmd);
            }
        }

        public override void SetTestPattern(TestPattern testPattern)
        {
            string cmd = WRITE + BLANK_SPACE + TEST_PATTERN + BLANK_SPACE + testPattern.ToString() + CARRIAGE_RETURN;
            WriteString(cmd);
        }

        public void SetTestPattern(int testPattern)
        {
            string cmd = WRITE + BLANK_SPACE + TEST_PATTERN + BLANK_SPACE + testPattern.ToString() + CARRIAGE_RETURN;
            WriteString(cmd);
        }

        public override int TestImageHeight
        {
            set
            {
                string cmd = WRITE + BLANK_SPACE + TEST_IMAGE_HEIGHT + BLANK_SPACE + value.ToString() + CARRIAGE_RETURN;
                WriteString(cmd);
            }
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


        public override string MinExposureTimeInMicroSeconds
        {
            get
            {
                string cmd = READ + BLANK_SPACE + EXPOSURE_TIME_MIN + CARRIAGE_RETURN;
                WriteString(cmd);
                return exposureTimeMininumInMicroSecs;
            }
        }


        public override string MaxExposureTimeInMicroSeconds
        {
            get
            {
                return maxExposureTimeInMicroSeconds;
            }
        }


        public override string ExposureTimeInMicroSeconds
        {
            set
            {
                string cmd = WRITE + BLANK_SPACE + EXPOSURE_TIME + BLANK_SPACE + "1140" + CARRIAGE_RETURN;
                WriteString(cmd);
                exposureTimeInMicroSeconds = "1140";
                cmd = READ + BLANK_SPACE + EXPOSURE_TIME + CARRIAGE_RETURN;
                WriteString(cmd);
                string reply = serialPort.ReadExisting();
                if (!reply.Contains(exposureTimeInMicroSeconds))
                    reply = "";

            }
            get
            {
                return exposureTimeInMicroSeconds;
            }
        }


        public override void SetTriggerMode(bool ExternalModeEnabled, bool ProgrammableExposureTimeEnabled)
        {
            string cmd = "";
            if (!ExternalModeEnabled && ProgrammableExposureTimeEnabled)
                cmd = WRITE + BLANK_SPACE + TRIGGER_MODE + BLANK_SPACE + "0" + CARRIAGE_RETURN;
            else if (!ExternalModeEnabled && !ProgrammableExposureTimeEnabled)
                cmd = WRITE + BLANK_SPACE + TRIGGER_MODE + BLANK_SPACE + "1" + CARRIAGE_RETURN;
            else if (ExternalModeEnabled && ProgrammableExposureTimeEnabled)
                cmd = WRITE + BLANK_SPACE + TRIGGER_MODE + BLANK_SPACE + "2" + CARRIAGE_RETURN;
            else
                cmd = WRITE + BLANK_SPACE + TRIGGER_MODE + BLANK_SPACE + "3" + CARRIAGE_RETURN;

            WriteString(cmd);

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
