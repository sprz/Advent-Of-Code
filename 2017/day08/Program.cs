using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_8
{
    class Program
    {
        private static Dictionary<string,int> registers = new Dictionary<string,int>();
        private static Dictionary<string,Func<string,string,bool>> operators = new Dictionary<string,Func<string,string,bool>>()
        {
            {"<=",(reg,num) => {return registers[reg] <= Convert.ToInt16(num);}},
            {">=",(reg,num) => {return registers[reg] >= Convert.ToInt16(num);}},
            {"<",(reg,num) => {return registers[reg] < Convert.ToInt16(num);}},
            {">",(reg,num) => {return registers[reg] > Convert.ToInt16(num);}},
            {"==",(reg,num) => {return registers[reg] == Convert.ToInt16(num);}},
            {"!=",(reg,num) => {return registers[reg] != Convert.ToInt16(num);}},
        };

        static void Main(string[] args)
        {
            var maxValue = -1;
            var instructions = File.ReadAllLines("data.txt");

            foreach(var instruction in instructions)
            {
                var splitted1 = instruction.Split(" if ");

                var splittedContition = splitted1[1].Split(" ");
                if(!registers.ContainsKey(splittedContition[0]))
                    registers.Add(splittedContition[0],0);

                if(!operators.ContainsKey(splittedContition[1]))
                {
                    operators.Add("==",(reg,num) => {return registers[reg] == Convert.ToInt16(num);});
                }

                bool isConditionValid = operators[splittedContition[1]](splittedContition[0],splittedContition[2]);

                if(isConditionValid)
                {
                    var splittedOperators = splitted1[0].Split(" ");

                    if(!registers.ContainsKey(splittedOperators[0]))
                        registers.Add(splittedOperators[0],0);

                    if(splittedOperators[1] == "dec")
                        registers[splittedOperators[0]] -= Convert.ToInt32(splittedOperators[2]);
                    else if(splittedOperators[1] == "inc")
                        registers[splittedOperators[0]] += Convert.ToInt32(splittedOperators[2]);
                }

                if(registers.Values.Max() > maxValue)
                {
                    maxValue = registers.Values.Max(); 
                }
            }
            Console.WriteLine("maxValue at the end: " + registers.Values.Max());
            Console.WriteLine("maxValue during operations: " + maxValue);
        }
    }
}
