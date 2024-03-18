namespace frontAspBasic.Models;

public class UpdateGameDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Genre { get; init; }
    public decimal Price { get; init; }
    public DateOnly ReleaseDate { get; init; }

    
}