using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using GigHub.Core;

namespace GigHub.Controllers.Api
{
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Action Method to delete the Gig
        /// </summary>
        /// <param name="id">Id of the gig</param>
        /// <returns>Http status</returns>
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.CancelGig(userId, id);
            // if the cancel is reloded with second time

            if (gig.IsCanceled)
            {
                return NotFound();
            }

            gig.Cancel();
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
