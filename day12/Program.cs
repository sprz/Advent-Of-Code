using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1 - Connected programs: "+Part1());
            Console.WriteLine("Part 2 - groups: "+Part2());
        }

        private static int Part1()
        {
            var lines = File.ReadAllLines("data.txt");
            
            var connections = new Dictionary<short,List<short>>();
            var connectedPipesToZero = new List<short>();

            foreach(var line in lines)
            {
                var splitted = line.Split("<->");
                var started = Convert.ToInt16(splitted[0]);
                var connectedPipes =splitted[1].Split(",").Select(x=> Convert.ToInt16(x));
                connections.Add(started,connectedPipes.ToList());
            }




            var newlyAdded = new List<short>();

            connectedPipesToZero.AddRange(connections[0]);
            connectedPipesToZero.Add(0);
            newlyAdded.AddRange(connections[0]);


            connections.Remove(0);

            while(newlyAdded.Count > 0)
            {

                foreach(var id in new List<short>(newlyAdded))
                {
                    
                    if(!connections.ContainsKey(id)) continue;

                    var newConections = connections[id];

                    foreach(var newID in newConections)
                    {
                        if(connectedPipesToZero.Contains(newID)) continue;

                        connectedPipesToZero.Add(newID);
                        newlyAdded.Add(newID);

                    }
                    newlyAdded.Remove(id);
                    connections.Remove(id);
                }


            }


            return connectedPipesToZero.Count;
        }

        private static int Part2(){

             var lines = File.ReadAllLines("data.txt");
            
            var connections = new Dictionary<short,List<short>>();

            foreach(var line in lines)
            {
                var splitted = line.Split("<->");
                var started = Convert.ToInt16(splitted[0]);
                var connectedPipes =splitted[1].Split(",").Select(x=> Convert.ToInt16(x));
                connections.Add(started,connectedPipes.ToList());
            }


            var groups = 0;
            
            while(connections.Count > 0){
                
                var connectedToCurrentGroup = new List<short>();
                var firstConn = connections.First();

                if(firstConn.Value.Count == 1 && firstConn.Value.First() == firstConn.Key)
                {
                    connections.Remove(firstConn.Key);
                    groups++;
                    continue;
                }
                connectedToCurrentGroup.AddRange(firstConn.Value);
                connectedToCurrentGroup.Add(firstConn.Key);



                var newlyAdded = new List<short>();
                newlyAdded.AddRange(firstConn.Value);
                connections.Remove(firstConn.Key);

                
                while(newlyAdded.Count > 0)
                {

                    foreach(var id in new List<short>(newlyAdded))
                    {
                        
                        if(!connections.ContainsKey(id)) {
                            connections.Remove(id);
                            newlyAdded.Remove(id);
                            continue;
                        }

                        var newConections = connections[id];

                        foreach(var newID in newConections)
                        {
                            if(connectedToCurrentGroup.Contains(newID)) continue;

                            connectedToCurrentGroup.Add(newID);
                            newlyAdded.Add(newID);

                        }
                        connections.Remove(id);
                            newlyAdded.Remove(id);
                    }


                }

                groups++;

            }
                    
                return groups;
        }
    }
}
