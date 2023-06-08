using Orders.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.BL.Services;

public interface IOrderService
{
    Task<IReadOnlyCollection<OrderDto>> GetOrdersAsync();
}
