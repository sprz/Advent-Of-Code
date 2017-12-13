using System;
using System.Collections.Generic;
using System.Linq;

namespace day_13
{
    internal class Firewall
    {
        private Dictionary<int,Layer> Layers {get;set;} = new Dictionary<int,Layer>();
        private int _upTime =0;
        private List<Packet> Packets {get;set;} = new List<Packet>();
        private int Severity{get;set;}
        internal void AddLayer(int layerno, int layerRange)
        {
           Layers.Add(layerno,new Layer(layerRange){LayerNo = layerno});
        }

        internal bool DoesPacketPass()
        {
            return Packets.Any( x=> x.Position == Layers.Keys.Max() + 1);
        }

        internal void SendPacket(Packet packet){
            if(Layers[0].CurrentState != 0)
            {
                Packets.Add(packet);
                packet.Delay = _upTime;
            }
        }

        internal void Print()
        {
            var LayersCount = Layers.Keys.Max();
            var LayerMaxRange = Layers.Values.Max(x=> x.Range);
            for(int currRange = 0;currRange<LayerMaxRange;currRange++)
            {
                for(int i=0;i<LayersCount;i++)
                {
                // L - Layer state
                // P - Packet state
                // B - layer and Packet same pos
                    if(currRange == 0){
                        
                        var isPacketFirst = Packets.Any(x=> x.Position == i);
                        var isLayerTop =  Layers.ContainsKey(i) ? Layers[i].CurrentState == 0 : false;

                        if(isPacketFirst == true && isLayerTop == true)
                            Console.Write("B");
                        else if(isPacketFirst == true && isLayerTop == false)
                            Console.Write("P");
                        else if(isPacketFirst == false && isLayerTop == true)
                            Console.Write("L");
                        else
                            Console.Write(" ");
                    }
                    else if(!Layers.ContainsKey(i)) 
                        Console.Write(" ");
                    else
                    {
                        if(Layers[i].CurrentState == currRange)
                        Console.Write("L");
                        else if(Layers[i].CurrentState < i) 
                            {
                                Console.Write(" ");
                            }
                        else
                        Console.Write(" ");
                    
                    }
                    
                }
                Console.WriteLine();
            }
            for(int i=0; i<LayersCount;i++)
                Console.Write("-");
            Console.WriteLine();
        }

        internal Packet GetPassedPacket(){
            return Packets.Single( x=> x.Position == Layers.Keys.Max() + 1);
        }

        internal void GoOnePicosecond()
        {
                foreach(var packet in new List<Packet>(Packets))
                    if(Layers.ContainsKey(packet.Position))
                        if(Layers[packet.Position].CurrentState == 0 )
                            Packets.Remove(packet);

                foreach(var layer in Layers.Values){
                    layer.Move();
                }

                foreach(var packet in Packets)
                    packet.Position ++;

                _upTime ++;
        }
    }
}