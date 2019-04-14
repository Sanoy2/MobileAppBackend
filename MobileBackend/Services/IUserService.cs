using MobileBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string email);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task RegisterAsync(string email, string password);
    }
}
