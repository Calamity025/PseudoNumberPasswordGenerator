using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
    class DicewordPasswordGenerator : IPasswordGenerator
    {
        private readonly RandomGenerator _random;
        private readonly List<string> _alphabet;

        public DicewordPasswordGenerator()
        {
            _random = new RandomGenerator();
            _alphabet = Alphabet.GetInstance().DicewareAlph;
        }

        public string Generate(int passwordLength)
        {
            var builder = new StringBuilder();
            var wordCount = 0;

            while (wordCount < passwordLength)
            {
                var dice = _random.Next() % 7776;
                var uppercase = _random.Next() % 2;

                var currWord = _alphabet[dice];
                var temp = currWord.ToCharArray();
                if (uppercase == 1)
                {
                    temp[0] = temp[0].ToString().ToUpper()[0];
                }
                for(int i = 0; i < currWord.Length; i++)
                {
                    var currChar = currWord[i];
                    switch (currChar)
                    {
                        case 'o':
                            var replaceO = _random.Next() % 2;
                            if (replaceO == 1)
                            {
                                temp[i] = '0';
                            }
                            break;
                        case 'i':
                            var replaceI = _random.Next() % 2;
                            if (replaceI == 1)
                            {
                                temp[i] = '1';
                            }
                            break;
                        case 'l':
                            var replaceL = _random.Next() % 2;
                            if (replaceL == 1)
                            {
                                temp[i] = '7';
                            }
                            break;
                    } 
                }
                
                builder.Append($"{new string(temp)}-");
                wordCount++;
            }

            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        public int Length => GetAlgorithmAlphabet();

        private int GetAlgorithmAlphabet()
        {
            return 7776 * 2 - 308 + 5912;
        }
    }
}
