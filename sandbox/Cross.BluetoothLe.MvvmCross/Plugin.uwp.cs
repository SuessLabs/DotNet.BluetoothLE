using System.BluetoothLe;
using MvvmCross;
using MvvmCross.Logging;
using MvvmCross.Plugin;

[assembly: Preserve]
namespace MvvmCross.System.BluetoothLe
{
  [Preserve(AllMembers = true)]
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
