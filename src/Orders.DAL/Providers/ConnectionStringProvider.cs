using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Orders.DAL.Models;

namespace Orders.DAL.Providers;

public class ConnectionStringProvider : IConnectionStringProvider
{
    private readonly DatabaseConnectionsOptions _connectionStringOptions;

    public ConnectionStringProvider(
        IOptions<DatabaseConnectionsOptions> options,
        ILogger<ConnectionStringProvider> logger)
    {
        _connectionStringOptions = options.Value!;
        Orders = GetConnectionString(_connectionStringOptions.Orders);
        logger.LogInformation(Orders);
    }

    public string Orders { get; private set; }

    private string GetConnectionString(DataBaseConnection connection)
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.InitialCatalog = connection.InitialCatalog;
        builder.Password = connection.Password;
        builder.UserID = connection.UserId;
        builder.TrustServerCertificate = connection.TrustServerCertificate;
        builder.DataSource = $"{connection.Server},{connection.Port}";

        return builder.ConnectionString;
    }
}
