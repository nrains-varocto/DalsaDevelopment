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
                cmd = WRITE + TEST_PATTERN + "7" + CARRIAGE_RETURN;
            else
                cmd = WRITE + TEST_PATTERN + "0" + CARRIAGE_RETURN;
            serialPort.Write(cmd);
        }

        public override string ManufactureName
        {
            get
            {
                return manufactureName;
            }
        }
        public string ModelName
        {
            get
            {
                return modelName;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }
        }

        public string ManufactureInfo
        {
            get
            {
                return manufactureInfo;
            }
        }

        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
        }

        public string UserDefinedDeviceName
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

        public string FirmwareVersion
        {
            get
            {
                return firmwareVersion;
            }
        }

        private string sensorWidth;
        public string SensorPhysicalWidth
        {
            get
            {
                return sensorWidth;
            }
        }

        private string roiSensorWidth;
        public string RoiSensorWidth
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
        public string OutputMode
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

        private string cameraLinkOutputFrequency;
        public string CameraLinkOutputFrequency
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
        public bool ReverseModeEnabled
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

        public void EnableTestMode()
        {

        }

        public void SetTestPattern(string patternType, int testImageHeight, int testImageWidth)
        {

        }

        private UInt16 linePeriodInMinutes;
        public UInt16 LinePeriodInMinutes
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

        private UInt16 exposureTimeInMinutes;
        public UInt16 ExposureTimeInMinutes
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

        private UInt16 maxExposureTimeInMinutes;
        public UInt16 MaxExposureTimeInMinutes
        {
            get
            {
                return maxExposureTimeInMinutes;
            }
        }

        private UInt16 minExposureTimeInMinutes;
        public UInt16 MinExposureTimeInMinutes
        {
            get
            {
                return minExposureTimeInMinutes;
            }
        }


        public void SetTriggerMode(bool ExternalModeEnabled, bool ProgrammableExposureTimeEnabled)
        {

        }

        private UInt16 triggerMissedSinceLastReset;
        public UInt16 TriggerMissedSinceLastReset
        {
            get
            {
                return triggerMissedSinceLastReset;
            }
        }

        private UInt16 WriteString(string command)
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
