using Microsoft.EntityFrameworkCore;
using StudySphere.API.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Povezivanje s bazom podataka
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers(); // Dodajemo podršku za kontrolere (trebat æe nam kasnije)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // OVO JE NOVA LINIJA IZ SWASHBUCKLE PAKETA

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // OVO JE NOVA LINIJA
    app.UseSwaggerUI(); // OVO JE NOVA LINIJA koja kreira UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Govorimo aplikaciji da koristi kontrolere

// --- OVAJ DIO SADA MOŽEMO ZAKOMENTIRATI ILI OBRISATI ---
// Mi æemo endpointove definirati u posebnim datotekama (kontrolerima),
// a ne direktno ovdje.
/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/

app.Run();