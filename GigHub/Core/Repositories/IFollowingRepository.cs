using GigHub.Core.Dtos;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        /// <summary>
        /// Method to get the following artist
        /// </summary>
        /// <param name="userId">id of authenticated user</param>
        /// <param name="artistId">id of the artist</param>
        /// <returns>Get the following object</returns>
        Following GetFollowing(string userId, string artistId);
        /// <summary>
        /// Method to follow the artist
        /// </summary>
        /// <param name="userId">user id of the authenticated user</param>
        /// <param name="followingDtos">following dtos object</param>
        /// <returns>bool flag</returns>
        bool Follow(string  userId , FollowingDtos followingDtos);
        /// <summary>
        /// Method to remove the following artist
        /// </summary>
        /// <param name="userId">id of authenticated user</param>
        /// <param name="artistId">id of the artist</param>
        /// <returns>Get the following object</returns>
        Following RemoveFollowings(string userId , string Id);
        /// <summary>
        /// Method to add the following object
        /// </summary>
        /// <param name="following">Following Object</param>
        void Add(Following following);
    }
}