using AirlineBookingSystem.Flights.Core.Repositories;
using System.Data;
using Dapper;

namespace AirlineBookingSystem.Flight.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDbConnection _dbConnection;
        public FlightRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }   
        public async Task AddFlightAsync(Flights.Core.Entities.Flight flight)
        {
           const string query = "INSERT INTO Flights (Id,FlightNumber, Origin, Destination, DepartureTime, ArrivalTime) VALUES (@FlightNumber, @Origin, @Destination, @DepartureTime, @ArrivalTime)";
             await _dbConnection.ExecuteAsync(query, flight);   
        }

        public Task DeleteFlightAsync(int id)
        {
            const string query = "DELETE FROM Flights WHERE Id = @Id";
            return _dbConnection.ExecuteAsync(query, new { Id = id });


        }

        public Task<IEnumerable<Flights.Core.Entities.Flight>> GetFlightAsync()
        {
            const string query = "SELECT * FROM Flights";
            return _dbConnection.QueryAsync<Flights.Core.Entities.Flight>(query);

        }
    }
}
