using System.Text;

namespace day16
{
    internal class SwapCharDance : IDance
    {
        private string _v1;
        private string _v2;

        public SwapCharDance(string firstChar, string secondChar)
        {
            this._v1 = firstChar;
            this._v2 = secondChar;
        }

        public void Mutate(StringBuilder order)
        {
            var firstpos = order.ToString().IndexOf(_v1);
            var secPos = order.ToString().IndexOf(_v2);

            var first = order[firstpos];
            var second = order[secPos];

            order[firstpos] = second;
            order[secPos] = first;
        }
    }
}