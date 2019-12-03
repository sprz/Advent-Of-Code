using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("data.txt");
            Console.WriteLine("part1: " + part1(text));
            Console.WriteLine("part2: " + part2(text));
        }
         
        static int part1(string[] lines)
        {
            var grid = new Dictionary<string,bool>();

            int lowestManhattanDist = -1;
            bool isSecondWire = false;
            foreach(var wire in lines)
            {
                var centralPoint = new Point();
                foreach(var path in wire.Split(","))
                {
                    var direction = path.First();
                    var length = Convert.ToInt16(path.Substring(1));
              
                    for(int i = 0; i < length; i++)
                    {
                        if(direction == 'R')
                            centralPoint.X +=1;
                        else if(direction == 'L')
                            centralPoint.X -=1;
                        else if(direction == 'U')
                            centralPoint.Y +=1;
                        else if(direction == 'D')
                            centralPoint.Y -=1;

                        var key = GetKey(centralPoint);

                        if(grid.ContainsKey(key) == false)
                        {
                            grid.Add(key,isSecondWire);
                        }
                        else if(isSecondWire)
                        {
                            if(grid[key] != isSecondWire)
                            {
                                var manhDist = Math.Abs(centralPoint.X) + Math.Abs(centralPoint.Y);
                                if(lowestManhattanDist > manhDist || lowestManhattanDist == -1)
                                    lowestManhattanDist = manhDist;
                            }
                        }
                            
                    }
                }

                isSecondWire = true;
            }

            
            return lowestManhattanDist;
        }

         
        static int part2(string[] lines)
        {
            var grid = new Dictionary<string,Tuple<bool,int>>();

            int lowestManhattanDist = -1;
            bool isSecondWire = false;
            foreach(var wire in lines)
            {
                var centralPoint = new Point();
                    var steps = 0;
                foreach(var path in wire.Split(","))
                {
                    var direction = path.First();
                    var length = Convert.ToInt16(path.Substring(1));
              
                    for(int i = 0; i < length; i++)
                    {
                        if(direction == 'R')
                            centralPoint.X +=1;
                        else if(direction == 'L')
                            centralPoint.X -=1;
                        else if(direction == 'U')
                            centralPoint.Y +=1;
                        else if(direction == 'D')
                            centralPoint.Y -=1;
                        steps++;
                        var key = GetKey(centralPoint);

                        if(grid.ContainsKey(key) == false)
                        {
                            grid.Add(key,new Tuple<bool,int>(isSecondWire,steps));
                        }
                        else
                        {
                            if(grid[key].Item1 != isSecondWire)
                            {
                                if(lowestManhattanDist > (steps + grid[key].Item2) || lowestManhattanDist == -1)
                                    lowestManhattanDist = (steps + grid[key].Item2);
                            }
                        }
                            
                    }
                }

                isSecondWire = true;
            }

            
            return lowestManhattanDist;
        }

        static string GetKey(Point point){
            return point.X + "," + point.Y;
        }
    }
    public class Grid {
        
    }
}
