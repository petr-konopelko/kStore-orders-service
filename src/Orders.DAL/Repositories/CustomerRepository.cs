using Dapper;
using Microsoft.Data.SqlClient;
using Orders.DAL.Models;
using Orders.DAL.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.DAL.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public CustomerRepository(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public async Task<IReadOnlyCollection<Customer>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionStringProvider.Orders);
        await connection.OpenAsync();

        return (await connection.QueryAsync<Customer>("SELECT * FROM Customer")).ToArray();
    }

    public async Task<int> AddAsync(Customer entity)
    {
        using var connection = new SqlConnection(_connectionStringProvider.Orders);
        await connection.OpenAsync();

        return await connection.QueryFirstAsync<int>($"INSERT INTO Customer (Name) OUTPUT INSERTED.ID VALUES(@{nameof(entity.Name)})", entity);
    }
}
