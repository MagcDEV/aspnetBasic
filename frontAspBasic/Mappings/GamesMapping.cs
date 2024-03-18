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

        public static CreateGamesDto ToUpdateDto(this UpdateGameDto game, int id)
        {
            return new CreateGamesDto()
            {
                Name = game.Name,
                GenreId = id,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }


        
    }
}