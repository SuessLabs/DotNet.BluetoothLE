using Android.Bluetooth;

namespace Cross.BluetoothLe.EventArgs
{
    public class CharacteristicReadCallbackEventArgs
    {
        public BluetoothGattCharacteristic Characteristic { get; }

        public CharacteristicReadCallbackEventArgs(BluetoothGattCharacteristic characteristic)
        {
            Characteristic = characteristic;
        }
    }
}
