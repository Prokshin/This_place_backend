using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ThisPlace.Context;
using ThisPlace.Dto;
using ThisPlace.Entities;
using ThisPlace.Modules.Places.Dto;
using ThisPlace.Modules.Places.Entities;

namespace ThisPlace.Modules.Places.Repository
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly DapperContext _context;

        public PlaceRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            const string query = "SELECT * FROM places";
            using (var connection = _context.CreateConnection())
            {
                var places = await connection.QueryAsync<Place>(query);
                return places.ToList();
            }
        }

        public async Task<Place> GetPlaceById(Guid id)
        {
            const string query = "SELECT * FROM places WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var place = await connection.QuerySingleOrDefaultAsync<Place>(query, new {id});
                
                return place;
            }
        }

        public async Task<Place> CreatePlace(PlaceForCreationDto newPlace)
        {
            const string query = "INSERT INTO places (title, description, longitude, latitude) VALUES (@Title, @Description, @Longitude, @Latitude) RETURNING id";

            var parameters = PlaceUtils.GeneratePlaceCreateParameters(newPlace);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QueryFirstAsync<Guid>(query, parameters);
                return PlaceUtils.GenerateCreatedPlace(id, newPlace);
            }
        }
    }
}