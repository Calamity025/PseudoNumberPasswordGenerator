using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    internal class Alphabet
    {
        private static Alphabet _alphabetInstance;
        private static readonly char[,,] _mechanicalAlph =
        {
            {
                {'a', 'b', 'c', 'd', 'e', 'f' },
                {'g', 'h', 'i', 'j', 'k', 'l' },
                {'m', 'n', 'o', 'p', 'g', 'r' },
                {'s', 't', 'u', 'v', 'w', 'x' },
                {'y', 'z', '0', '1', '2', '3' },
                {'4', '5', '6', '7', '8', '9' },
            },
            {
                {'A', 'B', 'C', 'D', 'E', 'F' },
                {'G', 'H', 'I', 'J', 'K', 'L' },
                {'M', 'N', 'O', 'P', 'G', 'R' },
                {'S', 'T', 'U', 'V', 'W', 'X' },
                {'Y', 'Z', '_', '!', '@', '+' },
                {'$', '%', '=', '&', '-', '?' },
            }
        };

        private Alphabet() { }

        public static Alphabet GetInstance() =>
                _alphabetInstance ?? (_alphabetInstance = new Alphabet());

        public char[,,] MechanicalAlph => _mechanicalAlph;
        public List<string> DicewareAlph => Reader.Read();
    }
}
