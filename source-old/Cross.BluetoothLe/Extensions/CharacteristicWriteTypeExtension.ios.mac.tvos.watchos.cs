using System;
using CoreBluetooth;
using Cross.BluetoothLe;

namespace Cross.BluetoothLe.Extensions
{
    internal static class CharacteristicWriteTypeExtension
    {
        public static CBCharacteristicWriteType ToNative(this CharacteristicWriteType writeType)
        {
            switch (writeType)
            {
                case CharacteristicWriteType.WithResponse:
                    return CBCharacteristicWriteType.WithResponse;
                case CharacteristicWriteType.WithoutResponse:
                    return CBCharacteristicWriteType.WithoutResponse;
                default:
                    throw new NotImplementedException();
            }
        }
    }

}
