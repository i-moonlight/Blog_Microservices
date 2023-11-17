
using ContentAPI.Services;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();
Log.Information("Hello, {Name}!", Environment.UserName);


builder.Services.AddLogging(loggingBuilder =>
   {
       loggingBuilder.AddSeq();
   });


builder.Services.AddSingleton(sp => new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest"
});

builder.Services.AddHostedService<LogBackgroundService>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
