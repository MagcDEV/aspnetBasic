using System.Net.Http.Json;
using frontAspBasic.Models;

namespace frontAspBasic;

public class GameClient
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;

    public GameClient(IConfiguration configuration)
    {
      _client = new HttpClient();
      _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl")!;
    }
    public async Task<List<Games>> GetAllGames()
    {
      string url = $"{_baseUrl}/games";
      Console.WriteLine(url);
      HttpResponseMessage response = await _client.GetAsync(url);
      response.EnsureSuccessStatusCode();
      List<Games>? games = await response.Content.ReadFromJsonAsync<List<Games>>();
      return games ?? [];
    }

    public async Task<Games?> GetGameById(int id)
    {
      string url = $"{_baseUrl}/games/{id}";
      HttpResponseMessage response = await _client.GetAsync(url);
      response.EnsureSuccessStatusCode();
      Games? game = await response.Content.ReadFromJsonAsync<Games>();
      return game;
    }

    public async Task<Games> UpdateGame(Games game)
    {
        string url = $"{_baseUrl}/games/{game.Id}";
        HttpResponseMessage response = await _client.PutAsJsonAsync(url, game);
        response.EnsureSuccessStatusCode();
        Games? updatedGame = await response.Content.ReadFromJsonAsync<Games>();
        return updatedGame!;
    }

    public async Task DeleteGame(int id)
    {
        string url = $"{_baseUrl}/games/{id}";
        HttpResponseMessage response = await _client.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }
}