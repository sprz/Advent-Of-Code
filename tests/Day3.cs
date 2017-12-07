using System;
using day_3;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1,1,Side.Right)]
        [InlineData(2,1,Side.Up)]
        [InlineData(3,1,Side.Up)]
        [InlineData(-1,1,Side.Right)]
        [InlineData(0,1,Side.Right)]
        [InlineData(-4,1,Side.Down)]
        [InlineData(3,3,Side.Right)]
        [InlineData(5,-16,Side.Left)]
        [InlineData(6,0,Side.Up)]
        [InlineData(1,-16,Side.Left)]
        [InlineData(6,16,Side.Right)]
        [InlineData(8,-162,Side.Left)]
        [InlineData(12,-141,Side.Left)]
        [InlineData(-55,55,Side.Right)]
        [InlineData(-28,-28,Side.Down)]
        [InlineData(255,-255,Side.Left)]
        [InlineData(255,255,Side.Right)]
        
        public void Square(int x, int y, Side side)
        {
            Assert.Equal(new Square(x,y,0).NextSquareDirection(),side);
        }
    }
}
