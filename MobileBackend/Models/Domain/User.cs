using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Models.Domain
{
    public class User
    {
        public int Id { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public DateTime DateOfJoin { get; protected set; }

        protected User() { }

        public User(string username, string password)
        {
            Username = username.Trim().ToLower();
            Password = password;
            DateOfJoin = DateTime.UtcNow;
        }
    }
}
