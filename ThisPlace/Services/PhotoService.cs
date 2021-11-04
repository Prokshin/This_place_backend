using System;
using System.Threading.Tasks;
using ThisPlace.Contracts;

namespace ThisPlace.Services
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
    }
}