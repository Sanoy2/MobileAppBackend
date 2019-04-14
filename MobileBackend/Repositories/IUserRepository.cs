using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserAsync(int userId);

        Task<User> GetUserAsync(string email);
        Task<IEnumerable<User>> GetUsersAsync(string username);

        Task AddAsync(User newUser);

        Task UpdateAsync(User user);

        Task RemoveAsync(int userId);
    }
}
