using System;
using System.Collections.Generic;
using System.Linq;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("data.txt").ToList();
           Console.WriteLine("part1: " + part1(lines, true));
           Console.WriteLine("part2: " + part1(lines, false));
        }

        static object part1(List<string> lines, bool part1)
        {
            var xPos = lines[0].IndexOf("|");
            var yPos = 0;
            bool canContinue = true;
            var direction = Direction.Down;
            var counter = 0;
            var letters = "";
            while(canContinue)
            {
                //printCurrentPos(lines,xPos,yPos, direction);
                var currentSign = lines[yPos][xPos];
                
                if(currentSign == ' ')
                    break;
                else if(currentSign == '+')
                {
                    if(direction == Direction.Down || direction == Direction.Up)
                    {
                        var left = lines[yPos][xPos-1];
                        var right = lines[yPos][xPos+1];

                        if(left != ' ')
                        {
                            direction = Direction.Left;
                        }
                        else if(right != ' ')
                        {
                            direction = Direction.Right;
                        }
                    }
                    else
                    { 
                        var top = lines[yPos-1][xPos];
                        var bottom = lines[yPos+1][xPos];

                        if(top != ' ')
                        {
                            direction = Direction.Up;
                        }
                        else if(bottom != ' ')
                        {
                            direction = Direction.Down;
                        }
                    }
                }
                else if (currentSign != '|' && currentSign != '-')
                {
                       letters +=currentSign;
                }
                
                if(direction == Direction.Down)
                    yPos++;
                else if(direction == Direction.Up)
                    yPos--;
                else if(direction == Direction.Right)
                    xPos++;
                else if(direction == Direction.Left)
                    xPos--;
                    
                if(xPos >= lines.Count || xPos < 0 || yPos >=lines[0].Length || yPos <0)
                {
                    break;
                }
                counter ++;
            }
            
            if(part1) 
                return letters;
            else 
                return counter -1;

            return "";
        }

        static void printCurrentPos(List<string> lines, int xPos, int yPos, Direction direction)
        {
            Console.WriteLine(direction);

            string firstt = String.Format(" {0} ",yPos > 0 ? lines[yPos-1][xPos].ToString() : " ");
            string second = String.Format("{0}{1}{2}",
                    xPos > 0 ?  lines[yPos][xPos-1].ToString() : " ",
                    lines[yPos][xPos],
                    lines[0].Length > xPos ?  lines[yPos][xPos+1].ToString() : " ");
            string thirdd = String.Format(" {0} ",lines.Count() > yPos  ? lines[yPos+1][xPos].ToString() : " ");

            Console.WriteLine("!" + firstt + "!");
            Console.WriteLine("!" + second + "!");
            Console.WriteLine("!" + thirdd + "!");
            
            Console.WriteLine("----------------------");

        }
    }
    public enum Direction{
        Up,
        Down,
        Left,
        Right
    }
}
