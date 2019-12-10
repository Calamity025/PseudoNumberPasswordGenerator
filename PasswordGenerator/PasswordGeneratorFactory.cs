using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    internal static class PasswordGeneratorFactory
    {
        public enum AvailableFactories 
        {
            Diceware,
            Mechanical
        }

        public static IPasswordGenerator GetPasswordGenerator(AvailableFactories factory, RandomGenerator rnd)
        {
            switch (factory)
            {
                case AvailableFactories.Diceware:
                    return new DicewordPasswordGenerator(rnd);
                case AvailableFactories.Mechanical:
                    return new MechanicalPasswordGenerator(rnd);
                default:
                    return null;
            };
        }
    }
}
