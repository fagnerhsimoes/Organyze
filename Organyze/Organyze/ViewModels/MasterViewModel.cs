using Organyze.Helpers;
using Organyze.Methods;
using System.Windows.Input;
using Xamarin.Forms;

namespace Organyze.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        protected readonly Services.IMessageService _messageService;
        protected readonly Services.INavigationService _navigationService;

        public MasterViewModel()
        {
            _navigationService = DependencyService.Get<Services.INavigationService>();
            _messageService = DependencyService.Get<Services.IMessageService>();

            ClienteCommand      = new Command(Cliente);
            ItemCommand         = new Command(Item);
            CategoriaCommand    = new Command(Categoria);
            ProjetoCommand      = new Command(Projeto);
            FuncionarioCommand  = new Command(Funcionario);
            DepartamentoCommand = new Command(Departamento);
            SobreCommand        = new Command(Sobre);
            SairCommand         = new Command(ExecuteSairCommand);
        }

        public ICommand ProjetoCommand
        {
            get;
            set;
        }
        public ICommand CategoriaCommand
        {
            get;
            set;
        }
        public ICommand DepartamentoCommand
        {
            get;
            set;
        }
        public ICommand FuncionarioCommand
        {
            get;
            set;
        }
        public ICommand ClienteCommand
        {
            get;
            set;
        }
        public ICommand ItemCommand
        {
            get;
            set;
        }
        public ICommand ConfigCommand
        {
            get;
            set;
        }
        public ICommand HorariosCommand
        {
            get;
            set;
        }
        public ICommand SobreCommand
        {
            get;
            set;
        }
        public ICommand TagCommand
        {
            get;
            set;
        }
        public ICommand GetSobreCommand
        {
            get;
            set;
        }
        public ICommand SairCommand
        {
            get;
            set;
        }


        private async void Projeto()
        {
            await _navigationService.NavigationToProjetoPage();
        }
        private async void Categoria()
        {
            await _navigationService.NavigationToCategoriaPage();
        }
        private async void Departamento()
        {
            await _navigationService.NavigationToDepartamentoPage();
        }
        private async void Funcionario()
        {
            await _navigationService.NavigationToFuncionarioPage();
        }
        private async void Cliente()
        {
            await _navigationService.NavigationToClientesPage();
        }
        private async void Item()
        {
            await _navigationService.NavigationToItemsPage();
        }
        private async void Sobre()
        {
            await _navigationService.NavigationToSobre();
        }
        private async void ExecuteSairCommand()
        {
            bool resposta = await _messageService.PerguntaAsync("Deseja sair da Aplicação?");
            if (resposta)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                if (Device.OS == TargetPlatform.Android)
                {
                    DependencyService.Get<IMethods>().Close_App();
                }
            }
        }
    }
}
