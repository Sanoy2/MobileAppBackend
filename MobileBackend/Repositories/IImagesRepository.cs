using System.IO;
using System.Threading.Tasks;
using MobileBackend.Services;

namespace MobileBackend.Repositories
{
    public interface IImagesRepository : IService
    {
        FileStream GetFile(string filename);
        string SaveFile(FileStream file);

        // Task<byte[]> GetFileBytesAsync(string filename);
    }
}