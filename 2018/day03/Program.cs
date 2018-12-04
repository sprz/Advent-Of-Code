using System;
using System.Collections.Generic;
using System.Linq;

namespace day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            
           var text = System.IO.File.ReadAllText("data.txt");
            
           Console.WriteLine(Part1(text));
           Console.WriteLine(Part2(text));
        }

        public static int Part1(string input){
           
            var datas = input.Split(Environment.NewLine);

            int[,] squares = new int[1000,1000];
            var count = 0;
            
            for(int i = 0; i < datas.Length;i++)
            {
                string[] splitted = datas[i].Split(new char[] { '@', ',',':','x' }, StringSplitOptions.RemoveEmptyEntries);

                var X = Convert.ToInt16(splitted[1]);
                var Y = Convert.ToInt16(splitted[2]);
                var width = Convert.ToInt16(splitted[3]);
                var height = Convert.ToInt16(splitted[4]);

                for(int x = X; x<X+width;x++)
                    for(int y = Y;y < Y+height;y++)
                    {    
                        squares[x,y] +=1;
                        if(squares[x,y] == 2) count++;
                    }
            }


           return count;
        }
        public static int Part2(string input){
           
            var datas = input.Split(Environment.NewLine);

            Square[,] squares = new Square[1000,1000];
            List<Elve> elves = new List<Elve>();
            
            for(int i = 0; i < datas.Length;i++)
            {
                string[] splitted = datas[i].Split(new char[] { '#', '@', ',',':','x' }, StringSplitOptions.RemoveEmptyEntries);
                
                Elve e = new Elve(){
                    id = Convert.ToInt16(splitted[0])
                };
                elves.Add(e);
                var X = Convert.ToInt16(splitted[1]);
                var Y = Convert.ToInt16(splitted[2]);
                var width = Convert.ToInt16(splitted[3]);
                var height = Convert.ToInt16(splitted[4]);

                for(int x = X; x<X+width;x++)
                    for(int y = Y;y < Y+height;y++)
                    {
                        if(squares[x,y]==null) squares[x,y] = new Square();
                        e.squares.Add(squares[x,y]);
                        squares[x,y].Count +=1;
                    }
            }


           return elves.Single( x=> x.squares.All(y=> y.Count == 1)).id;
        }
        
    }
    public class Elve
        {
            public int id;
            public List<Square> squares = new List<Square>();
        }
        public class  Square {
            public int Count = 0;
            
        }
}
