using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Organyze.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Sobre";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.xamarin.com/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
