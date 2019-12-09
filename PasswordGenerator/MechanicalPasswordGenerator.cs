using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    public class MechanicalPasswordGenerator : IPasswordGenerator
    {
        private readonly RandomGenerator _random;
        private readonly char[,,] _alphabet;
        public MechanicalPasswordGenerator()
        {
            _random = new RandomGenerator();
            _alphabet = Alphabet.GetInstance().MechanicalAlph;
        }

        public string Generate(int passwordLength)
        {
            var builder = new StringBuilder();

            while (builder.Length < passwordLength)
            {
                var dice1 = _random.Next() % 6;
                var dice2 = _random.Next() % 6;
                var coinFlip = _random.Next() % 2;

                var currChar = _alphabet[coinFlip, dice1, dice2];
                builder.Append(currChar);
            }

            return builder.ToString(); 
        }

        public int Length => _alphabet.Length;
    }
}
