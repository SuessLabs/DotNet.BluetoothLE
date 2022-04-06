using System;

namespace Cross.BluetoothLe
{
  public partial class BluetoothLe
  {
    static readonly System.Lazy<BluetoothLe> Singleton = new System.Lazy<BluetoothLe>(Initialize, System.Threading.LazyThreadSafetyMode.PublicationOnly);

    public static BluetoothLe Current
    {
      get
      {
        var ret = Singleton.Value;

        if (ret == null)
          throw new PlatformNotSupportedException();
      }
    }
    static BluetoothLe Initialize()
    {
      // var impl = new BluetoothLe();
    }
  }
}
