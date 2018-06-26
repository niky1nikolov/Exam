using System;
using System.Text.RegularExpressions;


namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            string surFase1 = Console.ReadLine();
            string mantle1 = Console.ReadLine();
            string midle = Console.ReadLine();
            string mantle2 = Console.ReadLine();
            string surFase2 = Console.ReadLine();

            string surFasePatter = @"[^A-Za-z0-9\n]+";
            string mantlePattern = @"[\d_]+";
            string corePatter = @"([A-Za-z]+)";
            string midlePatter = $"^{surFasePatter}{mantlePattern}{corePatter}{mantlePattern}{surFasePatter}$";

            if (!Regex.IsMatch(surFase1, $"^{surFasePatter}$"))
            {
                Console.WriteLine("Invalid");
                return;
            }
            if (!Regex.IsMatch(mantle1, $"^{mantlePattern}$"))
            {
                Console.WriteLine("Invalid");
                return;
            }
            if (!Regex.IsMatch(midle, $"^{midlePatter}$"))
            {
                Console.WriteLine("Invalid");
                return;
            }
            if (!Regex.IsMatch(mantle2, $"^{mantlePattern}$"))
            {
                Console.WriteLine("Invalid");
                return;
            }
            if (!Regex.IsMatch(surFase2, $"^{surFasePatter}$"))
            {
                Console.WriteLine("Invalid");
                return;
            }

            Match match = Regex.Match(midle, midlePatter);

            Console.WriteLine("Valid");
            Console.WriteLine(match.Groups[1].Value.Length);
        }
    }
}
