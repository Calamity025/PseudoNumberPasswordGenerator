using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator
{
    internal class RandomGenerator
    {
        private byte[] _seed;
        private readonly byte[] _key;
        private readonly byte[] _iv;


        public RandomGenerator(long seed)
        {
            _seed = BitConverter.GetBytes(seed);
        }

        public RandomGenerator(long seed, long key, long iv)
        {
            _seed = BitConverter.GetBytes(seed);
            _key = BitConverter.GetBytes(key);
            _iv = BitConverter.GetBytes(iv);
        }

        public int Next()
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                if (_key != null && _key.Length == 16 && _iv != null && _iv.Length == 16)
                {
                    tdes.Key = _key;
                    tdes.IV = _iv;
                }

                var encryptor = tdes.CreateEncryptor();
                var time = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
                var tempArr = encryptor.TransformFinalBlock(time, 0, time.Length);
                var xored = BitConverter.GetBytes(BitConverter.ToInt64(_seed, 0) ^ BitConverter.ToInt64(tempArr, 0));
                var x = encryptor.TransformFinalBlock(xored, 0, xored.Length);
                var xoredOut = BitConverter.GetBytes(BitConverter.ToInt64(x, 0) ^ BitConverter.ToInt64(tempArr, 0));

                _seed = encryptor.TransformFinalBlock(xoredOut, 0, xoredOut.Length);
                var res = BitConverter.ToInt32(x, 0);

                return res < 0 ? res * -1 : res;
            }
        }
    }
}
