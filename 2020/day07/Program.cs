using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day07
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
            var dictionary= OrganizeBags(lines);

            var shinyGoldBag = dictionary["shiny gold"];
            var names = GetParentNamesRecursive(shinyGoldBag);
            
            Console.WriteLine($"Part1: {names.ToList().Distinct().Count()-1}");
        }
        static void part2(string[] lines){
            
            var dictionary= OrganizeBags(lines);
            var shinyGoldBag = dictionary["shiny gold"];
            
            Console.WriteLine($"Part1: {CountBagsInsideRecursive(shinyGoldBag)}");
        }

        public static int CountBagsInsideRecursive(Bag bag)
        {
            var output = 0;
            foreach(var bagInside in bag.InsideBags)
            {
                var count = bagInside.Item2;
                var insideBags = CountBagsInsideRecursive(bagInside.Item1);
                output +=count +insideBags*count;
            }

            return output;
        }
        public static Dictionary<string,Bag> OrganizeBags(string[] lines)
        {
            var dictionary = new Dictionary<string, Bag>();
            foreach(var line in lines)
            {
                var splitted = line.Split(" contain ");
                var mainBagName = splitted[0].Replace("bags","").Trim();
                
                if(dictionary.ContainsKey(mainBagName) == false)
                    dictionary.Add(mainBagName,new Bag(){Name = mainBagName});

                    var b = dictionary[mainBagName];

                if(splitted[1].StartsWith("no other bags")) continue;
                if(splitted[1].Contains(','))
                {
                    var insideSplitted =  splitted[1].Split(", ");
                    foreach(var split in insideSplitted)
                    {
                        var name = GetName(split);
                        var number = GetNumber(split);

                        if(dictionary.ContainsKey(name) == false)
                            dictionary.Add(name,new Bag(){ Name = name });
                        
                        b.AddBags(dictionary[name],number);
                    }
                }
                else
                {
                    var name = GetName(splitted[1]);
                    var number = GetNumber(splitted[1]);

                    if(dictionary.ContainsKey(name) == false)
                        dictionary.Add(name,new Bag(){ Name = name });

                    b.AddBags(dictionary[name],number);

                }
            }
            return dictionary;
        }        
        public static int GetNumber(string stringToParse)
        {
            return Convert.ToInt32(stringToParse.Substring(0,stringToParse.IndexOf(" ")));
        }
        public static string GetName(string stringToParse)
        {
            var name = stringToParse.Substring(stringToParse.IndexOf(" "));
            return name.Replace("bags","").Replace("bag","").Replace(".","").Trim();
        }
        private static List<String> GetParentNamesRecursive(Bag bag)
        {        
            var list= new List<String>();
            list.Add(bag.Name);
            foreach(var parentBag in bag.ParentBags)
            {
                    foreach(var parentParent in  GetParentNamesRecursive(parentBag))
                        list.Add(parentParent);
            }
            return list;
        }
    }

    public class Bag
    {
        public List<Bag> ParentBags {get;set;} = new List<Bag>();
        public String Name { get; set; }

        public List<Tuple<Bag,int>> InsideBags {get;set;} = new List<Tuple<Bag, int>>();

        public void AddBags(Bag bag,int amount)
        {
            InsideBags.Add(new Tuple<Bag,int>(bag,amount));
            bag.ParentBags.Add(this);
        }
        public override string ToString()
        {
            return $"{Name}, CountOfBags: {InsideBags.Count}";
        }
    }
}
