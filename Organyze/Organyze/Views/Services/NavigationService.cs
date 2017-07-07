using System.Threading.Tasks;

namespace Organyze.Views.Services
{
    public class NavigationService : ViewModels.Services.INavigationService
    {
        public async Task NavigationToLogin()
        {
            await App.NavigationMasterDetail(new LoginPage());
        }

        public async Task NavigationVoltarToLogin()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public async Task NavigationToMain()
        {
            await App.NavigationMasterDetail(new MainPage());
        }

        public async Task NavigationVoltarToMain()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        public async Task NavigationToRegister()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        public async Task NavigationToItemsPage()
        {
      //      await App.NavigationMasterDetail(new ItemsPage());
        }

        public async Task NavigationToClientesPage()
        {
      //      await App.NavigationMasterDetail(new ClientesPage());
        }

        public async Task NavigationToFuncionarioPage()
        {
      //      await App.NavigationMasterDetail(new FuncionarioPage());
        }

        public async Task NavigationToSobre()
        {
            await App.NavigationMasterDetail(new AboutPage());
        }

        public async Task NavigationToOrdemServicoPage(string Status)
        {
     //       await App.NavigationMasterDetail(new OrdemServicoPage(Status));
        }

        public async Task NavigationToProjetoPage()
        {
            await App.NavigationMasterDetail(new ProjetoPage());
        }

        public async Task NavigationVoltar()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigationToNewFuncionario()
        {
     //       await App.NavigationMasterDetail(new NewFuncionarioPage());
        }

        public async Task NavigationToNewCliente()
        {
     //       await App.NavigationMasterDetail(new NewClientePage());
        }

        public async Task NavigationToNewOrdemServico()
        {
      //      await App.NavigationMasterDetail(new NewOrdemServicoPage());
        }

        public async Task NavigationToNewItem()
        {
      //      await App.NavigationMasterDetail(new NewItemPage());
        }

        public async Task NavigationToCategoriaPage()
        {
      //      await App.NavigationMasterDetail(new CategoriaPage());
        }

        public async Task NavigationToNewCategoria()
        {
      //      await App.NavigationMasterDetail(new NewCategoriaPage());
        }

        public async Task NavigationToDepartamentoPage()
        {
       //     await App.NavigationMasterDetail(new DepartamentoPage());
        }

        public async Task NavigationToNewDepartamento()
        {
      //      await App.NavigationMasterDetail(new NewDepartamentoPage());
        }
    }
}

