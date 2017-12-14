using System;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "230,1,2,221,97,252,168,169,57,99,0,254,181,255,235,167".Split(",");
            //  var input = "3, 4, 1, 5".Split(",");

            var disc = new Disc(256);

            foreach(var length in input.Select(x=> Convert.ToInt16(x)))
            {
                disc.Reverse(length);
            }
            
            disc.Part1();
        }
        // 27060 too high
    }
}
