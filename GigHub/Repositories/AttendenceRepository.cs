    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    using GigHub.Models;

namespace GigHub.Repositories
{
    public class AttendenceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendenceRepository(ApplicationDbContext context)
        {
           _context = context; 
        }
        public IEnumerable<Attendence> GetFutureAttendences(string userId)
        {
            return _context
                .Attendences
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendence GetAttendence(int gigsId  , string userId)
        {
           return _context.Attendences.SingleOrDefault( a => a.GigId == gigsId && a.AttendeeId == userId);
        }

    }
}