using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MobileBackend.Services;

namespace MobileBackend.Repositories
{
    public interface IImagesRepository : IService
    {
        Task<byte[]> GetFileAsBytesAsync(string filename);
        Task<string> SaveFileAsync(IFormFile file);
    }
}