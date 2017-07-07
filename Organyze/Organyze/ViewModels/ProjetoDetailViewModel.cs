using Organyze.Models;

namespace Organyze.ViewModels
{
    public class ProjetoDetailViewModel : BaseViewModel
    {
        public Projeto Projeto { get; set; }
        public ProjetoDetailViewModel(Projeto projeto = null)
        {
            Title = projeto.Nome;
            Projeto = projeto;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}