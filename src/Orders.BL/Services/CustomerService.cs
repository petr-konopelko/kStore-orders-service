using Mapster;
using Orders.BL.Models;
using Orders.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.BL.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IReadOnlyCollection<CustomerDto>> GetAllAsync()
    {
        var result = await _customerRepository.GetAllAsync();

        return result.Adapt<CustomerDto[]>();
    }

    public Task<int> AddAsync(string name)
    {
        return _customerRepository.AddAsync(new DAL.Models.Customer(default, name));
    }
}
