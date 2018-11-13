using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private  set; }

        // the client of the object can not modify these properties
        public DateTime? OrignalDateTime { get; private set; }
        public string OrignalValue { get;private set; }


        [Required]
        public Gig Gig { get; set; }

        protected Notification()
        {
            // for the entity framework
        }

        private Notification(Gig gig , NotificationType notificationType)
        {
            if (gig == null)
            {
                throw new ArgumentNullException("gig");
            }

            DateTime = DateTime.Now;
            Gig = gig;
            Type = notificationType;
        }


        // FACTORY METHODS
        public static Notification GigsCreated(Gig gig)
        {
            return new Notification(gig , NotificationType.GigCreated);
        }


        // in future for change
        // the paremeters will be
        // oldGig, newGig
        public static Notification GigsUdated(Gig newGig , DateTime orignalDateTime ,string orignalVenue)
        {

            var notification = new Notification(newGig , NotificationType.GigUpdated);
            notification.OrignalDateTime = orignalDateTime;
            notification.OrignalValue = orignalVenue;
            return notification;
        }


        public static Notification GigsCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }


     
    }
}
