using Newtonsoft.Json;
using System;

namespace CinemaClient.Models
{
    public class OrderTicket
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("countTicket")]
        public int CountTicket { get; set; }

        [JsonProperty("orderTime")]
        public DateTime OrderTime { get; set; }
    }
}
