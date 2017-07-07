using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Organyze.Helpers;
using Organyze.Models;
using Xamarin.Forms;

namespace Organyze.ViewModels
{
    public class ProjetoViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Projeto> Projetos { get; set; }
        public Command LoadProjetoCommand { get; set; }

        private readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;
        public ProjetoViewModel()
        {
            Title = "Projetos";
            Projetos = new ObservableRangeCollection<Projeto>();
            LoadProjetoCommand = new Command(async () => await ExecuteLoadProjetoCommand());

            _messageService = DependencyService.Get<Services.IMessageService>();
            _navigationService = DependencyService.Get<Services.INavigationService>();
        }

        async Task ExecuteLoadProjetoCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Projetos.Clear();
                var projetos = DataProjeto.GetProjetos(true);
                Projetos.ReplaceRange(projetos);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await _messageService.msgErroAsync("Não foi possível carregar os projetos");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}