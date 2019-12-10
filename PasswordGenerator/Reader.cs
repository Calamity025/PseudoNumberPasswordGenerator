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
            var directory = Directory.GetCurrentDirectory();
            using var file = new StreamReader(File.OpenRead(directory.Remove(directory.Length - 24) + "\\diceware.wordlist..txt"));
            var stream = file.ReadToEnd();
            var lines = stream.Split('\n');
            var result = lines.Skip(2).Take(7776).Select(x => x.Split('\t')[1]).ToList();
            return result;
        }
    }
}
