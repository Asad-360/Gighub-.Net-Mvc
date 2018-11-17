using System.Linq;
using System.Web.Http;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{


    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }



        [HttpPost]
        public IHttpActionResult Follow(FollowingDtos followingDtos)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(f=>f.FollowerId == userId  && f.FolloweeId == followingDtos.FolloweeId))
            {
                return BadRequest("Already Followed");
            }
            var follow = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDtos.FolloweeId
            };
            _context.Followings.Add(follow);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveFollowings(string id)
        {
            var userId = User.Identity.GetUserId();
            
            var follower = _context.Followings.Single(f=>f.FollowerId == userId && f.FolloweeId ==id);
            _context.Followings.Remove(follower);
            _context.SaveChanges();
            return Ok(id);
        }


    }
}
