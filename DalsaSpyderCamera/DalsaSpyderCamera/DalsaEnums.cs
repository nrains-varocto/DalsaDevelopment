using System;
using DALSA.SaperaLT.SapClassBasic;

namespace Varocto.Cameras
{

    public class TransferNotifyEventArgs : EventArgs
    {
        public object Context { get; set; }
        public int PairIndex { get; set; }
        public bool Trash { get; set; }
        public int GenericParamValue3 { get; set; }
        public int GenericParamValue2 { get; set; }
        public int GenericParamValue1 { get; set; }
        public int GenericParamValue0 { get; set; }
        public int CustomSize { get; set; }
        public IntPtr CustomData { get; set; }
        public long AuxTimeStamp { get; set; }
        public long HostTimeStamp { get; set; }
        public int EventCount { get; set; }
        public SapXferPair.XferEventType EventType { get; set; }

        public TransferNotifyEventArgs(SapXferNotifyEventArgs sapXferNotifyEventArgs)
        {

            Context = sapXferNotifyEventArgs.Context;
            PairIndex = sapXferNotifyEventArgs.PairIndex;
            Trash = sapXferNotifyEventArgs.Trash;
            GenericParamValue3 = sapXferNotifyEventArgs.GenericParamValue3;
            GenericParamValue2 = sapXferNotifyEventArgs.GenericParamValue2;
            GenericParamValue1 = sapXferNotifyEventArgs.GenericParamValue1;
            GenericParamValue0 = sapXferNotifyEventArgs.GenericParamValue0;
            CustomSize = sapXferNotifyEventArgs.CustomSize;
            CustomData = sapXferNotifyEventArgs.CustomData;
            AuxTimeStamp = sapXferNotifyEventArgs.AuxTimeStamp;
            HostTimeStamp = sapXferNotifyEventArgs.HostTimeStamp;
            EventCount = sapXferNotifyEventArgs.EventCount;
            EventType = sapXferNotifyEventArgs.EventType;
        }

 
    }

    public enum TransferEventType
    {
        None = 0,
        StartOfField = 65536,
        StartOfOdd = 131072,
        StartOfEven = 262144,
        StartOfFrame = 524288,
        EndOfField = 1048576,
        EndOfOdd = 2097152,
        EndOfEven = 4194304,
        EndOfFrame = 8388608,
        EndOfLine = 16777216,
        EndOfNLines = 33554432,
        EndOfTransfer = 67108864,
        LineUnderrun = 134217728,
        FieldUnderrun = 268435456
    }
    
    public class SignalNotifyEventArgs : EventArgs
    {
        private object context;
        private AcqisitionSignalStatus signalStatus;
        public object Context
        {
            get
            {
                return context;
            }
        }
        public AcqisitionSignalStatus SignalStatus
        {
            get
            {
                return signalStatus;
            }
         }

        public SignalNotifyEventArgs(SapSignalNotifyEventArgs sapSignalNotifyEventArgs)
        {
            context = sapSignalNotifyEventArgs.Context;
            signalStatus = (AcqisitionSignalStatus)sapSignalNotifyEventArgs.SignalStatus;

        }

    }

   
    public enum AcqisitionSignalStatus
    {
        None = 0,
        LineValidPresent = 1,
        HSyncPresent = 1,
        FrameValidPresent = 2,
        VSyncPresent = 2,
        PixelClk1Present = 4,
        PixelClkPresent = 4,
        ChromaPresent = 8,
        HSyncLock = 16,
        VSyncLock = 32,
        PowerPresent = 64,
        PoCLActive = 128,
        PoCLActive2 = 256,
        PixelClk2Present = 512,
        PixelClk3Present = 1024,
        PixelClkAllPresent = 2048,
        PixelLinkLock = 4096,
        PixelLane1Lock = 8192,
        PixelLane2Lock = 16384,
        PixelLane3Lock = 32768,
        PixelLane4Lock = 65536,
        PixelLane5Lock = 131072,
        PixelLane6Lock = 262144,
        PixelLane7Lock = 524288
    }

    

}