using System;
using System.Globalization;
using System.Numerics;

namespace Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            ulong  coutStep = ulong.Parse(Console.ReadLine()) % 86400;
            ulong stetTimeSec = ulong.Parse(Console.ReadLine()) % 86400;

             //BigInteger secTime = new BigInteger();

            ulong secTime = coutStep * stetTimeSec;
            DateTime result =  time.AddSeconds(secTime);

            Console.WriteLine("Time Arrival: {0:HH:mm:ss}", result);
            
        }
    }
}
