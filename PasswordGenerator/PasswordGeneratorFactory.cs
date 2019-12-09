using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    public static class PasswordGeneratorFactory
    {
        public enum AvailableFactories 
        {
            Diceware,
            Mechanical
        }

        public static IPasswordGenerator GetPasswordGenerator(AvailableFactories factory)
        {
            switch (factory)
            {
                case AvailableFactories.Diceware:
                    return new DicewordPasswordGenerator();
                case AvailableFactories.Mechanical:
                    return new MechanicalPasswordGenerator();
                default:
                    return null;
            }
        }
    }
}
