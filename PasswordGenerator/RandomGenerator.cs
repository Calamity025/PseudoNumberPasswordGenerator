using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator
{
    public class RandomGenerator
    {
        private byte[] seed = { 119, 221, 153, 207, 170, 221, 140, 31, 121, 110, 91, 86, 247, 132, 165, 172 };
        private RNGCryptoServiceProvider _random;

        public RandomGenerator()
        {
            _random = new RNGCryptoServiceProvider();
        }
        
        public int Next()
        {
            var time = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Mode = CipherMode.CBC;
            var encr = tdes.CreateEncryptor();
            var tempArr = encr.TransformFinalBlock(time, 0, time.Length);
            var xored = BitConverter.GetBytes(BitConverter.ToInt64(seed) ^ BitConverter.ToInt64(tempArr));
            var x = encr.TransformFinalBlock(xored, 0, xored.Length);
            var xoredOut = BitConverter.GetBytes(BitConverter.ToInt64(x) ^ BitConverter.ToInt64(tempArr));
            seed = encr.TransformFinalBlock(xoredOut, 0, xoredOut.Length);
            var res = BitConverter.ToInt32(x);

            return res < 0 ? res * -1 : res;
        }
    }
}
