using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ThisPlace.Context;
using ThisPlace.Contracts;
using ThisPlace.Dto;
using ThisPlace.Entities;

namespace ThisPlace.Repository
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
            const string query = "SELECT * FROM \"Places\"";
            using (var connection = _context.CreateConnection())
            {
                var places = await connection.QueryAsync<Place>(query);
                return places.ToList();
            }
        }

        public async Task<Place> GetPlaceById(int id)
        {
            const string query = "SELECT * FROM \"Places\" WHERE \"Id\" = @Id";

            using (var connection = _context.CreateConnection())
            {
                var place = await connection.QuerySingleOrDefaultAsync<Place>(query, new {id});
                return place;
            }
        }

        public async Task<Place> CreatePlace(PlaceForCreationDto newPlace)
        {
            const string query = "INSERT INTO \"Places\" (\"Title\", \"Description\") VALUES (@Title, @Description) RETURNING \"Id\"";

            var parameters = new DynamicParameters();
            parameters.Add("Title", newPlace.Title, DbType.String);
            parameters.Add("Description", newPlace.Description, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QueryFirstAsync<int>(query, parameters);
                

                var createdPlace = new Place()
                {
                    Id = id,
                    Title = newPlace.Title,
                    Description = newPlace.Description
                };
                return createdPlace;
            }
        }
    }
}