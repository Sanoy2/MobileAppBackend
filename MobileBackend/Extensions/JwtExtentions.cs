using Microsoft.AspNetCore.Http;
using MobileBackend.Models.Enums;
using System;
using System.Linq;
using System.Security.Claims;

namespace MobileBackend.Extensions
{
    public static class JwtExtentions
    {
        public static long ToTimeStamp(this DateTime dateTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(epoch.Ticks));

            return time.Ticks / 10000;
        }

        public static string GetJwtPayload(this HttpContext context, JwtEnums property)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            var value = claimsIdentity.Claims.Single(n => n.Type.Equals(property.ToString())).Value;

            return value;
        }
    }
}
