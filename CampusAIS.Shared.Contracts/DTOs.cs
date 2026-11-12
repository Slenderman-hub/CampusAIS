namespace CampusAIS.Shared.Contracts;

public record LessonDto(Guid Id, string Subject, string Teacher, string Room, DateTime Start, DateTime End);
public record ScheduleGridDto(IEnumerable<LessonDto> Lessons);
public record RoomBookingRequest(Guid RoomId, DateTime Start, DateTime End, string Purpose);
public record RoomBookingResponse(Guid BookingId, bool Success, string? Message);