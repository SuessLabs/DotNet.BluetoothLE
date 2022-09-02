using Cross.BluetoothLe;
using Microsoft.Extensions.Logging;
using MvvmCross.IoC;
using MvvmCross.Plugin;

namespace MvvmCross.Cross.BluetoothLe
{
  [MvxPlugin]
  public class Plugin : IMvxPlugin
  {
    public Plugin()
    {
      ILogger<Plugin> log;
      if (Mvx.IoCProvider.TryResolve(out log))
        Trace.TraceImplementation = log.LogTrace;
    }

    public void Load()
    {
      Trace.Message("Loading bluetooth low energy plugin");
      //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IBluetoothLE>(() => CrossBluetoothLE.Current);
      //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IAdapter>(() => Mvx.IoCProvider.Resolve<IBluetoothLE>().Adapter);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current.Adapter);
    }
  }
}
