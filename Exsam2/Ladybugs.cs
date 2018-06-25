using System;
using System.Linq;

namespace Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int siseArray =int.Parse(Console.ReadLine());

            int[] indexArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] ladybugIndex = new int[siseArray];

            foreach (var index in indexArray)
            {
                ladybugIndex[index] = 1;
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "end")
                {
                    break;
                }

                string command = commands[1];
                int indexNewpositions = int.Parse(commands[2]);
                int positions = int.Parse(commands[0]);

                ladybugIndex[positions] = 0;

                if (command == "right")
                {
                    while (true)
                    {
                        int indexNew = positions + indexNewpositions;

                        if (indexNew >= siseArray)
                        {
                            break;
                        }

                        if (ladybugIndex[indexNew] != 1)
                        {
                            ladybugIndex[indexNew] = 1;
                            break;
                        }
                        else
                        {
                            indexNewpositions += indexNewpositions;
                        }
                    }
                }
                else if (command == "left")
                {
                    while (true)
                    {
                        int indexNew = positions - indexNewpositions;

                        if (indexNew < 0)
                        {
                            break;
                        }

                        if (ladybugIndex[indexNew] != 1)
                        {
                            ladybugIndex[indexNew] = 1;
                            break;
                        }
                        else
                        {
                            indexNewpositions -= indexNewpositions;
                        }
                    }
                }

            }

            Console.WriteLine(string.Join(" ", ladybugIndex));
            
        }
    }
}
