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
            new User(1, "sanoy@email.com", "sanoy", "pass"),
            new User(2, "master@email.com", "mAsTeR", "pass"),
            new User(3, "jody3@email.com", "jodoeo", "pass"),
            new User(4, "gengu@email.com", "kingoscope", "pass"),
            new User(5, "hopyhops@email.com", "ChefOfTheYear", "pass"),
            new User(6, "johny_b@email.com", "tomatoSoupWinner", "pass")
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

        public async Task<IEnumerable<User>> GetUsersAsync(string username)
        {
            //return await Task.FromResult(users.SingleOrDefault(n => n.Email.Equals(email.Trim().ToLower())));
            var result = users
                .Where(n => n.Username.Trim().ToLower()
                .Contains(username.Trim().ToLower()))
                .ToList();
            return await Task.FromResult(result);
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
