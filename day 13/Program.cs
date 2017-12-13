using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");
            var firewall = new Firewall();

            foreach(var line in lines)
            {
                var splitted = line.Split(":").Select(x=> Convert.ToInt16(x)).ToArray();
                firewall.AddLayer(splitted[0],splitted[1]);
            }
            firewall.CreateRestLayers();

            firewall.SendPacket();

            
        }
    }
}
