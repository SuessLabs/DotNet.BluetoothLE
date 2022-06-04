using System;
using System.Collections.Generic;
using System.Text;

/*
namespace Cross.BluetoothLe.Abstracts
{
  public abstract class DeviceAbstract // : IDevice
  {
    /// <summary>Gets or sets the device's UUID.</summary>
    /// <remarks>Property's is currently named, `Id`.</remarks>
    public virtual Guid UUID { get; protected set; }
    ////{
    ////  get { return _id; }
    ////  set { _id = value; NotifyPropertyChanged(nameof(Id)); NotifyPropertyChanged(nameof(NameOrId)); }
    ////}

    public virtual string Name { get; protected set; }

    public abstract object NativeDevice { get; }

    /// <summary>Gets the Connection state.</summary>
    /// <remarks>Property is currently named, `State`.</remarks>
    public abstract ConnectionStatus Status { get; }

    /// <summary>Gets or sets the Rssi(Received Signal Strength Indicator) value for the device.</summary>
    /// <value>The rssi.</value>
    public int Rssi { get; protected set; }
    ////{
    ////  get { return _rssi; }
    ////  protected set { _rssi = value; NotifyPropertyChanged(nameof(Rssi)); }
    ////}

    public virtual IObservable<int> GetRssi()

    public virtual Task<IReadonlyList<Service>> GetServicesAsync() => throw new NotImplementedException("GetServicesAsync is not implmented by the platform");

    public virtual IObservable<IReadonlyList<Service>> GetServices() => throw new NotImplementedException("GetServices is not implmented by the platform");

    public virtual async Task<Service> GetServiceAsync(Guid id, CancellationToken cancellationToken = default)  => throw new NotImplementedException("GetServiceAsync is not supported on this platform");

  }
}
*/
