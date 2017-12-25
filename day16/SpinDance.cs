using System.Text;

namespace day16
{
    internal class SpinDance : IDance
    {
        private int _count;

        public SpinDance(int count)
        {
            _count = count;
        }

        public void Mutate(StringBuilder order)
        {
            var endSubstring = order.ToString().Substring(order.Length-_count);
            order.Replace(endSubstring,"");
            order.Insert(0,endSubstring);
        }
    }
}