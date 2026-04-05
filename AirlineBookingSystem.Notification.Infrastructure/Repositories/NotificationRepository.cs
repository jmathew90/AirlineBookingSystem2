using AirlineBookingSystem.Notifications.Core.Entities;
using AirlineBookingSystem.Notifications.Core.Repositories;
using System.Data;
using Dapper;
namespace AirlineBookingSystem.Notifications.Infrastructure
{
    public class NotificationRepository : INotificationRepository
    {

        private readonly IDbConnection _dbConnection;
            public NotificationRepository(IDbConnection dbConnection) { 
           
                _dbConnection = dbConnection;


        }
        public async Task logNotificationAsync(Notification notification)
        {
            const string sql = "INSERT INTO Notifications (Id,Recipent,Message,Type,SentAt) VALUES (@Id,@Recipient, @Message, @Type,@SentAt)";
            await _dbConnection.ExecuteAsync(sql,notification);


        }
    }
}
