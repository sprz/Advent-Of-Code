using System;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "230,1,2,221,97,252,168,169,57,99,0,254,181,255,235,167";
           

            var disc = new Disc(256);

            foreach(var length in input.Split(",").Select(x=> Convert.ToInt16(x)))
            {
                disc.Reverse(length);
            }
            
            disc.Part1();

            var hash1 = GetHashOfString("");
            var hash2 = GetHashOfString("AoC 2017");
            var hash3 = GetHashOfString("1,2,3");
            var hash4 = GetHashOfString("1,2,4");
            Console.WriteLine(GetHashOfString(input).ToLower());

        }


        public static string GetHashOfString(String input)
        {
            var hashes = input.Select( x=> (int)x).ToList();
            hashes.Add(17);
            hashes.Add(31);
            hashes.Add(73);
            hashes.Add(47);
            hashes.Add(23);

            var discPart2 = new Disc(256);


            for(int i=0;i<64;i++)
                foreach(short length in hashes)
                    discPart2.Reverse(length);

            var hash =  discPart2.GetHash();

            Console.WriteLine(String.Format("{0} -> {1}",input,hash));


            return hash;
        }
        
    }
}
