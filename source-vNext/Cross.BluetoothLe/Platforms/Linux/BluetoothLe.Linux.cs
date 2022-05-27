using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Radios;

namespace Cross.BluetoothLe
{
  public partial class BluetoothLe
  {
    ////internal Adapter CreateNativeAdapter() => throw new PlatformNotSupportedException();
    ////
    ////internal BluetoothState GetInitialStateNative() => throw new PlatformNotSupportedException();
    ////
    ////internal void InitializeNative() => throw new PlatformNotSupportedException();

    ////private BluetoothAdapter NativeAdapter
    ////{
    ////  get => _bluetoothadapter;
    ////  set
    ////  {
    ////    _bluetoothadapter = value;
    ////
    ////    if (_bluetoothadapter == null)
    ////    {
    ////      State = BluetoothState.Unavailable;
    ////    }
    ////
    ////    State = BluetoothState.On;
    ////  }
    ////}
    ////
    /////public Radio NativeRadio => _radio;
    ////
    ////internal Adapter CreateNativeAdapter()
    ////{
    ////  return new Adapter();
    ////}    
    ////
    ////private async Task InitAdapter()
    ////{
    ////  NativeAdapter = await BluetoothAdapter.GetDefaultAsync();
    ////
    ////  _radio = await NativeAdapter.GetRadioAsync();
    ////
    ////  if (_radio != null)
    ////  {
    ////    _radio.StateChanged += OnRadioStateChanged;
    ////  }
    ////
    ////  State = GetInitialStateNative();
    ////
    ////}
  }
}
