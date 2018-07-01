using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Exsam1
{
    class Program
    {
        static void Main()
        {
            long employees1 = long.Parse(Console.ReadLine());
            long employees2 = long.Parse(Console.ReadLine());
            long employees3 = long.Parse(Console.ReadLine());
            long studentsCount = long.Parse(Console.ReadLine());

            int couter = 0;
            int time = 3;

            while (studentsCount > 0)
            {
                long totalEfficiency1Hour = employees1 + employees2 + employees3;
                studentsCount = (studentsCount - totalEfficiency1Hour);
                if (couter == time )
                {
                    couter++;
                    time += 4;
                }
                couter++;
            }

            Console.WriteLine($"Time needed: {couter}h.");


        }
    }
}
