using GameStore.Api.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (GameStoreContext gameStoreContext) =>
        {
            return await gameStoreContext.Genres
                .Select(genre => genre.ToDto())
                .AsNoTracking()
                .ToListAsync();
        });
        return group;

    }

}
