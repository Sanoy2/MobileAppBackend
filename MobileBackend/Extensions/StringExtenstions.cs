using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Extensions
{
    public static class StringExtenstions
    {
        public static bool NotExists(this string value)
        {
            return string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value);
        }

        public static bool NotExist(this string[] values)
        {
            foreach(var value in values)
            {
                if(value.NotExists())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
