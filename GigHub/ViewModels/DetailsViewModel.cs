using GigHub.Models;

namespace GigHub.ViewModels
{
    public class DetailsViewModel
    {
        public Gig Gigs { get; set; }
        public bool IsFollowed { get; set; }
        public bool IsAttending { get; set; }
    }
}