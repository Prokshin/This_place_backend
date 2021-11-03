using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ThisPlace.Context;
using ThisPlace.Contracts;
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
    }
}