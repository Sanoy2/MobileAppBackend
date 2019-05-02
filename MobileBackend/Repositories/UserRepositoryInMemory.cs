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
            new User(1, "sanoy@email.com", "sanoy", "pass", "salt"),
            new User(2, "master@email.com", "mAsTeR", "pass", "salt"),
            new User(3, "jody3@email.com", "jodoeo", "pass", "salt"),
            new User(4, "gengu@email.com", "kingoscope", "pass", "salt"),
            new User(5, "hopyhops@email.com", "ChefOfTheYear", "pass", "salt"),
            new User(6, "johny_b@email.com", "tomatoSoupWinner", "pass", "salt"),
            new User(7, "example@email.com", "john", "BA21767AE494AFE5A2165DCB3338C5323E9907050E34542C405D575CC31BF527" ,"salt")
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
