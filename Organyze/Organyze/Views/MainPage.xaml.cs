using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Organyze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
          //  BindingContext = new ViewModels.MainViewModel();

            Master = new MasterPage();
            Detail = new TodoList();
        //    Detail = App.GetMainPage();
        //    App.MasterDetail = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}


