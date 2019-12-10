using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
    internal class DicewordPasswordGenerator : IPasswordGenerator
    {
        private readonly RandomGenerator _random;
        private readonly Alphabet _alphabet;

        public DicewordPasswordGenerator(RandomGenerator rnd)
        {
            _random = rnd;
            _alphabet = Alphabet.GetInstance();
        }

        public string Generate(int passwordLength)
        {
            var builder = new StringBuilder();
            var wordCount = 0;

            while (wordCount < passwordLength)
            {
                var dice = _random.Next() % 7776;
                var uppercase = _random.Next() % 2;

                var currWord = _alphabet.DicewareAlph[dice];
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

        public int Length => _alphabet.DicewareAlph.Count + _alphabet.DicewareAlph.Count(x => Char.IsLetter(x.First())) + GetReplaceableCharCount();

        private int GetReplaceableCharCount()
        {
            var count = 0;
            _alphabet.DicewareAlph.ForEach(str =>
            {
                foreach (char ch in str.Skip(1))
                {
                    if (ch == 'o' || ch == 'i' || ch == 'l')
                        count++;
                }
            });
            return count;

        }
    }
}
