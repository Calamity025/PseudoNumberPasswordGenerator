using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    internal interface IPasswordGenerator
    {
        string Generate(int length);
        int Length { get; }
    }
}
