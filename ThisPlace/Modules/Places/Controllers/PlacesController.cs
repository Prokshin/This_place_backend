using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThisPlace.Dto;
using ThisPlace.Modules.Places.Dto;
using ThisPlace.Modules.Places.Services;

namespace ThisPlace.Modules.Places.Controllers
{
    [Route("api/places")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces()
        {
            try
            {
                var places = await _placeService.GetPlaces();
                return Ok(places);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetPlaceById(Guid id)
        {
            try
            {
                var place = await _placeService.GetPlaceById(id);
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
                var createdPlace = await _placeService.CreatePlace(newPlace);
                return Ok(createdPlace);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}