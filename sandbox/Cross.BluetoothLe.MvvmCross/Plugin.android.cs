using System.BluetoothLe;
using MvvmCross.Logging;
using MvvmCross.Plugin;

namespace MvvmCross.System.BluetoothLe
{
  [MvxPlugin]
  public class Plugin
     : IMvxPlugin
  {
    public Plugin()
    {
      var log = Mvx.IoCProvider.Resolve<IMvxLog>();
      Trace.TraceImplementation = log.Trace;
    }

    public void Load()
    {
      Trace.Message("Loading bluetooth low energy plugin");
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current.Adapter);
    }
  }
}
