using System;

namespace GigHub.Core.Dtos
{
    public class GigDto
    {
        public bool IsCanceled { get; set; }

        public int Id { get; set; }

        // Who is making the gig
        public UserDto Artist { get; set; }



        //When the gig is made
        public DateTime DateTime { get; set; }
        //Where the gig is hapenning
        public string Venue { get; set; }
        //What genre it is
        public GenreDto Genre { get; set; }



    }
}