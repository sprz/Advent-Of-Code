using System;

namespace day_3
{
    class Program
    {
        static void Main(string[] args)
        {

        //    Console.WriteLine(CalculateDistance(12) == 3);
        //    Console.WriteLine(CalculateDistance(23) == 2);
        //    Console.WriteLine(CalculateDistance(25) == 4);
        //    Console.WriteLine(CalculateDistance(27) == 4);
        //    Console.WriteLine(CalculateDistance(28) == 3);
        //    Console.WriteLine(CalculateDistance(29) == 4);
        //    Console.WriteLine(CalculateDistance(30) == 5);
        //    Console.WriteLine(CalculateDistance(31) == 6);
        //    Console.WriteLine(CalculateDistance(50) == 7);
        //    Console.WriteLine(CalculateDistance(49) == 6);
        //    Console.WriteLine(CalculateDistance(1024) == 31);
        //    Console.WriteLine(CalculateDistance(361527));



           Console.WriteLine(Part2(1) == 1);
           Console.WriteLine(Part2(3) == 4);
           Console.WriteLine(Part2(5) == 10);
           Console.WriteLine(Part2(6) == 10);
           Console.WriteLine(Part2(7) == 10);
           Console.WriteLine(Part2(8) == 10);
           Console.WriteLine(Part2(9) == 10);
           Console.WriteLine(Part2(10) == 11);
           Console.WriteLine(Part2(99) == 122);
           Console.WriteLine(Part2(146) == 147);
           Console.WriteLine(Part2(147) == 304);
           Console.WriteLine(Part2(700) == 747);
           Console.WriteLine(Part2(400) == 747);
           
           Console.WriteLine(Part2(361527));
        }


        public static int CalculateDistance (int squareNum){
            
            var circleNum = Math.Floor(Math.Ceiling(Math.Sqrt(squareNum)) / 2);
            
            var maxValue = Math.Pow(circleNum * 2 +1,2);

            var distToCorner = (maxValue - squareNum) %(circleNum*2);
            var distToCenterOfSide = Math.Abs(distToCorner - circleNum);
            
            return (int) (distToCenterOfSide+circleNum);
        }
        
        public static int Part2(int value){

            return -1;
        }
    }
}
