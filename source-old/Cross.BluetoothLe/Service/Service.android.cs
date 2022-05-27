using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Bluetooth;

namespace Cross.BluetoothLe
{
  public partial class Service
  {
    private readonly BluetoothGatt _gatt;

    private readonly IGattCallback _gattCallback;

    internal Guid NativeGuid => Guid.ParseExact(NativeService.Uuid.ToString(), "d");

    internal bool NativeIsPrimary => NativeService.Type == GattServiceType.Primary;

    internal BluetoothGattService NativeService { get; private set; }

    internal Service(BluetoothGattService nativeService, BluetoothGatt gatt, IGattCallback gattCallback, Device device) : this(device)
    {
      NativeService = nativeService;

      _gatt = gatt;
      _gattCallback = gattCallback;
    }

    internal Task<IList<Characteristic>> GetCharacteristicsNativeAsync()
    {
      return Task.FromResult<IList<Characteristic>>(
        NativeService.Characteristics.Select(characteristic => new Characteristic(characteristic, _gatt, _gattCallback, this))
        .Cast<Characteristic>().ToList());
    }

    public virtual void Dispose()
    {

    }
  }
}
