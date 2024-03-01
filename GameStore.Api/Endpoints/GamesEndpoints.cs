using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

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

        group.MapGet("/", (GameStoreContext gameStoreContext) => {
            return gameStoreContext.Games.Find();
        });

        group.MapGet("/{id}", (int id) => {

            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);

            });

        group.MapPost("/", (CreateGameDto newGame, GameStoreContext gameStoreContext) => {
            Game game = new() {
                Name = newGame.Name,
                Genre = gameStoreContext.Genres.Find(newGame.GenreId),
                GenreId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate,
            };

            gameStoreContext.Games.Add(game);
            gameStoreContext.SaveChanges();

            GameDto gameDto = new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.ReleaseDate
            );

            return Results.Created($"/games/{game.Id}", gameDto);

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

