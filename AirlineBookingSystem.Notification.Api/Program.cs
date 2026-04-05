using AirlineBookingSystem.Notifications.Core.Repositories;
using System.Data;
using Microsoft.Data.SqlClient;
using AirlineBookingSystem.Notifications.Infrastructure;
using System.Reflection;
using MediatR;
using AirlineBookingSystem.Notification.Application.Handlers;
using AirlineBookingSystem.Notification.Application.Interfaces;
using AirlineBookingSystem.Notification.Application.Services;
using MassTransit;
using RabbitMQ.Client;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message;
using AirlineBookingSystem.Notification.Application.Consumers;
using AirlineBookingSystem.BuildingBlocks.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var assembly = new Assembly[] {
    Assembly.GetExecutingAssembly(),
    typeof(SendNotificationHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
builder.Services.AddScoped<INotificationService, NotificationService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IDbConnection>(sp =>
new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));


//MassTransit Configuration

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<PaymentProcessedConsumer>();
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusContract.PaymentProcessedQueue, e =>
        {
            e.ConfigureConsumer<PaymentProcessedConsumer>(context);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
