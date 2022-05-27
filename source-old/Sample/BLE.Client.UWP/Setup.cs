using Cross.BluetoothLe;
using System.Diagnostics;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using Trace = Cross.BluetoothLe.Trace;
using MvvmCross.IoC;

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
  }
}
