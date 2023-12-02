using ImageStoreAPI.Services;
using Minio;

var builder = WebApplication.CreateBuilder(args);

var endpoint = "localhost:9000";
var accessKey = "shLtQJKQi5WC105JegsY";
var secretKey = "elgwdoJ5NJu3PYosfBFQ6vJQkgIBinPV8OkM2D31";

// builder.Services.AddMinio(accessKey, secretKey);
builder.Services.AddMinio(configureClient => configureClient
            .WithEndpoint(endpoint)
            .WithCredentials(accessKey, secretKey).WithSSL(false));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IImageService, ImageService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

