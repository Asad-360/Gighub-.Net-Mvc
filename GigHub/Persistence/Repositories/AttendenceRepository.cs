using System;
using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class AttendenceRepository : IAttendenceRepository
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