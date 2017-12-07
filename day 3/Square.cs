using System;

namespace day_3
{
    public class Square
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Value { get; private set; }
        public Side SquareSide{ get; private set; }
        public Square(int x, int y, int value)
        {
            X = x;
            Y = y;

            

            Value = value;
        }
        public Side NextSquareDirection(){
            if(Math.Abs(X) == Math.Abs(Y))
            {
                if(X>Y) return Side.Left;
                if(X<Y) return Side.Right;
                if(X < 0) return Side.Down;
                return Side.Right;
            }
            else if(Math.Abs(X) > Math.Abs(Y))
            {
                if(X>Y) return Side.Up;
                return Side.Down;
            }
            else
            {
                if(Y>X) return Side.Right;
                return Side.Left;
            }
        }

        public override string ToString(){
            return string.Format("[{0}:{1}] {2}",X,Y,Value);
        }
    }
}