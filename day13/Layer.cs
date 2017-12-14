using System;

namespace day_13
{
    public class Layer
    {  
        public int LayerNo {get;set;}
        public int Range {get;set;}
        public int CurrentState {get;set;} = 0;
        private int _direction = 1;

        public int LayerSeverity { get { return LayerNo * Range;} }

        public Layer(int range){
            Range = range;
        }
        public override string ToString(){

            return string.Format("[{2}] Range: {0}, current position: {1}",Range,CurrentState,LayerNo);
        }

        internal void Move()
        {
            CurrentState += _direction;

            if(CurrentState == 0 || CurrentState + 1 == Range)
                _direction *=-1;
        }
    }
}