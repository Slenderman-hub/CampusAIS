using CampusAIS.Gateway.Booking;
using CampusAIS.Gateway.Sync;
using CampusAIS.Shared.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Регистрация зависимостей (Dependency Injection)
builder.Services.AddSingleton<IBookingService, BookingService>();
builder.Services.AddSingleton<IScheduleSyncService, ScheduleSyncService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Эндпоинт GET /schedule
app.MapGet("/schedule", () =>
{
    var lessons = new List<LessonDto>
    {
        new(Guid.NewGuid(), "Математика", "Иванов И.И.", "Ауд. 101", DateTime.Today.AddHours(9), DateTime.Today.AddHours(10.5)),
        new(Guid.NewGuid(), "Программирование", "Петров П.П.", "Ауд. 202", DateTime.Today.AddHours(11), DateTime.Today.AddHours(12.5))
    };
    return Results.Ok(new ScheduleGridDto(lessons));
});

// Эндпоинт POST /rooms/book
app.MapPost("/rooms/book", async (RoomBookingRequest request, IBookingService bookingService) =>
{
    var result = await bookingService.BookRoomAsync(request);
    return result.Success ? Results.Ok(result) : Results.BadRequest(result);
});

app.Run();