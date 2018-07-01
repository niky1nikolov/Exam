using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Bar_Income3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string patter = @"%([A-Z][a-z]+)%<([A-Za-z]+)>([a-z]*)\|([\d]+)\|\3([\d]+\.*[\d])\$";
            double totalPrise = 0;

            while (input != "end of shift")
            {
                if (Regex.IsMatch(input, patter))
                {
                    Match current = Regex.Match(input, patter);
                    string customer = current.Groups[1].Value;
                    string product = current.Groups[2].Value;
                    int count = int.Parse(current.Groups[4].Value);
                    double prise = double.Parse(current.Groups[5].Value);

                    totalPrise += (count * prise);

                    Console.WriteLine($"{customer}: {product} - {(count * prise):F2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalPrise:F2}");
        }
    }
}
