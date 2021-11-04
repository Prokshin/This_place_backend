using System;
using System.Collections.Generic;

namespace ThisPlace.Entities
{
    public class Place
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public IEnumerable<Photo> Photos { get; set; } = new List<Photo>();
    }
}