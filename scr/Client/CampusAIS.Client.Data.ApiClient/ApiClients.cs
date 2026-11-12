using CampusAIS.Shared.Contracts;

namespace CampusAIS.Client.Data.ApiClient;

public interface IScheduleApiClient
{
    Task<ScheduleGridDto?> GetScheduleAsync();
}

public class ScheduleApiClient : IScheduleApiClient
{
    private readonly HttpClient _httpClient;
    public ScheduleApiClient(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ScheduleGridDto?> GetScheduleAsync()
    {
        // В реальности тут должен быть вызов сервера. 
        // Для демо возвращаем заглушку, чтобы не настраивать CORS и порты.
        await Task.Delay(500);
        return new ScheduleGridDto(new List<LessonDto>
        {
            new(Guid.NewGuid(), "Физика", "Сидоров С.С.", "Ауд. 303", DateTime.Today.AddHours(10), DateTime.Today.AddHours(11.5))
        });
    }
}