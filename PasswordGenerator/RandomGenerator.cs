using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator
{
    public class RandomGenerator
    {
        private RNGCryptoServiceProvider _random;

        public RandomGenerator()
        {
            _random = new RNGCryptoServiceProvider();
        }
        
        public int Next()
        {
            byte[] rnd = new byte[8];
            _random.GetBytes(rnd);
            var value = BitConverter.ToInt32(rnd);
            return value < 0 ? value * -1 : value;
        }
    }
}
