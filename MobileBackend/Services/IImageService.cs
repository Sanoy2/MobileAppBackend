using Microsoft.AspNetCore.Http;
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
        Task<byte[]> GetFileAsBytesAsync(string filename);
        Task<string> SaveFileAsync(IFormFile file);
    }
}
