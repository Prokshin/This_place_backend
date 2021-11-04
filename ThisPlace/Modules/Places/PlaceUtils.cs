using System;
using System.Data;
using Dapper;
using ThisPlace.Dto;
using ThisPlace.Entities;
using ThisPlace.Modules.Places.Dto;
using ThisPlace.Modules.Places.Entities;

namespace ThisPlace.Modules.Places
{
    public class PlaceUtils
    {
        public static DynamicParameters GeneratePlaceCreateParameters(PlaceForCreationDto newPlace)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Title", newPlace.Title, DbType.String);
            parameters.Add("Description", newPlace.Description, DbType.String);
            parameters.Add("Longitude", newPlace.Longitude, DbType.Decimal);
            parameters.Add("Latitude", newPlace.Latitude, DbType.Decimal);

            return parameters;
        }

        public static Place GenerateCreatedPlace(Guid id, PlaceForCreationDto newPlace)
        {
            return new Place()
            {
                Id = id,
                Title = newPlace.Title,
                Description = newPlace.Description,
                Latitude = newPlace.Latitude,
                Longitude = newPlace.Longitude
            };
        }
    }
}