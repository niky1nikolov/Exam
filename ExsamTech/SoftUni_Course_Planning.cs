using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            var lessons = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] commands = input.Split(':').ToArray();

                int index = 0;
               

                string command = commands[0];    // Add:Databases
                string lesson = commands[1];
                int  lessonCount = lesson.Count();


                if (command == "Add"  && (!lessons.Contains(lesson)))
                {
                    lessons.Add(lesson);
                }
                else if (command == "Insert"  && (0 >= index && index < lessonCount ) && (!lessons.Contains(lesson)))
                {
                    index = int.Parse(commands[2]);
                    lessons.Insert(index, lesson);  
                }
                else if (command == "Remove" && (lessons.Contains(lesson)) )
                {
                    lessons.Remove(lesson);
                }
                else if (command == "Swap")
                {
                    string less1 = commands[1];
                    string less2 = commands[2];

                    if ((lessons.Contains(less1)) && (lessons.Contains(less2)))
                    {
                        int index11 = lessons.IndexOf(less1);
                        int index22 = lessons.IndexOf(less2);
                        string buff = "";
                        buff = lessons[index11];
                        lessons[index11] = lessons[index22];
                        lessons[index22] = buff;

                    }

                }
                else if (command == "Exercise")
                {
                    if (!lessons.Contains(lesson))
                    {
                        string newLesson = lesson + "-Exercise";
                        
                        lessons.Add(newLesson);
                        lessons.Add(lesson);
                    }
                    else
                    {
                        int index11 = lessons.IndexOf(lesson);
                        string newLesson = lesson + "-Exercise";
                        lessons.Insert(index11, newLesson);
                    }

                }

                
                input = Console.ReadLine();
            }

            int nn = 1;
            foreach (var item in lessons)
            {
                Console.WriteLine($"{nn++}.{item}");
            }
        }
    }
}
