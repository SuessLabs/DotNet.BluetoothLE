using System;

namespace Cross.BluetoothLe
{
  public class CharacteristicReadException : Exception
  {
    public CharacteristicReadException(string message) : base(message)
    {
    }
  }
}
