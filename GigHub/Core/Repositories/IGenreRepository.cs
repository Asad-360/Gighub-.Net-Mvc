using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGenreRepository
    {
        /// <summary>
        /// Method to get Genres
        /// </summary>
        /// <returns>List of Genre</returns>
        IEnumerable<Genre> GetGenres();
    }
}