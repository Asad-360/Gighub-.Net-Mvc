using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IAttendenceRepository
    {
        Attendence GetAttendence(int gigsId, string userId);
        IEnumerable<Attendence> GetFutureAttendences(string userId);
    }
}