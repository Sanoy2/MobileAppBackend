using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expiry { get; set; }
    }
}
