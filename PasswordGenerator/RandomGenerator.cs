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
            byte[] rnd = new byte[1];
            _random.GetBytes(rnd);
            return (int)rnd[0];
        }
    }
}
