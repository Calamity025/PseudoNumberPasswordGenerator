using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
    public static class Reader
    {
        public static List<string> Read()
        {
            using (var file = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory() + "\\diceware.wordlist..txt")))
            {
                var stream = file.ReadToEnd();
                var lines = stream.Split('\n');

                return lines.Skip(2).Take(7776).Select(x => x.Split('\t')[1]).ToList();
            }
        }
    }
}
