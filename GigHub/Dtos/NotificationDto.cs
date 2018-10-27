﻿using System;
using System.ComponentModel.DataAnnotations;
using GigHub.Models;

namespace GigHub.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }

        // the client of the object can not modify these properties
        public DateTime? OrignalDateTime { get;  set; }
        public string OrignalVenue { get; set; }
        public GigDto Gig { get; set; }
    }
}