﻿using System;
using Android.Bluetooth;
using Android.Content;
using Cross.BluetoothLe.Extensions;

namespace Cross.BluetoothLe.BroadcastReceivers
{
  public class BluetoothStatusBroadcastReceiver : BroadcastReceiver
  {
    private readonly Action<BluetoothState> _stateChangedHandler;

    public BluetoothStatusBroadcastReceiver(Action<BluetoothState> stateChangedHandler)
    {
      _stateChangedHandler = stateChangedHandler;
    }

    public override void OnReceive(Context context, Intent intent)
    {
      var action = intent.Action;

      if (action != BluetoothAdapter.ActionStateChanged)
        return;

      var state = intent.GetIntExtra(BluetoothAdapter.ExtraState, -1);

      if (state == -1)
      {
        _stateChangedHandler?.Invoke(BluetoothState.Unknown);
        return;
      }

      var btState = (State)state;
      _stateChangedHandler?.Invoke(btState.ToBluetoothState());
    }
  }
}
