using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        // Who is making the gig
        public ApplicationUser Artist { get; set; }


        [Required]
        public string ArtistId { get; set; }

        //When the gig is made
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(250)]
        //Where the gig is hapenning
        public string Venue { get; set; }
        //What genre it is
        public Genre Genre { get; set; }


        [Required]
        public byte GenreId { get; set; }

    }
}