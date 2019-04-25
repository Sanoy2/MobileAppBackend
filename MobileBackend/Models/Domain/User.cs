using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Models.Domain
{
    public class User
    {
        public int Id { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime DateOfJoin { get; protected set; }

        protected User() { }

        public User(string email, string username, string password, string salt)
        {
            Email = email.Trim().ToLower();
            Username = username;
            Password = password;
            Salt = salt;
            DateOfJoin = DateTime.UtcNow;
        }

        // Method for in memory repository
        public User(int id, string email, string username, string password, string salt)
        : this(email, username, password, salt)
        {
            Id = id;
        }
    }
}
