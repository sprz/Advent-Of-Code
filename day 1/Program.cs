using System;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateCaptcha("1212")==6);
            Console.WriteLine(CalculateCaptcha("1221")==0);
            Console.WriteLine(CalculateCaptcha("123425")==4);
            Console.WriteLine(CalculateCaptcha("123123")==12);
            Console.WriteLine(CalculateCaptcha("12131415")==4);




            var text = System.IO.File.ReadAllText("data.txt");
            
            Console.WriteLine(CalculateCaptcha(text));
         
        }

        public static int CalculateCaptcha(string data)
        {
            var count = 0;
            var step = data.Length / 2;
            for(int i = 0;i < data.Length/2; i++)
            {
                if(data[i] == data[(i+step)%data.Length])
                {
                    //  Console.WriteLine(data[i] + " - " +data[(i+step)%data.Length]);
                    // Console.WriteLine(count);
                    count += Convert.ToInt16(data[i]+"")*2;
                    // Console.WriteLine(count);
                }
            }
            //  Console.WriteLine(count);
            return count;
        }
    }
}
