using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.DAL.Repositories;

public interface IRepository<T>
{
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<int> AddAsync(T entity);
}
