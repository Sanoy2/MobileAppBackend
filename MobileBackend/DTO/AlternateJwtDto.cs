using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.DTO
{
    public class AlternateJwtDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
