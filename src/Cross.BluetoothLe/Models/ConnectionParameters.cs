namespace Cross.BluetoothLe
{
  /// <summary>
  /// Connection parameters. Contains platform specific parameters needed to achieved connection
  /// </summary>
  public struct ConnectionParameters
  {
    /// <summary>Construct connection parameters.</summary>
    /// <param name="autoConnect">Android only: Whether to directly connect to the remote device (false) or to automatically connect as soon as the remote device becomes available (true). The default is false.</param>
    /// <param name="forceBleTransport">Android only: For Dual Mode device, force transport mode to LE. The default is false.</param>
    public ConnectionParameters(bool autoConnect = false, bool forceBleTransport = false)
    {
      AutoConnect = autoConnect;
      ForceBleTransport = forceBleTransport;
    }

    public static ConnectionParameters None { get; } = new ConnectionParameters();

    /// <summary>
    /// Android only, from documentation:
    /// boolean: Whether to directly connect to the remote device (false) or to automatically connect as soon as the remote device becomes available (true).
    /// </summary>
    public bool AutoConnect { get; }

    /// <summary>
    /// Android only: For Dual Mode device, force transport mode to LE. The default is false.
    /// </summary>
    public bool ForceBleTransport { get; }
  }
}
