namespace day_13
{
    internal class Packet
    {
        public int Position { get; internal set; }
        public int Delay { get; internal set; }

        public override string ToString() 
        {
            return string.Format("[{0}] Delay: {1}", Position,Delay);
        }
    }
}