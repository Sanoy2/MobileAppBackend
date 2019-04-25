using MobileBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Handlers
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, int userId, string role);
    }
}
