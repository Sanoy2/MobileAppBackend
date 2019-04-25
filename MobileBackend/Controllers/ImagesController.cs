using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    public class ImagesController : ApiControllerBase
    {
        private readonly string basePath; // only for testing 

        public ImagesController(
            ICommandDispatcher commandDispatcher)  
            : base(commandDispatcher)
        {
            basePath = $"{Directory.GetCurrentDirectory()}{@"/wwwroot/"}";
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> GetSomeImage(string filename)
        {
            string path = basePath + filename + ".jpeg";
            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }
    }
}
