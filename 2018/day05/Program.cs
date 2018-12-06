using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllText("data.txt");
             Console.WriteLine(Part1(lines));
             Console.WriteLine(Part2(lines));
            
        }

        public static int Part1(string path)
        {
            for(int i =path.Length-1; i > 0; i--)
            {
                if(i >=path.Length) i--;
                if(AreReacting(path[i-1],path[i]))
                {
                    path  = path.Remove(i-1,2);
                    continue;
                }

            }

             return path.Length;
        }
        public static int Part2(string path)
        {
            int best = path.Length +1;
            
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for(int i =0 ; i < alpha.Length;i++)
            {
                var charAsString = alpha[i].ToString();
                var copiedPath = (string)path.Clone();
                var pathWithRemoved = copiedPath.Replace(charAsString,"").Replace(charAsString.ToString().ToLower(),"");
                var result = Part1(pathWithRemoved);
                if(best > result) best = result;
            }
             return best;
        }

        private static bool AreReacting(char a, char b)
        {
            return (a.ToString()).ToUpper() == (b.ToString()).ToUpper() && a != b;
            //return ((int)a - (int)b) % 32 == 0;
        }
    }
}
