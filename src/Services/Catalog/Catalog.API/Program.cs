using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

//Add Services to the Container

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Logging.AddConsole();


// Build the app
var app = builder.Build();

// Configure the HTTP Request pipeline
app.MapCarter();


app.Run();
