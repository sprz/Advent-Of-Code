using System;
using System.Text;

namespace day16
{
    public interface IDance
    {
        void Mutate(StringBuilder order);
    }


    internal class Dance
    {
        public void Mutate()
        {

        }

        internal static IDance CreateNew(string move)
        {
           if(move.StartsWith('x'))
            {
                var fd = move.Substring(1).Split('/');

                var firstpos = Convert.ToInt16(fd[0]);
                var secPos = Convert.ToInt16(fd[1]);

                return new SwapPosDance(firstpos,secPos);
                
            }   
            else if(move.StartsWith('p'))
            {
                
                var fd = move.Substring(1).Split('/');

                return new SwapCharDance(fd[0],fd[1]);
            }    
            else
            {
                var count = Convert.ToInt16(move.Substring(1));

                return new SpinDance(count);
            }
        }
    }
}