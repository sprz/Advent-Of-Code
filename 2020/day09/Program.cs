using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
namespace day09
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt").Select( x=> long.Parse(x)).ToList();
            part1(lines);
        }
        static void part1(List<long> numbers)
        {
            var output = 0;
            for(int i=25;i<numbers.Count;i++)
            {
                var preambles = numbers.GetRange(i-25,25).OrderBy( x=> x);
                var number = numbers[i];
                
                if(preambles.Any( x=> preambles.Any( y=> y + x == number))) continue;

                Console.WriteLine("part1: " + numbers[i]);
                return;
            }
        }
    }
}
