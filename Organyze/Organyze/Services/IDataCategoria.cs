using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organyze.Services
{
    public interface IDataCategoria<T>
    {
        Task<IEnumerable<T>> GetTagsAsync();
    }
}