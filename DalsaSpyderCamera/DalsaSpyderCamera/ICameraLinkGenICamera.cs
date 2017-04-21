namespace Varocto.Cameras
{ 
    public interface IVaroctoCamera
    {
        int CameraLinkOutputFrequency { get; set; }
        string ExposureTimeInMicroSeconds { get; set; }
        string FirmwareVersion { get; }
        bool Grabbing { get; }
        ushort LinePeriodInMicroSeconds { get; set; }
        string ManufactureInfo { get; }
        string ManufactureName { get; }
        string MaxExposureTimeInMicroSeconds { get; }
        string MinExposureTimeInMicroSeconds { get; }
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