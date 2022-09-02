using Cross.BluetoothLe;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Plugin;

[assembly: Preserve]
namespace MvvmCross.Cross.BluetoothLe
{
  [Preserve(AllMembers = true)]
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
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current.Adapter);
      ////Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IBluetoothLE>(() => CrossBluetoothLE.Current);
      ////Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IAdapter>(() => Mvx.IoCProvider.Resolve<IBluetoothLE>().Adapter);
    }
  }
}
