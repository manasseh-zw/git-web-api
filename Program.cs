var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet(
        "hello",
        () =>
        {
            return Results.Ok(new { message = "Hello!" });
        }
    )
    .WithName("hello");

app.MapGet(
        "date-now",
        () =>
        {
            return Results.Ok(DateTime.UtcNow);
        }
    )
    .WithName("date");

app.MapGet(
        "random",
        () =>
        {
            return Results.Ok(new Random().Next(1000, 9999));
        }
    )
    .WithName("random");

app.Run();
