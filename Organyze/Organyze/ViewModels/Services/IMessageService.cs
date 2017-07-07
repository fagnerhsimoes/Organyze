using System.Threading.Tasks;

namespace Organyze.ViewModels.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
        Task<bool> PerguntaAsync(string message);
        Task msgErroAsync(string message);
    }
}

