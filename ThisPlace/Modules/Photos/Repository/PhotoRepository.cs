using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using ThisPlace.Context;
using ThisPlace.Contracts;
using ThisPlace.Entities;

namespace ThisPlace.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DapperContext _context;

        public PhotoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddPhoto(string path, Guid placeId)
        {
            const string query = "INSERT INTO photos (path, placeId) VALUES (@Path, @PlaceId) RETURNING id";

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QueryFirstOrDefaultAsync<Guid>(query, new {path, placeId});
                return id;
            }
        }

        public async Task<IEnumerable<Photo>> GetPhotosByPlaceId(Guid placeId, int limit)
        {
            var query = "SELECT * FROM photos WHERE placeid = @placeId";

            if (limit > 0)
            {
                query += " LIMIT @limit";
            }
            
            using (var connection = _context.CreateConnection())
            {
                var photos = await connection.QueryAsync<Photo>(query, new {placeId, limit});
                return photos;
            }
        }
    }
}