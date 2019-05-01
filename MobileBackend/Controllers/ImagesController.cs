using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    public class ImagesController : ApiControllerBase
    {
        private readonly IImageService imageService;
        private readonly IHostingEnvironment env;

        public ImagesController(
            IImageService imageService,
            ICommandDispatcher commandDispatcher,
            IHostingEnvironment hostingEnvironment)  
            : base(commandDispatcher)
        {
            this.imageService = imageService;
            this.env = hostingEnvironment;
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> GetSomeImage(string filename)
        {
            var bytes = await imageService.GetFileAsBytesAsync(filename);
            return File(bytes, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var imageId = await imageService.SaveFileAsync(file);
                return Created($"api/images/{imageId}", new object());
            }
            catch(Exception ex)
            {
                if(env.IsDevelopment())
                    throw;

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}   
