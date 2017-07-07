using System.Threading.Tasks;

namespace Organyze.ViewModels.Services
{
    public interface INavigationService
    {
        Task NavigationToLogin();
        Task NavigationToMain();
        Task NavigationVoltarToMain();
        Task NavigationVoltarToLogin();
        Task NavigationToRegister();
        Task NavigationToClientesPage();
        Task NavigationToItemsPage();
        Task NavigationToSobre();
        Task NavigationToFuncionarioPage();
        Task NavigationToOrdemServicoPage(string Status);
        Task NavigationToProjetoPage();
        Task NavigationVoltar();
        Task NavigationToNewFuncionario();
        Task NavigationToNewCliente();
        Task NavigationToNewOrdemServico();
        Task NavigationToNewItem();
        Task NavigationToCategoriaPage();
        Task NavigationToNewCategoria();
        Task NavigationToDepartamentoPage();
        Task NavigationToNewDepartamento();
    }
}
