using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        /// <summary>
        /// Method to get upcoming gigs
        /// </summary>
        /// <returns>List of gig</returns>
        IEnumerable<Gig> GetUpcomingGigs();
        /// <summary>
        /// Method to add gig
        /// </summary>
        /// <param name="gig">Gig object</param>
        void Add(Gig gig);
        /// <summary>
        /// Method to get specific gig
        /// </summary>
        /// <param name="gigId">gig id</param>
        /// <returns>Gig Object</returns>
        Gig GetGig(int gigId);
        /// <summary>
        /// Method to cancel the gig
        /// </summary>
        /// <param name="userId">id of authenticated user</param>
        /// <param name="id">id of the gig</param>
        /// <returns></returns>
        Gig CancelGig(string userId, int id);
        /// <summary>
        /// MEthod to get the gig user are attending
        /// </summary>
        /// <param name="userId">id of the authenticated user</param>
        /// <returns>List of Gig</returns>
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        /// <summary>
        /// Method to get gig with attendence
        /// </summary>
        /// <param name="id">id of the gig</param>
        /// <returns>gig</returns>
        Gig GetGigsWithAttendences(int id);
        /// <summary>
        /// Method to get upcoming gig by artist
        /// </summary>
        /// <param name="userId">authenticated user id</param>
        /// <returns>list of gig</returns>
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
    }
}