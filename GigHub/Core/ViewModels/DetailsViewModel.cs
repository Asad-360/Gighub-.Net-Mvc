using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class DetailsViewModel
    {
        public Gig Gigs { get; set; }
        public bool IsFollowed { get; set; }
        public bool IsAttending { get; set; }
    }
}