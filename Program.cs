using System;
using System.Collections.Generic;
using System.Linq;

namespace RoliTheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> nnn = new Dictionary<string, List<string>>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Time for Code")
                {
                    break;
                }

                string[] events = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var eventId = 0;

                if (!int.TryParse(events[0], out eventId))
                {
                    continue;
                }

                string eventName = events[1];

                if (!eventName.StartsWith('#'))
                {
                    continue;
                }

                eventName = eventName.TrimStart('#');


               if (!nnn.ContainsKey(eventName))
               {
                   nnn.Add(eventName, new List<string>());
               }

                for (int i = 2; i < events.Length; i++)
                {
                    nnn[eventName].Add(events[i]);
                }
            }

            foreach (var kvp in nnn.OrderByDescending(x => x.Value.Count))
            {
                var participanCount = kvp.Value.Count;
                var nameEve = kvp.Key;
                Console.WriteLine($"{nameEve} - {participanCount}");
                var participan = kvp.Value;

                foreach (var item in participan)
                {
                    Console.WriteLine(item);
                }
                
            }
        }
    }
}
