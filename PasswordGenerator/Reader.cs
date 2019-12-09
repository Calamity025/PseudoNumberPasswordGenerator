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
            using (var file = new StreamReader(File.OpenRead(directory.Remove(directory.Length - 24) + "\\diceware.wordlist..txt")))
            {
                var stream = file.ReadToEnd();
                var lines = stream.Split('\n');
                var counter = 0;
                var result = lines.Skip(2).Take(7776).Select(x => {
                    var key = x.Split('\t')[1];
                    if((key.Contains('o') || key.Contains('i') || key.Contains('l')) && (!key.First().Equals('o') || !key.First().Equals('i') || !key.First().Equals('l')))
                    {
                        counter += key.Count(y => y.Equals('o') || y.Equals('i') || y.Equals('l'));
                    }
                    return key;
                    }).ToList();
                Console.WriteLine(counter);
                return result;
            }
        }
    }
}
