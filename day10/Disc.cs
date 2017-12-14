using System;
using System.Collections.Generic;
using System.Linq;
namespace day10
{
    internal class Disc
    {
        private int _count;
        private int _currentPos;
        private int _skipSize = 0;
        public int currentPos
        {
            get { return _currentPos;}
            set { _currentPos = value % _count;}
        }
        
        
        Dictionary<int,int> data = new Dictionary<int, int>();
        public Disc(short count)
        {
            _count = count;
            for(short i=0;i<_count;i++)
            data.Add(i,i);
        }
        public void Reverse(short length)
        {
            var list = data.Where(x=> x.Key >=currentPos && x.Key <currentPos+length).ToList();

            if(list.Count != length)
                list.AddRange(data.Take(length-list.Count));

            for(int i=0;i<length/2;i++)
            {
                var secondNum = list[length-1-i].Key;
                var firstNum = list[i].Key;
                var diff = data[secondNum]-data[firstNum];
                
                 data[firstNum] += diff;
                 data[secondNum] -= diff;

            }

            currentPos +=length + _skipSize;
            _skipSize++;
        }

        public void Part1(){
            Console.WriteLine("Part1 = " + data[0]*data[1]);
        }
    }
}