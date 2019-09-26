using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class GigsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action method to create new Gig
        /// </summary>
        /// <returns>Gig form View Model</returns>
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _unitOfWork.Genre.GetGenres(),
                Heading = "Add A Gig"
            };
            return View("GigForm", viewModel);
        }

        /// <summary>
        /// Action method to create new Gig from GigformviewModel
        /// </summary>
        /// <returns>Redirect to Mine Page of Gig</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genre.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDatetime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _unitOfWork.Gigs.Add(gig);
            _unitOfWork.Complete();
            return RedirectToAction("Mine", "Gigs");
        }

        /// <summary>
        /// Action method to Update new Gig from GigformviewModel
        /// </summary>
        /// <returns>Redirect to Mine Page of Gig</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genre.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = _unitOfWork.Gigs.GetGigsWithAttendences(viewModel.Id);

            if (gig == null)
            {
                return HttpNotFound();
            }

            if (gig.ArtistId != User.Identity.GetUserId())
            {
                return new HttpUnauthorizedResult();
            }

            gig.DateTime = viewModel.GetDatetime();
            gig.Venue = viewModel.Venue;
            gig.GenreId = viewModel.Genre;

            gig.Modify(viewModel.GetDatetime(), viewModel.Venue, viewModel.Genre);

            _unitOfWork.Complete();
            return RedirectToAction("Mine", "Gigs");
        }
        /// <summary>
        /// Action method to Edit new Gig 
        /// </summary>
        /// <returns>Redirect to GigForm of Gig</returns>
        [Authorize]
        public ActionResult Edit(int id)
        {
            var gig = _unitOfWork.Gigs.GetGig(id);

            if (gig == null)
            {
                return HttpNotFound();
            }

            if (gig.ArtistId != User.Identity.GetUserId())
            {
                return new HttpUnauthorizedResult();
            }

            var viewModel = new GigFormViewModel
            {
                Id = gig.Id,
                Heading = "Edit A Gig",
                Genres = new ApplicationDbContext().Genres.ToList(),
                Time = gig.DateTime.ToString("HH:mm"),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Genre = gig.GenreId,
                Venue = gig.Venue
            };

            return View("GigForm", viewModel);
        }
        /// <summary>
        /// Method for attending the gig
        /// </summary>
        /// <returns>Gig View</returns>
        [Authorize]
        public ActionResult Attending()
        {
            // get the user id
            var userId = User.Identity.GetUserId();

            var viewModel = new GigsViewModel
            {
                ShowActions = User.Identity.IsAuthenticated,
                UpcomingGigs = _unitOfWork.Gigs.GetGigsUserAttending(userId),
                Heading = "Gigs I'm Attending",
                Attendences = _unitOfWork.Attendence.GetFutureAttendences(userId).ToLookup(a => a.GigId)
            };
            return View("Gigs", viewModel);
        }

        /// <summary>
        /// Method of GetUpcomingGigs by Artist
        /// </summary>
        /// <returns>Mine View</returns>
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _unitOfWork.Gigs.GetUpcomingGigsByArtist(userId);
            return View(gigs);
        }

        [HttpPost]
        public ActionResult Search(GigsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new {query = viewModel.SearchTerm});
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            var gigs = _unitOfWork.Gigs.GetGig(id);

            if (gigs == null)
            {
                return HttpNotFound();
            }

            // we check if we are following the artist
            var isFollowing = _unitOfWork.Following.GetFollowing(userId, gigs.ArtistId) != null;
            var isAttending = _unitOfWork.Attendence.GetAttendence(gigs.Id, userId) != null;
            // check can be here for authenticating
            var detail = new DetailsViewModel
            {
                Gigs = gigs,
                IsFollowed = isFollowing,
                IsAttending = isAttending
            };
            return View(detail);
        }
    }
}