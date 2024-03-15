using GameStore.Api;
using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("http://localhost:5045") // replace with your client's origin
                           .AllowAnyHeader()
                           .AllowAnyMethod());
});

var connectionString = builder.Configuration.GetConnectionString("GameStoreDb");

builder.Services.AddSqlite<GameStoreContext>(connectionString);

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenreEndpoints();

await app.MigrateDbAsync();

app.UseCors("AllowMyOrigin");

app.Run();
