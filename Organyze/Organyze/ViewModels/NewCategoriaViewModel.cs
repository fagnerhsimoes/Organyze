using System.Windows.Input;
using Xamarin.Forms;
using Organyze.Interfaces;
using Organyze.Models;
using Organyze.Services;
using System.Threading.Tasks;

namespace Organyze.ViewModels
{
    public class NewCategoriaViewModel : BaseViewModel
    {
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService _messageService;
        public Categoria Categoria { get; set; }
        public NewCategoriaViewModel()
        {
            _navigationService  = DependencyService.Get<Services.INavigationService>();
            _messageService     = DependencyService.Get<Services.IMessageService>();
            Categoria           = new Categoria();
            SalvarCommand       = new Command(ExecuteSalvar);
        }

        public ICommand SalvarCommand
        {
            get;
            set;
        }

        private async void ExecuteSalvar()
        {
           // await DataCategoria.SaveTaskAsync(Categoria);
            await _navigationService.NavigationVoltar();
        }
    }
}
