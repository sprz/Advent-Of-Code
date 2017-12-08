using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");
            var programs = new List<Programm>();
            foreach(var line in lines)
            {
                var splitted = line.Split(' ');
                if(splitted.Length == 2)
                {
                    programs.Add(new Programm(){
                        Name = splitted[0],
                        OwnWeight = Convert.ToInt32(splitted[1].Substring(1,splitted[1].Length - 2))
                    });
                }
                else 
                {
                    var program = new Programm(){
                        Name = splitted[0],
                        OwnWeight = Convert.ToInt32(splitted[1].Substring(1,splitted[1].Length - 2))
                    };

                    for(int i = 3;i<splitted.Length;i++)
                        program.NamesOfNotParsedPrograms.Add(splitted[i].Replace(",",""));

                    programs.Add(program);
                    
                }
            }

            foreach(var program in programs)
            {
                if(program.NamesOfNotParsedPrograms.Any())
                {
                    foreach (var name in new List<String>(program.NamesOfNotParsedPrograms))
                    {
                        var childprogram = programs.Single(x=> x.Name == name);
                        program.AddProgramInstance(childprogram);
                    }
                }
            }
            
            var root = programs.Single(x=> x.Parent == null);

            root.CalculateWeights();

            var unbalanced = root.GetUnbalancedProgram();
        }


        public class Programm{
            public string Name {get;set;}
            public int OwnWeight {get;set;}
            public int Weight {get;set;}
            public bool AreChildBalanced{
                get {
                    return ChildPrograms.Select(x=> x.Weight).Distinct().Count() == 1;
                }
            }
            
            public void CalculateWeights(){
                if(ChildPrograms.Any())
                    foreach(var childProgram in ChildPrograms)
                        childProgram.CalculateWeights();

                Weight = OwnWeight + ChildPrograms.Sum(x=> x.Weight);
            }

            public List<Programm> ChildPrograms {get;set;} = new List<Programm>();
            public List<String> NamesOfNotParsedPrograms {get;set;} = new List<String>();
            public Programm Parent {get;set;}

            public void AddProgramInstance(Programm program)
            {
                ChildPrograms.Add(program);
                NamesOfNotParsedPrograms.Remove(program.Name);
                program.Parent = this;
            }
            public Programm GetUnbalancedProgram(){

                var unbalancedChild = ChildPrograms.Where( x=> !x.AreChildBalanced).SingleOrDefault();
                if(unbalancedChild == null) return this;
                
                return unbalancedChild.GetUnbalancedProgram();
            }
            public override string ToString(){
                return Weight.ToString();
            }
                
            

        }
    }
}
