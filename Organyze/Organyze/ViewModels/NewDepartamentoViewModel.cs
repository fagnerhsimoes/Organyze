using System.Windows.Input;
using Xamarin.Forms;
using Organyze.Interfaces;
using Organyze.Models;
using Organyze.Services;
using System.Threading.Tasks;

namespace Organyze.ViewModels
{
    public class NewDepartamentoViewModel : BaseViewModel
    {
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;
        public Departamento Departamento { get; set; }
        public NewDepartamentoViewModel()
        {
            _navigationService = DependencyService.Get<Services.INavigationService>();
            _messageService    = DependencyService.Get<Services.IMessageService>();
            Departamento       = new Departamento();
            SalvarCommand      = new Command(ExecuteSalvar);
        }

        public ICommand SalvarCommand
        {
            get;
            set;
        }

        private async void ExecuteSalvar()
        {
            await DataDepartamento.SaveTaskAsync(Departamento);
            await _navigationService.NavigationVoltar(); 
        }
    }
}
