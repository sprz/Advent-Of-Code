using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");
            Console.WriteLine(Part1(lines));
            Console.WriteLine(Part2(lines));
            
        }

        public static int Part1(string[] path)
        {
            var coordinates = new List<Coordinates>();
            for(int i =0; i < path.Length;i++)
            {
                var splitted = path[i].Split(",");

                coordinates.Add(new Coordinates(){
                    X = Convert.ToInt16(splitted[0]),
                    Y = Convert.ToInt16(splitted[1]),
                    // name = Guid.NewGuid().ToString()
                    // name = alpha[i].ToString()
                });
            }

            var maxX = coordinates.Max(x=> x.X);
            var maxY = coordinates.Max(y=> y.Y);

            var maxVal  = maxX > maxY ? maxX : maxY;

            for(int x = -1;x < maxX+2; x++)
                for(int y = -1; y < maxY +2; y++)
                {
                    var lowest = coordinates
                    .GroupBy( coord=> CalculateManhattanDistance(x,y,coord))
                    .OrderBy( dist=> dist.Key).First();

                    if(lowest.Count() == 1)
                         lowest.First().Counter +=1;

                    if(x == -1 || x == maxX +1 || y == -1 || y == maxY+1)
                        lowest.First().IsInfinite = true;
                }
            return coordinates.Where( x=> !x.IsInfinite).Max(x=> x.Counter);
        }


        public static int Part2(string[] path)
        {
            var coordinates = new List<Coordinates>();
            for(int i =0; i < path.Length;i++)
            {
                var splitted = path[i].Split(",");

                coordinates.Add(new Coordinates(){
                    X = Convert.ToInt16(splitted[0]),
                    Y = Convert.ToInt16(splitted[1]),
                    // name = Guid.NewGuid().ToString()
                    // name = alpha[i].ToString()
                });
            }

            var maxX = coordinates.Max(x=> x.X);
            var maxY = coordinates.Max(y=> y.Y);

            var maxVal  = maxX > maxY ? maxX : maxY;

            var counter = 0;   
            for(int x = 0;x < maxX+1; x++)
                for(int y = 0; y < maxY +1; y++)
                {
                    var lowest = coordinates.Sum(coord => CalculateManhattanDistance(x,y,coord));

                    if(lowest< 10000)
                         counter +=1;

                }
            return counter;
        }


        public static int CalculateManhattanDistance(int x, int y, Coordinates coords)
        {
            return Math.Abs(x - coords.X) + Math.Abs(y - coords.Y);
        }
        
        public class Coordinates
        {
            public short X {get;set;}
            public short Y {get;set;}
            // public string name {get;set;}
            public int Counter { get; internal set; }
            public bool IsInfinite { get; internal set; } = false;

            // public override string ToString(){
            //     return String.Format("{0}, counter: {1}",name,Counter);
            // }
        }


    }
}
