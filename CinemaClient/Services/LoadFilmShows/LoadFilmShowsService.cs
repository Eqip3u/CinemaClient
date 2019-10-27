using CinemaClient.Helpers.InternetAvailability;
using CinemaClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaClient.Services
{
    public class LoadFilmShowsService : BaseService, ILoadFilmShowsService
    {
        public async Task<List<FilmShow>> GetFilmShows()
        {
            List<FilmShow> result = null;

            var response = await client.GetAsync($"{App.BackendUrl}/api/filmShows");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<FilmShow>>(content);
            }

            return result;
        }
    }
}
