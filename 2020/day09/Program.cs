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
            var result = part1(lines);
            part2(lines,result);
        }
        static long part1(List<long> numbers)
        {
            var output = 0;
            for(int i=25;i<numbers.Count;i++)
            {
                var preambles = numbers.GetRange(i-25,25).OrderBy( x=> x);
                var number = numbers[i];
                
                if(preambles.Any( x=> preambles.Any( y=> y + x == number))) continue;

                Console.WriteLine("part1: " + numbers[i]);
                return numbers[i];
            }

            return -1;
        }
        static void part2(List<long> numbers, long part1Result)
        {
            var summedNumbers = new List<long>();
            for(int i=numbers.IndexOf(part1Result);i>=0;i--)
            {
                summedNumbers.Add(numbers[i]);
                var sum = summedNumbers.Sum();
                if(summedNumbers.Count > 2 && sum == part1Result)
                {
                    Console.WriteLine("part2: " + (summedNumbers.Min() + summedNumbers.Max()));
                    return;
                }
                else if (sum > part1Result)
                    summedNumbers.RemoveAt(0);
                
               
                
            }

        }
    }
}
