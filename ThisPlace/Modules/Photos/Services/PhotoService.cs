using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThisPlace.Contracts;
using ThisPlace.Entities;
using ThisPlace.Services;

namespace ThisPlace.Modules.Photos.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        
        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public Task<Guid> AddImage(string path, string id)
        {
            return _photoRepository.AddPhoto(path, new Guid(id));
        }

        public Task<IEnumerable<Photo>> GetPhotosByPlaceId(string id)
        {
            return _photoRepository.GetPhotosByPlaceId(new Guid(id), -1);
        }
    }
}