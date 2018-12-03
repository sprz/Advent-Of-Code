using System;
using System.Linq;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("data.txt");
            
            Console.WriteLine(CalculateCheckSumStep1(text));
            Console.WriteLine(CalculateCheckSumStep2(text));
         
        }

        public static int CalculateCheckSumStep1(string data)
        {
            var doubleLetters = 0;
            var trippleLetters = 0;
            var changes = data.Split(Environment.NewLine);
            for(int i =0;i < changes.Length; i++)
            {
                var id = changes[i];
                var grouped = id.GroupBy(x=> x);
                doubleLetters += grouped.Any( x=> x.Count() == 2) ? 1:0;
                trippleLetters += grouped.Any( x=> x.Count() == 3) ? 1:0;
            }
            return doubleLetters * trippleLetters;
        }
         public static string CalculateCheckSumStep2(string data)
         {
            var changes = data.Split(Environment.NewLine);
            for(int i =0;i < changes.Length; i++)
            {
                var compared2 = changes[i];
                for(int j =0; j < changes.Length;j++)
                {
                    var compared1 = changes[j];
                    var givenChar = "";
                    var index = -1;
                    for(int ind = 0; ind < compared2.Length;ind++)
                    {
                        if(compared2[ind] != compared1[ind])
                        {
                            givenChar +=compared2[ind];
                            index = ind;
                        }
                        
                        if(givenChar.Length > 1)
                           break;
                    }
                     if(givenChar.Length == 1) 
                      return compared1.Remove(index,1);
                }
            }
            
            return String.Empty;
        }
    }
}
