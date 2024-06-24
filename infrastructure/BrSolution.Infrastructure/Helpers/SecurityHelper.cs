using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Infrastructure.Helpers
{
    public static class SecurityHelper
    {
        private static readonly char[] Digits =
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

        private static string ComputeHash(HashAlgorithm algorithm, string value)
        {
            using (algorithm)
            {
                var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));

                var strBuilder = new StringBuilder();
                foreach (var v in bytes)
                {
                    strBuilder.Append(v.ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }

        public static string ComputeSha256Hash(string value)
            => ComputeHash(SHA256.Create(), value);

        public static string ComputeSha512Hash(string value)
            => ComputeHash(SHA512.Create(), value);

        public static string GenerateRandomIntegerString(int length)
        {
            if (length <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var digitChars = new char[length];

            for (var i = 0; i < digitChars.Length; i++)
            {
                digitChars[i] = Digits[Random.Shared.Next(0, Digits.Length)];
            }

            return new string(digitChars);
        }
    }
}
