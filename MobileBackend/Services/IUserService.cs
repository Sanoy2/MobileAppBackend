using MobileBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetUserAsync(string email);
        Task<IEnumerable<UserDto>> GetUsersAsync(string username);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task RegisterAsync(string email, string username, string password);

        Task<JwtDto> LoginAsync(string email, string password);
        Task<AlternateJwtDto> LoginAsyncAlternate(string email, string password);
    }
}
