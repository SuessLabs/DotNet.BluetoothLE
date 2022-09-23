using System;
using Cross.BluetoothLe;
using MvvmCross.ViewModels;

namespace BLE.Client.ViewModels
{
  public class DeviceListItemViewModel : MvxNotifyPropertyChanged // BindableBase
  {
    public DeviceListItemViewModel(Device device)
    {
      Device = device;
    }

    public Device Device { get; private set; }

    public Guid Id => Device.Id;

    public bool IsConnected => Device.State == DeviceState.Connected;

    public int Rssi => Device.Rssi;

    public string Name => Device.Name;

    public void Update(Device? newDevice = null)
    {
      if (newDevice != null)
        Device = newDevice;

      RaisePropertyChanged(nameof(IsConnected));
      RaisePropertyChanged(nameof(Rssi));
    }
  }
}
