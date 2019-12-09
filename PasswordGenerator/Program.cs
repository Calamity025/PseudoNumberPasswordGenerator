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
            for(int i = 0; i < 5; i++)
            {
                var password = _passwordGenerator.Generate(length);
                Console.WriteLine(password);
            }
            //Console.WriteLine("Entropy of standard Diceware generator: " + _strengthChecker.GetPasswordStrength(7776, length));
            //Console.WriteLine("Entropy per character of standard Diceware generator: " + _strengthChecker.GetPasswordStrength(7776, length) / length);
            Console.WriteLine("Entropy: " + _strengthChecker.GetPasswordStrength(_passwordGenerator.Length, length));
            Console.WriteLine("Entropy per character: " + _strengthChecker.GetPasswordStrength(_passwordGenerator.Length, length) / length);
            Console.ReadKey();
        }


    }
}
