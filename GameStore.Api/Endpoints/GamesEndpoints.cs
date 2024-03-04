using GameStore.Api.Data;
using GameStore.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext gameStoreContext) =>
        {
            return await gameStoreContext.Games
                .Select(game => game.ToDetailsDto())
                .AsNoTracking()
                .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, GameStoreContext gameStoreContext) =>
        {

            var gameToFind = await gameStoreContext.Games.FindAsync(id);
            if (gameToFind is null)
            {
                return Results.NotFound();
            }

            gameToFind.Genre = await gameStoreContext.Genres.FindAsync(gameToFind.GenreId);

            var gameToFindDto = gameToFind?.ToDto();

            return gameToFind is null ? Results.NotFound() : Results.Ok(gameToFindDto);

        });

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext gameStoreContext) =>
        {
            var game = newGame.ToEntity();
            game.Genre = await gameStoreContext.Genres.FindAsync(game.GenreId);

            await gameStoreContext.Games.AddAsync(game);
            await gameStoreContext.SaveChangesAsync();

            var gameDto = game.ToDto();

            return Results.Created($"/games/{game.Id}", gameDto);

        });

        group.MapPut("/{id}", async (int id, UpdateGameDto game, GameStoreContext gameStoreContext) =>
        {

            var gameToUpdate = await gameStoreContext.Games.FindAsync(id);

            if (gameToUpdate is null) return Results.NotFound();

            gameToUpdate.Name = game.Name;
            gameToUpdate.Genre = await gameStoreContext.Genres.FindAsync(game.GenreId);
            gameToUpdate.Price = game.Price;
            gameToUpdate.ReleaseDate = game.ReleaseDate;

            gameStoreContext.Games.Update(gameToUpdate);
            await gameStoreContext.SaveChangesAsync();

            var gameDto = gameToUpdate.ToDto();

            return Results.Ok(gameDto);

        });


        group.MapDelete("/{id}", async (int id, GameStoreContext gameStoreContext) =>
        {

            await gameStoreContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}

