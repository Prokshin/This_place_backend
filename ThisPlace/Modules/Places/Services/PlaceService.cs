using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThisPlace.Contracts;
using ThisPlace.Dto;
using ThisPlace.Entities;
using ThisPlace.Modules.Places.Dto;
using ThisPlace.Modules.Places.Entities;
using ThisPlace.Modules.Places.Repository;

namespace ThisPlace.Modules.Places.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPhotoRepository _photoRepository;

        public PlaceService(IPlaceRepository placeRepository, IPhotoRepository photoRepository)
        {
            _placeRepository = placeRepository;
            _photoRepository = photoRepository;
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            var places = await _placeRepository.GetPlaces();
            
            foreach (var place in places)
            {
                var photos = await _photoRepository.GetPhotosByPlaceId(place.Id, 2);
                place.Photos = photos;
            }
            
            return places;
        }

        public async Task<Place> GetPlaceById(Guid id)
        {
            var place = await _placeRepository.GetPlaceById(id);
            var photos = await _photoRepository.GetPhotosByPlaceId(id, -1);
            place.Photos = photos;
            return place;
        }

        public Task<Place> CreatePlace(PlaceForCreationDto newPlace)
        {
            return _placeRepository.CreatePlace(newPlace);
        }
    }
}