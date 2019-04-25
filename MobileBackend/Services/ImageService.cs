using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MobileBackend.DTO;
using MobileBackend.Models.Domain;
using MobileBackend.Repositories;

namespace MobileBackend.Services
{
    public class ImageService : IImageService
    {
        private readonly IImagesRepository imageRepository;
        public ImageService(IImagesRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public FileStream GetFile(string filename)
        {
            return imageRepository.GetFile(filename);
        }

        // public async Task<FileStream> GetFileAsync(string filename)
        // {
        //     var bytes = await imageRepository.GetFileBytesAsync(filename);
        // }

        public string SaveFile(FileStream file)
        {
            return imageRepository.SaveFile(file);
        }
    }
}