using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        private readonly StrengthChecker _strengthChecker;
        private readonly IPasswordGenerator _passwordGenerator;

        public PasswordGenerator(long seed, string pathToDicewareAlph = null, 
            PasswordGeneratorFactory.AvailableFactories factory = PasswordGeneratorFactory.AvailableFactories.Diceware)
        {
            _strengthChecker = new StrengthChecker();
            if(pathToDicewareAlph != null)
                Reader.Path = pathToDicewareAlph;
            _passwordGenerator = PasswordGeneratorFactory.GetPasswordGenerator(factory, new RandomGenerator(seed));
        }

        public PasswordGenerator(long seed, long key, long iv, string pathToDicewareAlph = null, 
            PasswordGeneratorFactory.AvailableFactories factory = PasswordGeneratorFactory.AvailableFactories.Diceware)
        {
            _strengthChecker = new StrengthChecker();
            if (pathToDicewareAlph != null)
                Reader.Path = pathToDicewareAlph;
           _passwordGenerator = PasswordGeneratorFactory.GetPasswordGenerator(factory, new RandomGenerator(seed, key, iv));
        }

        public Responce Generate(int length)
        {
            Console.WriteLine(Reader.Read());
            var res = new List<string>();
            for(int i = 0; i < 5; i++)
            {
                var password = _passwordGenerator.Generate(length);
                res.Add(password);
            }
            return new Responce
            {
                Passwords = res,
                Entropy = _strengthChecker.GetPasswordStrength(_passwordGenerator.Length, length),
                EntropyPerSymbol = _strengthChecker.GetPasswordStrength(_passwordGenerator.Length, length) / length,
                Path = Reader.Path
            };
        }

        public class Responce
        {
            public List<string> Passwords { get; set; }
            public double Entropy { get; set; }
            public double EntropyPerSymbol { get; set; }
            public string Path { get; set; }
        }
    }
}
