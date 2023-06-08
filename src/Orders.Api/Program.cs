using Microsoft.AspNetCore.Mvc;
using Orders.BL.Models;
using Orders.BL.Services;
using Orders.DAL.Models;
using Orders.DAL.Providers;
using Orders.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables("OrdersService_");

builder.Services.Configure<DatabaseConnectionsOptions>(builder.Configuration.GetSection("DatabaseConnections"));
builder.Services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

//var ordersGroup = app.MapGroup("/orders");
//ordersGroup.MapGet("", async (IOrderService orderService) => await orderService.GetOrdersAsync());

app.Logger.LogInformation(app.Configuration.GetConnectionString("Orders"));


var customerGroup = app.MapGroup("/customers");
customerGroup.MapGet("", async (ICustomerService customerService) => await customerService.GetAllAsync());
customerGroup.MapPost("", async ([FromBody] CustomerDto customer, ICustomerService customerService) =>
    await customerService.AddAsync(customer.Name));

app.Run();
