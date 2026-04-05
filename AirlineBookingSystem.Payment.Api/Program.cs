using AirlineBookingSystem.BuildingBlocks.Common;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Message;
using AirlineBookingSystem.Payment.Application.Consumers;
using AirlineBookingSystem.Payments.Application.Handlers;
using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using MassTransit;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var assembly = new Assembly[] {
    Assembly.GetExecutingAssembly(),
    typeof(ProcessPaymentHandler).Assembly,
   
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPaymentRepository, AirlineBookingSystem.Payments.Infrastructure.Repositories.PaymentRepository>();

//MassTransit Configuration

//builder.Services.AddMassTransit(config =>
//{
//    config.AddConsumer<NotificationEventConsumer>();
//    config.UsingRabbitMq((context, cfg) =>
//    {
//        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
//        cfg.ReceiveEndpoint(EventBusContract.NotificationSentQueue, e =>
//        {
//            e.ConfigureConsumer<NotificationEventConsumer>(context);
//        });
//    });
//});

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<FlightBookedConsumer>();
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(AirlineBookingSystem.BuildingBlocks.Common.EventBusContract.FlightBookedQueue, e =>
        {
            e.ConfigureConsumer<FlightBookedConsumer>(context);
        });
    });
});

builder.Services.AddScoped<IDbConnection>(sp =>
new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
