using Organyze.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Organyze.ViewModels
{
    public class CategoriaDetailViewModel : BaseViewModel
    {
        private readonly Services.INavigationService _navigationService;
        private readonly Services.IMessageService    _messageService;

        public Categoria Categoria { get; set; }
        public CategoriaDetailViewModel(Categoria categoria = null)
        {
            _navigationService = DependencyService.Get<Services.INavigationService>();
            _messageService    = DependencyService.Get<Services.IMessageService>();
            Categoria          = new Categoria();
            SalvarCommand      = new Command(ExecuteSalvar);

            Title = categoria.Nome;
            Categoria = categoria;
        }

        public ICommand SalvarCommand
        {
            get;
            set;
        }

        private async void ExecuteSalvar()
        {
          //  await  DataCategoria.SaveTaskAsync(Categoria);
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