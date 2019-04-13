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

        public IEnumerable<UserDto> GetAllUsers()
        {
            return userRepository
                .GetAllAsync()
                .Result
                .Select(n => mapper.Map<User, UserDto>(n))
                .ToList();
        }

        public UserDto GetUser(string username)
        {
            var user = userRepository.GetUserAsync(username.Trim().ToLower()).Result;

            return mapper.Map<User, UserDto>(user);
        }

        public void Register(string username, string password)
        {
            var user = userRepository.GetUserAsync(username).Result;
            if(user != null)
            {
                throw new Exception($"User {username} already exists");
            }

            user = new User(username, password);
            userRepository.AddAsync(user);
        }
    }
}
