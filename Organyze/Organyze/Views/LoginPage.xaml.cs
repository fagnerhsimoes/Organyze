using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Organyze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.LoginViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}

