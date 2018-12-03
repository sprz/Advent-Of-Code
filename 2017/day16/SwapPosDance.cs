using System.Text;

namespace day16
{
    internal class SwapPosDance : IDance
    {
        private short _firstpos;
        private short _secPos;

        public SwapPosDance(short firstpos, short secPos)
        {
            this._firstpos = firstpos;
            this._secPos = secPos;
        }

        public void Mutate(StringBuilder order)
        {
            var first = order[_firstpos];
            var second = order[_secPos];

            order[_firstpos] = second;
            order[_secPos] = first;
        }
    }
}