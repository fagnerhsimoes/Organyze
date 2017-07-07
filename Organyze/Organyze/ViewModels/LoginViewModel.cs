using Organyze.Helpers;
using Organyze.Services;
using Organyze.Views;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Organyze.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        string senha = string.Empty;
        public string Senha
        {
            get { return senha; }
            set { SetProperty(ref senha, value); }
        }

        public Command LoginCommand
        {
            get;
            set;
        }

        public Command LoginFacebookCommand
        {
            get;
            set;
        }

        public Command RegisterCommand
        {
            get;
            set;
        }

        private readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;
        private readonly AzureService _azureService;
        private bool _isBusy;

        public LoginViewModel()
        {
            _azureService = DependencyService.Get<AzureService>();
            _messageService = DependencyService.Get<Services.IMessageService>();
            _navigationService = DependencyService.Get<Services.INavigationService>();

            LoginCommand = new Command(ExecuteLogarAsync);
            LoginFacebookCommand = new Command(ExecuteLoginCommandAsync);
            RegisterCommand = new Command(NavegarToRegister);
        }

        private async void ExecuteLogarAsync()
        {
            if (Email == "admin" && Senha == "123")
            {
                App.Current.MainPage = new NavigationPage(new Views.MainPage());
            }
            else
            {
                await _messageService.ShowAsync("Email e/ou senha inválidos...");
            }
        }

        private async void ExecuteLoginCommandAsync()
        {
            if (_isBusy || !(await LoginAsync()))
            {
                return;
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new Views.MainPage());
            }
            _isBusy = false;
        }

        private Task<bool> LoginAsync()
        {
            _isBusy = true;
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return _azureService.LoginAsync();
        }

        private async void NavegarToRegister()
        {
            await _navigationService.NavigationToRegister();
        }
    }
}

