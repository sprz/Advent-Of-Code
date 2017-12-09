using System;
using System.IO;

namespace day_9
{
    class Program
    {
        static void Main(string[] args)
        {
           var chars = File.ReadAllText("data.txt");

           var actualGroupOpened = 0;
           var isGarbageOpened = false;
           var score = 0;
           var IsCancelled = false;
           var notCancelled = 0;
           foreach(var character in chars)
           {
                if(IsCancelled)
                {
                    IsCancelled = false;
                     continue;
                }

                if(character == '!')
                {
                    IsCancelled = true;
                    continue;
                }

                

                if(isGarbageOpened)
                    if(character == '>')
                       {
                            isGarbageOpened = false;
                            continue;
                       }
                    else
                    {
                        notCancelled ++;
                        continue;
                    }

                if(character == '<')
                    isGarbageOpened = true;

                if(character == '{')
                    actualGroupOpened++;

                if(character == '}')
                    {
                        score +=actualGroupOpened;
                        actualGroupOpened --;
                    }
                
           }
           Console.WriteLine("SCORE: " + score);
           Console.WriteLine("Not Cancelled: " + notCancelled);
        }
    }
}
