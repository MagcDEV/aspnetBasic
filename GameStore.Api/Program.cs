using GameStore.Api;
using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStoreDb");

builder.Services.AddSqlite<GameStoreContext>(connectionString);

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenreEndpoints();

await app.MigrateDbAsync();

app.Run();
