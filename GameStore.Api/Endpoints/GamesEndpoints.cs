using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    private static readonly List<GameDto> games = [
     new ( 1, "Zelda", "Action", 10.0M, new DateOnly(2010, 9, 10)),
     new ( 2, "Pokemon", "Action", 60.0M, new DateOnly(2011, 7, 30)),
     new ( 3, "Dragon ball", "Fights", 50.0M, new DateOnly(2015, 10, 15)),
     new ( 4, "Call of Duty", "FPS", 40.0M, new DateOnly(2019, 8, 20)),
];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app) {

        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) => {

            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);

            });

        group.MapPost("/", (CreateGameDto game) => {
            GameDto newGame = new (
                games.Count + 1, 
                game.Name, 
                game.Genre, 
                game.Price, 
                game.ReleaseDate
                );

            games.Add(newGame);

            return Results.Created($"/games/{newGame.Id}", newGame);
        });

        group.MapPut("/{id}", (int id, UpdateGameDto game) => {

            var index = games.FindIndex(g => g.Id == id);

            if (index == -1) return Results.NotFound();

            games[index] = new GameDto(
                id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) => {
            games.RemoveAll(g => g.Id == id);
            return Results.NoContent();
        });

        return group;
    }
}

