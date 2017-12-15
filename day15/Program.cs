using System;

namespace day15
{
    class Program
    {
        static void Main(string[] args)
        {
            // var genA = new Generator(783,16807);
            // var genB = new Generator(325,48271);
            var genA = new Generator(783,16807);
            var genB = new Generator(325,48271);
            var counter = 0;
            for(int i=0;i<40000000;i++)
            {
                var valA = genA.GetNextVal() % 65536;
                var valB = genB.GetNextVal() % 65536;

                if( valA ==  valB)
                counter ++;

            }


            Console.WriteLine("Part 1 - " + counter);
        }
    }
}
