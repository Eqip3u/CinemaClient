using CinemaClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaClient.Services
{
    public class OrderTicketFilmService : BaseService, IOrderTicketFilmService
    {
        public async Task<bool> PostOrderTicket(OrderTicket orderTicket)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(orderTicket), Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync($"{App.BackendUrl}/api/filmshoworder", httpContent);

            return responseMessage.IsSuccessStatusCode;
        }
    }
}
