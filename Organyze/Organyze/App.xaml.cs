using Organyze.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Organyze
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetail { get; set; }

        public async static Task NavigationMasterDetail(Page page)
        {
            MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        }

        public App()
        {
            DependencyService.Register<ViewModels.Services.IMessageService, Views.Services.MessageService>();
            DependencyService.Register<ViewModels.Services.INavigationService, Views.Services.NavigationService>();

            InitializeComponent();

            if (Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new Views.MainPage());
            }
            else
            {
                Current.MainPage = new NavigationPage(new Views.MainPage());
                //Current.MainPage = new NavigationPage(new LoginPage());
            }

            //within IMethods PCL class
            void Close_App()
            {

            };
        }

        /*public static Page GetMainPage()
        {
            return new TabbedPage
            {
               Children =
                 {
                     new OrdemServicoPage("Executando")
                     {
                         Title = "Em Execução",
                         Icon = "play.png"
                     },
                     new OrdemServicoPage("Aguardando")
                     {
                         Title = "Aguardando",
                         Icon = "pend.png"
                     },
                     new OrdemServicoPage("Finalizada")
                     {
                         Title = "Finalizadas",
                         Icon = "ok.png"
                     },
                 }
            };

        }*/

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
