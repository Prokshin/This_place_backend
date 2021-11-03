using System.Collections.Generic;

namespace ThisPlace.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<Photo> Photos { get; set; } = new List<Photo>();
    }
}