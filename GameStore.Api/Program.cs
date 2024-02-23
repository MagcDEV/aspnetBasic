using GameStore.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
     new ( 1, "Zelda", "Action", 10.0M, new DateOnly(2010, 9, 10)),
     new ( 2, "Pokemon", "Action", 60.0M, new DateOnly(2011, 7, 30)),
     new ( 3, "Dragon ball", "Fights", 50.0M, new DateOnly(2015, 10, 15)),
     new ( 4, "Call of Duty", "FPS", 40.0M, new DateOnly(2019, 8, 20)),
];

app.MapGet("games", () => games);

app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));


app.Run();
