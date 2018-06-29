using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string commands = Console.ReadLine();

            while (commands != "end")
            {
                string[] buff = commands.Split().ToArray();
                string command = buff[0];

                if (buff.Length > 3)
                {


                    int startIndex = int.Parse(buff[2]); // проверка
                    int count = int.Parse(buff[4]);
                                        
                    if (command == "reverse")
                    {
                        if (startIndex < 0 || startIndex >= text.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        if (startIndex + count < 0 || count < 0 || startIndex + count - 1 >= text.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        text.Reverse(startIndex, count);
                    }
                    else if (command == "sort")
                    {
                        text = Sort(text, startIndex, count);
                    }
                }
                else
                {
                    int count = int.Parse(buff[1]); 

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    if (command == "rollLeft")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            var nn = text.ElementAt(0);
                            text.RemoveAt(0);
                            text.Add(nn);

                        }
                    }
                    else if (command == "rollRight")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            var nn = text.ElementAt(text.Count - 1);
                            text.RemoveAt(text.Count - 1);
                            text.Insert(0, nn);
                        }
                    }
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", text)}]");
        }

        private static List<string> Sort(List<string> text, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= text.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return text;
            }

            if (startIndex + count <0 || count <0 || startIndex + count-1 >= text.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return text;
            }

            var firstPart = text.Take(startIndex).ToList();
            var sortetPart = text.Skip(startIndex).Take(count).OrderBy(s => s).ToList();
            var lastPart = text.Skip(startIndex + count).ToList();

            return firstPart.Concat(sortetPart).Concat(lastPart).ToList();
        }
    }
}
