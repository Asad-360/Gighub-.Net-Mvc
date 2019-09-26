using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class CompositionRepository : ICompositionRepository
    {
        private ApplicationDbContext _context;

        public CompositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Composition compostion)
        {
            _context.Compositions.Add(compostion);
        }

        public List<Composition> GetAllComposition(string userId)
        {
            return _context.Compositions.Where(c => c.ArtistId == userId).ToList();
        }
    }
}