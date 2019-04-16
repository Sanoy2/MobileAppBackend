using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MobileBackend.DTO;
using MobileBackend.Settings;
using MobileBackend.Extensions;
using MobileBackend.Models.Enums;

namespace MobileBackend.Handlers
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings jwtSettings;

        public JwtHandler(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public JwtDto CreateToken(string email, int userId, string role)
        {
            var now = DateTime.UtcNow;
            var days = jwtSettings.ExpirationDays;

            var notBefore = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
            var expiry = new DateTimeOffset(DateTime.UtcNow.AddDays(days)).ToUnixTimeSeconds().ToString();

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(nameof(JwtEnums.userId), userId.ToString()),
                new Claim(nameof(JwtEnums.userEmail), email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                
                new Claim(JwtRegisteredClaimNames.Nbf, notBefore),
                new Claim(JwtRegisteredClaimNames.Exp, expiry)
            };

            var jwtKey = Encoding.UTF8.GetBytes(jwtSettings.Key);
            var symmetricSecurityKey = new SymmetricSecurityKey(jwtKey);
            var jwtSecurityAlgorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, jwtSecurityAlgorithm);

            var jwt = new JwtSecurityToken(
                new JwtHeader(signingCredentials),
                new JwtPayload(claims));

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto()
            {
                Token = token
            };
        }
    }
}
