using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Organyze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.RegisterViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
