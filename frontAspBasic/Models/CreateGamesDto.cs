using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frontAspBasic.Models;

public class CreateGamesDto
{
    public required string Name { get; set; }
    public required int GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    
}