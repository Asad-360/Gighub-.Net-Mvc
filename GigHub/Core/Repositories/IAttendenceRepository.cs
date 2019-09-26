using System.Collections.Generic;
using GigHub.Core.Dtos;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IAttendenceRepository
    {
        /// <summary>
        /// Method to Get the the Attending Status
        /// </summary>
        /// <param name="gigsId">gig id</param>
        /// <param name="userId">id of authenticated user</param>
        /// <returns>Attendence Object</returns>
        Attendence GetAttendence(int gigsId, string userId);
        /// <summary>
        /// Method to get Future Attending Status of Gig
        /// </summary>
        /// <param name="userId">Id of Authenticated user</param>
        /// <returns>List of Attendence</returns>
        IEnumerable<Attendence> GetFutureAttendences(string userId);
        /// <summary>
        /// Method to check the gig is attending
        /// </summary>
        /// <param name="userId">autehticated user id</param>
        /// <param name="attendencesDto">attendence dto object</param>
        /// <returns>boolean flag</returns>
        bool Attend(string userId , AttendencesDto attendencesDto);
        /// <summary>
        /// Method to remove the gig
        /// </summary>
        /// <param name="userId">autehticated user id</param>
        /// <param name="attendencesDto">id of gig</param>
        /// <returns>boolean flag</returns>
        bool Remove(string userId , int id);
        /// <summary>
        /// Method to add the gig
        /// </summary>
        /// <param name="userId">autehticated user id</param>
        /// <param name="attendencesDto">attendence dto object</param>        
        void Add(Attendence attendence);
    }
}