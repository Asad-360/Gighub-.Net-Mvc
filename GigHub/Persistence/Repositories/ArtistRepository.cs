using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private ApplicationDbContext _context;

        public ArtistRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Method to get the following Artists
        /// </summary>
        /// <param name="userId">userid of authenticated user</param>
        /// <returns>List of artist</returns>
        public IEnumerable<Composition> GetArtistCompositions(string id)
        {
            return _context.Compositions.Where(c => c.ArtistId == id).ToList();
        }
        /// <summary>
        /// Method to get the artist compostions
        /// </summary>
        /// <param name="userId">userid of authenticated user</param>
        /// <returns>List of artist composition</returns>
        public IEnumerable<ArtistViewModel> GetArtistFollowing(string userId)
        {
            return _context.Followings.Where(f => f.FollowerId == userId)
                .Select(g => new ArtistViewModel
                {
                    ArtistName = g.Followee.Name,
                    ArtistId = g.Followee.Id
                })
                .ToList();
        }
    }
}