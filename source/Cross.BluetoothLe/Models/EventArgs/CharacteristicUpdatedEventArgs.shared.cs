﻿using Cross.BluetoothLe;

namespace Cross.BluetoothLe.EventArgs
{
    public class CharacteristicUpdatedEventArgs : System.EventArgs
    {
        public Characteristic Characteristic { get; set; }

        public CharacteristicUpdatedEventArgs(Characteristic characteristic)
        {
            Characteristic = characteristic;
        }
    }
}
