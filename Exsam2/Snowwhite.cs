using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        class Dwarf
        {
            public Dwarf(string name, string color, int physics)
            {
                Name = name;
                Color = color;
                Physics = physics;
            }

            public string Name { get; set; }
            public string Color { get; set; }
            public int Physics { get; set; }
        }

        static void Main(string[] args)
        {
            var colorToDwarf = new Dictionary<string, List<Dwarf>>();
            var allDwarf = new List<Dwarf>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Once upon a time")
                {
                    break;
                }

                string[] dwarf = line.Split(new char[] { ' ', '<', ':', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string name = dwarf[0];
                string color = dwarf[1];
                int physics = int.Parse(dwarf[2]);

                if (!colorToDwarf.ContainsKey(color))
                {
                    colorToDwarf.Add(color, new List<Dwarf>());
                }

                var dwarfByCurrentColor = colorToDwarf[color];
                var foundDwaf = dwarfByCurrentColor.FirstOrDefault(d => d.Name == name);

                if (foundDwaf != null)
                {
                    foundDwaf.Physics = Math.Max(physics, foundDwaf.Physics);
                }
                else
                {
                    Dwarf dwarfList = new Dwarf(name, color, physics);
                    dwarfByCurrentColor.Add(dwarfList);
                    allDwarf.Add(dwarfList);
                }
            }

            var result = allDwarf
                .OrderByDescending(d => d.Physics)
                .ThenByDescending(d => colorToDwarf[d.Color]
                .Count()).ToList();

            foreach (var dwarf in result)
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
}
