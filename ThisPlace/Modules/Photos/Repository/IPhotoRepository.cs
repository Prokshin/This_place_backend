using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThisPlace.Entities;

namespace ThisPlace.Contracts
{
    public interface IPhotoRepository
    {
        public Task<Guid> AddPhoto(string path, Guid placeId);
        public Task<IEnumerable<Photo>> GetPhotosByPlaceId(Guid placeId, int limit);
    }
}