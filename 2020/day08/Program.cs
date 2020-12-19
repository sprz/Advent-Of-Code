using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");
            part1(lines);
            part2(lines);
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

        static void part2(string[] lines)
        {
            var parsedLines = ParseLines(lines);

           
           foreach(var line in parsedLines.Where( x=> x.Operation != OperationEnum.ACC))
           {
                line.SwapOperation();
                var output = Run(parsedLines);
                if(output.Item1)
                {
                    Console.WriteLine("Part2: " + output.Item2);
                    return;
                }

                line.SwapOperation();
           }
        }

        static (bool,int) Run(List<Instruction> instructions)
        {
            var isTerminatedByLoop = false;
            int i=0;
            int acc=0;
            HashSet<int> visited = new HashSet<int>();
            while(i != instructions.Count)
            {
                if(visited.Contains(i)) {return (false,acc);}
                else visited.Add(i);

                if(instructions[i].Operation == OperationEnum.NOP) 
                {
                    i++;
                }
                else if (instructions[i].Operation == OperationEnum.ACC)
                { 
                    acc+=instructions[i].Argument;
                    i++; 
                }
                else if(instructions[i].Operation == OperationEnum.JMP)
                {
                    i+=instructions[i].Argument;
                }
            }

            return (true,acc);
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
        public void SwapOperation()
        {
            if(Operation == OperationEnum.JMP)      Operation = OperationEnum.NOP;
            else if(Operation == OperationEnum.NOP) Operation = OperationEnum.JMP;
        }
    }
    public enum OperationEnum
    {
        ACC,JMP,NOP
    }
}
