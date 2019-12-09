using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    public class MechanicalPasswordGenerator : IPasswordGenerator
    {
        private RandomGenerator _random;
        private readonly Alphabet _alphabet;
        public MechanicalPasswordGenerator()
        {
            _random = new RandomGenerator();
            _alphabet = Alphabet.GetInstance();
        }

        public string Generate(int passwordLength)
        {
            var builder = new StringBuilder();

            while (builder.Length < passwordLength)
            {
                var dice1 = _random.Next() % 6;
                var dice2 = _random.Next() % 6;
                var coinFlip = _random.Next() % 2;

                var currChar = _alphabet[dice1, dice2, coinFlip];
                builder.Append(currChar);
            }

            return builder.ToString(); 
        }

    }
}
