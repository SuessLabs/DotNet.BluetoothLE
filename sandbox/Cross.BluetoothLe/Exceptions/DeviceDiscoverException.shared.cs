using System;

namespace Cross.BluetoothLe
{
  public class DeviceDiscoverException : Exception
  {
    public DeviceDiscoverException() : base("Could not find the specific device.")
    {
    }
  }
}
