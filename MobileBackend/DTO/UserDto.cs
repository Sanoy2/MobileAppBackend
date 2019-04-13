using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DateOfJoin { get; set; }
    }
}
