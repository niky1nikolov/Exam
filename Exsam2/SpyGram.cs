using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Spay
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();
            int[] enigma = new int[input.Length];
            ConvertCharToInt(input, enigma);
            string text = Console.ReadLine();

            string pattern = @"TO: ([A-Z]+); MESSAGE: ([a-z']*.*)";
            List<string> kriptMesseg = new List<string>();
            SortedDictionary<string, string> machcollection = new SortedDictionary<string, string>();

            while (text != "END")
            {
                if (Regex.IsMatch(text, pattern))
                {
                    Match match = Regex.Match(text, pattern);
                    string name = match.Groups[1].Value;
                    string messeg = match.Groups[2].Value;
                    machcollection.Add(name, messeg);
                }
                text = Console.ReadLine();
            }

            int buff = 0;
            string result = string.Empty;
            string textMesseg = string.Empty;

            foreach (var kvp in machcollection)
            {
                textMesseg = $"TO: {kvp.Key}; MESSAGE: {kvp.Value}";

                for (int i = 0; i < textMesseg.Length; i++)
                {
                    buff = textMesseg[i] + enigma[i % enigma.Length];
                    result += (char)buff;
                }

                kriptMesseg.Add(result);
                result = string.Empty;
            }

            foreach (var mach in kriptMesseg)
            {
                Console.WriteLine(mach);
            }

        }

        private static void ConvertCharToInt(char[] input, int[] enigma)
        {
            for (int i = 0; i < input.Length; i++)
            {
                enigma[i] = (int)Char.GetNumericValue(input[i]);
            }

        }
    }
}
