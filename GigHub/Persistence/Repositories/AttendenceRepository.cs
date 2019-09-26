using System;
using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Dtos;
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

        public bool Attend(string userId, AttendencesDto attendencesDto)
        {
            return _context.Attendences.Any(a => a.AttendeeId == userId && a.GigId == attendencesDto.GigId);
        }

        public bool Remove(string userId, int id)
        {
           var x = _context.Attendences.Single(a => a.GigId == id && a.AttendeeId == userId);
            if (x == null)
            {
                return false;
            }
            return true;
        }

        public void Add(Attendence attendence)
        {
            _context.Attendences.Add(attendence);
        }
    }
}