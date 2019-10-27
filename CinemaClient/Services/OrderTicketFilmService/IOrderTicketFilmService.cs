using CinemaClient.Models;
using System.Threading.Tasks;

namespace CinemaClient.Services
{
    public interface IOrderTicketFilmService
    {
        Task<bool> PostOrderTicket(OrderTicket orderTicket);
    }
}
