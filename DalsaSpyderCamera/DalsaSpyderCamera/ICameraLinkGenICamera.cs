namespace Varocto.Cameras
{ 
    public interface IVaroctoCamera
    {
        string CameraLinkOutputFrequency { get; set; }
        ushort ExposureTimeInMicroSeconds { get; set; }
        string FirmwareVersion { get; }
        bool Grabbing { get; }
        ushort LinePeriodInMicroSeconds { get; set; }
        string ManufactureInfo { get; }
        string ManufactureName { get; }
        ushort MaxExposureTimeInMicroSeconds { get; }
        ushort MinExposureTimeInMicroSeconds { get; }
        string ModelName { get; }
        string OutputMode { get; set; }
        bool ReverseModeEnabled { get; set; }
        string RoiSensorWidth { get; set; }
        string SensorPhysicalWidth { get; }
        string SerialNumber { get; }
        ushort TriggerMissedSinceLastReset { get; }
        string UserDefinedDeviceName { get; set; }
        string Version { get; }

        event FrameCaptured FrameCaptured;
        event GetSignalStatusEventHandler SignalStatus;

        bool Initialize();
        bool IsSignalDetected();

        bool Grab();
        bool Snap();
        bool Freeze();

    }
}