using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Helpers
{
    public class HashHelper
    {
        public static string CalcHash(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("Invalid Content!");
            }
            byte[] saltBytes = Convert.FromBase64String("gI976UUn3/m59A==");
            byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(content);

            System.Security.Cryptography.HMACSHA256 myHash =
                new System.Security.Cryptography.HMACSHA256(saltBytes);

            byte[] hashedData = myHash.ComputeHash(contentBytes);
            return Convert.ToBase64String(hashedData);
        }
    }
}
