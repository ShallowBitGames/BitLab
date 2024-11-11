using BitLabyrinth;
using BitLabyrinth.Maze;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;

string wd = AppContext.BaseDirectory;
Console.WriteLine(wd);
int index = wd.IndexOf("net-api");
wd = wd.Remove(index);
wd += "njs";
Console.WriteLine(wd);

var processStartInfo = new ProcessStartInfo()
{
    FileName = "cmd",
    RedirectStandardOutput = true,
    RedirectStandardInput = true,
    WorkingDirectory = wd
};

var process = Process.Start(processStartInfo);

if (process == null)
{
    throw new Exception("Process should not be null.");
}

process.StandardInput.WriteLine($"npm run dev &");

//

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/maze/maze", () =>
{
    //string filePath = "./Maze/test-values/simple.txt";
    //Map maze = MazeIO.ReadMap(filePath);
    //string jsonString = JsonSerializer.Serialize(maze);
    //return jsonString;
    return "test";
})
    .WithName("GetMaze")
    .WithOpenApi();

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
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


