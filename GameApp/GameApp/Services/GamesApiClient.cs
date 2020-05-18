using GameApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameApp.Services
{
    class GamesApiClient:IGamesApiClient
    {
        private const string ApiUrl = "https://api.rawg.io/api/games?dates=2020-05-08,2020-05-10.";

        private readonly HttpClient httpClient;

        public GamesApiClient()
            {
            httpClient = new HttpClient();
            }
        public async Task<ObservableCollection<Result>> GetGames()
        {
            var json = await httpClient.GetStringAsync($"{ApiUrl}");
            var response = JsonConvert.DeserializeObject<List>(json);
            return response.results;
        }

    }
}
