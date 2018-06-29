using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToUpper();
            string pattern = @"([\D]+)(\d+)";
                        
            MatchCollection matches = Regex.Matches(text, pattern);
            StringBuilder result = new StringBuilder(); 
            string words = "";

            foreach (Match match in matches)
            {
                string word = match.Groups[1].Value;
                int count = int.Parse(match.Groups[2].Value);
                result.Append(Repear(word, count));
                if (count != 0)
                {
                    words += word;
                }
                
            }        

            int unique = words.ToCharArray().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {unique}");
            Console.WriteLine(result);
        }

        private static string Repear(string word, int count)
        {
            var result = string.Empty;
            
            for (var i = 0; i < count; i++)
            { 
               result += word;
                
            }
            return result;
        }
    }
}
