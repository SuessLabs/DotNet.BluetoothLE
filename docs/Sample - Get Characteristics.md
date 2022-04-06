# Proposal

## Overview

The BLE Interfaces aims to provide a cross-platform experience so that developers can test on both Linux and Windows devices.

## Proposal Sample

The following sample demonstrates a sample for obtaining a Service's Characteristics.

```cs
private MyClass(IBluetoothLeService ble)
{
  _ble = ble;
}

private async Task DisplayCharacteristicsAsync()
{
  try
  {
    if (_ble.State != BluetoothState.On)
    {
      //wait for it to initialise
      await Task.Delay(TimeSpan.FromSeconds(5));

      if (_ble.State != BluetoothState.On)
        throw new Exception("Bluetooth not available");
    }

    var bleAdapter = _ble.Adapter;
    await bleAdapter.StartScanningAsync();

    /*
      // Alternative Approach: Event driven discovery
      bleAdapter.DiscoverDevices += (devices) =>
      {
        foreach (var device in devices)
        {
          // ... (same as below)
        }
      }
    */
    var devices = bleAdapter.DiscoveredDevices;

    if (!devices.Any())
      throw new Exception("No devices found");

    foreach (var device in devices)
    {
      Debug.WriteLine($"Connecting to device: {device.Id}");

      try
      {
        await bleAdapter.ConnectAsync(device);

        try
        {
          var services = await device.GetServicesAsync();
          Debug.WriteLine($"Found {services.Count} service(s)");

          foreach (var service in services)
          {
            try
            {
              var characteristics = await service.GetCharacteristicsAsync();

              Debug.WriteLine($"Found {characteristics.Count} characteritics(s) for service: {service.Id}");

            }
            catch (Exception ex)
            {
              Debug.WriteLine($"Excpetion loading characteristics: {ex.Message}");
            }
          }
        }
        catch (Exception ex)
        {
          Debug.WriteLine($"Excpetion loading services: {ex.Message}");
        }

        //try
        //{
        //  Debug.WriteLine($"Disconnecting device: {device.Id}");
        //  Task.Run(async () => await bleAdapter.DisconnectAsync(device));
        //}
        //catch (Exception ex)
        //{
        //  Debug.WriteLine($"Excpetion disconnecting device: {ex.Message}");
        //}
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Excpetion connecting to device: {ex.Message}");
      }
    }
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
  }
}
```
