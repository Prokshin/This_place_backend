using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThisPlace.Contracts;
using ThisPlace.Dto;

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
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPlaceById(int id)
        {
            try
            {
                var place = await _placeRepository.GetPlaceById(id);
                if (place == null)
                {
                    return NotFound();
                }
                return Ok(place);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlace(PlaceForCreationDto newPlace)
        {
            try
            {
                var createdPlace = await _placeRepository.CreatePlace(newPlace);
                return Ok(createdPlace);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}