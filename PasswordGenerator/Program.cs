using System;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        private static readonly StrengthChecker _strengthChecker;
        private static readonly IPasswordGenerator _passwordGenerator;

        static Program()
        {
            _strengthChecker = new StrengthChecker();
            _passwordGenerator = PasswordGeneratorFactory.GetPasswordGenerator(PasswordGeneratorFactory.AvailableFactories.Diceware);
        }

        static void Main(string[] args)
        {
            Console.Write("\nEnter password length: ");
            var length = Convert.ToInt32(Console.ReadLine());
            var password = _passwordGenerator.Generate(length);
            Console.WriteLine(password);
            Console.WriteLine(_strengthChecker.GetPasswordStrength(7776, length));
            Console.WriteLine(_strengthChecker.GetPasswordStrength(7776, length) / length);
            Console.WriteLine(_strengthChecker.GetPasswordStrength(7776 * 2 + 5912, length));
            Console.WriteLine(_strengthChecker.GetPasswordStrength(7776 * 2 + 5912, length) / length);
            Console.ReadKey();
        }


    }
}
