using System.Reflection.Metadata.Ecma335;
using BookingAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<BookingsDb>(opt => opt.UseInMemoryDatabase("Bookings"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapOpenApi();

app.MapGet("/date", () =>
{
    return DateTime.UtcNow;
});

app.MapGet("/bookings", async (BookingsDb db) =>
    await db.Bookings.ToListAsync());

app.MapGet("/bookings/{id}", async (int id, BookingsDb db) =>
    await db.Bookings.FindAsync(id)
        is Booking todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/bookings", async (Booking todo, BookingsDb db) =>
{
    db.Bookings.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/bookings/{todo.Id}", todo);
});

app.MapPut("/bookings/{id}", async (int id, Booking inputTodo, BookingsDb db) =>
{
    var todo = await db.Bookings.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.PlaceName = inputTodo.PlaceName;
    todo.Date = inputTodo.Date;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/bookings/{id}", async (int id, BookingsDb db) =>
{
    if (await db.Bookings.FindAsync(id) is Booking todo)
    {
        db.Bookings.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
