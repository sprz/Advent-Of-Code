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
            var input = "xlqgujun";

            var hashes = new List<string>();
            for(int i=0;i<128;i++)
                hashes.Add(day10.Program.GetHashOfString(input+"-"+i));

            var gridsValues = hashes.Select(x=> 
            string.Join("",x.Select( y=> HexToBinary(y+"")))
            ).ToList();

            Console.WriteLine("PART 1 - "+ gridsValues.Select( x=> x.Count( y=> y=='1')).Sum());

            var grid = new char[128][];

            for(int i=0;i<gridsValues.Count();i++)
            {
                grid[i] = new char[128];
                for(int k=0;k<gridsValues[i].Length;k++)
                { 
                   grid[i][k] = gridsValues[i][k];
                }
            }
            var counter = 0;

            DisplayGrid(grid);

            for(int i=0;i<128;i++)
                for(int k=0;k<128;k++)
                { 
                    if(grid[i][k] == '1')
                    {
                        ZeroNeighbours(grid,i,k);
                        counter ++;
                        
                        // DisplayGrid(grid);
                    }
                }
            
            
            Console.WriteLine("PART 2 - " + counter);
        }

        public static void DisplayGrid(char[][] grid)
        {
                Console.WriteLine();
            foreach(var line in grid.Take(70).Select(x=>new string(x)).ToList())
                Console.WriteLine(line); 

        }

        public static void ZeroNeighbours(char[][] grid, int i, int k)
        {
            grid[i][k] = '0';

            

            if(i <127 && grid[i+1][k] == '1')
                ZeroNeighbours(grid,i+1,k);
            
            if(i > 0 && grid[i-1][k] == '1')
                ZeroNeighbours(grid,i-1,k);

            if(k <127 && grid[i][k+1] == '1')
                ZeroNeighbours(grid,i,k+1);
            
            if(k > 0 && grid[i][k-1] == '1')
                ZeroNeighbours(grid,i,k-1);

        }
    

     public static string HexToBinary(string hexValue)
        {
            ulong number = UInt64.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);

            byte[] bytes = BitConverter.GetBytes(number);

            string binaryString = Convert.ToString(bytes[0], 2);

            return binaryString.PadLeft(4, '0');;
        }

    }
}
