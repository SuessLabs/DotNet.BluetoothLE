using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cross.BluetoothLe
{
  public partial class Device
  {
    internal object NativeDevice => throw new PlatformNotSupportedException();

    public virtual void Dispose()
    {
      Adapter?.DisconnectDeviceAsync(this);
    }

    private Task<bool> UpdateRssiNativeAsync() => throw new PlatformNotSupportedException();

    private DeviceState GetState() => throw new PlatformNotSupportedException();

    private Task<IReadOnlyList<Service>> GetServicesNativeAsync() => throw new PlatformNotSupportedException();

    private Task<Service> GetServiceNativeAsync(Guid id) => throw new PlatformNotSupportedException();

    private Task<int> RequestMtuNativeAsync(int requestValue) => throw new PlatformNotSupportedException();

    private bool UpdateConnectionIntervalNative(ConnectionInterval interval) => throw new PlatformNotSupportedException();
  }
}
