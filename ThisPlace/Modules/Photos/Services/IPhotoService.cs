using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThisPlace.Entities;

namespace ThisPlace.Services
{
    public interface IPhotoService
    {
        public Task<Guid> AddImage(string path, string id);
        public Task<IEnumerable<Photo>> GetPhotosByPlaceId(string id);
    }
}