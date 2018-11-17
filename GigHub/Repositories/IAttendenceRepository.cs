using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IAttendenceRepository
    {
        Attendence GetAttendence(int gigsId, string userId);
        IEnumerable<Attendence> GetFutureAttendences(string userId);
    }
}