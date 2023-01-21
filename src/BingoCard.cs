using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoCardGenerator
{
    public class BingoCard
    {

        public List<string> B;
        public List<string> I;
        public List<string> N;
        public List<string> G;
        public List<string> O;

        public BingoCard(IEnumerable<string> bVals, 
                         IEnumerable<string> iVals, 
                         IEnumerable<string> nVals, 
                         IEnumerable<string> gVals, 
                         IEnumerable<string> oVals)
        {
            B = new List<string>(bVals);
            I = new List<string>(iVals);
            N = new List<string>(nVals);
            G = new List<string>(gVals);
            O = new List<string>(oVals);
        }

    }
}
