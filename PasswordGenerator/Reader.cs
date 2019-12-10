using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
    internal static class Reader
    {
        private static string currentVersion;
        public static string Path { get; set; }
        private static List<string> diceware;

        public static List<string> Read()
        {
            var path = Path ?? Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 15) + "\\diceware.wordlist.txt";
            if (currentVersion == null || currentVersion != path)
            {
                using (var file = new StreamReader(File.OpenRead(path)))
                {
                    var stream = file.ReadToEnd();
                    var lines = stream.Split('\n');
                    var result = lines.SkipWhile(x => x.Length < 5 || !x.Take(5).All(ch => Char.IsDigit(ch))).TakeWhile(x => x.Length > 5 && x.Take(5).All(ch => Char.IsDigit(ch))).Select(x => x.Split('\t')[1]).ToList();
                    currentVersion = path;
                    diceware = result;
                    Debug.Print(path);
                }
            }
            return diceware;
        }
    }
}
