using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cross.BluetoothLe
{
  public partial class Device : IDisposable, ICancellationMaster, INotifyPropertyChanged
  {
    protected readonly Adapter Adapter;
    private readonly List<Service> KnownServices = new List<Service>();
    private string _name;

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    private int _rssi;
    private Guid _id;

    /// <summary>Gets or sets the Id of the device.</summary>
    /// <value>The Id.</value>
    public Guid Id
    {
      get => _id;
      set { _id = value; NotifyPropertyChanged(nameof(Id)); NotifyPropertyChanged(nameof(NameOrId)); }
    }

    /// <summary>Gets or sets the name of the device.</summary>
    /// <value>The name of the device.</value>
    public string Name
    {
      get => _name;
      protected set { _name = value; NotifyPropertyChanged(nameof(Name)); NotifyPropertyChanged(nameof(NameOrId)); }
    }

    /// <summary>Gets or sets the Rssi(Received Signal Strength Indicator) value for the device.</summary>
    /// <value>The rssi.</value>
    public int Rssi
    {
      get => _rssi;
      protected set { _rssi = value; NotifyPropertyChanged(nameof(Rssi)); }
    }

    public DeviceState State => GetState();

    public IReadOnlyList<AdvertisementRecord> AdvertisementRecords { get; protected set; }

    CancellationTokenSource ICancellationMaster.TokenSource { get; set; } = new CancellationTokenSource();

    /// <summary>Gets the name if set or the Id if not.</summary>
    /// <value>The name or Id.</value>
    public string NameOrId => (string.IsNullOrWhiteSpace(Name)) ? Id.ToString() : Name;

    protected Device()
    {
    }

    private Device(Adapter adapter)
    {
      Adapter = adapter;
    }

    public async Task<IReadOnlyList<Service>> GetServicesAsync(CancellationToken cancellationToken = default)
    {
      lock (KnownServices)
      {
        if (KnownServices.Any())
          return KnownServices.ToArray();
      }

      using (var source = this.GetCombinedSource(cancellationToken))
      {
        var services = await GetServicesNativeAsync();

        lock (KnownServices)
        {
          if (services != null)
            KnownServices.AddRange(services);

          return KnownServices.ToArray();
        }
      }
    }

    public async Task<Service> GetServiceAsync(Guid id, CancellationToken cancellationToken = default)
    {
      var services = await GetServicesAsync(cancellationToken);

      return services.ToList().FirstOrDefault(x => x.Id == id);
    }

    public Task<int> RequestMtuAsync(int requestValue) => RequestMtuNativeAsync(requestValue);

    public bool UpdateConnectionInterval(ConnectionInterval interval) => UpdateConnectionIntervalNative(interval);

    public override string ToString()
    {
      return Name;
    }

    public void ClearServices()
    {
      this.CancelEverythingAndReInitialize();

      lock (KnownServices)
      {
        foreach (var service in KnownServices)
        {
          try
          {
            service.Dispose();
          }
          catch (Exception ex)
          {
            Trace.Message("Exception while cleanup of service: {0}", ex.Message);
          }
        }

        KnownServices.Clear();
      }
    }

    public override bool Equals(object other)
    {
      if (other == null)
        return false;

      if (other.GetType() != GetType())
        return false;

      var otherDeviceBase = (Device)other;
      return Id == otherDeviceBase.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public Task<bool> UpdateRssiAsync() => UpdateRssiNativeAsync();

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
