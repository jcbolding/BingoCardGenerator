using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoCardGenerator
{
	public class BingoCardGenerator
	{
        private static List<string> BVals;
        private static List<string> IVals;
        private static List<string> NVals;
        private static List<string> GVals;
        private static List<string> OVals;


        private static Random random;

        static BingoCardGenerator()
        {
            random = new Random();

            BVals = new List<string>(Enumerable.Range(1, 15).Select(x => x.ToString()));
            IVals = new List<string>(Enumerable.Range(16, 15).Select(x => x.ToString()));
            NVals = new List<string>(Enumerable.Range(31, 15).Select(x => x.ToString()));
            GVals = new List<string>(Enumerable.Range(46, 15).Select(x => x.ToString()));
            OVals = new List<string>(Enumerable.Range(61, 15).Select(x => x.ToString()));
        }



        private static List<string> RandomValues(List<string> allVals, int number)
        {
            var ret = new List<string>(number);

            int current = 0;
            while (current < number)
            {
                var i = random.Next(0, allVals.Count);

                if (!ret.Contains(allVals[i]))
                {
                    ret.Add(allVals[i]);
                    current++;
                }
            }
            return ret;
        }

        public static BingoCard Generate(bool freeSpace, string freeText)
        {
            var card = new BingoCard(RandomValues(BVals, 5),
                RandomValues(IVals, 5),
                RandomValues(NVals, 5),
                RandomValues(GVals, 5),
                RandomValues(OVals, 5));

            if (freeSpace)
                card.N[2] = freeText;

            return card;
        }

        public static BingoCard Generate()
        {
            return Generate(true, "FREE");
        }

        public static List<BingoCard> GenerateBatch(int number)
        {
            var start = DateTime.Now;
            Trace.WriteLine($"Start Generation of {number} cards");
            var ret = new List<BingoCard>(number);
            for (int i = 0; i < number; i++)
                ret.Add(Generate());
            var diff = DateTime.Now - start;
            Trace.WriteLine($"End Generation in {diff.TotalSeconds} seconds");
            return ret;
        }


    }
}
