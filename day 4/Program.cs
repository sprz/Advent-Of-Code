using System;
using System.Collections.Generic;
using System.IO;

namespace day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
             var lines = File.ReadAllLines("data.txt");
            var count = 0;
             foreach (var line in lines)
             {
                 var isValid = true;
                 HashSet<string> uniquePasswords = new HashSet<string>();
                 foreach (var word in line.Split(' '))
                 {
                     isValid &= !uniquePasswords.Contains(word);
                        if(!isValid) break;
                        uniquePasswords.Add(word);


                 }
                 if(isValid) count ++;
             }
             Console.WriteLine(count);
        }
    }
}
