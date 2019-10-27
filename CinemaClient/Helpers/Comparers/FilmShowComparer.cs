using CinemaClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaClient.Helpers.Comparers
{
    public class FilmShowComparer : IEqualityComparer<FilmShow>
    {
        public bool Equals(FilmShow x, FilmShow y)
        {

            if (Object.ReferenceEquals(x, y)) return true;

            if (x is null || y is null)
                return false;

            return x.Name == y.Name && x.FilmStartTime == y.FilmStartTime;
        }

        public int GetHashCode(FilmShow filmShow)
        {
            if (filmShow is null) return 0;

            int hashfilmShowName = filmShow.Name == null ? 0 : filmShow.Name.GetHashCode();

            int hashfilmShowFilmStartTime = filmShow.FilmStartTime.GetHashCode();

            return hashfilmShowName ^ hashfilmShowFilmStartTime;
        }
    }
}
