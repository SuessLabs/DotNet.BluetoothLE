namespace Cross.BluetoothLe
{
  /// <summary>Defines how Scans are performed.</summary>
  /// <remarks>
  ///   - https://github.com/xabre/xamarin-bluetooth-le/blob/master/doc/scanmode_mapping.md
  ///   - https://lists.apple.com/archives/bluetooth-dev/2012/May/msg00041.html
  ///   - https://developer.android.com/reference/android/bluetooth/le/ScanSettings.html
  ///   - https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothlescanningmode
  /// </remarks>
  public enum ScanMode
  {
    /// <summary>Passively listen for Scan results.</summary>
    Passive,

    /// <summary>Perform Bluetooth LE scan in low power mode.</summary>
    LowPower,

    /// <summary>Perform Bluetooth LE scan in balanced power mode. Scan results are returned at a rate that provides a good trade-off between scan frequency and power consumption.</summary>
    Balanced,

    /// <summary>Scan using highest duty cycle.</summary>
    LowLatency,
  }
}
