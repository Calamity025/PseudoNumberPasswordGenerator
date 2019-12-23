using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    internal class StrengthChecker
    {
        public double GetPasswordStrength(int totalNumberOfChars, int passwordLength) =>
            passwordLength * (Math.Log(totalNumberOfChars) / Math.Log(2));
    }  
}
