using CampusAIS.Client.Data.ApiClient;
using CampusAIS.Shared.Contracts;

namespace CampusAIS.Client.Core.BusinessLogic;

public interface IScheduleService
{
    Task<ScheduleGridDto?> GetScheduleAsync();
}

public class ScheduleService : IScheduleService
{
    private readonly IScheduleApiClient _apiClient;
    public ScheduleService(IScheduleApiClient apiClient) => _apiClient = apiClient;

    public Task<ScheduleGridDto?> GetScheduleAsync() => _apiClient.GetScheduleAsync();
}

public class BookingRequestValidator
{
    public bool Validate(RoomBookingRequest request)
    {
        return request.Start < request.End;
    }
}