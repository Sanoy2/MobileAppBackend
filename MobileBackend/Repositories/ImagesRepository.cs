using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace MobileBackend.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly IHostingEnvironment env;
        public ImagesRepository(IHostingEnvironment hostingEnvironment)  
        {
            this.env = hostingEnvironment;
        }

        public FileStream GetFile(string filename)
        {
            var path = env.WebRootFileProvider.GetFileInfo($"images/{filename}.jpeg")?.PhysicalPath;
            var image = System.IO.File.OpenRead(path);
            return image;
        }

        // public async Task<byte[]> GetFileBytesAsync(string filename)
        // {
        //     var path = env.WebRootFileProvider.GetFileInfo($"images/{filename}.jpeg")?.PhysicalPath;
        //     return await System.IO.File.ReadAllBytesAsync(path);
        // }

        public string SaveFile(FileStream file)
        {
            throw new System.NotImplementedException();
        }
    }
}