using frontAspBasic.Models;

namespace frontAspBasic.Mappings
{
    public static class GamesMapping
    {
        public static GamesDto ToDto(this Games game)
        {
            return new GamesDto()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }
        
    }
}