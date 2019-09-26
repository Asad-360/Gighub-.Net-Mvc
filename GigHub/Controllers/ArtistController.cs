using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Action Method to Get the following Artists
        /// </summary>
        /// <returns>View Result Of Artists</returns>
        public ActionResult Following()
        {
            //get the user id
            var userId = User.Identity.GetUserId();
            //select the followings based on the id
            var following = _unitOfWork.Artist.GetArtistFollowing(userId);            
            return View("Artists", following);
        }
        /// <summary>
        /// Action Method to Get the composition of Artists
        /// </summary>
        /// <returns>View Result Of Compositions</returns>
        public ActionResult GetCompositions(string id)
        {
            //  var userId = User.Identity.GetUserId();
            var compositions = _unitOfWork.Artist.GetArtistCompositions(id);
            return View(compositions);
        }
    }
}