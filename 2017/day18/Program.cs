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
            Console.WriteLine("part2: "+  part2(orders));
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

        static long part2(List<string> instructions)   
        {
            int counter=0;
            Programm p0 = new Programm(instructions,0);
            Programm p1 = new Programm(instructions,1);
            p0.SetProgram(p1);
            p1.SetProgram(p0);

            bool deadlock0 = false;
            bool deadlock1 = false;

            while((deadlock0 && deadlock1)== false) // lack of time to implement async :)
            {
                deadlock0 = p0.DoStep();
                deadlock1 = p1.DoStep();
            }
            
            return p1.counter;
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
    public class Programm{

        private Dictionary<string, Register> registers = new Dictionary<string, Register>();
        private List<string> _instructions;
        private Programm _program;
        private int i;
        public int counter;
        private List<long> Queue = new List<long>();
        public int RegisterNumber;
        public Programm(List<string> instructions, int number) 
        {
            i=0;
            counter = 0;
            RegisterNumber = number;
            _instructions = instructions;
            registers.Add("p",new Register(){Value = number});

        }
        public void SetProgram(Programm program) => _program = program;

        public void ReceiveValue(long value)
        {
            Queue.Add(value);
        }

        public bool DoStep()
        {
            var splitted = _instructions[i].Split(' ');

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
                var value = GetValue(splitted[1]);
                _program.ReceiveValue(value);
                counter++;
            }
            else if(splitted[0] == "rcv")
            {
                if(Queue.Any())
                {
                    var register = GetOrCreateRegister(splitted[1]);
                    register.Value = Queue.First();
                    Queue.RemoveAt(0);
                    
                }
                else
                {
                    return true;
                }
                
            }
            i++;
            return false;
        }
        
        private Register GetOrCreateRegister(string registerName)
        {
            if(registers.ContainsKey(registerName) == false) 
                registers.Add(registerName, new Register());

            return registers[registerName];
        }

        private long GetValue(string value)
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
