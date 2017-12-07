using System;
using System.Linq;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        { 
            var text = System.IO.File.ReadLines("data.txt");
            short count = 0;
            foreach(var line in text)
            {
                var values = line.Split("\t").Select( x=> Convert.ToInt16(x));
                Console.WriteLine(values);

                foreach(var number in values.Where(x=> x < values.Max()/2))
                {
                    var theNumber = values.Where( x=> x % number == 0 && x != number);
                    if(theNumber.Count() == 1)
                    {
                        count += (short) (theNumber.First() / number);
                        break;
                    }
                }
            }
            
            count += 0;
        }
    }
}
