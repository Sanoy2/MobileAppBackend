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
        public string Password { get; protected set; }
        public DateTime DateOfJoin { get; protected set; }

        protected User() { }

        public User(string email, string password)
        {
            Email = email.Trim().ToLower();
            Password = password;
            DateOfJoin = DateTime.UtcNow;
        }
    }
}
