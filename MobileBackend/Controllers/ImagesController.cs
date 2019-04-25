using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var path = env.WebRootFileProvider.GetFileInfo($"images/{filename}.jpeg")?.PhysicalPath;
            var b = await System.IO.File.ReadAllBytesAsync(path);
            return File(b, "image/jpeg");
        }
    }
}   
