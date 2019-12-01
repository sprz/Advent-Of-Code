using System;
using System.Linq;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("data.txt");
            Console.WriteLine(part1(text));
            Console.WriteLine(part2(text));
        }

        static int part1(string[] lines)
        {
            int output = 0;

            foreach(var mass in lines)
            {
                var fuelFirst = (int)Convert.ToInt32(mass)/3;
                var fuel = fuelFirst -2;

                output+=fuel;
            }

            return output;
        }
        static int part2(string[] lines)
        {
            int output = 0;

            foreach(var mass in lines.Select( x=> Convert.ToInt32(x)))
            {
                var fuel = mass;
                
                while(fuel > 0 )
                {
                    var fuelFirst = (int)fuel/3;
                    fuel = fuelFirst -2;
                    if(fuel > 0)
                        output+=fuel;
                }
            }

            return output;
        }
    }
}
