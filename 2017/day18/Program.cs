using System;
using System.Collections.Generic;
using System.Linq;

namespace day18
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = System.IO.File.ReadAllLines("data.txt").ToList();
            Console.WriteLine("part1: "+  part1(orders));
        }
        static Dictionary<string, Register> registers = new Dictionary<string, Register>();
        static long part1(List<string> instructions)
        {
            long lastPlayedSound = -1;
            for(int i=0; i < instructions.Count; i++)
            {
                var splitted = instructions[i].Split(' ');

                if(splitted[0] == "set")
                {
                    var register = GetOrCreateRegister(splitted[1]);
                    register.Value = GetValue(splitted[2]);
                }
                else if(splitted[0] == "mul")
                {
                    var register = GetOrCreateRegister(splitted[1]);
                    register.Value *= GetValue(splitted[2]);
                }
                else if(splitted[0] == "jgz")
                {
                    if(GetValue(splitted[1]) > 0)
                        i += (int)(GetValue(splitted[2]) - 1);
                }
                else if(splitted[0] == "add")
                {
                    var register = GetOrCreateRegister(splitted[1]);
                    register.Value += GetValue(splitted[2]);
                }
                else if(splitted[0] == "mod")
                {
                    var register = GetOrCreateRegister(splitted[1]);
                    register.Value = register.Value % GetValue(splitted[2]);
                }
                else if(splitted[0] == "snd")
                {
                    var register = GetOrCreateRegister(splitted[1]);
                    register.RecentlyPlayedSound = register.Value;
                    lastPlayedSound = register.RecentlyPlayedSound;
                }
                else if(splitted[0] == "rcv")
                {
                    var register = GetOrCreateRegister(splitted[1]);
                    if(register.Value != 0)
                    {
                        register.Value = register.RecentlyPlayedSound;
                        return lastPlayedSound;
                    }
                    
                }

            }
            return 0;
        }

        private static Register GetOrCreateRegister(string registerName)
        {
            if(registers.ContainsKey(registerName) == false) 
                registers.Add(registerName, new Register());

            return registers[registerName];
        }

        private static long GetValue(string value)
        {
            if(registers.ContainsKey(value)) return registers[value].Value;

            return Convert.ToInt64(value);
        }

    }
    public class Register{
        public long Value {get;set;}
        public long RecentlyPlayedSound{get;set;}
        public override string ToString(){return Value + " - " + RecentlyPlayedSound;}
    }
}
