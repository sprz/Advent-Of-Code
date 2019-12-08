using System;
using System.Linq;
using System.Collections.Generic;

namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("data.txt");
            Console.WriteLine(part1(text, 1));
            Console.WriteLine(part2(text,5));
        }
        
        static int part1(string text, int id)
        {
            //text = testinput;
            var orbitDict = new Dictionary<string, Orbit>();

            var lines = text.Split(Environment.NewLine).Select(x=> x.Split(')')).ToList();
            foreach(var line in lines)
            {
                Orbit parent;
                Orbit child;
                if(!orbitDict.TryGetValue(line[0],out parent))
                {
                    parent = new Orbit(){Name = line[0]};
                    orbitDict.Add(line[0],parent);
                }
                if(!orbitDict.TryGetValue(line[1],out child))
                {
                    child =  new Orbit(){Name = line[1]};
                    orbitDict.Add(line[1],child);
                }
                child.Parent = parent;

            }

            var output = orbitDict.Sum(x=> x.Value.CountOrbits());

            return 0;
        }

        
        static int part2(string text, int id)
        {
            return 0;
        }
         class Orbit
        {
            public string Name {get;set;}
            public Orbit Parent {get;set;}

            public int CountOrbits()
            {
                if(Parent == null) 
                    return 0;
                return Parent.CountOrbits() +1;
            }

        }


        static string testinput = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";
    }
}
