using System.BluetoothLe;
using System.Diagnostics;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using Plugin.Permissions;
using Plugin.Settings;
using Trace = System.BluetoothLe.Trace;

namespace BLE.Client.UWP
{
  public class Setup : MvxFormsWindowsSetup<BleMvxApplication, BleMvxFormsApp>
  {
    protected override void InitializeIoC()
    {
      base.InitializeIoC();

      Mvx.IoCProvider.RegisterSingleton(() => UserDialogs.Instance);
      Mvx.IoCProvider.RegisterSingleton(() => CrossSettings.Current);
      Mvx.IoCProvider.RegisterSingleton(() => CrossPermissions.Current);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current);
      Mvx.IoCProvider.RegisterSingleton(() => BluetoothLE.Current.Adapter);

      Trace.TraceImplementation = (s, objects) => Debug.WriteLine(s, objects);
    }
  }
}
