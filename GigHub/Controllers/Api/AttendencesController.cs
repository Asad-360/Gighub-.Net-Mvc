using System.Linq;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    //// [Authorize]
    public class AttendencesController : ApiController
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public AttendencesController(IUnitOfWork unitOfWork)
        {           
            this._unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Method for Attending the GIg. Gig Going Options
        /// </summary>
        /// <param name="attendencesDto">Attendence DetailsS</param>
        /// <returns>Http Status</returns>
        [HttpPost]
        public IHttpActionResult Attend( AttendencesDto attendencesDto)
        {

            var userId = User.Identity.GetUserId();
            if (_unitOfWork.Attendence.Attend(userId , attendencesDto))
            {
                return BadRequest("The attendence already exist");
            }
            var attendence = new Attendence
            {
                GigId = attendencesDto.GigId,
                AttendeeId = User.Identity.GetUserId()
            };
            _unitOfWork.Attendence.Add(attendence);
            _unitOfWork.Complete();
            return Ok();
        }
        /// <summary>
        /// Method for Removing the attending the GIg. Gig Un-Going Options
        /// </summary>
        /// <param name="attendencesDto">Id of gig</param>
        /// <returns>Http Status</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendences = _unitOfWork.Attendence.Remove(userId , id);
            if (!attendences)
            {
                return NotFound();
            }
            _unitOfWork.Complete();
            return Ok(id);
        }
    }
}
