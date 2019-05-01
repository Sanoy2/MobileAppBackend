using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MobileBackend.Extensions;
using MobileBackend.Settings;

namespace MobileBackend.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly IHostingEnvironment env;
        private readonly GeneralSettings settings;
        public ImagesRepository(IHostingEnvironment hostingEnvironment, GeneralSettings settings)  
        {
            this.settings = settings;
            this.env = hostingEnvironment;
        }


        public async Task<byte[]> GetFileAsBytesAsync(string filename)
        {
            var path = GetFilePath(filename);
            ThrowExceptionIfNotExists(path);
            return await System.IO.File.ReadAllBytesAsync(path);
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            try
            {
                var imagesPath = Path.Combine(env.WebRootPath, settings.ImagesDirectory);
                var imageGuid = Guid.NewGuid().ToString();
                var extension = ".jpeg";
                var physicalFileName = imageGuid + extension;
                var fullPath = Path.Combine(imagesPath, physicalFileName);
                await file.CopyToAsync(new FileStream(fullPath, FileMode.Create));
                
                return imageGuid;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private string GetFilePath(string filename)
        {
            string path = $"{settings.ImagesDirectory}/{filename}.jpeg";
            return env.WebRootFileProvider.GetFileInfo(path)?.PhysicalPath;
        }

        private void ThrowExceptionIfNotExists(string path)
        {
            if(path.NotExists())
            {
                throw new ArgumentNullException("Given file does not exist");
            }
        }
    }
}