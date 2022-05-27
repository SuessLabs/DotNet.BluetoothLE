using System;
using System.Threading.Tasks;

namespace Cross.BluetoothLe
{
  public partial class Descriptor
  {
    protected object NativeDescriptor => throw new PlatformNotSupportedException();

    protected byte[] NativeValue => throw new PlatformNotSupportedException();

    protected Guid NativeGuid => throw new PlatformNotSupportedException();

    protected Task<byte[]> ReadNativeAsync() => throw new PlatformNotSupportedException();

    protected Task WriteNativeAsync(byte[] data) => throw new PlatformNotSupportedException();
  }
}
