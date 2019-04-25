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
            var path = env.WebRootFileProvider.GetFileInfo($"images/{filename}.jpeg")?.PhysicalPath;
            var b = await System.IO.File.ReadAllBytesAsync(path);
            return File(b, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var uploads = Path.Combine(env.WebRootPath, "images");
            var imageGuid = Guid.NewGuid().ToString() + ".jpeg";
            var fullPath = Path.Combine(uploads, imageGuid);
            if(file == null)
            {
                return Content("null");
            }
            if(file.Length > 0)
            {
                var builder = new StringBuilder();
                builder.AppendLine($"name: {file.Name}");
                builder.AppendLine($"filename: {file.FileName}");
                builder.AppendLine($"content type: {file.ContentType}");
                builder.AppendLine($"length: {file.Length}");
                await file.CopyToAsync(new FileStream(fullPath, FileMode.Create));

                return Content(builder.ToString());
            }
            else
            {
                return Content("file.Length > 0 is false");
            }
        }
    }
}   
