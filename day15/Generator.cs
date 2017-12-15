using System;

namespace day15
{
    internal class Generator
    {
        private int _factor;
        
        private BigInteger _currentVal;
        public BigInteger CurrentVal
        {
            get { return _currentVal;}
            set { _currentVal = value < 0 ? value + int.MaxValue : value;}
        }
        

        public Generator(int value,int factor)
        {
            this.CurrentVal = value;
            this._factor = factor;
        }

        internal BigInteger GetNextVal()
        {
            var newVal = CurrentVal * _factor;

            
            CurrentVal = newVal % 2147483647;
            
            return CurrentVal;
        }
    }
}