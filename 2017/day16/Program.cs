using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace day16
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = File.ReadAllText("data.txt").Split(',').Select(x=> Dance.CreateNew(x)).ToList();
            var startOrder = "abcdefghijklmnop";

            var part1 = Part1(orders,startOrder);
            Console.WriteLine("Part 1: " + part1);

           
            var count = 1000000000;
            
            var initialOrder = Part2(orders,startOrder,count);
            
            
            

            Console.WriteLine("Part 2: "+initialOrder);
        }
        //wrong ecodajpgkfihlbnm
        public static string Part1(IEnumerable<IDance> input,String order)
        {
            StringBuilder output = new StringBuilder(order);

            foreach(var move in input)
            {
                move.Mutate(output);
            }
            
            return output.ToString();
        }

        public static string Part2(IEnumerable<IDance> input,String order,int count)
        {
            StringBuilder output = new StringBuilder(order);

            var repeatCount = 1;
            
            for(;repeatCount<count;repeatCount++)
            { 
                foreach(var move in input)
                {
                    move.Mutate(output);
                }
                
                if(output.ToString() == order)

                break;
            }

            for(int i=0;i<count % repeatCount;i++)
            { 
                foreach(var move in input)
                {
                    move.Mutate(output);
                }
            }
            
            return output.ToString();
        }


    }

}
