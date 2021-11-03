using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThisPlace.Contracts;

namespace ThisPlace.Controllers
{
    [Route("api/places")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepository;

        public PlacesController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces()
        {
            try
            {
                var places = await _placeRepository.GetPlaces();
                return Ok(places);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}