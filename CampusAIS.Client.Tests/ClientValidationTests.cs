using CampusAIS.Client.Core.BusinessLogic;
using CampusAIS.Shared.Contracts;

namespace CampusAIS.Client.Tests;

public class ClientValidationTests
{
    [Fact]
    public void Validate_EndTimeBeforeStart_ReturnsFalse()
    {
        // Arrange
        var validator = new BookingRequestValidator();
        var request = new RoomBookingRequest(
            Guid.NewGuid(),
            DateTime.Now.AddHours(2), // Начало позже
            DateTime.Now.AddHours(1), // Окончания раньше
            "Лекция");

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Validate_CorrectTime_ReturnsTrue()
    {
        // Arrange
        var validator = new BookingRequestValidator();
        var request = new RoomBookingRequest(
            Guid.NewGuid(),
            DateTime.Now,
            DateTime.Now.AddHours(1),
            "Лекция");

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result);
    }
}