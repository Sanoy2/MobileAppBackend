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
            new User("sanoy@email.com", "pass"),
            new User("master@email.com", "pass"),
            new User("jody3@email.com", "pass"),
            new User("gengu@email.com", "pass"),
            new User("hopyhops@email.com", "pass"),
            new User("johny_b@email.com", "pass")
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

        public async Task<User> GetUserAsync(string email)
        {
            return await Task.FromResult(users.SingleOrDefault(n => n.Email.Equals(email.Trim().ToLower())));
        }

        public async Task RemoveAsync(int userId)
        {
            var user = await GetUserAsync(userId);
            await Task.FromResult(users.Remove(user));
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
