using Organyze.Interfaces;
using Organyze.Models;
using Organyze.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Organyze.ViewModels
{
    public class DepartamentoDetailViewModel : BaseViewModel
    {
      //  DepartamentoManager manager;

        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;

        public Departamento Departamento { get; set; }
        public DepartamentoDetailViewModel(Departamento departamento = null)
        {
          //  manager = new DepartamentoManager();

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

       // public Departamento Departamento { get; set; }
        private async void ExecuteSalvar()
        {
            //await DataDepartamento.AddDepartamentoAsync(Departamento);
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