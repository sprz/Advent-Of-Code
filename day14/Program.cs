using System;
using System.Collections.Generic;
using day10;
using System.Linq;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "flqrgnkx";

            var hashes = new List<string>();
            for(int i=0;i<128;i++)
                hashes.Add(day10.Program.GetHashOfString(input+"-"+i));

            var gridsValues = hashes.Select(x=> 
            string.Join("",x.Select( y=> HexToBinary(y+"")))
            );

            Console.WriteLine("PART 1 - "+ gridsValues.Select( x=> x.Count( y=> y=='1')).Sum());


        }

     public static string HexToBinary(string hexValue)
        {
            ulong number = UInt64.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);

            byte[] bytes = BitConverter.GetBytes(number);

            string binaryString = Convert.ToString(bytes[0], 2);

            return binaryString;
        }

    }
}
