using frontAspBasic.Models;

namespace frontAspBasic;

public static class GameClient
{
  private static readonly List<Games> games = [
    new Games() {
        Id= 1,
        Name= "Grand Theft Auto V",
        Genre= "Action-adventure",
        Price= 29.99M,
        ReleaseDate= new DateOnly(2013, 9, 17)
      },
      new Games() {
        Id= 2,
        Name= "The Witcher 3 Wild Hunt",
        Genre= "Action RPG",
        Price= 39.99M,
        ReleaseDate= new DateOnly(2015, 5, 18)
      },
      new Games() {
        Id= 3,
        Name= "Red Dead Redemption 2",
        Genre= "Action-adventure",
        Price= 59.99M,
        ReleaseDate= new DateOnly(2018, 10, 26)
      },
      new Games() {
        Id= 4,
        Name= "Horizon Zero Dawn",
        Genre= "Action RPG",
        Price= 19.99M,
        ReleaseDate= new DateOnly(2017, 2, 28)
      },
      new Games() {
        Id= 5,
        Name= "God of War",
        Genre= "Action-adventure",
        Price= 14.99M,
        ReleaseDate= new DateOnly(2018, 4, 20)
      }
    ];

    public static Games[] GetGames() {
        return games.ToArray();
    }
}