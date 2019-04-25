using MobileBackend.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Services
{
    public interface IImageService : IService
    {
        FileStream GetFile(string filename);
        string SaveFile(FileStream file);

        // Task<FileStream> GetImageAsync(string filename);
    }
}
