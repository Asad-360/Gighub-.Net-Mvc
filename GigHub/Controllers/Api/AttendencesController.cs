using System.Linq;
using System.Web.Http;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
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

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendences = _context.Attendences.Single(a => a.GigId == id && a.AttendeeId == userId);
            if (attendences == null)
            {
                return NotFound();
            }
            _context.Attendences.Remove(attendences);
            _context.SaveChanges();
            return Ok(id);
        }
    }
}
