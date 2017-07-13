using Organyze.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Organyze.Services
{
    public interface IDataCliente<T>
    {
        T GetNewClienteAsync();
        DataCliente DefaultManager { get; }
        Task<ObservableCollection<T>> GetTodoItemsAsync(bool syncItems = false);
        Task<bool> SaveTaskAsync(Cliente item);
    }
}
