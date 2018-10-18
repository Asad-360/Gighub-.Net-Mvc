using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Following([FromBody] string followingDtos)
        {
            var userId = User.Identity.GetUserId();
            var follow = new Following
            {
                FollowerId = userId,
                ArtistId = followingDtos
            };
            _context.Followings.Add(follow);
            _context.SaveChanges();
            return Ok();
        }
    }

    public class FollowingDtos
    {
        public string ArtistId { get; set; }
    }
}
