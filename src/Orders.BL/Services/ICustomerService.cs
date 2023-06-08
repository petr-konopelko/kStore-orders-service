using Orders.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.BL.Services;

public interface ICustomerService
{
    Task<IReadOnlyCollection<CustomerDto>> GetAllAsync();
    Task<int> AddAsync(string name);
}
