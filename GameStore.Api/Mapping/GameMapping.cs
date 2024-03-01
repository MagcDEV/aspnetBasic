using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace GameStore.Api;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game) 
    {
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };

    }

    public static GameDto ToDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }

}
