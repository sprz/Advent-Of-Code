using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace day_11
{
    class Program
    {
        private static Dictionary<string,Func<Point,Point>> dict = new Dictionary<string, Func<Point,Point>>(){
            {"n",(point) => {return new Point(point.X, point.Y+ 2);} },
            {"nw",(point) => {return new Point(point.X - 1,point.Y + 1);} },
            {"ne",(point) => {return new Point(point.X + 1,point.Y + 1);} },
            {"s",(point) => {return new Point(point.X, point.Y - 2);} },
            {"sw",(point) => {return new Point(point.X - 1,point.Y - 1);} },
            {"se",(point) => {return new Point(point.X + 1,point.Y - 1);} },
        };
        static void Main(string[] args)
        {
            var directions = File.ReadAllText("data.txt").Split(",");

            Point currentPos = new Point();
            var maxDist = 0;

            foreach(var direction in directions)
            {
                currentPos = dict[direction](currentPos);

                var dist = DistToStart(currentPos);
                if(maxDist < dist)
                maxDist = dist;
            }

            currentPos = new Point(currentPos.Y,currentPos.X);
            Console.WriteLine("Dist = " + DistToStart(currentPos));
            Console.WriteLine("Furthest he ever got: "+ maxDist);

        }


        public static int DistToStart(Point point)
        {
                if(Math.Abs(point.X) > Math.Abs(point.Y))
                {
                    return Math.Abs(point.X);
                }
                else
                {
                    return Math.Abs(point.X+point.Y)/ 2;
                }
        }
    }
}
