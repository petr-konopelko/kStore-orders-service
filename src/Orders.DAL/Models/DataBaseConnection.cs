namespace Orders.DAL.Models;

public record DataBaseConnection
{
    public required string Server { get; set; }

    public required int Port { get; set; }

    public required string UserId { get; set; }

    public required string Password { get; set; }

    public required string InitialCatalog { get; set; }

    public bool TrustServerCertificate { get; set; }
}
