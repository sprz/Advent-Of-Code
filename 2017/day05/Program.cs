using System;
using System.IO;
using System.Linq;

namespace day_5
{
    class Program
    {
        static void Main(string[] args)
        {
             var lines = File.ReadAllLines("data.txt").Select( x=> Convert.ToInt16(x)).ToArray();
            var i =0;
            var count = 0;
            while(i < lines.Length)
            {
                var oldI = i;
                i+=lines[i];

                if(lines[oldI] <3) //comment for part 1
                lines[oldI] ++;
                else // comment for part 1
                lines[oldI] --; // comment for part 1

                count ++;
            }

        }
    }
}
