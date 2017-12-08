using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_4
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine(Part1("data.txt"));
             Console.WriteLine(Part2("data.txt"));
            
        }

        public static int Part1(string path)
        {
            var lines = File.ReadAllLines(path);
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
             return count;
        }
        public static int Part2(string path)
        {
            var lines = File.ReadAllLines(path);
            var count = 0;
             foreach (var line in lines)
             {
                 var isValid = true;
                 HashSet<Dictionary<char,int>> uniquePasswords = new HashSet<Dictionary<char,int>>(new DictEqualityComparer());
                 foreach (var word in line.Split(' '))
                 {
                    var keyValues = word.Distinct().ToDictionary(x=> x, x=> word.Count(y=> x == y));
                  
                    isValid &= !uniquePasswords.Contains(keyValues);
                    
                    if(!isValid) break;
                    uniquePasswords.Add(keyValues);
                 }
                 if(isValid) count ++;
             }

             return count;
        }
        public class DictEqualityComparer : IEqualityComparer<Dictionary<char, int>>
        {
            public bool Equals(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
            {
                var keys = dict1.Keys.Concat(dict2.Keys).Distinct();
                
                if(dict1.Keys.Count != keys.Count() || dict2.Keys.Count != keys.Count()) 
                    return false;
                
                if(keys.Select( x => dict1[x] != dict2[x]).Any(x=> x))
                    return false;

                return true;
            }

            public int GetHashCode(Dictionary<char, int> obj)
            {
                return base.GetHashCode();
            }
        }
    }
}
