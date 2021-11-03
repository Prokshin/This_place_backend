using System.Collections.Generic;
using System.Threading.Tasks;
using ThisPlace.Dto;
using ThisPlace.Entities;

namespace ThisPlace.Contracts
{
    public interface IPlaceRepository
    {
        public Task<IEnumerable<Place>> GetPlaces();
        public Task<Place> GetPlaceById(int id);
        public Task<Place> CreatePlace(PlaceForCreationDto newPlace);
    }
}