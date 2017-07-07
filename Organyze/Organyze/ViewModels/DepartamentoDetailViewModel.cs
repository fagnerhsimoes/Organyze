using Organyze.Interfaces;
using Organyze.Models;

namespace Organyze.ViewModels
{
    public class DepartamentoDetailViewModel : BaseViewModel
    {
        public Departamento Departamento { get; set; }
        public DepartamentoDetailViewModel(Departamento departamento = null)
        {
            Title = departamento.Nome;
            Departamento = departamento;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}