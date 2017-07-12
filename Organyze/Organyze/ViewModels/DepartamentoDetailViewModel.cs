using Organyze.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Organyze.ViewModels
{
    public class DepartamentoDetailViewModel : BaseViewModel
    {
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;

        public Departamento Departamento { get; set; }
        public DepartamentoDetailViewModel(Departamento departamento = null)
        {
            _navigationService = DependencyService.Get<Services.INavigationService>();
            _messageService    = DependencyService.Get<Services.IMessageService>();
            Departamento       = new Departamento();
            SalvarCommand      = new Command(ExecuteSalvar);

            Title = departamento.Nome;
            Departamento = departamento;
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

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}