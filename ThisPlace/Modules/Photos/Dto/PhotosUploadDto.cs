using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ThisPlace.Dto
{
    public class PhotosUploadDto
    {
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "PlaceId is required")]
        public string PlaceId { get; set; }
    }
}