﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cross.BluetoothLe
{
  public partial class Service
  {
    internal Guid NativeGuid => throw new PlatformNotSupportedException();

    internal bool NativeIsPrimary => throw new PlatformNotSupportedException();

    internal Task<IList<Characteristic>> GetCharacteristicsNativeAsync() => throw new PlatformNotSupportedException();

    internal object NativeService => throw new PlatformNotSupportedException();

    public virtual void Dispose()
    {
    }
  }
}
