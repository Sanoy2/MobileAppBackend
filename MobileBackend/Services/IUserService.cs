using MobileBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Services
{
    public interface IUserService
    {
        UserDto GetUser(string username);
        IEnumerable<UserDto> GetAllUsers();
        void Register(string username, string password);

        
    }
}
