using System;
using System.Collections.Generic;

namespace day17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part1: "+ Part1(366));
            Console.WriteLine("Part2: "+ Part2(366,50000000));
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
        
        public static int Part2(int step,int count)
        {
            int listCount = 1;
            int currPos = 0;
            int valueAfter0 = 0;

            for(int i=1;i<count;i++)
            {
                currPos = ((currPos + step)%listCount);

                if(currPos == 0)
                    valueAfter0 = i;

                currPos++;
                listCount++;
            }   

            return valueAfter0;

        }
    }
}
