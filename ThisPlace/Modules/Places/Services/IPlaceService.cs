using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThisPlace.Dto;
using ThisPlace.Entities;
using ThisPlace.Modules.Places.Dto;
using ThisPlace.Modules.Places.Entities;

namespace ThisPlace.Modules.Places.Services
{
    public interface IPlaceService
    {
        public Task<IEnumerable<Place>> GetPlaces();
        public Task<Place> GetPlaceById(Guid id);
        public Task<Place> CreatePlace(PlaceForCreationDto newPlace);
    }
}