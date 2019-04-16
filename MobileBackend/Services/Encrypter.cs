using MobileBackend.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MobileBackend.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int saltSize = 40;

        public string GetSalt(string value)
        {
            if(value.NotExists())
            {
                throw new ArgumentException($"Cannot generate salt from an empty value {nameof(value)}");
            }

            var saltBytes = new byte[saltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if(new string[] {value, salt}.NotExist())
            {
                throw new ArgumentException($"Cannot use an empty value {nameof(value)} or {nameof(salt)}");
            }

            var pbkfz2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkfz2.GetBytes(saltSize));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
