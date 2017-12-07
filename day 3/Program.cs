using System;
using System.Collections.Generic;
using System.Linq;

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



           Console.WriteLine(Part2(1) == 2);
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
        private static List<Square> _squares = new List<Square>() { new Square(0,0,1),new Square(1,0,1),};
        public static int Part2(int value){
            
            
            Square maxSquareVal;
            if(_squares.Count == 2) 
                maxSquareVal = _squares.Last();
                else 
                maxSquareVal = _squares.Aggregate((i1, i2) => i1.Value > i2.Value ? i1 : i2);


            while(maxSquareVal.Value <= value)
            {
                maxSquareVal = GetNextSquare(maxSquareVal);
                _squares.Add(maxSquareVal);
            }

            return maxSquareVal.Value;
        }

        public static Square GetNextSquare(Square square){
            
            var newX = square.X;
            var newY = square.Y;
            var newValue = -1;


            switch(square.NextSquareDirection())
            {
                case Side.Right:
                    newX += 1;
                break;
                case Side.Left:
                    newX += -1;
                break;
                case Side.Up:
                    newY += -1;
                break;
                case Side.Down:
                    newY +=  + 1;
                break;

                default:
                
                break;
            }
            
            newValue = _squares
                .Where(x=> x.X <= newX +1 && x.X >= newX-1 )
                .Where(x=> x.Y <= newY +1 && x.Y >= newY-1 )
                .Sum(x=> x.Value);

            return new Square(newX,newY,newValue);
        }
    }
}
