
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThisPlace.Dto;
using ThisPlace.Services;

namespace ThisPlace.Controllers
{
    [Route("api/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload([FromForm] PhotosUploadDto data)
        {
            var gg = data;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullImageName = $@"{Guid.NewGuid()}{Path.GetExtension(data.File.FileName)}";
            var fullPath = Path.Combine(pathToSave, fullImageName);

            try
            {
                using (var stream = System.IO.File.Create(fullPath))
                {
                    await data.File.CopyToAsync(stream);
                }

                var id = await _photoService.AddImage(fullImageName, data.PlaceId);
                return Ok(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }
    }
}