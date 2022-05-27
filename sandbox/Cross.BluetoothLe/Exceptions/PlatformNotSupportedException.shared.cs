using System;

namespace Cross.BluetoothLe
{
  public class PlatformNotSupportedException : Exception
  {
    public PlatformNotSupportedException()
      : base("Platfrom not supported.  Ensure you are using the correct version of the library")
    {
    }
  }
}
