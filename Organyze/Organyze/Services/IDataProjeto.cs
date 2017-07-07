using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organyze.Services
{
    public interface IDataProjeto<T>
    {
        Task<bool> AddProjetoAsync(T projeto);
        Task<bool> UpdateProjetoAsync(T funcionario);
        Task<bool> DeleteProjetoAsync(T funcionario);
        Task<T> GetProjetoAsync(string id);
        IEnumerable<T> GetProjetos(bool forceRefresh = false);

        Task InitializeAsync();
        Task<bool> PullLatestAsync();
        Task<bool> SyncAsync();
    }
}
