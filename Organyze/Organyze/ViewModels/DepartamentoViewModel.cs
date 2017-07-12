using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Organyze.Helpers;
using Xamarin.Forms;
using Organyze.Interfaces;
using Organyze.Services;

namespace Organyze.ViewModels
{
    public class DepartamentoViewModel : BaseViewModel
    {
        public ObservableRangeCollection<IDepartamento> Departamentos { get; set; }
        public Command LoadDepartamentosCommand { get; set; }

        public readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;
        public DepartamentoViewModel()
        {
            Title = "Departamentos";
            Departamentos = new ObservableRangeCollection<IDepartamento>();
            LoadDepartamentosCommand = new Command(async () => await ExecuteLoadDepartamentosCommand());
            AddDepartamentoCommand = new Command(ExecuteAddDepartamento);

            _messageService = DependencyService.Get<Services.IMessageService>();
            _navigationService = DependencyService.Get<Services.INavigationService>();
        }

        public Command AddDepartamentoCommand
        {
            get;
            set;
        }

        private async void ExecuteAddDepartamento()
        {
            await _navigationService.NavigationToNewDepartamento();
        }

        private async Task ExecuteLoadDepartamentosCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Departamentos.Clear();
                var departamentos = await DataDepartamento.GetTodoItemsAsync(true);
                Departamentos.ReplaceRange(departamentos);

                /*  foreach (IDepartamento depart in departamentos)
                  {
                      Departamentos.Add(depart);
                  }*/


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await _messageService.msgErroAsync("Não foi possível carregar os departamentos");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}