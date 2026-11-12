using CampusAIS.Gateway.Booking;
using CampusAIS.Shared.Contracts;

namespace CampusAIS.Gateway.Tests;

public class BookingTests
{
    [Fact]
    public void Validate_InvalidTime_ReturnsFalse()
    {
        var validator = new RoomBookingValidator();
        var request = new RoomBookingRequest(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddHours(-1), "Лекция");
        Assert.False(validator.Validate(request));
    }
}