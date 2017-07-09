using Organyze.Interfaces;

namespace Organyze.ViewModels
{
    public class DepartamentoDetailViewModel : BaseViewModel
    {
        public IDepartamento Departamento { get; set; }
        public DepartamentoDetailViewModel(IDepartamento departamento = null)
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