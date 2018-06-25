using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;


namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<string, int> demonHelths = new SortedDictionary<string, int>();
            SortedDictionary<string, double> demonDamages = new SortedDictionary<string, double>();
            string patter = @"-?\d+\.?\d*";

            Regex regex = new Regex(patter);

            foreach (var demon in demons)
            {
                var health = demon.Where(s => !char.IsDigit(s) && s != '+' && s != '-' && s != '*' && s != '/' && s != '.').Sum(s => s);

                demonHelths[demon] = health;

                MatchCollection matches = regex.Matches(demon);

                double damage = 0.0;

                foreach (Match mach in matches)
                {
                    var value = mach.Value;
                    damage += double.Parse(value); 
                }

                foreach (var symbol in demon)
                {
                    if(symbol == '*')
                    {
                        damage *= 2;
                    }
                    else if(symbol =='/')
                    {
                        damage /= 2;
                    }
                }

                demonDamages[demon] = damage;
            }

            foreach (var demon in demonDamages)
            {
                var demonName = demon.Key;
                var demonHealth = demonHelths[demonName];
                var demonDamage = demon.Value;

                Console.WriteLine($"{demonName} - {demonHealth} health, {demonDamage:F2} damage");
            }
        }
    }
}
