using AutoMapper;
using MobileBackend.DTO;
using MobileBackend.Handlers;
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
        private readonly IEncrypter encrypter;
        private readonly IJwtHandler jwtHandler;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.encrypter = encrypter;
            this.jwtHandler = jwtHandler;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var allUsers = await userRepository.GetAllAsync();
            return allUsers.Select(n => mapper.Map<User, UserDto>(n)).ToList();
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            email = email.Trim().ToLower();
            var user = await userRepository.GetUserAsync(email);

            return mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync(string username)
        {
            var users = await userRepository.GetUsersAsync(username);
            return users.Select(n => mapper.Map<User, UserDto>(n)).ToList();
        }

        public async Task RegisterAsync(string email, string username, string password)
        {
            email = email.Trim().ToLower();
            var user = await userRepository.GetUserAsync(email);
            if(user != null)
            {
                throw new Exception($"User {email} already exists");
            }

            var salt = encrypter.GetSalt(password);
            var hash = encrypter.GetHash(password, salt);
            user = new User(email, username, hash, salt);
            await userRepository.AddAsync(user);
        }

        public async Task<JwtDto> LoginAsync(string email, string password)
        {
            email = email.Trim().ToLower();
            var user = await userRepository.GetUserAsync(email);

            if(user == null)
            {
                throw new ArgumentNullException("Invalid email or password");
            }

            var salt = user.Salt;
            var hash = encrypter.GetHash(password, salt);

            if (user.Password.Equals(hash))
            {
                return jwtHandler.CreateToken(user.Email, user.Id, "user");
            }
            else
            {
                throw new Exception("Invalid email or password");
            }
        }
    }
}
