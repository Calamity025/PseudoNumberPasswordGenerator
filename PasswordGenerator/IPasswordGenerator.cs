using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    public interface IPasswordGenerator
    {
        string Generate(int length);
    }
}
