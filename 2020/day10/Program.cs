using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt").Select(x => int.Parse(x)).ToList();
            part1(lines);
            part2(lines);
        }

        private static void part1(List<int> lines)
        {
            var ordered = lines.OrderBy(x => x).ToList();

            var oneJoltDiff = 1;
            var twoJoltDiff = 0;
            var threeJoltDiff = 1;
            for (int i = 0; i < ordered.Count - 1; i++)
            {
                if (ordered[i] + 1 == ordered[i + 1])
                    oneJoltDiff++;
                if (ordered[i] + 2 == ordered[i + 1])
                    twoJoltDiff++;
                if (ordered[i] + 3 == ordered[i + 1])
                    threeJoltDiff++;
            }

            Console.WriteLine("part1: " + (oneJoltDiff*threeJoltDiff));
        }
        private static void part2(List<int> lines)
        {
            var max = lines.Max() + 3;
            lines.Add(max);
            lines.Add(0);
            var ordered = lines.OrderBy(x => x).ToList();

            var threeJoltDiffs = ordered.Where(x => lines.Count(y => y > x && y <= x + 3) == 1 && lines.Count(y => y < x && y >= x - 3) == 1 && lines.Contains(x+3) && lines.Contains(x - 3)).ToList();
            threeJoltDiffs.Insert(0, 0);
            threeJoltDiffs.Add(max);
            long output = 1;
            for (int i = 0; i < threeJoltDiffs.Count-1;i++)
            {
                var startRange = threeJoltDiffs[i];
                var endRange = threeJoltDiffs[i + 1];
                var splitted = ordered.Where(x => startRange < x && x <= endRange).ToList();

                var result = CountPossibilities(startRange, splitted);
                output *= result;
            }

                Console.WriteLine("part2: " + output);
        }

        #region veeeryyyyy long
        //private static void part2(List<int> lines)
        //{
        //    var max = lines.Max() + 3;
        //    lines.Add(max);
        //    var ordered = lines.OrderBy(x => x).ToList();

        //    var output = CountPossibilities(0, ordered);

        //    Console.WriteLine("part2: " + output);
        //}
        //static int  counter = 0;

        private static int CountPossibilities(int value, List<int> lines)
        {
            if (value == lines.Max()) return 1;

            var validContinuations = lines.Where(y => y > value && y <= value + 3).ToList();

            var possibilites = validContinuations.Sum(x => CountPossibilities(x, lines));

            return possibilites;
        }
        #endregion
    }
}
