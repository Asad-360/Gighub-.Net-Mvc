using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistController()
        {
             _context = new ApplicationDbContext();
        }

        public ActionResult Following()
        {
            //get the user id
            var userId = User.Identity.GetUserId();
            //select the followings based on the id
            var following = _context.Followings.Where(f => f.FollowerId == userId)
                .Select(g => g.Followee.Name)
                .ToList();

            var viewModel = new ArtistViewModel
            {
                Artists = following
            };
            return View("Artists", viewModel);
        }
    }
}