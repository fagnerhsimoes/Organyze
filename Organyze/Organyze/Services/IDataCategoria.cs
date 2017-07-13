using Organyze.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organyze.Services
{
    public interface IDataCategoria<T>
    {
        Task<bool> AddCategoriaAsync(T categoria);
        Task<bool> UpdateCategoriaAsync(T categoria);
        Task<bool> DeleteCategoriaAsync(T categoria);
        Task<T> GetCategoriaAsync(string id);
        T GetNewCategoriaAsync();
        IEnumerable<T> GetCategorias(bool forceRefresh = false);
        Task<IEnumerable<T>> GetCategoriasAsync();

        Task InitializeAsync();
        Task<bool> PullLatestAsync();
        Task<bool> SyncAsync();

        Task<IEnumerable<T>> BuscarCategoriasAsync();
    }
}
