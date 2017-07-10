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
       // DepartamentoManager manager;
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;
        public Departamento Departamento { get; set; }
        public NewDepartamentoViewModel()
        {
           // manager = new DepartamentoManager();
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

       // public IDepartamento Departamento { get; set; }
        private async void ExecuteSalvar()
        {
            /*   var teste = Departamento.Nome;

               await  manager.SaveTaskAsync(Departamento);
               await _navigationService.NavigationVoltar();*/

            /*  var todo = new Departamento { Nome = "Teste Depart505" };
              await AddItem(todo);

              async Task AddItem(Departamento item)
              {
                  await DataDepartamento.SaveTaskAsync(item);
                  //todoList.ItemsSource = await manager.GetTodoItemsAsync();*/

            var teste = Departamento.Nome;
            var teste2 = Departamento.Id;
            await DataDepartamento.SaveTaskAsync(Departamento);
            await _navigationService.NavigationVoltar(); 
        }
    }
}
