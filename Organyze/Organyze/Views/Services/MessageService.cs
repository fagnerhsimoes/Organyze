using System.Threading.Tasks;

namespace Organyze.Views.Services
{
    public class MessageService : ViewModels.Services.IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Organyze", message, "OK");
        }

        public async Task<bool> PerguntaAsync(string message)
        {
             return await App.Current.MainPage.DisplayAlert("Organyze", message, "Sim","Não");
        }

        public async Task msgErroAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Erro", message, "OK");
        }
    }
}

