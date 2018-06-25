using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpyGramMentor
{
    class Program
    {
        class Recipient
        {
            public Recipient(string name, string text)
            {
                Name = name;
                Text = text;
            }

            public string Name { get; set;}
            public string Text { get; set; }
        }

        static void Main(string[] args)
        {
            string pattern = @"TO: ([A-Z]+); MESSAGE: (.*?);";
            List<Recipient> recipiends = new List<Recipient>();

            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string name = match.Groups[1].Value;

                    Recipient recipient = new Recipient(name, input);
                    

                }

                input = Console.ReadLine();
            }
        }
    }
}
