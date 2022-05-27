using System;
using System.Collections.Generic;
using System.Text;

namespace Cross.BluetoothLe
{
  /// <summary>Base cross-platform GATT Service.</summary>
  public partial class Service : IDisposable
  {
    private readonly List<Characteristic> _characteristics = new List<Characteristic>();

    public BleService(Device device)
    {
      Device = device;
      // COMING SOON!
    }

    public BleDevice Device { get; }

    public string Name => throw new NotImplementedException();  // KnowServices.Lookup(Id).Name;

    public bool IsPrimary => NativeIsPrimary;

    public async Task<IReadOnlyList<BleCharacteristic>> GetCharacteristicsAsync()
    {
      if (!_characteristics.Any())
        _characteristics.AddRange(await GetCharacteristicsNativeAsync());

      return _characteristics.ToList();
    }
  }
}
