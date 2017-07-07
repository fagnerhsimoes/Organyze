using System.Windows.Input;
using Xamarin.Forms;
using Organyze.Interfaces;

namespace Organyze.ViewModels
{
    public class NewDepartamentoViewModel : BaseViewModel
    {
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;
        public NewDepartamentoViewModel()
        {
            _navigationService = DependencyService.Get<Services.INavigationService>();
            _messageService    = DependencyService.Get<Services.IMessageService>();
          //  Departamento       = DataDepartamento.GetNewDepartamentoAsync();
          //  SalvarCommand      = new Command(ExecuteSalvar);
        }

        public ICommand SalvarCommand
        {
            get;
            set;
        }

       /* public IDepartamento Departamento { get; set; }
        private async void ExecuteSalvar()
        {
            await DataDepartamento.AddDepartamentoAsync(Departamento);
            await _navigationService.NavigationVoltar();
        }*/
    }
}
