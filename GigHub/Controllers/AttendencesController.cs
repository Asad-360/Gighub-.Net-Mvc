using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    //// [Authorize]
    public class AttendencesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendencesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend( AttendencesDto attendencesDto)
        {

            var userId = User.Identity.GetUserId();
            if (_context.Attendences.Any(a => a.AttendeeId == userId && a.GigId == attendencesDto.GigId))
            {
                return BadRequest("The attendence already exist");
            }
            var attendence = new Attendence
            {
                GigId = attendencesDto.GigId,
                AttendeeId = User.Identity.GetUserId()
            };
            _context.Attendences.Add(attendence);
            _context.SaveChanges();
            return Ok();
        }
    }
}
