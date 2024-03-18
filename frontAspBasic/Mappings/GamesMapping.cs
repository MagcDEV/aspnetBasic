using frontAspBasic.Models;

namespace frontAspBasic.Mappings
{
    public static class GamesMapping
    {
        public static CreateGamesDto ToDto(this Games game)
        {
            return new CreateGamesDto()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }
        
    }
}