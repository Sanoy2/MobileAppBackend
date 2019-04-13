using MobileBackend.Models.Domain;
using MobileBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Repositories
{
    public class UserRepositoryInMemory : IUserRepository
    {
        private static ISet<User> users = new HashSet<User>()
        {
            new User("sanoy", "pass"),
            new User("master", "pass"),
            new User("jody3", "pass"),
            new User("gengu", "pass"),
            new User("hopyhops", "pass"),
            new User("johny_b", "pass")
        };

        public async Task AddAsync(User newUser)
        {
            await Task.FromResult(users.Add(newUser));
        }

        public async Task<IEnumerable<User>> GetAllAsync()   
        {
            return await Task.FromResult(users.OrderByDescending(n => n.DateOfJoin).ToList());
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await Task.FromResult(users.SingleOrDefault(n => n.Id == userId));
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await Task.FromResult(users.SingleOrDefault(n => n.Username.Equals(username.Trim().ToLower())));
        }

        public async Task RemoveAsync(int userId)
        {
            var user = await GetUserAsync(userId);
            await Task.FromResult(users.Remove(user));
        }

        public async Task UpdateAsync(User user)
        {
            
        }
    }
}
