using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    class DicewordPasswordGenerator : IPasswordGenerator
    {
        private RandomGenerator _random;
        private readonly Alphabet _alphabet;
        public DicewordPasswordGenerator()
        {
            _random = new RandomGenerator();
            _alphabet = Alphabet.GetInstance();
        }

        public string Generate(int passwordLength)
        {
            var builder = new StringBuilder();
            var wordCount = 0;

            while (wordCount < passwordLength)
            {
                var dice = _random.Next() % 7776;

                var currWord = _alphabet[dice];
                builder.Append($"{currWord}-");
                wordCount++;
            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
    }
}
