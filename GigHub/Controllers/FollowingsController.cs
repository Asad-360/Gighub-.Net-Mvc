using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
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
            if (_context.Followings.Any(f=>f.FolloweeId == userId  && f.FollowerId == followingDtos.FolloweeId))
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

       
    }
}
