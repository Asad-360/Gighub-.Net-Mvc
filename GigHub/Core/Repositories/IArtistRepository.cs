using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Core.Repositories
{
    public interface IArtistRepository
    {
        /// <summary>
        /// Method to get the following Artists
        /// </summary>
        /// <param name="userId">userid of authenticated user</param>
        /// <returns>List of artist</returns>
        IEnumerable<ArtistViewModel> GetArtistFollowing(string userId);
        /// <summary>
        /// Method to get the artist compostions
        /// </summary>
        /// <param name="userId">userid of authenticated user</param>
        /// <returns>List of artist composition</returns>
        IEnumerable<Composition> GetArtistCompositions(string id);
    }
}