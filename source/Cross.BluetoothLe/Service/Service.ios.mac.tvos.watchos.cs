﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBluetooth;
using Cross.BluetoothLe.Utils;

namespace Cross.BluetoothLe
{
  public partial class Service
  {
    private readonly CBPeripheral _device;
    private readonly IBleCentralManagerDelegate _bleCentralManagerDelegate;

    internal Guid NativeGuid => NativeService.UUID.GuidFromUuid();

    internal bool NativeIsPrimary => NativeService.Primary;

    internal CBService NativeService { get; private set; }

    internal Service(CBService nativeService, Device device, IBleCentralManagerDelegate bleCentralManagerDelegate)
      : this(device)
    {
      NativeService = nativeService;

      _device = device.NativeDevice as CBPeripheral;
      _bleCentralManagerDelegate = bleCentralManagerDelegate;
    }

    internal Task<IList<Characteristic>> GetCharacteristicsNativeAsync()
    {
      var exception = new Exception($"Device '{Device.Id}' disconnected while fetching characteristics for service with {Id}.");

      return TaskBuilder.FromEvent<IList<Characteristic>, EventHandler<CBServiceEventArgs>, EventHandler<CBPeripheralErrorEventArgs>>(
        execute: () =>
        {
          if (_device.State != CBPeripheralState.Connected)
            throw exception;

          _device.DiscoverCharacteristics(NativeService);
        },
        getCompleteHandler: (complete, reject) => (sender, args) =>
        {
          if (args.Error != null)
          {
            reject(new Exception($"Discover characteristics error: {args.Error.Description}"));
          }
          else
                if (args.Service?.Characteristics == null)
          {
            reject(new Exception($"Discover characteristics error: returned list is null"));
          }
          else
          {
            var characteristics = args.Service.Characteristics
                                            .Select(characteristic => new Characteristic(characteristic, _device, this, _bleCentralManagerDelegate))
                                            .Cast<Characteristic>().ToList();
            complete(characteristics);
          }
        },
        subscribeComplete: handler => _device.DiscoveredCharacteristic += handler,
        unsubscribeComplete: handler => _device.DiscoveredCharacteristic -= handler,
        getRejectHandler: reject => ((sender, args) =>
        {
          if (args.Peripheral.Identifier == _device.Identifier)
            reject(exception);
        }),
        subscribeReject: handler => _bleCentralManagerDelegate.DisconnectedPeripheral += handler,
        unsubscribeReject: handler => _bleCentralManagerDelegate.DisconnectedPeripheral -= handler);
    }

    public virtual void Dispose()
    {
    }
  }
}
