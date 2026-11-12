using CampusAIS.Shared.Contracts;

namespace CampusAIS.Gateway.Booking;

public class RoomBookingValidator
{
    public bool Validate(RoomBookingRequest request)
    {
        return request.Start < request.End && !string.IsNullOrWhiteSpace(request.Purpose);
    }
}

public interface IBookingService
{
    Task<RoomBookingResponse> BookRoomAsync(RoomBookingRequest request);
}

public class BookingService : IBookingService
{
    private readonly RoomBookingValidator _validator;
    public BookingService() => _validator = new RoomBookingValidator();

    public Task<RoomBookingResponse> BookRoomAsync(RoomBookingRequest request)
    {
        if (!_validator.Validate(request))
            return Task.FromResult(new RoomBookingResponse(Guid.Empty, false, "Ошибка валидации"));

        return Task.FromResult(new RoomBookingResponse(Guid.NewGuid(), true, "Успешно"));
    }
}