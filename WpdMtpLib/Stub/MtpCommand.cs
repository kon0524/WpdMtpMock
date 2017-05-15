using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WpdMtpLib.DeviceProperty;

namespace WpdMtpLib.Stub
{
    public class MtpCommand : WpdMtpLib.MtpCommand
    {
        public new event Action<ushort, object> MtpEvent;

        public override string[] GetDeviceIds()
        {
            string[] deviceIDs = { "\\\\?\\usb#vid_05ca&pid_0366#00001223#{6ac27878-a6fa-4155-ba85-f98f491d4f33}" };
            return deviceIDs;
        }
        public override string GetDeviceProtocol(string deviceId)
        {
            return "MTP: 1.10";
        }
        public override string GetDeviceFriendlyName(string deviceId)
        {
            return "RICOH THETA S";
        }
        public override string GetDeviceManufacturer(string deviceId)
        {
            return "Ricoh Company, Ltd.";
        }
        public override string GetDeviceDescription(string deviceId)
        {
            return "RICOH THETA S";
        }
        public override void Open(string deviceId)
        {
        }
        public override void Close()
        {
        }
        public override MtpResponse Execute(MtpOperationCode code, uint[] param, byte[] data = null)
        {
            switch (code)
            {
                case MtpOperationCode.GetDeviceInfo:
                    byte[] gdiRes = { 100, 0, 6, 0, 0, 0, 110, 0, 0, 1, 128, 26, 0, 0, 0, 1, 16, 2, 16, 3, 16, 4, 16, 5, 16, 6, 16, 7, 16, 8, 16, 9, 16, 10, 16, 11, 16, 20, 16, 21, 16, 27, 16, 1, 144, 145, 153, 153, 153, 154, 153, 155, 153, 156, 153, 157, 153, 14, 16, 22, 16, 28, 16, 24, 16, 162, 153, 6, 0, 0, 0, 2, 64, 6, 64, 8, 64, 10, 64, 12, 64, 13, 64, 34, 0, 0, 0, 1, 80, 2, 80, 3, 80, 17, 80, 18, 80, 7, 212, 5, 80, 14, 80, 15, 80, 16, 80, 19, 80, 26, 80, 27, 80, 44, 80, 6, 208, 15, 208, 1, 216, 2, 216, 3, 216, 5, 216, 6, 216, 7, 216, 8, 216, 9, 216, 10, 216, 11, 216, 12, 216, 13, 216, 14, 216, 15, 216, 16, 216, 17, 216, 18, 216, 19, 216, 0, 0, 0, 0, 4, 0, 0, 0, 1, 48, 1, 56, 2, 184, 130, 185, 20, 82, 0, 105, 0, 99, 0, 111, 0, 104, 0, 32, 0, 67, 0, 111, 0, 109, 0, 112, 0, 97, 0, 110, 0, 121, 0, 44, 0, 32, 0, 76, 0, 116, 0, 100, 0, 46, 0, 0, 0, 14, 82, 0, 73, 0, 67, 0, 79, 0, 72, 0, 32, 0, 84, 0, 72, 0, 69, 0, 84, 0, 65, 0, 32, 0, 83, 0, 0, 0, 6, 48, 0, 49, 0, 46, 0, 56, 0, 50, 0, 0, 0, 9, 48, 0, 48, 0, 48, 0, 48, 0, 49, 0, 50, 0, 50, 0, 51, 0, 0, 0 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, gdiRes);
                case MtpOperationCode.GetDevicePropDesc:
                    return ExecuteGetDevicePropDesc(param, data);
                case MtpOperationCode.GetDevicePropValue:
                    return ExecuteGetDevicePropValue(param, data);
                case MtpOperationCode.GetStorageIDs:
                    byte[] gsidRes = { 1, 0, 0, 0, 1, 0, 1, 0 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, gsidRes);
                case MtpOperationCode.GetStorageInfo:
                    byte[] gsiRes = { 3, 0, 3, 0, 0, 0, 0, 0, 112, 224, 1, 0, 0, 0, 0, 148, 240, 35, 1, 0, 0, 0, 215, 3, 0, 0, 0, 0 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, gsiRes);
                case MtpOperationCode.GetNumObjects:
                    uint[] num = { 11 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, num, null);
                case MtpOperationCode.GetObjectHandles:
                    byte[] gohRes = { 11, 0, 0, 0, 0, 0, 0, 128, 0, 0, 100, 0, 2, 3, 100, 0, 3, 3, 100, 0, 4, 3, 100, 0, 5, 3, 100, 0, 45, 3, 100, 0, 46, 3, 100, 0, 47, 3, 100, 0, 48, 3, 100, 0, 49, 3, 100, 0 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, gohRes);
                case MtpOperationCode.GetObjectInfo:
                    byte[] goiRes = { 1, 0, 1, 0, 1, 56, 0, 0, 113, 221, 57, 0, 8, 56, 108, 13, 0, 0, 160, 0, 0, 0, 120, 0, 0, 0, 0, 21, 0, 0, 128, 10, 0, 0, 8, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 82, 0, 48, 0, 48, 0, 49, 0, 48, 0, 55, 0, 55, 0, 48, 0, 46, 0, 74, 0, 80, 0, 71, 0, 0, 0, 16, 50, 0, 48, 0, 49, 0, 54, 0, 49, 0, 50, 0, 49, 0, 53, 0, 84, 0, 49, 0, 49, 0, 48, 0, 55, 0, 53, 0, 51, 0, 0, 0, 16, 50, 0, 48, 0, 49, 0, 54, 0, 49, 0, 50, 0, 49, 0, 53, 0, 84, 0, 49, 0, 49, 0, 48, 0, 55, 0, 53, 0, 51, 0, 0, 0, 1, 0, 0 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, goiRes);
                case MtpOperationCode.GetObject:
                    MtpResponse res;
                    using (FileStream fs = new FileStream(
                                        Path.GetFullPath("../../../WpdMtpLib/Stub/dummy.JPG"),
                                        FileMode.Open, FileAccess.Read))
                    {
                        byte[] goRes = new byte[fs.Length];
                        fs.Read(goRes, 0, goRes.Length);
                        res = new MtpResponse((ushort)MtpResponseCode.OK, null, goRes);
                    }
                    return res;
                case MtpOperationCode.InitiateCapture:
                    Task.Factory.StartNew(() => {
                        Thread.Sleep(1000);
                        Object objectId = (uint)6554430;
                        MtpEvent(WpdMtpLib.MtpEvent.ObjectAdded, objectId);
                        Thread.Sleep(500);
                        MtpEvent(WpdMtpLib.MtpEvent.CaptureComplete, null);
                    });
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, null);
                case MtpOperationCode.SetDevicePropValue:
                default:
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, null);
            }
        }

        public MtpResponse ExecuteGetDevicePropDesc(uint[] param, byte[] data = null)
        {
            switch (param[0])
            {
                case (uint)MtpDevicePropCode.StillCaptureMode:
                    byte[] resData = { 19, 80, 4, 0, 1, 1, 0, 1, 0, 2, 5, 0, 1, 0, 3, 0, 2, 128, 3, 128, 4, 128 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, resData);
                case (uint)MtpDevicePropCode.ExposureIndex:
                    byte[] eiRes = { 15, 80, 4, 0, 1, 255, 255, 255, 255, 2, 1, 0, 255, 255 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, eiRes);
                default:
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, null);
            }
        }

        public MtpResponse ExecuteGetDevicePropValue(uint[] param, byte[] data = null)
        {
            switch (param[0])
            {
                case (uint)MtpDevicePropCode.ShutterSpeed:
                    byte[] ssRes = { 1, 0, 0, 0, 60, 0, 0, 0 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, ssRes);
                case (uint)MtpDevicePropCode.StillCaptureMode:
                    byte[] scmRes = { 1, 0 };
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, scmRes);

                default:
                    return new MtpResponse((ushort)MtpResponseCode.OK, null, null);
            }
        }
    }
}
