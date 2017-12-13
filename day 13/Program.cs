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

            
            while(!firewall.DoesPacketPass())
            {
                firewall.SendPacket(new Packet());
                firewall.GoOnePicosecond();
            }
            
            var passedPacket = firewall.GetPassedPacket();

            Console.WriteLine("[Part 2]: Delay: " + passedPacket.Delay);
        }

        // 3850353 - too high;
    }
}
