using AutoMapper;
using MobileBackend.DTO;
using MobileBackend.Models.Domain;
using MobileBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var allUsers = await userRepository.GetAllAsync();
            return allUsers.Select(n => mapper.Map<User, UserDto>(n)).ToList();
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await userRepository.GetUserAsync(email.Trim().ToLower());

            return mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string password)
        {
            var user = await userRepository.GetUserAsync(email);
            if(user != null)
            {
                throw new Exception($"User {email} already exists");
            }

            user = new User(email, password);
            await userRepository.AddAsync(user);
        }
    }
}
