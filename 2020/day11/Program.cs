using System;
using System.IO;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");
            SeatMap map = SeatMap.Parse(lines);
            part1(map);
            map = SeatMap.Parse(lines);
            part2(map);
            Console.ReadKey();
        }

        private static void part1(SeatMap map)
        {
            map.IsPartOne = true;
            do
            {
                map.PrepareNextStates();
                map.DOIT();
            }
            while (map.SeatsOccupationChangedCount != 0);


            Console.WriteLine("part1:" + map.OccupiedSeats);
        }

        private static void part2(SeatMap map)
        {
            map.IsPartOne = false;
            do
            {
                map.PrepareNextStates();
                map.DOIT();
            }
            while (map.SeatsOccupationChangedCount != 0);


            Console.WriteLine("part1:" + map.OccupiedSeats);
        }
    }
}
