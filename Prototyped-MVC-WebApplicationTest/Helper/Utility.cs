using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototyped_MVC_WebApplicationTest.Helper
{
    public static class Utility
    {
        private static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        public static string GetRandomString(int length = 20)
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GetRandomInteger(int min = 1, int max = 100)
        {
            return random.Next(min, max);
        }
    }

}
