using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {   
        

        //for logical delete
        public bool IsCanceled { get; private set; }

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

        public ICollection<Attendence> Attendences { get;private set; }

        public Gig()
        {
            Attendences = new Collection<Attendence>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigsCanceled(this);

            foreach (var attendee in Attendences.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }



        public void Modify(DateTime dateTime , string venue , byte genre)
        {
            var notification = Notification.GigsUdated(this , dateTime , venue);
            // taking the orignal value from the object 
            // before assigining the new values to the 
            // object from method args
            // Note: Design Smell
            // W're not using this pattern here , the programmer might forgot the 
            // two lines below and the result will be null state, so to 
            // solve these issues we use factory methods.
            /*
            notification.OrignalDateTime = DateTime;
            notification.OrignalValue = Venue;
            */


            // assigning the new values
            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in Attendences.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}