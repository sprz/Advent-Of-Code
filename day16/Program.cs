using System;
using System.IO;
using System.Text;

namespace day16
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = File.ReadAllText("data.txt").Split(',');
            Console.WriteLine(Part1(orders));
        }
        //wrong ecodajpgkfihlbnm
        public static string Part1(String[] input)
        {
            StringBuilder output = new StringBuilder("abcdefghijklmnop");

            foreach(var move in input)
            {
                if(move.StartsWith('x'))
                {
                    var fd = move.Substring(1).Split('/');

                    var firstpos = Convert.ToInt16(fd[0]);
                    var secPos = Convert.ToInt16(fd[1]);

                    var first = output[firstpos];
                    var second = output[secPos];

                    output[firstpos] = second;
                    output[secPos] = first;
                }   
                else if(move.StartsWith('p'))
                {
                    
                    var fd = move.Substring(1).Split('/');

                    var firstpos = output.ToString().IndexOf(fd[0]);
                    var secPos = output.ToString().IndexOf(fd[1]);

                    var first = output[firstpos];
                    var second = output[secPos];

                    output[firstpos] = second;
                    output[secPos] = first;
                }    
                else if(move.StartsWith('s'))
                {
                    var count = Convert.ToInt16(move.Substring(1));
                    var endSubstring = output.ToString().Substring(output.Length-count);

                    output.Replace(endSubstring,"");
                    output.Insert(0,endSubstring);

                }
                else
                {

                }
            }
            
            return output.ToString();
        }
    }
}
