using System;

namespace Cross.BluetoothLe
{
  static class DefaultTrace
  {
    static DefaultTrace()
    {
      Trace.TraceImplementation = Console.WriteLine;
    }
  }
}
