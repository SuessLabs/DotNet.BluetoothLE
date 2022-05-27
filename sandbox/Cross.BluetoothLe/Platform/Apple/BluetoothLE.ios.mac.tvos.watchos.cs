using System;
using Cross.BluetoothLe.Extensions;
using CoreBluetooth;
using CoreFoundation;

namespace Cross.BluetoothLe
{
  public partial class BluetoothLE
  {
    private static string _restorationIdentifier;
    private static bool _showPowerAlert = true;
    private CBCentralManager _centralManager;
    private IBleCentralManagerDelegate _bleCentralManagerDelegate;

    internal static void UseRestorationIdentifier(string restorationIdentifier)
    {
      _restorationIdentifier = restorationIdentifier;
    }

    internal static void ShowPowerAlert(bool showPowerAlert)
    {
      _showPowerAlert = showPowerAlert;
    }

    internal void InitializeNative()
    {
      var cmDelegate = new BleCentralManagerDelegate();
      _bleCentralManagerDelegate = cmDelegate;

      var options = CreateInitOptions();

      _centralManager = new CBCentralManager(cmDelegate, DispatchQueue.CurrentQueue, options);
      _bleCentralManagerDelegate.UpdatedState += (s, e) => State = GetState();
    }

    internal BluetoothState GetInitialStateNative()
    {
      return GetState();
    }

    internal Adapter CreateNativeAdapter()
    {
      return new Adapter(_centralManager, _bleCentralManagerDelegate);
    }

    private BluetoothState GetState()
    {
      return _centralManager?.State.ToBluetoothState() ?? BluetoothState.Unavailable;
    }

    private CBCentralInitOptions CreateInitOptions()
    {
      return new CBCentralInitOptions
      {
#if __IOS__
        RestoreIdentifier = _restorationIdentifier,
#endif
        ShowPowerAlert = _showPowerAlert
      };
    }
  }
}
