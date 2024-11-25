using OpenCriticApp.Models;
using System.Net.Http.Json;

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
    }

