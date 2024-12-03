using OpenCriticApp.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class OpenCriticService {
    private readonly HttpClient _httpClient;

    public OpenCriticService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<Game>> HallOfFame() {
        try {
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "140877c6c7mshe5c14876df33c62p1e8b31jsn7c2c47c1d0f6");

            var response = await _httpClient.GetAsync("https://opencritic-api.p.rapidapi.com/game/hall-of-fame"); // current OpenCritic hall of fame

            // logging to check if worked
            //var responseData = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseData);

            if (response.IsSuccessStatusCode) {
                return await response.Content.ReadFromJsonAsync<List<Game>>();
            }
            else {
                throw new Exception("ERROR: " + response.StatusCode);
            }
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<SearchResult>> SearchGames(string query) {
        try {
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "140877c6c7mshe5c14876df33c62p1e8b31jsn7c2c47c1d0f6");
            var response = await _httpClient.GetAsync($"https://opencritic-api.p.rapidapi.com/meta/search?criteria={Uri.EscapeDataString(query)}");

            if (response.IsSuccessStatusCode) {
                var results = await response.Content.ReadFromJsonAsync<List<SearchResult>>();
                return results?.Where(r => r.Relation == "game").ToList() ?? new List<SearchResult>();
            }
            else {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public async Task<Game> GetGameDetailsAsync(int gameId) {
        try {
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "140877c6c7mshe5c14876df33c62p1e8b31jsn7c2c47c1d0f6");
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "opencritic-api.p.rapidapi.com");

            var response = await _httpClient.GetAsync($"https://opencritic-api.p.rapidapi.com/game/{gameId}");

            if (response.IsSuccessStatusCode) {
                var gameDetails = await response.Content.ReadFromJsonAsync<Game>();

                return gameDetails;
            }
            else {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}