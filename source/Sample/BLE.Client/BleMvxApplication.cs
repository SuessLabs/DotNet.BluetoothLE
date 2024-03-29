﻿using BLE.Client.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace BLE.Client
{
  public class BleMvxApplication : MvxApplication
  {
    public override void Initialize()
    {
      CreatableTypes()
        .EndingWith("Service")
        .AsInterfaces()
        .RegisterAsLazySingleton();

      RegisterAppStart<DeviceListViewModel>();
    }
  }
}
