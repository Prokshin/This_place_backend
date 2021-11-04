using System.Collections.Generic;
using ThisPlace.Entities;

namespace ThisPlace.Dto
{
    public class PlaceForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
    }
}