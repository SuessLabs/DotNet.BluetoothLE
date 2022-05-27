using System.Threading.Tasks;
using BLE.Client.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(BLE.Client.UWP.Helpers.PlatformHelpers))]

namespace BLE.Client.UWP.Helpers
{
  public class PlatformHelpers : IPlatformHelpers
  {
    public Task<PermissionStatus> CheckAndRequestBluetoothPermissions()
    {
      return Task.FromResult(PermissionStatus.Granted);
    }
  }
}
