using System.BluetoothLe.EventArgs;

namespace System.BluetoothLe
{
  public partial class BluetoothLE
  {
    private static readonly Lazy<BluetoothLE> Implementation = new Lazy<BluetoothLE>(CreateImplementation, System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current bluetooth LE implementation.
    /// </summary>
    public static BluetoothLE Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw new PlatformNotSupportedException();
        }

        return ret;
      }
    }

    private static BluetoothLE CreateImplementation()
    {
      var implementation = new BluetoothLE();
      implementation.Initialize();
      return implementation;
    }

    private readonly Lazy<Adapter> _adapter;
    private BluetoothState _state;

    public event EventHandler<BluetoothStateChangedArgs> StateChanged;

    public bool IsAvailable => _state != BluetoothState.Unavailable;

    public bool IsOn => _state == BluetoothState.On;

    public Adapter Adapter => _adapter.Value;

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

    internal BluetoothLE()
    {
      _adapter = new Lazy<Adapter>(CreateAdapter, System.Threading.LazyThreadSafetyMode.PublicationOnly);
    }

    public void Initialize()
    {
      InitializeNative();
      State = GetInitialStateNative();
    }

    private Adapter CreateAdapter()
    {
      return CreateNativeAdapter();
    }
  }
}
