using System.Collections.Generic;
using System.Threading.Tasks;
using ThisPlace.Entities;

namespace ThisPlace.Contracts
{
    public interface IPlaceRepository
    {
        public Task<IEnumerable<Place>> GetPlaces();
    }
}