using CinemaClient.Helpers.Comparers;
using CinemaClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CinemaClient.Extensions
{
    public static class UpdateFilmShowsExtensions
    {
        public static void UpdateFilmShows(this ObservableCollection<FilmShow> filmShows, List<FilmShow> newFilmShows)
        {
            AddNewFilmShows(filmShows, newFilmShows);

            RemoveDeletedFilmShows(filmShows, newFilmShows);
        }
        private static void AddNewFilmShows(ObservableCollection<FilmShow> filmShows, List<FilmShow> newFilmShows)
        {
            foreach (var item in newFilmShows)
                if (!filmShows.Contains(item, new FilmShowComparer()))
                    filmShows.Add(item);
        }

        private static void RemoveDeletedFilmShows(ObservableCollection<FilmShow> filmShows, List<FilmShow> newFilmShows)
        {
            foreach (var item in filmShows.ToList())
                if (!newFilmShows.Contains(item, new FilmShowComparer()))
                    filmShows.Remove(item);
        }
    }
}
