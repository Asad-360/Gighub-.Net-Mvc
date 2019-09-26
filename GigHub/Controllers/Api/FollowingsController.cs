using System.Linq;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
namespace GigHub.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public FollowingsController(IUnitOfWork unitOfWork)
        {            
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action Method to follow Artist
        /// </summary>
        /// <param name="followingDtos">Following data</param>
        /// <returns> Http Response Bad / Ok</returns>
        [HttpPost]
        public IHttpActionResult Follow(FollowingDtos followingDtos)
        {
            var userId = User.Identity.GetUserId();
            if (_unitOfWork.Following.Follow(userId, followingDtos))
            {
                return BadRequest("Already Followed");
            }
            var follow = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDtos.FolloweeId
            };
            _unitOfWork.Following.Add(follow);
            _unitOfWork.Complete();
            return Ok();
        }
        /// <summary>
        /// Action Method to unfollow Artist
        /// </summary>
        /// <param name="followingDtos">id of artist</param>
        /// <returns> Http Response Bad / Ok</returns>
        [HttpDelete]
        public IHttpActionResult RemoveFollowings(string id)
        {
            var userId = User.Identity.GetUserId();

            var follower = _unitOfWork.Following.RemoveFollowings(userId, id);

            _unitOfWork.Complete();
            return Ok(id);
        }


    }
}
