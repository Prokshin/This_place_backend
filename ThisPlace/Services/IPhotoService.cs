using System;
using System.Threading.Tasks;

namespace ThisPlace.Services
{
    public interface IPhotoService
    {
        public Task<Guid> AddImage(string path, string id);
    }
}