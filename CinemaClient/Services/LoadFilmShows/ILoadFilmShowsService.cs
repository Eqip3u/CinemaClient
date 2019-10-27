using CinemaClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaClient.Services
{
    public interface ILoadFilmShowsService
    {
        Task<List<FilmShow>> GetFilmShows();
    }
}
