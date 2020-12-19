using System;
using System.IO;
using System.Collections.Generic;
namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");
            part1(lines);
        }

        static void part1(string[] lines)
        {
            var parsedLines = ParseLines(lines);
            HashSet<int> visited = new HashSet<int>();
            int i=0;
            int acc=0;
            while(true)
            {
                if(visited.Contains(i)) break;
                else visited.Add(i);

                if(parsedLines[i].Operation == OperationEnum.NOP) 
                {
                    i++;
                }
                else if (parsedLines[i].Operation == OperationEnum.ACC)
                { 
                    acc+=parsedLines[i].Argument;
                    i++; 
                }
                else if(parsedLines[i].Operation == OperationEnum.JMP)
                {
                    i+=parsedLines[i].Argument;
                }
            }

            Console.WriteLine("Part1: "+ acc);
        }

        public static List<Instruction> ParseLines(string[] lines)
        {
            List<Instruction> output = new List<Instruction>();
            
            foreach(var line in lines)
            {
                var splitted = line.Split(" ");
                var instruction = new Instruction();
                instruction.Operation = (OperationEnum)Enum.Parse(typeof(OperationEnum),splitted[0].ToUpper());
                instruction.Argument = Int16.Parse(splitted[1]);
                output.Add(instruction);
            }

            return output;
        } 
    }

    public class Instruction
    {
        public OperationEnum Operation{get;set;}
        public int Argument{get;set;}
    }
    public enum OperationEnum
    {
        ACC,JMP,NOP
    }
}
