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
            return factory switch
            {
                AvailableFactories.Diceware => new DicewordPasswordGenerator(),
                AvailableFactories.Mechanical => new MechanicalPasswordGenerator(),
                _ => null,
            };
        }
    }
}
