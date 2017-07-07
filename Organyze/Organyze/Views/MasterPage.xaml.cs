using Xamarin.Forms;

namespace Organyze.Views
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
           // BindingContext = new ViewModels.MasterViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
