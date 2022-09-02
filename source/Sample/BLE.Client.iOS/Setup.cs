﻿using Acr.UserDialogs;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace BLE.Client.iOS
{
  public class Setup : MvxFormsIosSetup
  {
    protected override IMvxIoCProvider InitializeIoC()
    {
      var result = base.InitializeIoC();

      Mvx.IoCProvider.RegisterSingleton(() => UserDialogs.Instance);

      return result;
    }

    protected override Xamarin.Forms.Application CreateFormsApplication()
    {
      return new BleMvxFormsApp();
    }

    protected override IMvxApplication CreateApp(IMvxIoCProvider iocProvider)
    {
      return new BleMvxApplication();
    }

    protected override ILoggerProvider CreateLogProvider()
    {
      ////return new SerilogLoggerProvider();
      return null;
    }

    protected override ILoggerFactory CreateLogFactory()
    {
      ////// serilog configuration
      ////Log.Logger = new LoggerConfiguration()
      ////    .MinimumLevel.Debug()
      ////    .WriteTo.NSLog()
      ////    .CreateLogger();
      ////
      ////return new SerilogLoggerFactory();
      return null;
    }

    /*
    public override IEnumerable<Assembly> GetPluginAssemblies()
    {
        return new List<Assembly>(base.GetViewAssemblies().Union(new[] { typeof(MvvmCross.Plugins.BLE.iOS.Plugin).GetTypeInfo().Assembly }));
    }
    */
  }
}
