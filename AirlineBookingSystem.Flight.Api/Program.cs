using AirlineBookingSystem.Flight.Application.Handlers;
using AirlineBookingSystem.Flight.Application.Queries;
using AirlineBookingSystem.Flights.Core.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using MediatR;
using AirlineBookingSystem.Flight.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var assembly = new Assembly[] {
    Assembly.GetExecutingAssembly(),
    typeof(CreateFlightHandler).Assembly,
    typeof(DeleteFlightHandler).Assembly,
    typeof(GetFlightsHandler).Assembly

};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IDbConnection>(sp =>
new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

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
