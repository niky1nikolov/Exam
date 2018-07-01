using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> lenguageCount = new List<string>();
            Dictionary<string, int> namePoints = new Dictionary<string, int>();
            Dictionary<string, string> nameLenguage = new Dictionary<string, string>();

            string userName = "";
            string lenguage = "";
            int points = 0;
            string userNameDel = "";
            string lenguageDel = "";

            while (input != "exam finished")
            {
                string[] commands = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[1] == "banned" && commands.Length == 2)
                {
                    userNameDel = commands[0];
                }
               
                if (commands.Length > 2)
                {
                    userName = commands[0];
                    lenguage = commands[1];
                    points = int.Parse(commands[2]);
                }

                lenguageCount.Add(lenguage);

                if (!namePoints.ContainsKey(userName) && (0 <= points && points <=100))
                {
                    namePoints.Add(userName, points);
                }
                else
                {
                    namePoints[userName] = points;
                }

                if (!nameLenguage.ContainsKey(userName))
                {
                    nameLenguage.Add(userName, lenguage);
                }
                else
                {
                    nameLenguage[userName] = lenguage;
                }

                input = Console.ReadLine();
            }


            if (namePoints.ContainsKey(userNameDel))
            {
                lenguageDel = nameLenguage[userNameDel];
                namePoints.Remove(userNameDel);
            }

            Console.WriteLine("Results:");

            foreach (var kvp in namePoints.OrderByDescending(x =>x.Value).ThenBy(y =>y.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Dictionary<string, int> countLenguage = new Dictionary<string, int>();

             lenguageCount.Remove(lenguageDel);

            foreach (var lenguage1 in lenguageCount)
            {
                if (!countLenguage.ContainsKey(lenguage1))
                {
                    countLenguage[lenguage1] = 1;
                }
                else
                {
                    countLenguage[lenguage1]++;
                }
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in countLenguage.OrderByDescending(t => t.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
