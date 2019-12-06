using System;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        private static readonly StrengthChecker _strengthChecker;
        private static readonly PasswordGenerator _passwordGenerator;

        static Program()
        {
            _strengthChecker = new StrengthChecker();
            _passwordGenerator = new PasswordGenerator();
        }

        static void Main(string[] args)
        {
            Console.Write("\nEnter password length: ");
            var length = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 20; i++)
            {
                var password = _passwordGenerator.Generate(length);
                Console.WriteLine(password);
            }
            var enthropy = _strengthChecker.GetPasswordStrength(Alphabet.GetInstance().Length, length);
            Console.WriteLine($"\nEnthropy is {enthropy}\nEnthropy per symbol: {enthropy/length}");
            Console.ReadKey();
        }


    }
}
