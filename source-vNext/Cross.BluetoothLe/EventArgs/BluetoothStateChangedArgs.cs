﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cross.BluetoothLe.EventArgs
{
  public class BluetoothStateChangedArgs : System.EventArgs
  {
    /// <summary>
    /// State before the change.
    /// </summary>
    public BluetoothState OldState { get; }

    /// <summary>
    /// Current state.
    /// </summary>
    public BluetoothState NewState { get; }

    public BluetoothStateChangedArgs(BluetoothState oldState, BluetoothState newState)
    {
      OldState = oldState;
      NewState = newState;
    }
  }
}
