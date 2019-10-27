using CinemaClient.Helpers.InternetAvailability;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CinemaClient.Services
{
    public class BaseService
    {
        protected HttpClient client;

        public BaseService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.BackendUrl}/api/filmShows")
            };
        }
    }
}
