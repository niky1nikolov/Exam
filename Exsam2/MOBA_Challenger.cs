using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> plaerPool = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Season end")
            {
                string inputRep = input.Replace("vs", " -> ");
                string[] plaersLine = inputRep.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string namePlaer = "";
                string namePlaer1 = "";
                string namePlaer2 = "";
                string position = "";
                int skill = 0;

                if (plaersLine.Length == 2)
                {
                    namePlaer1 = plaersLine[0];
                    namePlaer2 = plaersLine[1];
                    input = Console.ReadLine();

                    if (plaerPool.ContainsKey(namePlaer1) && plaerPool.ContainsKey(namePlaer2))
                    {
                        string[] plaer1Position = plaerPool[namePlaer1].Keys.ToArray();

                        foreach (var pos2 in plaerPool[namePlaer2].Keys)
                        {
                            if (plaer1Position.Contains(pos2))
                            {
                                int totalSumSkill11 = plaerPool[namePlaer1].Values.Sum();
                                int totalSumSkill22 = plaerPool[namePlaer2].Values.Sum();

                                if (totalSumSkill11 > totalSumSkill22)
                                {
                                    plaerPool.Remove(namePlaer2);
                                }
                                else if (totalSumSkill11 < totalSumSkill22)
                                {
                                    plaerPool.Remove(namePlaer1);
                                }

                            }
                        }
                    }
                    continue;
                }
                else
                {
                    namePlaer = plaersLine[0];
                    position = plaersLine[1];
                    skill = int.Parse(plaersLine[2]);

                    if (!plaerPool.ContainsKey(namePlaer))
                    {
                        plaerPool.Add(namePlaer, new Dictionary<string, int>());
                    }

                    if (!plaerPool[namePlaer].ContainsKey(position))
                    {
                        plaerPool[namePlaer].Add(position, skill);
                    }
                    else
                    {
                        if (skill < plaerPool[namePlaer][position])
                        {
                            plaerPool[namePlaer][position] = skill;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> skillSum = new Dictionary<string, int>();

            int sum = 0;

            foreach (var kvp in plaerPool)
            {
                foreach (var kvp1 in kvp.Value)
                {
                    sum += kvp1.Value;
                }

                skillSum.Add(kvp.Key, sum);
                sum = 0;
            }
                        
            skillSum = skillSum.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in skillSum)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} skill");

                foreach (var kvp1 in plaerPool[kvp.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"- {kvp1.Key} <::> {kvp1.Value}");
                }
            }

        }
    }
}
