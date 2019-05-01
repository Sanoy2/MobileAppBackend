using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public async Task<byte[]> GetFileAsBytesAsync(string filename)
        {
            return await imageRepository.GetFileAsBytesAsync(filename);
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if(file == null)
            {
                throw new ArgumentNullException("File cannot be null");
            }

            return await imageRepository.SaveFileAsync(file);
        }
    }
}