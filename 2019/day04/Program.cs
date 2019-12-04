using System;
using System.Collections.Generic;
using System.Linq;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = 372037;
            var end = 905157;
            Console.WriteLine("part1: " + part1(start,end));
        }
        static int part1(int start, int end)
        {
            var counter = 0;

            for(int i =start;i < end;i++)
            {
                var twoAdjacentdigits = false;
                var isDecreasing = true;
                var literal = i.ToString();
                char previousChar = literal[0];
                for(int k = 1; k < literal.Count() && isDecreasing;k++)
                {
                    if(literal[k-1] <= literal[k]) 
                        continue;
                    isDecreasing = false;
                }
                if(isDecreasing == false) continue;

                previousChar = literal[0];
                for(int k = 1; k < literal.Count() && !twoAdjacentdigits;k++)
                {
                    if(previousChar== literal[k]) 
                        twoAdjacentdigits = true;
                    else 
                        previousChar = literal[k];
                }
                
                if(twoAdjacentdigits) counter++;

            }

            return counter;
        }
    }
}
