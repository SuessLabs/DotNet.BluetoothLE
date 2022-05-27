using System;

namespace Cross.BluetoothLe.Exceptions
{
  public class DeviceNotFoundException : Exception
  {
    public DeviceNotFoundException(Guid deviceId)
      : base($"Device with Id: {deviceId} not found.")
    {
    }
  }
}
