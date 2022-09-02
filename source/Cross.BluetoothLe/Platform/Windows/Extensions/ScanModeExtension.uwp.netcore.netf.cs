using System;
using Windows.Devices.Bluetooth.Advertisement;
using Cross.BluetoothLe;
using Trace = Cross.BluetoothLe.Trace;

namespace Cross.BluetoothLe.Extensions
{
    /// <summary>
    /// See https://github.com/xabre/xamarin-bluetooth-le/blob/master/doc/scanmode_mapping.md
    /// </summary>
    internal static class ScanModeExtension
    {
        public static BluetoothLEScanningMode ToNative(this ScanMode scanMode)
        {
            switch (scanMode)
            {
                case ScanMode.Passive:
                    return BluetoothLEScanningMode.Passive;
                case ScanMode.LowPower:
                case ScanMode.Balanced:
                case ScanMode.LowLatency:
                    return BluetoothLEScanningMode.Active;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scanMode), scanMode, null);
            }
        }
    }
}
