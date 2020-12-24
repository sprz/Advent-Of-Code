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
            //part2(lines);
        }

        private static void part1(SeatMap map)
        {
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
