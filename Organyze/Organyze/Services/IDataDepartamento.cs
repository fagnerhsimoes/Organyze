using Organyze.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Organyze.Services
{
    public interface IDataDepartamento<T>
    {
        /* Task<bool> AddProjetoAsync(T projeto);
         Task<bool> UpdateProjetoAsync(T funcionario);
         Task<bool> DeleteProjetoAsync(T funcionario);
         Task<T> GetProjetoAsync(string id);
         IEnumerable<T> GetProjetos(bool forceRefresh = false);

         Task InitializeAsync();
         Task<bool> PullLatestAsync();
         Task<bool> SyncAsync();*/
        T GetNewDepartamentoAsync();
        DataDepartamento DefaultManager { get; }
        Task<ObservableCollection<T>> GetTodoItemsAsync(bool syncItems = false);
        Task <bool>SaveTaskAsync(Departamento item);
    }
}
