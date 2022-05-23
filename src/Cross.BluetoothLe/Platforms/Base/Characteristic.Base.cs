using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cross.BluetoothLe.EventArgs;

namespace Cross.BluetoothLe
{
  /// <summary>Base cross-platform GATT Characteristic.</summary>
  public partial class Characteristic
  {
    private IReadOnlyList<Descriptor> _descriptors;
    private CharacteristicWriteType _writeType = CharacteristicWriteType.Default;
  }
}
