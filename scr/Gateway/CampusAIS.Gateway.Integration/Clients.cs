namespace CampusAIS.Gateway.Integration;

public interface IScheduleSystemClient
{
    Task<string> FetchScheduleAsync();
}

public interface IRoomSystemClient
{
    Task<bool> CheckAvailabilityAsync(Guid roomId, DateTime start, DateTime end);
}