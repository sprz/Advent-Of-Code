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
            Console.WriteLine(part1(text));
            Console.WriteLine(part2(text));
        }
        
        static int part1(string text)
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

        
        
        static int part2(string text)
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
            var sanOrbitCounts = orbitDict["SAN"].GetParentNames().Split(',').ToList();
            var youOrbitCounts = orbitDict["YOU"].GetParentNames().Split(',').ToList();

            while(sanOrbitCounts[0] == youOrbitCounts[0])
            {
                sanOrbitCounts.RemoveAt(0);
                youOrbitCounts.RemoveAt(0);
            }
            return sanOrbitCounts.Count + youOrbitCounts.Count -2;
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

            public string GetParentNames()
            {
                if(Parent ==null)
                    return "";
                return Parent.GetParentNames() + ","+this.Name;
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
K)L
K)YOU
I)SAN";
    }
}
