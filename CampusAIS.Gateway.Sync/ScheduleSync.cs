namespace CampusAIS.Gateway.Sync;

public interface IScheduleSyncService
{
    Task SyncAsync();
}

public class ScheduleSyncService : IScheduleSyncService
{
    public Task SyncAsync()
    {
        // Логика синхронизации
        return Task.CompletedTask;
    }
}