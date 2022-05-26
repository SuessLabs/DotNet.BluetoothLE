using System;
using System.Collections.Generic;
using System.Text;

/*
 * NOTE: 2022-05-23
 * - The system should use Abstract classes and interfaces to ensure
 *   that each implementation is correctly defined.
 * 
namespace Cross.BluetoothLe.Abstracts
{
  public abstract class AdapterAbstract : IAdapter
  {
    /// <summary>Creates a GATT Server.</summary>
    public abstract IObservable<IGattServer> CreateServer();

    public abstract IObservable<IScanResult> Scan();

    public abstract void StopScan();

    public virtual AdapterStatus Status { get; protected set; }

    public virtual bool IsScanning { get; protected set; }

    public virtual IObservable<IDevice> GetDevice(Guid deviceId) => throw new NotImplementedException("GetDevice is not supported on this platform");

    public virtual IObservable<IEnumerable<IDevice>> GetPairedDevices() => throw new NotImplementedException("GetPairedDevices is not supported on this platform");

    public virtual void SetAdapterState(bool enabled) => throw new NotImplementedException("SetAdapterState is not supported on this platform");
  }
}
*/
