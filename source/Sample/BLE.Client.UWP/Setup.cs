using Cross.BluetoothLe;
using System.Diagnostics;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using Trace = Cross.BluetoothLe.Trace;
using MvvmCross.IoC;
using Acr.UserDialogs.Infrastructure;
using Microsoft.Extensions.Logging;

namespace BLE.Client.UWP
{
  public class Setup : MvxFormsWindowsSetup<BleMvxApplication, BleMvxFormsApp>
  {
    protected override IMvxIoCProvider InitializeIoC()
    {
      var result = base.InitializeIoC();

      Mvx.IoCProvider.RegisterSingleton(() => UserDialogs.Instance);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current.Adapter);

      Trace.TraceImplementation = (s, objects) => Debug.WriteLine(s, objects);

      return result;
    }

    protected override ILoggerProvider CreateLogProvider()
    {
      ////return new SerilogLoggerProvider();
      return null;
    }

    protected override ILoggerFactory CreateLogFactory()
    {
      ////Log.Logger = new LoggerConfiguration()
      ////    .MinimumLevel.Debug()
      ////    .WriteTo.Debug()
      ////    .CreateLogger();
      ////
      ////return new SerilogLoggerFactory();
      return null;
    }
  }
}
