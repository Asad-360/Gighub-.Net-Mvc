using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Core.Models
{
    public class Composition
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string ArtistId { get; set; }
        public ApplicationUser Artist { get; set; }
    }
}