using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Varocto.Cameras
{

    public partial class OctoplusCamera
    {
        private const string BLANK_SPACE = " ";
        private const string WRITE = "w";
        private const string READ = "r";
        private const string CARRIAGE_RETURN = "\r";
        private const string MFG_NAME = "vdnm";
        private const string MODEL_NAME = "mdnm";
        private const string DEVICE_VERSION = "dhwv";
        private const string MFG_INFO = "idnb";
        private const string SERIAL_NUMBER = "deid";
        private const string USER_DEFINED_NAME = "cust";
        private const string FW_VERSION = "dfwv";
        private const string BAUD_RATE = "baud";
        private const string SENSOR_WIDTH = "snsw";
        private const string ROI_WIDTH = "widt";
        private const string OUTPUT_MODE = "mode";
        private const string CAMERA_LINK_OUTPUT_FREQUENCY = "clfq";
        private const string REVERSE_READING = "revr";
        private const string TEST_PATTERN = "srce";
        private const string TEST_IMAGE_HEIGHT = "tsth";
        private const string LINE_PERIOD = "tper";
        private const string LINE_PERIOD_MIN = "tpmi";
        private const string EXPOSURE_TIME = "tint";
        private const string EXPOSURE_TIME_MIN = "timi";
        private const string EXPOSURE_TIME_MAX = "tima";
        private const string TRIGGER_MODE = "sync";
        private const string TRIGGER_MISSED = "trgm";
        private const string ANALOG_GAIN = "pamp";
        private const string DIGITAL_GAIN = "gain";
        private const string DIGITAL_OFFSET = "offs";
        private const string FFC_ENABLE = "ffcp";
        private const string FPN_RESET = "rsto";
        private const string PRNU_RESET = "rstg";
        private const string FPN_CALIBRATION_CONTROL = "calo";
        private const string PRNU_CALIBRATION_CONTROL = "calg";
        private const string USER_SET_LOAD = "rcfg";
        private const string USER_SET_SAVE = "scfg";
        private const string RESTORE_FFC = "rffc";
        private const string SAVE_FFC = "sffc";

    }

    public enum OutputFrequency
    {
        FortyMHZ = 0,
        SixtyMHZ = 1,
        SeventyMHZ = 2,
        EightyMHZ = 3
    }

    public enum TestPattern
    {
        Off = 0,
        GreyHorizontalRamp = 1,
        GreyVerticalRamp = 2,
        GreyDiagonalRamp = 3,
        MovingGreyHorizontalRamp = 4,
        MovingGreyVerticalRamp = 5,
        MovingGreyDiagonalRamp = 6,
        CheckerBoard = 7,
        HorizontalLines = 8,
        VerticalLines = 9,
        ConstantPattern = 10
    }

    public enum TriggerModes
    {
        InteralProgrammbleMaxExposureTimeLinePeriod = 0,
        InternalMaxExposureTimeProgrammablePeriod = 1,
        ExternalProgrammableMaxExposure = 2,
        ExternalMaxExposureTime = 3
    }

     
    
}
