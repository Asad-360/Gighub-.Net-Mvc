using System.Linq;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public bool Follow(string userId , FollowingDtos followingDtos)
        {
            return _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDtos.FolloweeId);
        }

        public Following GetFollowing(string userId , string artistId)
        {
            return _context.Followings
                .SingleOrDefault(f => (f.FolloweeId == artistId && f.FolloweeId != userId) && (f.FollowerId == userId));
        }

        public Following RemoveFollowings(string userId, string id)
        {
            return  _context.Followings.Single(f => f.FollowerId == userId && f.FolloweeId == id);
        }
    }
}