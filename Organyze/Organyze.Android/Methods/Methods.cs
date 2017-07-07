using Organyze.Droid.Methods;
using Organyze.Methods;

[assembly: Xamarin.Forms.Dependency(typeof(Methods))]
namespace Organyze.Droid.Methods
{
    public class Methods : IMethods
    {
        public void Close_App()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}