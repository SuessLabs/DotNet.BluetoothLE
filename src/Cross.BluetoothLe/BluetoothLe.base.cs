using System;
using Cross.BluetoothLe.Abstracts;

namespace Cross.BluetoothLe
{
  public partial class BluetoothLe
  {
    private static readonly System.Lazy<BluetoothLe> Singleton = new System.Lazy<BluetoothLe>(Initialize, System.Threading.LazyThreadSafetyMode.PublicationOnly);

    private readonly Lazy<Adapter> _adapter;
    private BluetoothState _state;

    internal BluetoothLE()
    {
      _adapter = new Lazy<Adapter>(CreateAdapter, System.Threading.LazyThreadSafetyMode.PublicationOnly);
    }

    public event EventHandler<BluetoothStateChangedArgs> StateChanged;

    public static BluetoothLe Current
    {
      get
      {
        var ret = Singleton.Value;

        if (ret == null)
          throw new PlatformNotSupportedException();

        return ret;
      }
    }

    public Adapter Adapter => _adapter.Value;

    public bool IsAvailable => _state != BluetoothState.Unavailable;

    public bool IsOn => _state == BluetoothState.On;

    public BluetoothState State
    {
      get => _state;
      protected set
      {
        if (_state == value)
          return;

        var oldState = _state;
        _state = value;
        StateChanged?.Invoke(this, new BluetoothStateChangedArgs(oldState, _state));
      }
    }

    public void Initialize()
    {
      InitializeNative();
      State = GetInitialStateNative();
    }

    private static BluetoothLe CreateInstance()
    {
      var instance = new BluetoothLe();
      instance.Initialize();
      return instance;
    }

    private Adapter CreateAdapter()
    {
      return CreateNativeAdapter();
    }
  }
}
