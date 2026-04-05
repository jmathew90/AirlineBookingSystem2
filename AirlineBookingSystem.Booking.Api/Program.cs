using System.Data;
using System.Reflection;
using AirlineBookingSystem.Booking.Application.Handlers;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.Bookings.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using AirlineBookingSystem.BuildingBlocks.Common;
using MediatR;
using MassTransit;
using AirlineBookingSystem.Booking.Application.Consumers;
using RabbitMQ.Client;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var assembly = new Assembly[] { 
    Assembly.GetExecutingAssembly(), 
    typeof(CreateBookingHandler).Assembly,
    typeof(GetBookingHandler).Assembly 
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

builder.Services.AddOpenApi();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

//MassTransit Configuration

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<NotificationEventConsumer>();
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
            cfg.ReceiveEndpoint(EventBusContract.NotificationSentQueue, e =>
            {
                e.ConfigureConsumer<NotificationEventConsumer>(context);
            });
    });
}); 



// Add the database connection

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
app.UseRouting();
app.Run();
