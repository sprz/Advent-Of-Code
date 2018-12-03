using System;
using System.Collections.Generic;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("data.txt");
            
            Console.WriteLine(CalculateFrequencyStep1(text));
            Console.WriteLine(CalculateFrequencyStep2(text));
         
        }

        public static int CalculateFrequencyStep1(string data)
        {
            var count = 0;
            var changes = data.Split(Environment.NewLine);
            for(int i = 0; i < changes.Length; i++)
            {
                count +=Convert.ToInt32(changes[i]);
            }
            return count;
        }
         public static int CalculateFrequencyStep2(string data)
        {
            var count = 0;
            var changes = data.Split(Environment.NewLine);
            HashSet<int> occuredFrequencies = new HashSet<int>();
            occuredFrequencies.Add(count);
            var length = changes.Length;
            var index = 0;
            do{
                var number = Convert.ToInt32(changes[index%length]);
                count += number;
                
                if(occuredFrequencies.Contains(count))
                    return count;
                else
                    occuredFrequencies.Add(count);

                index++;
            }
            while(true);

            return count;
        }
    }
}
