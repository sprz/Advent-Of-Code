using System;
using System.Collections.Generic;
using System.Linq;

namespace day_13
{
    internal class Firewall
    {
        private Dictionary<int,Layer> Layers {get;set;} = new Dictionary<int,Layer>();
        
        private int PacketPosition {get;set;} =-1;
        private int Severity{get;set;}
        internal void AddLayer(int layerno, int layerRange)
        {
           Layers.Add(layerno,new Layer(layerRange){LayerNo = layerno});
        }

        internal void CreateRestLayers()
        {
            var maxLayerNo = Layers.Keys.Max();
            for(int i=0;i<maxLayerNo;i++)
                if(!Layers.ContainsKey(i))
                Layers.Add(i,new Layer(0){LayerNo = i});

        }

        internal void SendPacket()
        {
            PacketPosition = 0;

            while(PacketPosition < Layers.Count)
            {
                if(Layers[PacketPosition].CurrentState ==0 )
                    Severity += Layers[PacketPosition].LayerSeverity;

                foreach(var layer in Layers.Values){
                    layer.Move();
                }

                PacketPosition++;
            }
        }
    }
}