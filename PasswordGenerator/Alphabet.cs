using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    public class Alphabet
    {
        private static readonly object _locker = new object();
        private static Alphabet _alphabetInstance;
        private static readonly char[,] headAlph =
        {
            {'a', 'b', 'c', 'd', 'e', 'f' },
            {'g', 'h', 'i', 'j', 'k', 'l' },
            {'m', 'n', 'o', 'p', 'g', 'r' },
            {'s', 't', 'u', 'v', 'w', 'x' },
            {'y', 'z', '0', '1', '2', '3' },
            {'4', '5', '6', '7', '8', '9' },
        };
        private static readonly char[,] tailAlph =
        {
            {'A', 'B', 'C', 'D', 'E', 'F' },
            {'G', 'H', 'I', 'J', 'K', 'L' },
            {'M', 'N', 'O', 'P', 'G', 'R' },
            {'S', 'T', 'U', 'V', 'W', 'X' },
            {'Y', 'Z', '_', '!', '@', '+' },
            {'$', '%', '=', '&', '-', '?' },
        };
        private static readonly List<string> diceware = Reader.Read();

        private Alphabet() { }

        public static Alphabet GetInstance()
        {
            lock (_locker)
            {
                return _alphabetInstance ?? (_alphabetInstance = new Alphabet());
            }
        }

        public char this[int x, int y, int coinFlip]
        {
            get
            {
                try
                {
                    if(coinFlip == 1)
                    {
                        return headAlph[x, y];
                    }
                    else
                    {
                        return tailAlph[x, y];
                    }
                }
                catch
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public string this[int x]
        {
            get
            {
                return diceware[x];
            }
        }

        public int Length => headAlph.Length + tailAlph.Length;
    }
}
