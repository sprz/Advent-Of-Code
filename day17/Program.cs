using System;
using System.Collections.Generic;

namespace day17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part1: "+Part1(366));
        }

        public static int Part1(int step)
        {
            List<int> list = new List<int>() {0};
            int currPos = 0;
            for(int i=1;i<2018;i++)
            {
                currPos = ((currPos + step)%list.Count);
                list.Insert(++currPos,i);
            }   

            return list[currPos+1];

        }
    }
}
